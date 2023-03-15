namespace Gestión_Puertas
{
    partial class Form2
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
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RFIDBox = new System.Windows.Forms.TextBox();
            this.checkVisita = new System.Windows.Forms.CheckBox();
            this.checkValAl = new System.Windows.Forms.CheckBox();
            this.btn_Acept = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Mas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(65, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // NombreBox
            // 
            this.NombreBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.NombreBox.Location = new System.Drawing.Point(168, 86);
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(374, 23);
            this.NombreBox.TabIndex = 1;
            this.NombreBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(65, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "CodigRFID";
            // 
            // RFIDBox
            // 
            this.RFIDBox.Location = new System.Drawing.Point(168, 138);
            this.RFIDBox.Name = "RFIDBox";
            this.RFIDBox.Size = new System.Drawing.Size(335, 23);
            this.RFIDBox.TabIndex = 3;
            this.RFIDBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // checkVisita
            // 
            this.checkVisita.AutoSize = true;
            this.checkVisita.ForeColor = System.Drawing.Color.Maroon;
            this.checkVisita.Location = new System.Drawing.Point(65, 214);
            this.checkVisita.Name = "checkVisita";
            this.checkVisita.Size = new System.Drawing.Size(65, 19);
            this.checkVisita.TabIndex = 4;
            this.checkVisita.Text = "EsVisita";
            this.checkVisita.UseVisualStyleBackColor = true;
            // 
            // checkValAl
            // 
            this.checkValAl.AutoSize = true;
            this.checkValAl.ForeColor = System.Drawing.Color.Maroon;
            this.checkValAl.Location = new System.Drawing.Point(65, 262);
            this.checkValAl.Name = "checkValAl";
            this.checkValAl.Size = new System.Drawing.Size(62, 19);
            this.checkValAl.TabIndex = 5;
            this.checkValAl.Text = "Es Baja";
            this.checkValAl.UseVisualStyleBackColor = true;
            // 
            // btn_Acept
            // 
            this.btn_Acept.ForeColor = System.Drawing.Color.Maroon;
            this.btn_Acept.Location = new System.Drawing.Point(168, 367);
            this.btn_Acept.Name = "btn_Acept";
            this.btn_Acept.Size = new System.Drawing.Size(75, 23);
            this.btn_Acept.TabIndex = 6;
            this.btn_Acept.Text = "Aceptar";
            this.btn_Acept.UseVisualStyleBackColor = true;
            this.btn_Acept.Click += new System.EventHandler(this.btn_Acept_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ForeColor = System.Drawing.Color.Maroon;
            this.btn_Cancel.Location = new System.Drawing.Point(359, 367);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Mas
            // 
            this.btn_Mas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Mas.Location = new System.Drawing.Point(600, 367);
            this.btn_Mas.Name = "btn_Mas";
            this.btn_Mas.Size = new System.Drawing.Size(37, 23);
            this.btn_Mas.TabIndex = 10;
            this.btn_Mas.Text = ". . .";
            this.btn_Mas.UseVisualStyleBackColor = false;
            this.btn_Mas.Click += new System.EventHandler(this.btn_Mas_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Mas);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Acept);
            this.Controls.Add(this.checkValAl);
            this.Controls.Add(this.checkVisita);
            this.Controls.Add(this.RFIDBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NombreBox);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Añadir Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox NombreBox;
        private Label label2;
        private TextBox RFIDBox;
        private CheckBox checkVisita;
        private CheckBox checkValAl;
        private Button btn_Acept;
        private Button btn_Cancel;
        private Button btn_Mas;
    }
}