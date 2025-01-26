using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBMD1
{
    class MNK2
    {
        public struct MNKparab
        {
            public double a, b, c;
        }
        public static MNKparab Extr_Parab;
        public static void Build_Parab(double[] x, double[] y, int n)   //n = длине массивов x,y
        {
           double x0 = 0, x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, yx = 0, yx2 = 0;  
           Extr_Parab = new MNKparab();
           for (int k = 0; k < n - 1; k++)
           {
              x0++;
              x1 += x[k];
              x2 += x[k] * x[k];
              x3 += x[k] * x[k] * x[k];
              x4 += x[k] * x[k] * x[k] * x[k];
              y1 += y[k];
              yx += y[k] * x[k];
              yx2 += y[k] * x[k] * x[k];
           }
           double delta_0 =  x4*(x2*x0-x1*x1) -  x3*(x3*x0-x2*x1) +  x2*(x3*x1-x2*x2);
           double delta_a = yx2*(x2*x0-x1*x1) -  x3*(yx*x0-y1*x1) +  x2*(yx*x1-y1*x2);
           double delta_b =  x4*(yx*x0-y1*x1) - yx2*(x3*x0-x2*x1) +  x2*(x3*y1-x2*yx);
           double delta_c =  x4*(x2*y1-x1*yx) -  x3*(x3*y1-x2*yx) + yx2*(x3*x1-x2*x2);
           Extr_Parab.a = delta_a / delta_0;
           Extr_Parab.b = delta_b / delta_0;
           Extr_Parab.c = delta_c / delta_0;
        }
    }
}
