namespace Proyecto_FINAL
{
    partial class Form3
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            cmbRutina = new ComboBox();
            btnElegir = new Button();
            groupBox2 = new GroupBox();
            label3 = new Label();
            button2 = new Button();
            btnAgregar = new Button();
            groupBox3 = new GroupBox();
            lblDia1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnElegir);
            groupBox1.Controls.Add(cmbRutina);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(35, 26);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(803, 188);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selección de rutina";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 99);
            label1.Name = "label1";
            label1.Size = new Size(253, 32);
            label1.TabIndex = 0;
            label1.Text = "Tu rutina seleccionada";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(17, 36);
            label2.Name = "label2";
            label2.Size = new Size(505, 28);
            label2.TabIndex = 1;
            label2.Text = "¡Recuerda! Puedes elegir la rutina que mas se adecue a ti.";
            // 
            // cmbRutina
            // 
            cmbRutina.FormattingEnabled = true;
            cmbRutina.Location = new Point(266, 99);
            cmbRutina.Name = "cmbRutina";
            cmbRutina.Size = new Size(256, 40);
            cmbRutina.TabIndex = 2;
            // 
            // btnElegir
            // 
            btnElegir.Location = new Point(580, 70);
            btnElegir.Name = "btnElegir";
            btnElegir.Size = new Size(188, 61);
            btnElegir.TabIndex = 3;
            btnElegir.Text = "elegir";
            btnElegir.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(864, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1004, 188);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Agregar o eliminar ejercicios";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(67, 35);
            label3.Name = "label3";
            label3.Size = new Size(876, 28);
            label3.TabIndex = 2;
            label3.Text = "Puedes añadir el ejercicio dependiendo del tiempo que dispongas. (Máximo 7 ejercicios, mínimo 1) ";
            // 
            // button2
            // 
            button2.Location = new Point(190, 87);
            button2.Name = "button2";
            button2.Size = new Size(180, 62);
            button2.TabIndex = 3;
            button2.Text = "eliminar";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(617, 84);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(180, 62);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblDia1);
            groupBox3.Location = new Point(35, 238);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(968, 757);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // lblDia1
            // 
            lblDia1.AutoSize = true;
            lblDia1.Font = new Font("Segoe UI", 10F);
            lblDia1.Location = new Point(17, 88);
            lblDia1.Name = "lblDia1";
            lblDia1.Size = new Size(688, 28);
            lblDia1.TabIndex = 2;
            lblDia1.Text = "Día 1    Press banca, Dominadas, Peso muerto, Elevaciones laterales, Peck deck,";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1903, 1019);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private ComboBox cmbRutina;
        private Button btnElegir;
        private GroupBox groupBox2;
        private Label label3;
        private Button button2;
        private Button btnAgregar;
        private GroupBox groupBox3;
        private Label lblDia1;
    }
}