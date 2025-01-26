using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBMD1;

namespace NBMD1
{
    public struct Double3
    {
        public double x;
        public double y;
        public double z;
        public Double3(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        public Double3(Double3 a)
        {
            x = a.x; y = a.y; z = a.z;
        }

        public static Double3 ZeroD3 = new Double3(0, 0, 0); //Нулевой вектор
        
        public Double VectLength() //Длина вектора
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        
        public Double VectLength2() //Квадрат Длины вектора
        {
            return (x * x + y * y + z * z);
        }
        
        public Double Distance(Double3 a) //Расстояние между векторами
        {
            return Math.Sqrt(Math.Pow(x - a.x, 2) + Math.Pow(y - a.y, 2) + Math.Pow(z - a.z, 2));
        }

        public Double Distance2(Double3 a) //Расстояние между векторами ^2
        {
            return (Math.Pow(x - a.x, 2) + Math.Pow(y - a.y, 2) + Math.Pow(z - a.z, 2));
        }

        public Double Distance6(Double3 a) //Расстояние между векторами ^6
        {
            return Math.Pow((Math.Pow(x - a.x, 2) + Math.Pow(y - a.y, 2) + Math.Pow(z - a.z, 2)), 3);
        }

        public Double Distance8(Double3 a) //Расстояние между векторами ^8
        {
            return Math.Pow((Math.Pow(x - a.x, 2) + Math.Pow(y - a.y, 2) + Math.Pow(z - a.z, 2)), 4);
        }

        public Double Distance12(Double3 a) //Расстояние между векторами ^12
        {
            return Math.Pow((Math.Pow(x - a.x, 2) + Math.Pow(y - a.y, 2) + Math.Pow(z - a.z, 2)), 6);
        }

        public Double Distance14(Double3 a) //Расстояние между векторами ^14
        {
            return Math.Pow((Math.Pow(x - a.x, 2) + Math.Pow(y - a.y, 2) + Math.Pow(z - a.z, 2)), 7);
        }

        public static Double3 operator +(Double3 a, Double3 b) //Суммирование векторов
        {
            return new Double3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Double3 operator +(Double3 a, Double b) //Прибавка к компонентам вектора
        {
            return new Double3(a.x + b, a.y + b, a.z + b);
        }

        public static Double3 operator -(Double3 a, Double3 b) //Вычитание векторов
        {
            return new Double3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Double3 operator -(Double3 a, Double b) //Вычитание из компонентов вектора
        {
            return new Double3(a.x - b, a.y - b, a.z - b);
        }

        public static Double3 operator *(Double3 a, Double3 b) //Векторное произведение векторов
        {
            return new Double3(a.y * b.z - a.z * b.y, a.x * b.z - a.z * b.x, a.x * b.y - a.y * b.x);
        }

        public static Double3 operator *(Double3 a, Double c) //Умножение на константу
        {
            return new Double3(a.x * c, a.y * c, a.z * c);
        }

        public static Double3 operator /(Double3 a, Double c)//Деление на константу
        {
            return new Double3(a.x / c, a.y / c, a.z / c);
        }

        public static Double3 operator %(Double3 a, double c) //Деление на константу без остатка
        {
            return new Double3(a.x % c, a.y % c, a.z % c);
        }
    }

    public struct Int3
    {
        public int x;
        public int y;
        public int z;
        public Int3(int x, int y, int z)
        {
            this.x = x; this.y = y; this.z = z;
        }

        public static Int3 ZeroI3 = new Int3(0, 0, 0); //Нулевой вектор
        
        public int SumI3() //Сумма компонентов
        {
            return (x + y + z);
        }

        public int ScMult() //Скалярное произведение на себя
        {
            return (x * x + y * y + z * z);
        }
    }

    public struct MyParameters
    {
        public double Temp;
        public double Step;
        public double LS_RDF;
        public double LS_N;
        public double Sum_N;
        public double Energy;
        public double Temp_Drop;
        public double Temp_Gas;
        public double Part_Drop;
        public double Part_Gas;
    }
}
