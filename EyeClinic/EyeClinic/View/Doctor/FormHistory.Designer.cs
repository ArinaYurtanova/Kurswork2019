namespace EyeClinic.View.Doctor
{
    partial class FormHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPatient = new System.Windows.Forms.ComboBox();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.comboBoxIllness = new System.Windows.Forms.ComboBox();
            this.comboBoxTherapy = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonGetPatient = new System.Windows.Forms.Button();
            this.buttonGetDoctor = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonRecipe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пациент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Доктор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Болезнь";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Лечение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Статус";
            // 
            // comboBoxPatient
            // 
            this.comboBoxPatient.FormattingEnabled = true;
            this.comboBoxPatient.Location = new System.Drawing.Point(99, 4);
            this.comboBoxPatient.Name = "comboBoxPatient";
            this.comboBoxPatient.Size = new System.Drawing.Size(233, 21);
            this.comboBoxPatient.TabIndex = 5;
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(99, 31);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(233, 21);
            this.comboBoxDoctor.TabIndex = 6;
            // 
            // comboBoxIllness
            // 
            this.comboBoxIllness.FormattingEnabled = true;
            this.comboBoxIllness.Location = new System.Drawing.Point(99, 58);
            this.comboBoxIllness.Name = "comboBoxIllness";
            this.comboBoxIllness.Size = new System.Drawing.Size(234, 21);
            this.comboBoxIllness.TabIndex = 7;
            // 
            // comboBoxTherapy
            // 
            this.comboBoxTherapy.FormattingEnabled = true;
            this.comboBoxTherapy.Location = new System.Drawing.Point(99, 88);
            this.comboBoxTherapy.Name = "comboBoxTherapy";
            this.comboBoxTherapy.Size = new System.Drawing.Size(234, 21);
            this.comboBoxTherapy.TabIndex = 8;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(99, 117);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(234, 21);
            this.comboBoxStatus.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(607, 328);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(625, 170);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(625, 199);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 12;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(625, 228);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 13;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonGetPatient
            // 
            this.buttonGetPatient.Location = new System.Drawing.Point(12, 144);
            this.buttonGetPatient.Name = "buttonGetPatient";
            this.buttonGetPatient.Size = new System.Drawing.Size(144, 23);
            this.buttonGetPatient.TabIndex = 14;
            this.buttonGetPatient.Text = "Получить по пациенту";
            this.buttonGetPatient.UseVisualStyleBackColor = true;
            this.buttonGetPatient.Click += new System.EventHandler(this.buttonGetPatient_Click);
            // 
            // buttonGetDoctor
            // 
            this.buttonGetDoctor.Location = new System.Drawing.Point(188, 144);
            this.buttonGetDoctor.Name = "buttonGetDoctor";
            this.buttonGetDoctor.Size = new System.Drawing.Size(144, 23);
            this.buttonGetDoctor.TabIndex = 15;
            this.buttonGetDoctor.Text = "Получить по врачу";
            this.buttonGetDoctor.UseVisualStyleBackColor = true;
            this.buttonGetDoctor.Click += new System.EventHandler(this.buttonGetDoctor_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(625, 257);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(75, 23);
            this.buttonRef.TabIndex = 16;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(354, 2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(144, 23);
            this.buttonOpen.TabIndex = 17;
            this.buttonOpen.Text = "Открыть карту";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonRecipe
            // 
            this.buttonRecipe.Location = new System.Drawing.Point(625, 449);
            this.buttonRecipe.Name = "buttonRecipe";
            this.buttonRecipe.Size = new System.Drawing.Size(75, 49);
            this.buttonRecipe.TabIndex = 18;
            this.buttonRecipe.Text = "Выписать рецепт";
            this.buttonRecipe.UseVisualStyleBackColor = true;
            this.buttonRecipe.Click += new System.EventHandler(this.buttonRecipe_Click);
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 510);
            this.Controls.Add(this.buttonRecipe);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonGetDoctor);
            this.Controls.Add(this.buttonGetPatient);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBoxTherapy);
            this.Controls.Add(this.comboBoxIllness);
            this.Controls.Add(this.comboBoxDoctor);
            this.Controls.Add(this.comboBoxPatient);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormHistory";
            this.Text = "FormHistory";
            this.Load += new System.EventHandler(this.FormHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPatient;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.ComboBox comboBoxIllness;
        private System.Windows.Forms.ComboBox comboBoxTherapy;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonGetPatient;
        private System.Windows.Forms.Button buttonGetDoctor;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonRecipe;
    }
}