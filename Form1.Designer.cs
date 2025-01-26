namespace NBMD1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDcycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relaxTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.setToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.нагревToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шагTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.установитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шагПоВремениToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.установитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьНагревToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawParticlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисоватьОбластьРасчётаРФРToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображениеОбластиКаплиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(708, 37);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(708, 66);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(35, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 614);
            this.panel1.TabIndex = 10;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(707, 341);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 21);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "График";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(708, 96);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(56, 236);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(772, 96);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(203, 100);
            this.listBox1.TabIndex = 15;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(707, 370);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(517, 299);
            this.zedGraphControl1.TabIndex = 17;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(772, 204);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(203, 100);
            this.listBox2.TabIndex = 18;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(794, 341);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 23);
            this.button7.TabIndex = 19;
            this.button7.Text = "SaveRDF";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mDcycleToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.drawToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1238, 28);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.loadToolStripMenuItem.Text = "Загрузить";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.closeToolStripMenuItem.Text = "Выход";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // mDcycleToolStripMenuItem
            // 
            this.mDcycleToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.mDcycleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.mDcycleToolStripMenuItem.Name = "mDcycleToolStripMenuItem";
            this.mDcycleToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.mDcycleToolStripMenuItem.Text = "МД-цикл";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.startToolStripMenuItem.Text = "Старт";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.stopToolStripMenuItem.Text = "Стоп";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temperatureToolStripMenuItem,
            this.relaxTimeToolStripMenuItem,
            this.нагревToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.systemToolStripMenuItem.Text = "Система";
            // 
            // temperatureToolStripMenuItem
            // 
            this.temperatureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.setToolStripMenuItem});
            this.temperatureToolStripMenuItem.Name = "temperatureToolStripMenuItem";
            this.temperatureToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.temperatureToolStripMenuItem.Text = "Температура";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.setToolStripMenuItem.Text = "Установить";
            this.setToolStripMenuItem.Click += new System.EventHandler(this.setToolStripMenuItem_Click);
            // 
            // relaxTimeToolStripMenuItem
            // 
            this.relaxTimeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2,
            this.setToolStripMenuItem1});
            this.relaxTimeToolStripMenuItem.Name = "relaxTimeToolStripMenuItem";
            this.relaxTimeToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.relaxTimeToolStripMenuItem.Text = "Время релаксации";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            // 
            // setToolStripMenuItem1
            // 
            this.setToolStripMenuItem1.Name = "setToolStripMenuItem1";
            this.setToolStripMenuItem1.Size = new System.Drawing.Size(160, 24);
            this.setToolStripMenuItem1.Text = "Установить";
            this.setToolStripMenuItem1.Click += new System.EventHandler(this.setToolStripMenuItem1_Click);
            // 
            // нагревToolStripMenuItem
            // 
            this.нагревToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шагTToolStripMenuItem,
            this.шагПоВремениToolStripMenuItem,
            this.запуститьНагревToolStripMenuItem});
            this.нагревToolStripMenuItem.Name = "нагревToolStripMenuItem";
            this.нагревToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.нагревToolStripMenuItem.Text = "Нагрев";
            // 
            // шагTToolStripMenuItem
            // 
            this.шагTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox3,
            this.установитьToolStripMenuItem});
            this.шагTToolStripMenuItem.Name = "шагTToolStripMenuItem";
            this.шагTToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.шагTToolStripMenuItem.Text = "Шаг температуры";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 27);
            // 
            // установитьToolStripMenuItem
            // 
            this.установитьToolStripMenuItem.Name = "установитьToolStripMenuItem";
            this.установитьToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.установитьToolStripMenuItem.Text = "Установить";
            this.установитьToolStripMenuItem.Click += new System.EventHandler(this.установитьToolStripMenuItem_Click);
            // 
            // шагПоВремениToolStripMenuItem
            // 
            this.шагПоВремениToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox4,
            this.установитьToolStripMenuItem1});
            this.шагПоВремениToolStripMenuItem.Name = "шагПоВремениToolStripMenuItem";
            this.шагПоВремениToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.шагПоВремениToolStripMenuItem.Text = "Шаг по времени";
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 27);
            // 
            // установитьToolStripMenuItem1
            // 
            this.установитьToolStripMenuItem1.Name = "установитьToolStripMenuItem1";
            this.установитьToolStripMenuItem1.Size = new System.Drawing.Size(160, 24);
            this.установитьToolStripMenuItem1.Text = "Установить";
            this.установитьToolStripMenuItem1.Click += new System.EventHandler(this.установитьToolStripMenuItem1_Click);
            // 
            // запуститьНагревToolStripMenuItem
            // 
            this.запуститьНагревToolStripMenuItem.Checked = true;
            this.запуститьНагревToolStripMenuItem.CheckOnClick = true;
            this.запуститьНагревToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.запуститьНагревToolStripMenuItem.Name = "запуститьНагревToolStripMenuItem";
            this.запуститьНагревToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.запуститьНагревToolStripMenuItem.Text = "Запустить нагрев";
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawParticlesToolStripMenuItem,
            this.drawLayersToolStripMenuItem,
            this.рисоватьОбластьРасчётаРФРToolStripMenuItem,
            this.отображениеОбластиКаплиToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.drawToolStripMenuItem.Text = "Рисование";
            // 
            // drawParticlesToolStripMenuItem
            // 
            this.drawParticlesToolStripMenuItem.Checked = true;
            this.drawParticlesToolStripMenuItem.CheckOnClick = true;
            this.drawParticlesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawParticlesToolStripMenuItem.Name = "drawParticlesToolStripMenuItem";
            this.drawParticlesToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.drawParticlesToolStripMenuItem.Text = "Рисовать";
            // 
            // drawLayersToolStripMenuItem
            // 
            this.drawLayersToolStripMenuItem.CheckOnClick = true;
            this.drawLayersToolStripMenuItem.Name = "drawLayersToolStripMenuItem";
            this.drawLayersToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.drawLayersToolStripMenuItem.Text = "Рисовать по слоям";
            // 
            // рисоватьОбластьРасчётаРФРToolStripMenuItem
            // 
            this.рисоватьОбластьРасчётаРФРToolStripMenuItem.Checked = true;
            this.рисоватьОбластьРасчётаРФРToolStripMenuItem.CheckOnClick = true;
            this.рисоватьОбластьРасчётаРФРToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.рисоватьОбластьРасчётаРФРToolStripMenuItem.Name = "рисоватьОбластьРасчётаРФРToolStripMenuItem";
            this.рисоватьОбластьРасчётаРФРToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.рисоватьОбластьРасчётаРФРToolStripMenuItem.Text = "Рисовать область расчёта РФР";
            // 
            // отображениеОбластиКаплиToolStripMenuItem
            // 
            this.отображениеОбластиКаплиToolStripMenuItem.Checked = true;
            this.отображениеОбластиКаплиToolStripMenuItem.CheckOnClick = true;
            this.отображениеОбластиКаплиToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.отображениеОбластиКаплиToolStripMenuItem.Name = "отображениеОбластиКаплиToolStripMenuItem";
            this.отображениеОбластиКаплиToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.отображениеОбластиКаплиToolStripMenuItem.Text = "Отображение области капли";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1002, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Параметры эксперимента";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Location = new System.Drawing.Point(982, 92);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(228, 212);
            this.listBox3.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 683);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ListBox listBox1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mDcycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temperatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relaxTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawParticlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рисоватьОбластьРасчётаРФРToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нагревToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шагTToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripMenuItem установитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шагПоВремениToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.ToolStripMenuItem установитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem запуститьНагревToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ToolStripMenuItem отображениеОбластиКаплиToolStripMenuItem;
    }
}

