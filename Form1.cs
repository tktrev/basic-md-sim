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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Начальные Условия
            MyFunсProc.CreateLattice(1); // 0 - Кубическая решётка; 1 - ГЦК

            MyFunсProc.CreateNChain_cell();
            textBox1.Text = "Cell_size = " + Convert.ToString(Vars.Cell_Size);

            double dt = 0.5; Vars.Step_Numb = 0; Vars.Start = true;
            Vars.time_cycle_begin = DateTime.Now; Vars.time_cycle_end = DateTime.Now;

            listBox3.Items.Clear();
            listBox3.Items.Add("Время МД-шага: " + Convert.ToString(dt));
            listBox3.Items.Add("Начальная T-ра: " + Convert.ToString(Vars.Temp_fix));
            listBox3.Items.Add("Шаг изменения T-ры: " + Convert.ToString(Vars.Temp_plus));
            listBox3.Items.Add("Шаги мод. при 1-ой T: " + Convert.ToString(Vars.HS_Corr_ratio*Vars.Step_Temp));

            alglib.hqrndrandomize(out Vars.Start_rnd);
            //Directory.CreateDirectory(@"C:\4K4\CsProg\NBMD1\Autosaves\Exp"+ "_" + Vars.SaveDirectory);

            while (Vars.Start == true)
            {
                if (Vars.Step_Numb % Vars.Step_Freq == 0) { Vars.time_cycle_begin = DateTime.Now; }
                Vars.Step_Numb++;
                
                MyFunсProc.CreateHOC();                                                           //Создание связных списков
                MyFunсProc.Init_massive_RDF();                                                    //Инициализания массивов для РФР
                MyFunсProc.Find_Force();                                                          //Нахождение силы

                //МД - Цикл(скорость)
                for (int k = 0; k < Vars.Coor.Length; k++) { Vars.Vel[k] += (Vars.Force[k] / Vars.mass) * dt; }

                MyFunсProc.Pulse_Corr();                                                           //Коррекция импульса 

                //Нахождение Теампературы
                double E_kin1 = 0; Vars.Ek_system = 0; Vars.Temp = 0;
                for (int k = 0; k < Vars.Vel.Length; k++) { E_kin1 += Vars.Vel[k].VectLength2(); }
                Vars.Temp = Vars.mass * E_kin1 / (3 * Vars.k_bol * Vars.part_amount);               //Реальная температура

                //Ступенчатый нагрев
                if (запуститьНагревToolStripMenuItem.Checked == true)
                { if (Vars.Step_Numb % (Vars.HS_Corr_ratio * Vars.Step_Temp) == 0) Vars.Temp_fix += Vars.Temp_plus; }
                //Термостат Берендсена
                if (Vars.Step_Numb % Vars.Step_Temp == 0)
                {
                    Vars.Hard_Temp_Correct = false;
                    if (Vars.Step_Numb % (Vars.HS_Corr_ratio * Vars.Step_Temp) == 0) Vars.Hard_Temp_Correct = true;
                }
                if (Vars.Hard_Temp_Correct == true)
                { for (int k = 0; k < Vars.Vel.Length; k++) Vars.Vel[k] *= Math.Sqrt(Vars.Temp_fix / Vars.Temp); }
                else
                { for (int k = 0; k < Vars.Vel.Length; k++) Vars.Vel[k] *= Math.Sqrt(1 + (dt / Vars.Time_relax) * (Vars.Temp_fix / Vars.Temp - 1)); }
                
                //МД - Цикл(координата)
                for (int k = 0; k < Vars.Coor.Length; k++) { Vars.Coor[k] += Vars.Vel[k] * dt; }

                MyFunсProc.Reflection();             //Отражение
                
                MyFunсProc.Find_Drop();              //Нахождение температур капли и газа

                Param_Energy();
                if (Vars.Step_Numb % Vars.Step_Freq == 0)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("E = " + Convert.ToString(Vars.E_system));
                    listBox1.Items.Add("Ek = " + Convert.ToString(Vars.Ek_system));
                    listBox1.Items.Add("U = " + Convert.ToString(Vars.U_system));
                }
                
                MyFunсProc.Release_massive_RDF();  //Обрезание и усреднение радиальной функции распределения по внутренней области кристалла

                MySpline.Approx_peak();

                MyFunсProc.Find_Lattice_Size();
                if (Vars.Step_Numb % Vars.Step_Freq == 0) textBox1.Text = Convert.ToString(Vars.Lettice_Size_av / Vars.Step_Freq);

                //Усреднение по 100 шагам
                Vars.R_max1_av += Vars.R_max1; Vars.Sum_Neighbour_av += Vars.Sum_Neighbour; Vars.Temp_av += Vars.Temp; 
                Vars.E_system_av += Vars.E_system; Vars.Lettice_Size_av += Vars.Lattice_Size;
                Vars.Temp_Drop_av += Vars.Temp_Drop; Vars.Temp_Gas_av += Vars.Temp_Gas; Vars.Part_Drop_av += Vars.Part_Drop; Vars.Part_Gas_av += Vars.Part_Gas;
                for (int k = 0; k < Vars.N_massive_av.Length; k++) { Vars.N_massive_av[k] += Vars.N_massive[k]; }
                if (Vars.Step_Numb % Vars.Step_Freq == 0) { Param_RDF(); }

                //График
                if (checkBox3.Checked == true && Vars.Step_Numb % Vars.Step_Freq == 0) GRs_RDF(); 
               
                //Шаг по времени
                if (Vars.Step_Numb % Vars.Step_Freq == 0) Vars.time_cycle_end = DateTime.Now;           //Конец цикла
                   
                //Рисование конфигурации частиц
                if (Vars.Step_Numb % Vars.Step_Freq == 0) GRs_part_conf();

                //Автосохранение
                if (Vars.Step_Numb % Vars.Step_Freq == 0)
                {
                    Vars.Param1[Vars.Count_av].Step = Vars.Step_Numb;
                    Vars.Param1[Vars.Count_av].Energy = Vars.E_system_av / Vars.Step_Freq; Vars.Param1[Vars.Count_av].Temp = Vars.Temp_av / Vars.Step_Freq;
                    Vars.Param1[Vars.Count_av].LS_RDF = 1.414213562373095 * Vars.R_max1_av / Vars.Step_Freq; Vars.Param1[Vars.Count_av].LS_N = Vars.Lettice_Size_av / Vars.Step_Freq;
                    Vars.Param1[Vars.Count_av].Sum_N = Vars.Sum_Neighbour_av / Vars.Step_Freq;
                    Vars.Param1[Vars.Count_av].Temp_Drop = Vars.Temp_Drop_av / Vars.Step_Freq; Vars.Param1[Vars.Count_av].Temp_Gas = Vars.Temp_Gas_av / Vars.Step_Freq;
                    Vars.Param1[Vars.Count_av].Part_Drop = Vars.Part_Drop_av / Vars.Step_Freq; Vars.Param1[Vars.Count_av].Part_Gas = Vars.Part_Gas_av / Vars.Step_Freq;
                    Vars.Count_av++;
                }
               
                if (Vars.Step_Numb % (Vars.Param_Save_Freq * Vars.Step_Freq) == 0)
                {
                    Dataworks.Auto_save_Conf();                                                          //Автосохранение конфигурации
                    Dataworks.Auto_save_RDF();
                    Dataworks.Auto_save_Param();
                    for (int k = 0; k < Vars.Param1.Length; k++)
                    {
                        Vars.Param1[k].Step = 0;
                        Vars.Param1[k].Energy = 0; Vars.Param1[k].Temp = 0;
                        Vars.Param1[k].LS_RDF = 0; Vars.Param1[k].LS_N = 0;
                        Vars.Param1[k].Sum_N = 0;
                        Vars.Param1[k].Temp_Drop = 0; Vars.Param1[k].Temp_Gas = 0;
                        Vars.Param1[k].Part_Drop = 0; Vars.Param1[k].Part_Gas = 0;
                    }
                    Vars.Count_av = 0;
                }
                
                if (Vars.Step_Numb % Vars.Step_Freq == 0) Dataworks.Zero_av();                           //Обнуление средних величин

                Application.DoEvents();
            }
        }

        public void Param_Energy() //Вывод информации об энергии системы
        {
            //listBox1.Items.Clear();
            //Нахождение суммарной энергии системы
            double Ek_1 = 0; Vars.Ek_system = 0; Vars.Ek_system = 0;
            for (int k = 0; k < Vars.Vel.Length; k++) { Ek_1 += Vars.Vel[k].VectLength2(); }
            Vars.Ek_system = 0.5 * Vars.mass * Ek_1;                                         //Кинетическая энергия системы
            Vars.E_system = Vars.Ek_system + Vars.U_system;
            //listBox1.Items.Add("E = " + Convert.ToString(Vars.E_system));
            //listBox1.Items.Add("Ek = " + Convert.ToString(Vars.Ek_system));
            //listBox1.Items.Add("U = " + Convert.ToString(Vars.U_system));
        }

        public void Param_RDF() //Вывод данных найденных данных по радиальной функции распределения
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("R_max = " + Convert.ToString(Vars.R_max1_av / Vars.Step_Freq));
            listBox2.Items.Add("Sum_N = " + Convert.ToString(Vars.Sum_Neighbour_av / Vars.Step_Freq));
            listBox2.Items.Add("ПР = " + Convert.ToString(1.414213562373095 * Vars.R_max1_av / Vars.Step_Freq));
            for (int k = 0; k < Vars.N_massive_av.Length; k++) { Vars.N_massive_av[k] /= Vars.Step_Freq; }
            listBox2.Items.Add(Convert.ToString(Vars.Temp_Drop));
            listBox2.Items.Add(Convert.ToString(Vars.Temp_Gas));
        }

        public void GRs_RDF() //Вывод графика радиальной функиции распределения
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            GraphPane myPane1 = zedGraphControl1.GraphPane;
            myPane1.Title.Text = "Радиальное распределение";
            myPane1.XAxis.Title.Text = "R";
            myPane1.YAxis.Title.Text = "N(R)";
            myPane1.XAxis.Scale.Min = 0; myPane1.YAxis.Scale.Min = 0;
            myPane1.XAxis.Scale.Max = Vars.RRR + 1;
            myPane1.YAxis.Scale.Max = 10;
            myPane1.XAxis.Scale.MinorStep = 1; myPane1.YAxis.Scale.MinorStep = 0.1;
            zedGraphControl1.AxisChange();

            GraphPane myPane;
            PointPairList list1;
            LineItem myCurve;
            myPane = zedGraphControl1.GraphPane;
            list1 = new PointPairList(Vars.R_massive, Vars.N_massive_av);
            myCurve = myPane.AddCurve("Радиальная функция распределения", list1, Color.Firebrick, SymbolType.Star);
            for (int k = 0; k < Vars.N_massive_av.Length; k++) { Vars.N_massive_av[k] = 0; }

            GraphPane myPane0;
            PointPairList list0;
            LineItem myCurve0;
            myPane0 = zedGraphControl1.GraphPane;
            double[] q00 = new double[2]; double[] q11 = new double[2];
            q00[0] = Vars.R_massive[Vars.Index_minVal]; q11[0] = 0; q00[1] = q00[0]; q11[1] = myPane1.YAxis.Scale.Max;
            list0 = new PointPairList(q00, q11);
            myCurve0 = myPane0.AddCurve("R_Nmin", list0, Color.Blue, SymbolType.VDash);

            GraphPane myPane2;
            PointPairList list2;
            LineItem myCurve2;
            myPane2 = zedGraphControl1.GraphPane;
            double[] q000 = new double[2]; double[] q111 = new double[2];
            q000[0] = Vars.R_max1; q111[0] = 0; q000[1] = q000[0]; q111[1] = myPane1.YAxis.Scale.Max;
            list2 = new PointPairList(q000, q111);
            myCurve2 = myPane2.AddCurve("R_Nmax", list2, Color.Black, SymbolType.VDash);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh(); 
        }

        public void GRs_part_conf() //Отображение конфигурации частиц
        {
            textBox2.Text = "Шаг № " + Convert.ToString(Vars.Step_Numb);
            Text = "Т = " + Convert.ToString(Vars.Temp_av / Vars.Step_Freq) + " K   Шаг по времени = " +
                Convert.ToString((Vars.time_cycle_end.Ticks - Vars.time_cycle_begin.Ticks) * 1.0e-7 / (double)(Vars.Step_Freq));
            
            double C_x = panel1.Width / Vars.Cube_Size, C_y = panel1.Height / Vars.Cube_Size;
            Graphics Gr1 = panel1.CreateGraphics();
            Pen pencil_1 = new Pen(Color.Black, 1);
            Gr1.Clear(Color.White);

            if (рисоватьОбластьРасчётаРФРToolStripMenuItem.Checked == true)
            { Gr1.DrawEllipse(pencil_1, panel1.Width / 2 - (float)(C_x * Vars.R_cut), panel1.Height / 2 - (float)(C_y * Vars.R_cut), (float)(2 * C_x * Vars.R_cut), (float)(2 * C_y * Vars.R_cut)); }

            if (отображениеОбластиКаплиToolStripMenuItem.Checked == true)
            { 
                Gr1.DrawEllipse(pencil_1, (int)(C_x * Vars.Drop_Center_Point.x) - (float)(C_x * Vars.Drop_size), (int)(C_y * Vars.Drop_Center_Point.y) - (float)(C_y * Vars.Drop_size),
                    (float)(2 * C_x * Vars.Drop_size), (float)(2 * C_y * Vars.Drop_size));
            }

            trackBar1.Maximum = (int)(Vars.Cube_Size / Vars.Lattice_period) + 1;
            Vars.lay_numb = trackBar1.Value;
            if (drawParticlesToolStripMenuItem.Checked == true)
            {
                for (int k = 0; k < Vars.Coor.Length; k++)
                {
                    if (drawLayersToolStripMenuItem.Checked == true)
                    {
                        if (Vars.Coor[k].z > -Vars.Cube_Size / 2 + (Vars.lay_numb) * Vars.Lattice_period)
                            if (Vars.Coor[k].z < -Vars.Cube_Size / 2 + (Vars.lay_numb + 1) * Vars.Lattice_period)
                                Gr1.DrawEllipse(pencil_1, Convert.ToInt32(C_x * Vars.Coor[k].x + panel1.Width / 2), Convert.ToInt32(C_y * Vars.Coor[k].y + panel1.Height / 2), 2, 2);
                    }
                    else { Gr1.DrawEllipse(pencil_1, Convert.ToInt32(C_x * Vars.Coor[k].x + panel1.Width / 2), Convert.ToInt32(C_y * Vars.Coor[k].y + panel1.Height / 2), 2, 2); }
                }
            }
        }

        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vars.Temp_fix = Convert.ToDouble(toolStripTextBox1.Text);
        }

        private void setToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Vars.Time_relax = Convert.ToDouble(toolStripTextBox2.Text);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vars.Start = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Vars.lay_numb = (double)trackBar1.Value;
            textBox1.Text = Convert.ToString(Vars.lay_numb);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Text Files (*.txt)|.txt";
            svf.FilterIndex = 2;
            svf.RestoreDirectory = true;
            if (svf.ShowDialog() == DialogResult.OK)
            {
                FileInfo file_data = new FileInfo(svf.FileName);
                StreamWriter myStream = file_data.CreateText();
                myStream.WriteLine(Convert.ToString(Vars.Step_Numb));
                myStream.WriteLine(Convert.ToString(Vars.part_amount));
                for (int k = 0; k < Vars.Coor.Length; k++)
                {
                    myStream.WriteLine(Convert.ToString(k) + "\t" + Convert.ToString(Vars.Vel[k].x) + "\t"
                                                           + Convert.ToString(Vars.Vel[k].y) + "\t"
                                                           + Convert.ToString(Vars.Vel[k].z) + "\t"
                                                           + Convert.ToString(Vars.Coor[k].x) + "\t"
                                                           + Convert.ToString(Vars.Coor[k].y) + "\t"
                                                           + Convert.ToString(Vars.Coor[k].z));
                }
                myStream.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //StreamReader str_read = new StreamReader(@"C:\4K5\CsharpProjects\BMD2\Conf.txt");
            //string str = "";
            //while(!str_read.EndOfStream)
            //{
            //    str += str_read.ReadLine();
            //}
            //textBox6.Text = str;
            //string str_spl [] = str.Split(new string[] {"\t"},StringSplitOptions.RemoveEmptyEntries);
            //string text_in = File.ReadAllText(@"C:\4K5\CsharpProjects\BMD2\Conf.txt");
            string text_in = ""; OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Text Files|*.txt";
            if (opf.ShowDialog() == DialogResult.OK) { text_in = File.ReadAllText(opf.FileName); }
            string[] Massive_text_in = text_in.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int extra_values = 2;
            Vars.Step_Numb = Convert.ToInt32(Massive_text_in[0]);
            Vars.part_amount = Convert.ToInt32(Massive_text_in[1]);

            for (int k = 0; k < Vars.part_amount; k++)
            {
                Vars.part_conf[k] = new string[7];
                Vars.part_conf[k] = Massive_text_in[k + extra_values].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                Vars.Vel[k].x = double.Parse(Vars.part_conf[k][1]); Vars.Coor[k].x = double.Parse(Vars.part_conf[k][4]);
                Vars.Vel[k].y = double.Parse(Vars.part_conf[k][2]); Vars.Coor[k].y = double.Parse(Vars.part_conf[k][5]);
                Vars.Vel[k].z = double.Parse(Vars.part_conf[k][3]); Vars.Coor[k].z = double.Parse(Vars.part_conf[k][6]);
            }
            Vars.Start = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Text Files (*.txt)|.txt";
            svf.FilterIndex = 2;
            svf.RestoreDirectory = true;
            if (svf.ShowDialog() == DialogResult.OK)
            {
                FileInfo file_data = new FileInfo(svf.FileName);
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
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void установитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vars.Temp_plus = Convert.ToDouble(toolStripTextBox3.Text);
        }

        private void установитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Vars.Step_Temp = Convert.ToDouble(toolStripTextBox4.Text);
        }

    }
}
