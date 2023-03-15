namespace Gestión_Puertas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.btn_anPer = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_elim = new System.Windows.Forms.Button();
            this.btn_modify = new System.Windows.Forms.Button();
            this.btn_tarjeta = new System.Windows.Forms.Button();
            this.text_RFID = new System.Windows.Forms.TextBox();
            this.lbl_RFID = new System.Windows.Forms.Label();
            this.btn_añade_disp = new System.Windows.Forms.Button();
            this.btn_entradas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(37, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_anPer
            // 
            this.btn_anPer.BackColor = System.Drawing.Color.Silver;
            this.btn_anPer.Location = new System.Drawing.Point(37, 420);
            this.btn_anPer.Name = "btn_anPer";
            this.btn_anPer.Size = new System.Drawing.Size(328, 29);
            this.btn_anPer.TabIndex = 2;
            this.btn_anPer.Text = "AñadirPersona";
            this.btn_anPer.UseVisualStyleBackColor = false;
            this.btn_anPer.Click += new System.EventHandler(this.btn_show_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.ForeColor = System.Drawing.Color.Maroon;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(19, 28);
            this.listBox1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(257, 334);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(314, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 23);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Forte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(314, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_elim
            // 
            this.btn_elim.BackColor = System.Drawing.Color.Silver;
            this.btn_elim.Location = new System.Drawing.Point(37, 455);
            this.btn_elim.Name = "btn_elim";
            this.btn_elim.Size = new System.Drawing.Size(328, 30);
            this.btn_elim.TabIndex = 6;
            this.btn_elim.Text = "Dar de baja";
            this.btn_elim.UseVisualStyleBackColor = false;
            this.btn_elim.Click += new System.EventHandler(this.btn_elim_Click);
            // 
            // btn_modify
            // 
            this.btn_modify.BackColor = System.Drawing.Color.Silver;
            this.btn_modify.Location = new System.Drawing.Point(37, 491);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(328, 29);
            this.btn_modify.TabIndex = 7;
            this.btn_modify.Text = "Editar";
            this.btn_modify.UseVisualStyleBackColor = false;
            this.btn_modify.Click += new System.EventHandler(this.btn_modify_Click);
            // 
            // btn_tarjeta
            // 
            this.btn_tarjeta.BackColor = System.Drawing.Color.Silver;
            this.btn_tarjeta.Location = new System.Drawing.Point(208, 526);
            this.btn_tarjeta.Name = "btn_tarjeta";
            this.btn_tarjeta.Size = new System.Drawing.Size(328, 31);
            this.btn_tarjeta.TabIndex = 8;
            this.btn_tarjeta.Text = "Enviar Actualización";
            this.btn_tarjeta.UseVisualStyleBackColor = false;
            this.btn_tarjeta.Click += new System.EventHandler(this.btn_tarjeta_Click);
            // 
            // text_RFID
            // 
            this.text_RFID.Location = new System.Drawing.Point(314, 156);
            this.text_RFID.Name = "text_RFID";
            this.text_RFID.Size = new System.Drawing.Size(149, 23);
            this.text_RFID.TabIndex = 9;
            this.text_RFID.TextChanged += new System.EventHandler(this.text_RFID_TextChanged);
            // 
            // lbl_RFID
            // 
            this.lbl_RFID.AutoSize = true;
            this.lbl_RFID.Font = new System.Drawing.Font("Forte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_RFID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_RFID.Location = new System.Drawing.Point(314, 128);
            this.lbl_RFID.Name = "lbl_RFID";
            this.lbl_RFID.Size = new System.Drawing.Size(36, 14);
            this.lbl_RFID.TabIndex = 10;
            this.lbl_RFID.Text = "RFID";
            // 
            // btn_añade_disp
            // 
            this.btn_añade_disp.BackColor = System.Drawing.Color.Silver;
            this.btn_añade_disp.Location = new System.Drawing.Point(409, 456);
            this.btn_añade_disp.Name = "btn_añade_disp";
            this.btn_añade_disp.Size = new System.Drawing.Size(241, 29);
            this.btn_añade_disp.TabIndex = 11;
            this.btn_añade_disp.Text = "Añade Dispositivo";
            this.btn_añade_disp.UseVisualStyleBackColor = false;
            this.btn_añade_disp.Click += new System.EventHandler(this.btn_añade_disp_Click);
            // 
            // btn_entradas
            // 
            this.btn_entradas.BackColor = System.Drawing.Color.Silver;
            this.btn_entradas.Location = new System.Drawing.Point(409, 491);
            this.btn_entradas.Name = "btn_entradas";
            this.btn_entradas.Size = new System.Drawing.Size(241, 29);
            this.btn_entradas.TabIndex = 12;
            this.btn_entradas.Text = "Ver historial de entradas";
            this.btn_entradas.UseVisualStyleBackColor = false;
            this.btn_entradas.Click += new System.EventHandler(this.btn_entradas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(887, 460);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 60);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(378, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tarj";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nº Tarjeta:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_entradas);
            this.Controls.Add(this.btn_añade_disp);
            this.Controls.Add(this.lbl_RFID);
            this.Controls.Add(this.text_RFID);
            this.Controls.Add(this.btn_tarjeta);
            this.Controls.Add(this.btn_modify);
            this.Controls.Add(this.btn_elim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_anPer);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Gestion de Puertas ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Button button1;
        private Button btn_anPer;
        public ListBox listBox1;
        private TextBox textBox1;
        private ListView listDisp;
        private Label label1;
        private Button btn_elim;
        private Button btn_modify;
        private Button btn_tarjeta;
        private TextBox text_RFID;
        private Label lbl_RFID;
        private Button btn_añade_disp;
        private Button btn_entradas;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
    }
}