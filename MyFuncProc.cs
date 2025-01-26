using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBMD1
{
    class MyFunсProc
    {
        public static void CreateLattice(int type) //Создание решётки (начальные условия)
        {
            //Кубическая решётка
            int init_NU = 0;
            for (int x = 0; x < Vars.part_amount_x; x++)
                for (int y = 0; y < Vars.part_amount_y; y++)
                    for (int z = 0; z < Vars.part_amount_z; z++)
                    {
                        Vars.Coor[init_NU].x = x * Vars.Lattice_period;
                        Vars.Coor[init_NU].y = y * Vars.Lattice_period;
                        Vars.Coor[init_NU].z = z * Vars.Lattice_period;
                        Vars.Vel[init_NU] = Double3.ZeroD3;
                        init_NU++;
                    }
            
            if (type == 1)
            {
                Vars.part_amount = Vars.part_amount_x * Vars.part_amount_y * Vars.part_amount_z +
                    Vars.part_amount_x * (Vars.part_amount_y - 1) * (Vars.part_amount_z - 1) +
                    Vars.part_amount_z * (Vars.part_amount_x - 1) * (Vars.part_amount_y - 1) +
                    Vars.part_amount_y * (Vars.part_amount_z - 1) * (Vars.part_amount_x - 1); //Количество частиц в системе.
                Vars.Coor = new Double3[Vars.part_amount];                       //Координаты частиц.
                Vars.Vel = new Double3[Vars.part_amount];                        //Скорости частиц.
                Vars.Pulse = new Double3[Vars.part_amount];                      //Импульсы частиц.
                Vars.Force = new Double3[Vars.part_amount];
                Vars.LL = new int[Vars.part_amount];                                  //Связной список.
                Vars.part_conf = new string[Vars.part_amount][];
                Vars.N_massive_part = new double[Vars.part_amount, Vars.spl_R + 1];
                Vars.part_count_el_cell = 4;

                init_NU = 0;
                for (int x = 0; x < Vars.part_amount_x; x++)
                    for (int y = 0; y < Vars.part_amount_y; y++)
                        for (int z = 0; z < Vars.part_amount_z; z++)
                        {
                            Vars.Coor[init_NU].x = x * Vars.Lattice_period;
                            Vars.Coor[init_NU].y = y * Vars.Lattice_period;
                            Vars.Coor[init_NU].z = z * Vars.Lattice_period;
                            Vars.Vel[init_NU] = Double3.ZeroD3;
                            init_NU++;
                        }
                //ГЦК решётка
                for (int x = 0; x < Vars.part_amount_x; x++)
                    for (int y = 0; y < Vars.part_amount_y - 1; y++)
                        for (int z = 0; z < Vars.part_amount_z - 1; z++)
                        {
                            Vars.Coor[init_NU].x = x * Vars.Lattice_period;
                            Vars.Coor[init_NU].y = (y + 0.5) * Vars.Lattice_period;
                            Vars.Coor[init_NU].z = (z + 0.5) * Vars.Lattice_period;
                            Vars.Vel[init_NU] = Double3.ZeroD3;
                            init_NU++;
                        }

                for (int x = 0; x < Vars.part_amount_x - 1; x++)
                    for (int y = 0; y < Vars.part_amount_y - 1; y++)
                        for (int z = 0; z < Vars.part_amount_z; z++)
                        {
                            Vars.Coor[init_NU].x = (x + 0.5) * Vars.Lattice_period;
                            Vars.Coor[init_NU].y = (y + 0.5) * Vars.Lattice_period;
                            Vars.Coor[init_NU].z = z * Vars.Lattice_period;
                            Vars.Vel[init_NU] = Double3.ZeroD3;
                            init_NU++;
                        }

                for (int x = 0; x < Vars.part_amount_x - 1; x++)
                    for (int y = 0; y < Vars.part_amount_y; y++)
                        for (int z = 0; z < Vars.part_amount_z - 1; z++)
                        {
                            Vars.Coor[init_NU].x = (x + 0.5) * Vars.Lattice_period;
                            Vars.Coor[init_NU].y = y * Vars.Lattice_period;
                            Vars.Coor[init_NU].z = (z + 0.5) * Vars.Lattice_period;
                            Vars.Vel[init_NU] = Double3.ZeroD3;
                            init_NU++;
                        }
            }

            Double3 Cmass = new Double3(0, 0, 0);
            for (int k = 0; k < Vars.Coor.Length; k++) { Cmass += Vars.Coor[k]; }
            Vars.CentrePoint = Cmass / Vars.part_amount;
            //Центрирование системы координат в центр масс
            for (int m = 0; m < Vars.Coor.Length; m++) { Vars.Coor[m] -= Vars.CentrePoint; }
        }

        public static void CreateHOC() //Создание связных списков
        {
            //Связные списки
            for (int k = 0; k < Vars.Cell_amount; k++)
                for (int n = 0; n < Vars.Cell_amount; n++)
                    for (int m = 0; m < Vars.Cell_amount; m++) { Vars.HOC[k, n, m] = -1; }
            for (int q = 0; q < Vars.Coor.Length; q++)
            {
                Vars.LL[q] = 0;
                int k = (int)((Vars.Coor[q].x + Vars.HCS) / Vars.Cell_Size),
                    n = (int)((Vars.Coor[q].y + Vars.HCS) / Vars.Cell_Size),
                    m = (int)((Vars.Coor[q].z + Vars.HCS) / Vars.Cell_Size);
                Vars.LL[q] = Vars.HOC[k, n, m]; Vars.HOC[k, n, m] = q;
            }
        }

        public static void Init_massive_RDF() //Инициализания массивов для РФР
        {
            for (int k = 0; k < Vars.part_amount; k++)                                       
                for (int n = 0; n < Vars.spl_R + 1; n++)
                    Vars.N_massive_part[k, n] = 0;
            for (int k = 0; k < Vars.N_massive.Length; k++) { Vars.N_massive[k] = 0; }
            for (int k = 0; k < Vars.R_massive.Length; k++) { Vars.R_massive[k] = k * Vars.delta_R; }
        }

        public static void CreateNChain_cell() //Массив цепочечных ячеек
        {
            if (Vars.Cell_amount == 0)
            {
                Vars.Cell_amount = 1;
                Vars.HOC = new int[Vars.Cell_amount, Vars.Cell_amount, Vars.Cell_amount];
            }
            Vars.Cell_Size = Vars.Cube_Size / Vars.Cell_amount;
            Vars.NC[0] = new Int3(0, 0, 1); Vars.NC[1] = new Int3(0, 1, -1); Vars.NC[2] = new Int3(0, 1, 0); Vars.NC[3] = new Int3(0, 1, 1);
            Vars.NC[4] = new Int3(1, -1, -1); Vars.NC[5] = new Int3(1, -1, 0); Vars.NC[6] = new Int3(1, -1, 1);
            Vars.NC[7] = new Int3(1, 0, -1); Vars.NC[8] = new Int3(1, 0, 0); Vars.NC[9] = new Int3(1, 0, 1);
            Vars.NC[10] = new Int3(1, 1, -1); Vars.NC[11] = new Int3(1, 1, 0); Vars.NC[12] = new Int3(1, 1, 1); Vars.NC[13] = Int3.ZeroI3;
        }

        public static void Find_Force() //Расчёт силы взаимодействия
        {
            for (int k = 0; k < Vars.Coor.Length; k++) { Vars.Force[k] = Double3.ZeroD3; } Vars.U_system = 0; //double U_system_DS = 0;
            //Double3[] Force_DS = new Double3[Vars.part_amount];
            //for (int k = 0; k < Vars.Coor.Length; k++) { Force_DS[k] = Double3.ZeroD3; }
            int HOC_n, HOC_k;
            for (int q_x = 0; q_x < Vars.Cell_amount; q_x++)
                for (int q_y = 0; q_y < Vars.Cell_amount; q_y++)
                    for (int q_z = 0; q_z < Vars.Cell_amount; q_z++)
                        for (int k = 0; k < Vars.NC.Length; k++)
                        {
                            if ((q_x + Vars.NC[k].x >= 0) && (q_y + Vars.NC[k].y >= 0) && (q_z + Vars.NC[k].z >= 0))
                                if ((q_x + Vars.NC[k].x < Vars.Cell_amount) && (q_y + Vars.NC[k].y < Vars.Cell_amount) && (q_z + Vars.NC[k].z < Vars.Cell_amount))
                                {
                                    HOC_n = Vars.HOC[q_x, q_y, q_z];
                                    while (HOC_n >= 0)
                                    {
                                        if (Vars.NC[k].ScMult() == 0) HOC_k = Vars.LL[HOC_n]; else HOC_k = Vars.HOC[q_x + Vars.NC[k].x, q_y + Vars.NC[k].y, q_z + Vars.NC[k].z];
                                        while (HOC_k >= 0)
                                        {
                                            double r = 1 / Vars.Coor[HOC_n].Distance(Vars.Coor[HOC_k]);
                                            Double3 f = (Vars.Coor[HOC_n] - Vars.Coor[HOC_k]);
                                            double Cu12 = Vars.rMin * r, fi_6 = Math.Pow(Cu12, 6), fi_12 = Math.Pow(Cu12, 12),
                                            Cu123 = Vars.Epsil * (fi_12 - 2 * fi_6),
                                            Cf123 = 12 * r * r * Vars.Epsil * (fi_12 - fi_6);
                                            f *= Cf123;
                                            Vars.Force[HOC_n] += f;
                                            Vars.Force[HOC_k] -= f;
                                            Vars.U_system += Cu123;
                                            int qq = (int)(1 / r / Vars.delta_R);
                                            if (qq >= Vars.N_massive.Length) { qq = Vars.N_massive.Length - 1; }
                                            Vars.N_massive_part[HOC_n, qq] += 1;
                                            Vars.N_massive_part[HOC_k, qq] += 1;
                                            HOC_k = Vars.LL[HOC_k];
                                        }
                                        HOC_n = Vars.LL[HOC_n];
                                    }
                                }
                        }          
        }

        public static void Pulse_Corr() //Вычисление и коррекция импульса
        {
            Vars.P_system = Double3.ZeroD3;
            for (int k = 0; k < Vars.Vel.Length; k++)
            {
                Vars.Pulse[k] = Vars.Vel[k] * Vars.mass;
                Vars.P_system += Vars.Pulse[k];
            }
            for (int k = 0; k < Vars.Vel.Length; k++) Vars.Vel[k] -= Vars.P_system / (Vars.part_amount * Vars.mass);
        }

        public static void Release_massive_RDF() //Обрезание и усреднение радиальной функции распределения по внутренней области кристалла
        {
            Vars.R_amount = 0;
            for (int n = 0; n < Vars.part_amount; n++)
            {
                double R_i = Vars.Coor[n].VectLength();
                if (R_i < Vars.R_cut)
                {
                    Vars.R_amount += 1;
                    for (int k = 0; k < Vars.N_massive.Length; k++) { Vars.N_massive[k] += Vars.N_massive_part[n, k]; }
                }
            }
            if (Vars.R_amount == 0)
                for (int k = 0; k < Vars.N_massive.Length; k++)  Vars.N_massive[k] = 0;
            else 
                for (int k = 0; k < Vars.N_massive.Length; k++)  Vars.N_massive[k] /= Vars.R_amount;
            
        }
  
        public static void Find_Lattice_Size() //Поиск периода решётки через числовую плотность
        {            
            //Vars.part_count_R_c = 0;
            //for (int k = 0; k < Vars.part_amount; k++)
            //{
            //    if (Vars.Coor[k].VectLength() < Vars.R_c) Vars.part_count_R_c++;
            //}
            //Vars.Lattice_Size = Vars.R_c * Math.Pow(4 * Math.PI * Vars.part_count_el_cell / Vars.part_count_R_c / 3.0, 1 / 3.0);

            double rand = alglib.hqrnduniformr(Vars.Start_rnd);
            Vars.Lattice_Size = 0; 
            for (int rand_count = 1; rand_count <= 100; rand_count++)
            {
                Vars.R_c = Vars.R_c_Min + rand * (Vars.R_c_Max - Vars.R_c_Min);
                Vars.part_count_R_c = 0;
                for (int k = 0; k < Vars.part_amount; k++)
                {
                    if (Vars.Coor[k].VectLength() < Vars.R_c) Vars.part_count_R_c++;
                }
                if (Vars.part_count_R_c == 0) Vars.part_count_R_c = 1;
                Vars.Lattice_Size += Vars.R_c * Math.Pow(4 * Math.PI * Vars.part_count_el_cell / Vars.part_count_R_c / 3.0, 1 / 3.0);
            }
            Vars.Lattice_Size /= 100;
        }

        public static void Find_Drop() //Поиск температур капли жидкости и газа
        {
            //Связные списки
            for (int k = 0; k < Vars.Cell_amount; k++)
                for (int n = 0; n < Vars.Cell_amount; n++)
                    for (int m = 0; m < Vars.Cell_amount; m++)
                    {
                        Vars.HOC[k, n, m] = -1;
                        Vars.HOC_val[k, n, m] = 0;
                    }
            for (int q = 0; q < Vars.Coor.Length; q++)
            {
                Vars.LL[q] = 0;
                int k = (int)((Vars.Coor[q].x + Vars.HCS) / Vars.Cell_Size),
                    n = (int)((Vars.Coor[q].y + Vars.HCS) / Vars.Cell_Size),
                    m = (int)((Vars.Coor[q].z + Vars.HCS) / Vars.Cell_Size);
                Vars.LL[q] = Vars.HOC[k, n, m]; Vars.HOC[k, n, m] = q;
                Vars.HOC_val[k, n, m]++;
            }

            Vars.HOC_val_max = int.MinValue;
            for (int k = 0; k < Vars.Cell_amount; k++)
                for (int n = 0; n < Vars.Cell_amount; n++)
                    for (int m = 0; m < Vars.Cell_amount; m++)
                        if (Vars.HOC_val[k, n, m] > Vars.HOC_val_max)
                        {
                            Vars.HOC_val_max = Vars.HOC_val[k, n, m];
                            Vars.HOC_val_max_x = k; Vars.HOC_val_max_y = n; Vars.HOC_val_max_z = m;
                        }
            Vars.Drop_Center_Point = new Double3((Vars.HOC_val_max_x + 0.5) * Vars.Cell_Size, (Vars.HOC_val_max_y + 0.5) * Vars.Cell_Size, (Vars.HOC_val_max_z + 0.5) * Vars.Cell_Size);

            Vars.E_kin_Drop = 0; Vars.E_kin_Gas = 0; Vars.Temp_Drop = 0; Vars.Temp_Gas = 0; Vars.Part_Drop = 0; Vars.Part_Gas = 0;
            for (int k = 0; k < Vars.Coor.Length; k++)
            {
                double R_drop_i2 = Vars.Coor[k].Distance2(Vars.Drop_Center_Point - Vars.HCS);
                if (R_drop_i2 < (Vars.Drop_size * Vars.Drop_size))
                {
                    Vars.E_kin_Drop += Vars.Vel[k].VectLength2();
                    Vars.Part_Drop++;
                }
                else
                {
                    Vars.E_kin_Gas += Vars.Vel[k].VectLength2();
                    Vars.Part_Gas++;
                }
            }
            Vars.Temp_Drop = Vars.mass * Vars.E_kin_Drop / (3 * Vars.k_bol * Vars.Part_Drop);
            Vars.Temp_Gas = Vars.mass * Vars.E_kin_Gas / (3 * Vars.k_bol * Vars.Part_Gas);
            
        }

        public static void Reflection() //Диффузное отражение
        {
            //for (int k = 0; k < Vars.Coor.Length; k++)
            //{
            //    if (Vars.Coor[k].x > Vars.HCS) { Vars.Vel[k].x *= -1; Vars.Coor[k].x = 2 * Vars.HCS - Vars.Coor[k].x; }
            //    if (Vars.Coor[k].x < -Vars.HCS) { Vars.Vel[k].x *= -1; Vars.Coor[k].x = -2 * Vars.HCS - Vars.Coor[k].x; }
            //    if (Vars.Coor[k].y > Vars.HCS) { Vars.Vel[k].y *= -1; Vars.Coor[k].y = 2 * Vars.HCS - Vars.Coor[k].y; }
            //    if (Vars.Coor[k].y < -Vars.HCS) { Vars.Vel[k].y *= -1; Vars.Coor[k].y = -2 * Vars.HCS - Vars.Coor[k].y; }
            //    if (Vars.Coor[k].z > Vars.HCS) { Vars.Vel[k].z *= -1; Vars.Coor[k].z = 2 * Vars.HCS - Vars.Coor[k].z; }
            //    if (Vars.Coor[k].z < -Vars.HCS) { Vars.Vel[k].z *= -1; Vars.Coor[k].z = -2 * Vars.HCS - Vars.Coor[k].z; }     
            //}

            for (int k = 0; k < Vars.Coor.Length; k++)
            {
                Vars.Temp_part = Vars.mass * Vars.Vel[k].VectLength2() / (3 * Vars.k_bol);
                Vars.C_dif_temp = Math.Sqrt(Vars.Temp_fix / Vars.Temp_part);
                if (Vars.Coor[k].x > Vars.HCS) { Vars.Vel[k].x *= -Vars.C_dif_temp; Vars.Coor[k].x = 2 * Vars.HCS - Vars.Coor[k].x; }
                if (Vars.Coor[k].x < -Vars.HCS) { Vars.Vel[k].x *= -Vars.C_dif_temp; Vars.Coor[k].x = -2 * Vars.HCS - Vars.Coor[k].x; }
                if (Vars.Coor[k].y > Vars.HCS) { Vars.Vel[k].y *= -Vars.C_dif_temp; Vars.Coor[k].y = 2 * Vars.HCS - Vars.Coor[k].y; }
                if (Vars.Coor[k].y < -Vars.HCS) { Vars.Vel[k].y *= -Vars.C_dif_temp; Vars.Coor[k].y = -2 * Vars.HCS - Vars.Coor[k].y; }
                if (Vars.Coor[k].z > Vars.HCS) { Vars.Vel[k].z *= -Vars.C_dif_temp; Vars.Coor[k].z = 2 * Vars.HCS - Vars.Coor[k].z; }
                if (Vars.Coor[k].z < -Vars.HCS) { Vars.Vel[k].z *= -Vars.C_dif_temp; Vars.Coor[k].z = -2 * Vars.HCS - Vars.Coor[k].z; }
            }
        
        }

    }

}
