namespace EyeClinic.View
{
    partial class FormDiagramm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTherapy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIll = new System.Windows.Forms.TextBox();
            this.textBoxZdor = new System.Windows.Forms.TextBox();
            this.textBoxProbl = new System.Windows.Forms.TextBox();
            this.buttonGet = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(316, 53);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Пациенты";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(435, 307);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Создать диаграмму";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Лечение";
            // 
            // comboBoxTherapy
            // 
            this.comboBoxTherapy.FormattingEnabled = true;
            this.comboBoxTherapy.Location = new System.Drawing.Point(63, 36);
            this.comboBoxTherapy.Name = "comboBoxTherapy";
            this.comboBoxTherapy.Size = new System.Drawing.Size(168, 21);
            this.comboBoxTherapy.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Больных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Здоровых";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Проблемы в лечении";
            // 
            // textBoxIll
            // 
            this.textBoxIll.Location = new System.Drawing.Point(173, 81);
            this.textBoxIll.Name = "textBoxIll";
            this.textBoxIll.ReadOnly = true;
            this.textBoxIll.Size = new System.Drawing.Size(58, 20);
            this.textBoxIll.TabIndex = 7;
            // 
            // textBoxZdor
            // 
            this.textBoxZdor.Location = new System.Drawing.Point(173, 109);
            this.textBoxZdor.Name = "textBoxZdor";
            this.textBoxZdor.ReadOnly = true;
            this.textBoxZdor.Size = new System.Drawing.Size(58, 20);
            this.textBoxZdor.TabIndex = 8;
            // 
            // textBoxProbl
            // 
            this.textBoxProbl.Location = new System.Drawing.Point(173, 135);
            this.textBoxProbl.Name = "textBoxProbl";
            this.textBoxProbl.ReadOnly = true;
            this.textBoxProbl.Size = new System.Drawing.Size(58, 20);
            this.textBoxProbl.TabIndex = 9;
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(124, 217);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(107, 25);
            this.buttonGet.TabIndex = 10;
            this.buttonGet.Text = "Получить данные";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "На лечении";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(173, 161);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.ReadOnly = true;
            this.textBoxCount.Size = new System.Drawing.Size(58, 20);
            this.textBoxCount.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 22);
            this.button2.TabIndex = 13;
            this.button2.Text = "Очистить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(564, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 22);
            this.button3.TabIndex = 14;
            this.button3.Text = "Сохранить диаграмму";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Название диаграммы";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(463, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(288, 20);
            this.textBoxName.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Средняя оценка результатов лечения";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 191);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(58, 20);
            this.textBox1.TabIndex = 18;
            // 
            // FormDiagramm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.textBoxProbl);
            this.Controls.Add(this.textBoxZdor);
            this.Controls.Add(this.textBoxIll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTherapy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Name = "FormDiagramm";
            this.Text = "FormDiagramm";
            this.Load += new System.EventHandler(this.FormDiagramm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTherapy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIll;
        private System.Windows.Forms.TextBox textBoxZdor;
        private System.Windows.Forms.TextBox textBoxProbl;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
    }
}