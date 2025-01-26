using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBMD1;


namespace NBMD1
{
    //Описание переменных
    public class Vars
    {
        //Физические константы
        public const double k_bol = 8.617342791e-5;


        //Постоянные параметры
        public static double mass = 40;                                                //Масса частиц.
        public static double Lattice_period = 4;                                       //Начальный размер решётки.
        
        ////Н.У. ГЦК
        //public static int part_amount_x = 6, part_amount_y = 6, part_amount_z = 6
        //public static int part_amount = part_amount_x * part_amount_y * part_amount_z +
        //    part_amount_x * (part_amount_y - 1) * (part_amount_z - 1) +
        //    part_amount_z * (part_amount_x - 1) * (part_amount_y - 1) +
        //    part_amount_y * (part_amount_z - 1) * (part_amount_x - 1); //Количество частиц в системе.
       
        //Н.У. Кубический
        public static int part_amount_x = 6, part_amount_y = 6, part_amount_z = 6;
        public static int part_amount = part_amount_x * part_amount_y * part_amount_z;   //Количество частиц в системе.
        public static int part_count_el_cell = 1;                                        //Количество частиц в элементарной ячейке.
        public static double Cube_Size = 20 * part_amount_x * Lattice_period;               //Размер куба.
        public static double HCS = 0.5 * Cube_Size;                                      //Половина ребра куба.

        //Вывод информации, МД-шаги и различные времена
        public static int Step_Numb;                                                   //Номер МД-шага
        public static DateTime time_cycle_begin;                                       //Время начала цикла.
        public static DateTime time_cycle_end;                                         //Время конца цикла.
        public static double time_exp;
        public static int Step_Freq = 100;                                             //Частота вывода информации (в МД-шагах)
        public static int Step_Numb_Relax = 10000;                                     //Шаги, необходимые для релаксации
        public static double Step_Temp = 10000;                                        //Время моделирования при одной температуре.
        public static double Time_relax = 500;
        public static bool Hard_Temp_Correct = true;
        public static int HS_Corr_ratio = 5000;

        //Массивы данных для частиц
        public static Double CLJ1, CLJ2;                                               //Коэффициенты потенциала Леннарда-Джонса.
        public static double rMin = 3.8;
        public static double Epsil = 0.0123;
        public static Double3[] Coor = new Double3[part_amount];                       //Координаты частиц.
        public static Double3[] Vel = new Double3[part_amount];                        //Скорости частиц.
        public static Double3[] Pulse = new Double3[part_amount];                      //Импульсы частиц.
        public static Double3[] Force = new Double3[part_amount];                      //Сила, действующая на частицу со стороны других.
        public static Double3 CentrePoint;                                             //Координаты центра масс системы частиц.

        public static Int3[] NC = new Int3[14];
        

        //Метод цепочечных ячеек
        public static double Cell_Size = 12;                                            //Размер ячейки.
        public static int Cell_amount = (int)(Cube_Size / Cell_Size);                   //Количество ячеек на одно измерение.
        public static int[] LL = new int[part_amount];                                  //Связной список.                                       
        public static int[, ,] HOC = new int[Cell_amount, Cell_amount, Cell_amount];    //Заголовки цепочек.


        //Энергия, импульсы, термодинамические величины
        public static double U_system;                                                 //Потенциальная энергия системы.
        public static Double3 P_system;                                                //Общий импульс системы.
        public static double Ek_system;                                                //Кинетическая энергия системы.
        public static double E_system;                                                 //Полная энергия системы.
        public static double Temp;                                                     //Температура системы.
        public static double Temp_fix = 60;                                           //Жёстко фиксированная температура.
        public static double Temp_plus = 2;                                            //Изменение температуры во время эксперимента.      
        public static double C_dif_temp; 
        public static double Temp_part;
        
        //Булевы переменные
        public static bool Start;

        //Работа с файлами
        public static string[][] part_conf = new string[part_amount][];
        public static int Param_Save_Freq = 100;
        public static MyParameters[] Param1 = new MyParameters[Param_Save_Freq];
        public static int Count_av = 0;
        public static string SaveDate = Convert.ToString(DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year
                + "." + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second);

        public static double lay_numb;                   //Номер слоя куба

        //Поиск периода решётки и координационного числа
        public static double R_range = 8;
        public static double delta_R = 0.1;
        public static int spl_R = (int)(R_range / delta_R);
        public static double RRR = delta_R * spl_R;
        public static double[] N_massive = new double[spl_R + 1];
        public static double[,] N_massive_part = new double[part_amount,spl_R+1];
        public static double[] R_massive = new double[spl_R + 1];
        public static string[][] RDF_conf = new string[spl_R + 1][];
        public static double[] Find_Nmin = new double[(int)(Vars.spl_R / Vars.R_range)];
        public static double R_max1;
        public static double Sum_Neighbour;
        public static int R_amount;
        public static double R_cut = Vars.part_amount_x * Vars.Lattice_period / 3;
        public static int Index_minVal;

        //Поиск периода решётки через числовую плостность
        public static double Lattice_Size;
        public static double R_c;
        public static double R_c_Max = Vars.part_amount_x * Vars.Lattice_period / 3;
        public static double R_c_Min = Vars.part_amount_x * Vars.Lattice_period / 3.5;
        public static int part_count_R_c;
        public static alglib.hqrndstate Start_rnd;

        //Нахождение температуры капли
        public static int[, ,] HOC_val = new int[Cell_amount, Cell_amount, Cell_amount];
        public static int HOC_val_max;
        public static int HOC_val_max_x; public static int HOC_val_max_y; public static int HOC_val_max_z;
        public static Double3 Drop_Center_Point;
        public static double E_kin_Drop = 0, Temp_Drop = 0, E_kin_Gas = 0, Temp_Gas = 0;
        public static int Part_Drop;
        public static int Part_Gas;
        public static double Drop_size = part_amount_x * Lattice_period;
 
        //Величины для усреднения
        public static double[] N_massive_av = new double[Vars.spl_R + 1];
        public static double R_max1_av = 0, Sum_Neighbour_av = 0, Temp_av = 0, Lettice_Size_av = 0, E_system_av = 0,
            Temp_Drop_av = 0, Temp_Gas_av = 0, Part_Drop_av = 0, Part_Gas_av = 0;

    }
}
