namespace Gestión_Puertas
{
    partial class Form5
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
            this.ComboTipos = new System.Windows.Forms.ComboBox();
            this.comboZona = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_Acp = new System.Windows.Forms.Button();
            this.Btn_Cnl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(50, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(50, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Zona";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(50, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo";
            // 
            // ComboTipos
            // 
            this.ComboTipos.FormattingEnabled = true;
            this.ComboTipos.Location = new System.Drawing.Point(148, 152);
            this.ComboTipos.Name = "ComboTipos";
            this.ComboTipos.Size = new System.Drawing.Size(255, 23);
            this.ComboTipos.TabIndex = 4;
            this.ComboTipos.SelectedIndexChanged += new System.EventHandler(this.ComboTipos_SelectedIndexChanged);
            // 
            // comboZona
            // 
            this.comboZona.FormattingEnabled = true;
            this.comboZona.Location = new System.Drawing.Point(148, 117);
            this.comboZona.Name = "comboZona";
            this.comboZona.Size = new System.Drawing.Size(255, 23);
            this.comboZona.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 23);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox2.Location = new System.Drawing.Point(148, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(255, 23);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btn_Acp
            // 
            this.btn_Acp.ForeColor = System.Drawing.Color.Maroon;
            this.btn_Acp.Location = new System.Drawing.Point(75, 293);
            this.btn_Acp.Name = "btn_Acp";
            this.btn_Acp.Size = new System.Drawing.Size(75, 23);
            this.btn_Acp.TabIndex = 8;
            this.btn_Acp.Text = "Aceptar";
            this.btn_Acp.UseVisualStyleBackColor = true;
            this.btn_Acp.Click += new System.EventHandler(this.btn_Acp_Click);
            // 
            // Btn_Cnl
            // 
            this.Btn_Cnl.ForeColor = System.Drawing.Color.Maroon;
            this.Btn_Cnl.Location = new System.Drawing.Point(328, 293);
            this.Btn_Cnl.Name = "Btn_Cnl";
            this.Btn_Cnl.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cnl.TabIndex = 9;
            this.Btn_Cnl.Text = "Cancelar";
            this.Btn_Cnl.UseVisualStyleBackColor = true;
            this.Btn_Cnl.Click += new System.EventHandler(this.Btn_Cnl_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 339);
            this.Controls.Add(this.Btn_Cnl);
            this.Controls.Add(this.btn_Acp);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboZona);
            this.Controls.Add(this.ComboTipos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Añadir Dispositivo";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox ComboTipos;
        private ComboBox comboZona;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btn_Acp;
        private Button Btn_Cnl;
    }
}