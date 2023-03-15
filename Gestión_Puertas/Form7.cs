using Gestión_Puertas.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestión_Puertas
{
    public partial class Form7 : Form
    {
        public static bool correct= false;
        public Form7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EntitiesContext entities = new EntitiesContext())
            {
                foreach (BPersonas p in entities.BPersonas)
                {
                    if (p.Login == textBox1.Text && p.Password != null) 
                    {
                        if (DecryptStringFromBytes_Aes(p.Password) == textBox2.Text || p.Password == textBox2.Text)
                        {
                            if (!p.EsBaja && p.EsUsuario)
                            {                                   
                                correct= true;
                                Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Usuario no permitido", "Login error", MessageBoxButtons.OK);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("La contraseña no es correcta para este usuario", "Login error", MessageBoxButtons.OK);
                            return;
                        }
                    }
                  
                }
                MessageBox.Show("El usuario introducido no existe o no tiene contraseña", "Login error", MessageBoxButtons.OK);
                return;

            }
        }
       
        private void Form7_KeyPress_1(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                using (EntitiesContext entities = new EntitiesContext())
                {
                    foreach (BPersonas p in entities.BPersonas)
                    {
                        if (p.Login == textBox1.Text && p.Password != null)
                        {
                            if (DecryptStringFromBytes_Aes(p.Password) == textBox2.Text || p.Password == textBox2.Text)
                            {
                                if (!p.EsBaja && p.EsUsuario)
                                {
                                    correct = true;
                                    Close();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no permitido", "Login error", MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("La contraseña no es correcta para este usuario", "Login error", MessageBoxButtons.OK);
                                return;
                            }
                        }

                    }
                    MessageBox.Show("El usuario introducido no existe o no tiene contraseña", "Login error", MessageBoxButtons.OK);
                    return;

                }
            }
        }
        public static string DecryptStringFromBytes_Aes(string Texto)
        {
            string plaintext = null;
            try
            {
                // Declare the string used to hold 
                // the decrypted text. 
                
                string psw;
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hasmd5;
                byte[] pwdhas;
                byte[] buff;

                psw = "secretpassword_ITCL!";
                hasmd5 = new MD5CryptoServiceProvider();
                pwdhas = hasmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(psw));

                des = new TripleDESCryptoServiceProvider();
                des.Key = pwdhas;
                des.Mode = CipherMode.ECB;
                buff = Convert.FromBase64String(Texto);
                // Create an Aes object 
                // with the specified key and IV. 
                plaintext = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            return plaintext;
        }
    }
}
