using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NBMD1;
using ZedGraph;
using System.IO;

namespace NBMD1
{
    class Dataworks
    {
        public static void Auto_save_Conf() //Автосохранение конфигурации частиц
        {
            string Fname = @"C:\4K4\CsProg\NBMD1\Autosaves\Config\Conf" + "_" + Convert.ToString(Vars.Step_Numb) + ".txt";
            FileInfo file_data = new FileInfo(Fname);
            StreamWriter w = file_data.CreateText();
            w.WriteLine(Convert.ToString(Vars.Step_Numb));
            w.WriteLine(Convert.ToString(Vars.part_amount));
            for (int k = 0; k < Vars.Coor.Length; k++)
            {
                w.WriteLine(Convert.ToString(k) + "\t" + Convert.ToString(Vars.Vel[k].x) + "\t"
                                                       + Convert.ToString(Vars.Vel[k].y) + "\t"
                                                       + Convert.ToString(Vars.Vel[k].z) + "\t"
                                                       + Convert.ToString(Vars.Coor[k].x) + "\t"
                                                       + Convert.ToString(Vars.Coor[k].y) + "\t"
                                                       + Convert.ToString(Vars.Coor[k].z));
            }
            w.Close();
        }

        public static void Auto_save_Param() //Автосохранение параметров
        {
            string Fname = @"C:\4K4\CsProg\NBMD1\Autosaves\Parameters\Param"+"_"+Vars.SaveDate+".txt";
            FileInfo file_data = new FileInfo(Fname);
            StreamWriter w = new StreamWriter(Fname, true);
            if (Vars.Step_Numb == (Vars.Param_Save_Freq * Vars.Step_Freq))
                w.WriteLine("Шаг_№" + "\t" + "Температура" + "\t" + "Энергия" + "\t" + "ПР_по_числовой_плотности" + "\t" + "ПР_по_пику_РФР" + "\t" + "Число_соседей" + "\t"
                + "Температура_капли" + "\t" + "Температура_газа" + "\t" + "Частиц_в_капле" + "\t" + "Частиц_в_газе");
            for (int k = 0; k < Vars.Param1.Length; k++)
            {
                w.WriteLine(Convert.ToString(Vars.Param1[k].Step) + "\t" + Convert.ToString(Vars.Param1[k].Temp)
                            + "\t" + Convert.ToString(Vars.Param1[k].Energy) + "\t" + Convert.ToString(Vars.Param1[k].LS_N)
                            + "\t" + Convert.ToString(Vars.Param1[k].LS_RDF) + "\t" + Convert.ToString(Vars.Param1[k].Sum_N)
                            + "\t" + Convert.ToString(Vars.Param1[k].Temp_Drop) + "\t" + Convert.ToString(Vars.Param1[k].Temp_Gas)
                            + "\t" + Convert.ToString(Vars.Param1[k].Part_Drop) + "\t" + Convert.ToString(Vars.Param1[k].Part_Gas));          
            }
            w.Close();
        }

        public static void Auto_save_RDF() //Автосохранение РФР
        {
            string Fname = @"C:\4K4\CsProg\NBMD1\Autosaves\RDF\RDF" + "_" + Convert.ToString(Vars.Step_Numb) + ".txt";
            FileInfo file_data = new FileInfo(Fname);
            StreamWriter myStream = file_data.CreateText();
            myStream.WriteLine(Convert.ToString(Vars.Step_Numb));
            myStream.WriteLine(Convert.ToString(Vars.part_amount));
            for (int k = 0; k < Vars.N_massive.Length; k++)
            {
                myStream.WriteLine(Convert.ToString(k) + "\t" + Convert.ToString(Vars.R_massive[k]) + "\t"
                                                       + Convert.ToString(Vars.N_massive[k]));
            }
            myStream.Close();
        }

        //public static void Auto_save_Temp()
        //{
        //    string Fname = @"C:\4K4\CsProg\NBMD1\Autosaves\Parameters\Temperatures\Temp" + "_" + Vars.SaveDate + ".txt";
        //    FileInfo file_data = new FileInfo(Fname);
        //    StreamWriter w = new StreamWriter(Fname, true);
        //    if (Vars.Step_Numb == (Vars.Param_Save_Freq * Vars.Step_Freq))
        //    { w.WriteLine("Шаг_№" + "\t" + "Температура_капли" + "\t" + "Температура_газа" + "\t" + "Частиц_в_капле" + "\t" + "Частиц_в_газе"); }
        //    w.WriteLine(Convert.ToString(Vars.Step_Numb) + "\t" + Convert.ToString(Vars.Temp_Drop) + "\t" + Convert.ToString(Vars.Temp_Gas));
        //    w.Close();
        //}

        public static void Zero_av()
        {
            Vars.R_max1_av = 0; Vars.Sum_Neighbour_av = 0; Vars.Lettice_Size_av = 0; Vars.Temp_av = 0; Vars.E_system_av = 0;
            Vars.Temp_Drop_av = 0; Vars.Temp_Gas_av = 0; Vars.Part_Drop_av = 0; Vars.Part_Drop_av = 0; Vars.Part_Gas_av = 0;
        }

    }
}
