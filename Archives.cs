using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBMD1
{
    class Archives
    {
        ////Ставить после вычисления сил и перед интегратором скорости
        //if (Vars.Step_Numb > 200)
        //{
        //    for (int q = 0; q < Vars.Coor.Length - 1; q++)
        //    {
        //        for (int w = q + 1; w < Vars.Coor.Length; w++)
        //        {
        //            Double3 f = (Vars.Coor[q] - Vars.Coor[w]);
        //            double r = 1 / Vars.Coor[q].Distance(Vars.Coor[w]),
        //            Cu12 = Vars.rMin * r, fi_6 = Math.Pow(Cu12, 6), fi_12 = Math.Pow(Cu12, 12),
        //            Cu123 = Vars.Epsil * (fi_12 - 2 * fi_6),
        //            Cf123 = 12 * r * r * Vars.Epsil * (fi_12 - fi_6);
        //            f *= Cf123;
        //            Force_DS[q] += f;
        //            Force_DS[w] -= f;
        //            U_system_DS += Cu123;
        //        }
        //    }

        //    //Вычисление погрешностей сил и энергий
        //    double sum_df = 0, sum_f_DS = 0, dU = 0;
        //    for (int k = 0; k < Vars.Coor.Length; k++)
        //    {
        //        sum_df += Math.Abs(Force_DS[k].x - Vars.Force[k].x) + Math.Abs(Force_DS[k].y - Vars.Force[k].y) + Math.Abs(Force_DS[k].z - Vars.Force[k].z);
        //        sum_f_DS += Math.Abs(Force_DS[k].x) + Math.Abs(Force_DS[k].y) + Math.Abs(Force_DS[k].z);
        //    }
        //    dU = Math.Abs(Vars.U_system - U_system_DS);
        //    if (Vars.Step_Numb % 10 == 0)
        //    {
        //        textBox4.Text = Convert.ToString(sum_df / sum_f_DS);
        //        textBox5.Text = Convert.ToString(dU / Math.Abs(U_system_DS));
        //    }
        //}

        //for (int q = 0; q < Vars.Coor.Length - 1; q++)
        //{
        //    for (int w = q + 1; w < Vars.Coor.Length; w++)
        //    {
        //        Double3 f = (Vars.Coor[q] - Vars.Coor[w]);
        //        double r = 1 / Vars.Coor[q].Distance(Vars.Coor[w]),
        //        Cu12 = Vars.rMin * r, fi_6 = Math.Pow(Cu12, 6), fi_12 = Math.Pow(Cu12, 12),
        //        Cu123 = Vars.Epsil * (fi_12 - 2 * fi_6),
        //        Cf123 = 12 * r * r * Vars.Epsil * (fi_12 - fi_6);
        //        f *= Cf123;
        //        Force_DS[q] += f;
        //        Force_DS[w] -= f;
        //        U_system_DS += Cu123;
        //    }
        //}
    }
}
