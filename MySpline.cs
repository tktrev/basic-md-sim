using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBMD1
{
    public class MySpline
    {
        public static SplineTuple[] splines; // Сплайн

        // Структура, описывающая сплайн на каждом сегменте сетки
        public struct SplineTuple
        {
            public double a, b, c, d, x;
        }
        
        // Построение сплайна
        // x - узлы сетки, должны быть упорядочены по возрастанию, кратные узлы запрещены
        // y - значения функции в узлах сетки
        // n - количество узлов сетки
        public static void BuildSpline(double[] x, double[] y, int n)
        {
            // Инициализация массива сплайнов
            splines = new SplineTuple[n];
            for (int i = 0; i < n; ++i)
            {
                splines[i].x = x[i];
                splines[i].a = y[i];
            }
            splines[0].c = splines[n - 1].c = 0.0;

            // Решение СЛАУ относительно коэффициентов сплайнов c[i] методом прогонки для трехдиагональных матриц
            // Вычисление прогоночных коэффициентов - прямой ход метода прогонки
            double[] alpha = new double[n - 1];
            double[] beta = new double[n - 1];
            alpha[0] = beta[0] = 0.0;
            for (int i = 1; i < n - 1; ++i)
            {
                double hi = x[i] - x[i - 1];
                double hi1 = x[i + 1] - x[i];
                double A = hi;
                double C = 2.0 * (hi + hi1);
                double B = hi1;
                double F = 6.0 * ((y[i + 1] - y[i]) / hi1 - (y[i] - y[i - 1]) / hi);
                double z = (A * alpha[i - 1] + C);
                alpha[i] = -B / z;
                beta[i] = (F - A * beta[i - 1]) / z;
            }
            
            // Нахождение решения - обратный ход метода прогонки
            for (int i = n - 2; i > 0; --i)
            {
                splines[i].c = alpha[i] * splines[i + 1].c + beta[i];
            }

            // По известным коэффициентам c[i] находим значения b[i] и d[i]
            for (int i = n - 1; i > 0; --i)
            {
                double hi = x[i] - x[i - 1];
                splines[i].d = (splines[i].c - splines[i - 1].c) / hi;
                splines[i].b = hi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (y[i] - y[i - 1]) / hi;
            }
        }

        //public static double Approx_fun1(double x)
        //{
        //    return splines[3].a + splines[3].b * (x - splines[3].x) + splines[3].c * Math.Pow((x - splines[3].x), 2) / 2 + splines[3].d * Math.Pow((x - splines[3].x), 3) / 6;
        //}

        //public static double Approx_fun2(double x)
        //{
        //    return splines[4].a + splines[4].b * (x - splines[4].x) + splines[4].c * Math.Pow((x - splines[4].x), 2) / 2 + splines[4].d * Math.Pow((x - splines[4].x), 3) / 6;
        //}

        // Вычисление значения интерполированной функции в произвольной точке
        public static double Interpolate(double x)
        {
            if (splines == null)
            {
                return double.NaN; // Если сплайны ещё не построены - возвращаем NaN
            }

            int n = splines.Length;
            SplineTuple s;

            if (x <= splines[0].x) // Если x меньше точки сетки x[0] - пользуемся первым эл-тов массива
            {
                s = splines[0];
            }
            else if (x >= splines[n - 1].x) // Если x больше точки сетки x[n - 1] - пользуемся последним эл-том массива
            {
                s = splines[n - 1];
            }
            else // Иначе x лежит между граничными точками сетки - производим бинарный поиск нужного эл-та массива
            {
                int i = 0;
                int j = n - 1;
                while (i + 1 < j)
                {
                    int k = i + (j - i) / 2;
                    if (x <= splines[k].x)
                    {
                        j = k;
                    }
                    else
                    {
                        i = k;
                    }
                }
                s = splines[j];
            }

            double dx = x - s.x;
            // Вычисляем значение сплайна в заданной точке по схеме Горнера (в принципе, "умный" компилятор применил бы схему Горнера сам, но ведь не все так умны, как кажутся)
            return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx;
        }

        public static int inter_range = 3;                                              //Радиус интерполяции
        public static void Approx_peak()
        {
            //Нахождение количества ближайщих соседей
            for (int k = 0; k < Vars.Find_Nmin.Length; k++) { Vars.Find_Nmin[k] = Vars.N_massive[k + 40]; }
            Vars.Index_minVal = Array.IndexOf(Vars.Find_Nmin, Vars.Find_Nmin.Min()) + 40;         //Нахождение индекс минимального элемента после первого пика
            double[] N_sum = new double[Vars.Index_minVal + 1];
            for (int k = 0; k < N_sum.Length; k++) { N_sum[k] = Vars.N_massive[k]; } Vars.Sum_Neighbour = N_sum.Sum();
            //Нахождение максимума
            double[] Find_Nmax = new double[Vars.Index_minVal + 1];
            for (int k = 0; k < Find_Nmax.Length; k++) { Find_Nmax[k] = Vars.N_massive[k]; }
            int Index_maxVal = Array.IndexOf(Find_Nmax, Find_Nmax.Max());                                                //Нахождение индекса максимального элемента
            if (Index_maxVal == 0) Index_maxVal = 40;
            //Экстраполяция по сплайнам и нахождение максимума
            double[] R_Nmax = new double[2 * MySpline.inter_range + 1]; double[] N_Nmax = new double[2 * MySpline.inter_range + 1];        //Массивы значении в узлах
            for (int k = 0; k < N_Nmax.Length; k++) { N_Nmax[k] = Vars.N_massive[Index_maxVal - MySpline.inter_range + k]; R_Nmax[k] = Vars.R_massive[Index_maxVal - MySpline.inter_range + k]; }
            MySpline.BuildSpline(R_Nmax, N_Nmax, N_Nmax.Length);
            MySpline.SplineTuple[] MSpl = MySpline.splines;
            double N_max1 = double.MinValue; Vars.R_max1 = 0;
            for (int q = MySpline.inter_range; q <= MySpline.inter_range + 1; q++)
            {
                double dis_nant = MSpl[q].c * MSpl[q].c - 2 * MSpl[q].d * MSpl[q].b;
                if (dis_nant >= 0)
                {
                    double x_extr1 = (-MSpl[q].c + Math.Sqrt(dis_nant)) / MSpl[q].d + MSpl[q].x;
                    double x_extr2 = (-MSpl[q].c - Math.Sqrt(dis_nant)) / MSpl[q].d + MSpl[q].x;
                    if (x_extr1 >= MSpl[q - 1].x && x_extr1 <= MSpl[q].x)
                    {
                        if (MySpline.Interpolate(x_extr1) > N_max1) { N_max1 = MySpline.Interpolate(x_extr1); Vars.R_max1 = x_extr1; }
                    }
                    if (x_extr2 >= MSpl[q - 1].x && x_extr2 <= MSpl[q].x)
                    {
                        if (MySpline.Interpolate(x_extr2) > N_max1) { N_max1 = MySpline.Interpolate(x_extr2); Vars.R_max1 = x_extr2; }
                    }
                }
                //Значения на краях интервала
                if (MySpline.Interpolate(MSpl[q].x) > N_max1) { N_max1 = MySpline.Interpolate(MSpl[q].x); Vars.R_max1 = MSpl[q].x; }
            }
        }                                             //Аппроксимация пика
                      
    }
}
