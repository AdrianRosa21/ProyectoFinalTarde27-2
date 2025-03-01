namespace Proyecto_FINAL
{
    partial class InicioSesion
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
            checkBox1 = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            btnVerificación = new Button();
            TxtContraseña = new TextBox();
            txtContacto = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnVerificación);
            groupBox1.Controls.Add(TxtContraseña);
            groupBox1.Controls.Add(txtContacto);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(272, 38);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(442, 601);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(82, 354);
            checkBox1.Margin = new Padding(4, 4, 4, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(121, 29);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(120, 284);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 165);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 4;
            label2.Text = "label2";
            // 
            // btnVerificación
            // 
            btnVerificación.Location = new Point(154, 489);
            btnVerificación.Margin = new Padding(4, 4, 4, 4);
            btnVerificación.Name = "btnVerificación";
            btnVerificación.Size = new Size(118, 36);
            btnVerificación.TabIndex = 3;
            btnVerificación.Text = "button1";
            btnVerificación.UseVisualStyleBackColor = true;
            btnVerificación.Click += btnVerificación_Click;
            // 
            // TxtContraseña
            // 
            TxtContraseña.Location = new Point(82, 312);
            TxtContraseña.Margin = new Padding(4, 4, 4, 4);
            TxtContraseña.Name = "TxtContraseña";
            TxtContraseña.Size = new Size(223, 31);
            TxtContraseña.TabIndex = 2;
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(82, 194);
            txtContacto.Margin = new Padding(4, 4, 4, 4);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(223, 31);
            txtContacto.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(192, 48);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // InicioSesion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 679);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "InicioSesion";
            Text = "InicioSesion";
            Load += InicioSesion_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private Label label3;
        private Label label2;
        private Button btnVerificación;
        private TextBox TxtContraseña;
        private TextBox txtContacto;
        private Label label1;
    }
}