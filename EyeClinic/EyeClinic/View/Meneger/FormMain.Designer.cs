namespace EyeClinic.View
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пациентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПациентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПациентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группыПациентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проблемыВЛеченииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лечениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПрограммToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЛеченияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диаграммауспешностьЛеченияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокВрачейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.врачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пациентToolStripMenuItem,
            this.лечениеToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.списокВрачейToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(350, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // пациентToolStripMenuItem
            // 
            this.пациентToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПациентаToolStripMenuItem,
            this.списокПациентовToolStripMenuItem,
            this.группыПациентовToolStripMenuItem,
            this.проблемыВЛеченииToolStripMenuItem});
            this.пациентToolStripMenuItem.Name = "пациентToolStripMenuItem";
            this.пациентToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.пациентToolStripMenuItem.Text = "Пациент";
            // 
            // добавитьПациентаToolStripMenuItem
            // 
            this.добавитьПациентаToolStripMenuItem.Name = "добавитьПациентаToolStripMenuItem";
            this.добавитьПациентаToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.добавитьПациентаToolStripMenuItem.Text = "Добавить пациента";
            this.добавитьПациентаToolStripMenuItem.Click += new System.EventHandler(this.добавитьПациентаToolStripMenuItem_Click);
            // 
            // списокПациентовToolStripMenuItem
            // 
            this.списокПациентовToolStripMenuItem.Name = "списокПациентовToolStripMenuItem";
            this.списокПациентовToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.списокПациентовToolStripMenuItem.Text = "Список пациентов";
            this.списокПациентовToolStripMenuItem.Click += new System.EventHandler(this.списокПациентовToolStripMenuItem_Click);
            // 
            // группыПациентовToolStripMenuItem
            // 
            this.группыПациентовToolStripMenuItem.Name = "группыПациентовToolStripMenuItem";
            this.группыПациентовToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.группыПациентовToolStripMenuItem.Text = "Группы пациентов";
            this.группыПациентовToolStripMenuItem.Click += new System.EventHandler(this.группыПациентовToolStripMenuItem_Click);
            // 
            // проблемыВЛеченииToolStripMenuItem
            // 
            this.проблемыВЛеченииToolStripMenuItem.Name = "проблемыВЛеченииToolStripMenuItem";
            this.проблемыВЛеченииToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.проблемыВЛеченииToolStripMenuItem.Text = "Проблемы в лечении";
            this.проблемыВЛеченииToolStripMenuItem.Click += new System.EventHandler(this.проблемыВЛеченииToolStripMenuItem_Click);
            // 
            // лечениеToolStripMenuItem
            // 
            this.лечениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокПрограммToolStripMenuItem,
            this.списокЛеченияToolStripMenuItem});
            this.лечениеToolStripMenuItem.Name = "лечениеToolStripMenuItem";
            this.лечениеToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.лечениеToolStripMenuItem.Text = "Лечение";
            // 
            // списокПрограммToolStripMenuItem
            // 
            this.списокПрограммToolStripMenuItem.Name = "списокПрограммToolStripMenuItem";
            this.списокПрограммToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.списокПрограммToolStripMenuItem.Text = "Список программ";
            this.списокПрограммToolStripMenuItem.Click += new System.EventHandler(this.списокПрограммToolStripMenuItem_Click);
            // 
            // списокЛеченияToolStripMenuItem
            // 
            this.списокЛеченияToolStripMenuItem.Name = "списокЛеченияToolStripMenuItem";
            this.списокЛеченияToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.списокЛеченияToolStripMenuItem.Text = "Список лечения ";
            this.списокЛеченияToolStripMenuItem.Click += new System.EventHandler(this.списокЛеченияToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.диаграммауспешностьЛеченияToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // диаграммауспешностьЛеченияToolStripMenuItem
            // 
            this.диаграммауспешностьЛеченияToolStripMenuItem.Name = "диаграммауспешностьЛеченияToolStripMenuItem";
            this.диаграммауспешностьЛеченияToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.диаграммауспешностьЛеченияToolStripMenuItem.Text = "Диаграмма-успешность лечения";
            this.диаграммауспешностьЛеченияToolStripMenuItem.Click += new System.EventHandler(this.диаграммауспешностьЛеченияToolStripMenuItem_Click);
            // 
            // списокВрачейToolStripMenuItem
            // 
            this.списокВрачейToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.врачиToolStripMenuItem});
            this.списокВрачейToolStripMenuItem.Name = "списокВрачейToolStripMenuItem";
            this.списокВрачейToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.списокВрачейToolStripMenuItem.Text = "Список врачей";
            // 
            // врачиToolStripMenuItem
            // 
            this.врачиToolStripMenuItem.Name = "врачиToolStripMenuItem";
            this.врачиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.врачиToolStripMenuItem.Text = "Врачи";
            this.врачиToolStripMenuItem.Click += new System.EventHandler(this.врачиToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(350, 463);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "EyeClinic";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пациентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПациентаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокПациентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лечениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокПрограммToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЛеченияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группыПациентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem диаграммауспешностьЛеченияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проблемыВЛеченииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокВрачейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem врачиToolStripMenuItem;
    }
}