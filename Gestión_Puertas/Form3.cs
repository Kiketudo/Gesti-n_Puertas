using Gestión_Puertas.Models.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        private bool nuevo;
        private bool usada = false;
        public Form3(bool nuevo=true)
        {
            InitializeComponent();
            this.nuevo = nuevo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (!nuevo)
            {
                using (EntitiesContext entities = new EntitiesContext())
                {
                    BPersonas persona = Form1.personaActual;
                    if (persona != null)
                    {
                        text_equipo.Text = persona.FoEquipoTrabajo.ToString();
                        text_Perfil.Text = persona.FoPerfil.ToString();
                        textNombre.Text = persona.Nombre;
                        text_mostrar.Text = persona.MostrarComo;
                        text_login.Text = persona.Login;
                        text_psw.Text = persona.Password;
                        text_RFID.Text = persona.CodigoRfid;
                        text_DNI.Text = persona.Dni;
                        text_Empresa.Text = persona.FoEmpresa.ToString();
                        text_department.Text = persona.FoDepartamento.ToString();
                        text_grupoVisita.Text = persona.FoGrupoVisita.ToString();
                        text_categoria.Text = persona.FoCategoria.ToString();
                        text_email.Text = persona.Email;
                        text_zona.Text = persona.FoZona.ToString();
                        check_usr.Checked = persona.EsUsuario;
                        check_visita.Checked = persona.EsVisita;
                        check_res_dep.Checked = persona.EsResponsableDepartamento;
                        check_res_eq.Checked = persona.EsResponsableEquipoTrabajo;
                        check_baja.Checked = persona.EsBaja;
                        if (persona.PuedeValidarAlarma != null) { check_val_al.Checked = (bool)persona.PuedeValidarAlarma; } else { check_val_al.Checked = false; }
                        check_oculta.Checked = persona.EsOculta;
                        check_contrata.Checked = persona.EsContrata;
                        if (persona.EsVisibleEnPanelOperador != null) { check_visible.Checked = (bool)persona.EsVisibleEnPanelOperador; } else { check_visible.Checked = false; }
                    }
                }
            }
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_acept_Click(object sender, EventArgs e)
        {
            using (EntitiesContext entities = new EntitiesContext())
            {
                
                    BPersonas persona;
                    if (!nuevo)
                    {
                        persona = entities.BPersonas.SingleOrDefault(b => b.Id == Form1.personaActual.Id);
                    }
                    else
                    {
                        persona = new BPersonas();
                    }
                //BPersonas persona = Form1.personaActual;
                try
                {
                    if (text_equipo.Text.Length > 0)
                    {
                        persona.FoEquipoTrabajo = int.Parse(text_equipo.Text);
                    }
                    if (text_Perfil.Text.Length > 0)
                    {
                        persona.FoPerfil = int.Parse(text_Perfil.Text);
                    }
                    persona.Nombre = textNombre.Text;
                    persona.MostrarComo = text_mostrar.Text;
                    persona.Login = text_login.Text;
                    persona.Password = EncryptStringFromBytes_Aes(text_psw.Text);
                    persona.CodigoRfid = text_RFID.Text;
                    persona.CodigoTarjeta = text_RFID.Text;
                    persona.Dni = text_DNI.Text;
                    if (text_Empresa.Text.Length > 0)
                    {
                        persona.FoEmpresa = int.Parse(text_Empresa.Text);
                    }
                    if (text_department.Text.Length > 0)
                    {
                        persona.FoDepartamento = int.Parse(text_department.Text);
                    }
                    if (text_grupoVisita.Text.Length > 0)
                    {
                        persona.FoGrupoVisita = int.Parse(text_grupoVisita.Text);
                    }
                    if (text_categoria.Text.Length > 0)
                    {
                        persona.FoCategoria = int.Parse(text_categoria.Text);
                    }
                    persona.Email = text_email.Text;
                    if (text_zona.Text.Length > 0)
                    {
                        persona.FoZona = int.Parse(text_zona.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al introducir cambios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                persona.EsUsuario = check_usr.Checked;
                persona.EsVisita = check_visita.Checked;
                persona.EsResponsableDepartamento = check_res_dep.Checked;
                persona.EsResponsableEquipoTrabajo = check_res_eq.Checked;
                persona.PuedeValidarAlarma = check_val_al.Checked;
                persona.EsOculta = check_oculta.Checked;
                persona.EsContrata = check_contrata.Checked;
                persona.EsVisibleEnPanelOperador = check_visible.Checked;
                persona.EsBaja = check_baja.Checked;
                var tarj = ExistTarj(text_RFID.Text);
                if (tarj != null)
                {
                    persona.FoTarjeta = tarj.Id;
                }
                else if (usada) {
                    usada = false;
                    return;
                } else
                {
                    tarj = CreaTarj(text_RFID.Text);
                    if (tarj != null)
                    {
                        persona.FoTarjeta = tarj.Id;
                        tarj = entities.BTarjetasKimaldi.SingleOrDefault(b => b.Id == tarj.Id);
                        tarj.FlxUserId = Convert.ToInt16(tarj.Id);
                    }
                }
                if (nuevo)
                {
                    entities.BPersonas.Add(persona);
                    try
                    {
                        entities.SaveChanges();
                        MessageBox.Show("Se añadió correctamente");
                        this.Close();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                    {
                        MessageBox.Show(ex.InnerException.Message, "Error al introducir cambios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Form2 obj2 = (Form2)Application.OpenForms["Form2"];
                    obj2.Close();
                }
                else
                {
                    try
                    {
                        entities.SaveChanges();
                        MessageBox.Show("Se editó correctamente");
                        this.Close();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                    {
                        //-2146233088
                        MessageBox.Show(ex.InnerException.Message, "Error al introducir cambios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                Form1 obj = (Form1)Application.OpenForms["Form1"];
                obj.listBox1.Items.Clear();
                Form1.personaActual = persona;
                foreach (BPersonas per in entities.BPersonas.OrderBy(BPersonas => BPersonas.Nombre))
                {
                    obj.listBox1.Items.Add(per);
                    obj.listBox1.DisplayMember = "Nombre";
                }
                }
        }
        private BTarjetasKimaldi obtenTarjVac()
        {
            
            using (EntitiesContext ent = new EntitiesContext())
            {
                ArrayList tjId = new ArrayList(ent.BPersonas.Count());
                foreach (BPersonas p in ent.BPersonas)
                {
                    tjId.Add(p.FoTarjeta);
                }
                foreach (BTarjetasKimaldi tj in ent.BTarjetasKimaldi)
                {
                    if (!tjId.Contains(tj.Id))
                    {
                        return tj;
                    }
                }
                return null;
            }

        }
        private BTarjetasKimaldi ExistTarj(string RFID)
        {
            using (EntitiesContext ent = new EntitiesContext())
            {
                foreach (BTarjetasKimaldi tj in ent.BTarjetasKimaldi)
                    if (tj.CodigoRfid == RFID)
                    {

                        using (EntitiesContext enti = new EntitiesContext())
                        {
                            foreach (BPersonas p in enti.BPersonas)
                            {
                                if (p.CodigoRfid == RFID)
                                {
                                    if (nuevo)
                                    {
                                        DialogResult result = MessageBox.Show("La tarjeta ya está asignada a otra persona: \n"+p.Nombre+"\n ¿Desea continuar? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (result == DialogResult.Yes)
                                        {
                                            return tj;
                                        }
                                        else if (result == DialogResult.No)
                                        {
                                            usada = true;
                                            return null;
                                        }
                                    }
                                    else
                                    {
                                        if (!(p.Id==Form1.personaActual.Id))
                                        {
                                            DialogResult result = MessageBox.Show("La tarjeta ya está asignada a otra persona:\n"+p.Nombre+"\n ¿Desea continuar? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (result == DialogResult.Yes)
                                            {
                                                return tj;
                                            }
                                            else if (result == DialogResult.No)
                                            {
                                                usada = true;
                                                return null;
                                            }
                                        }
                                    }
                                }
                            }

                            return tj;
                        }
                    }
            }
            return null;
        }
        private BTarjetasKimaldi CreaTarj(string RFID) 
        {
            using (EntitiesContext entities = new EntitiesContext())

            {
                BTarjetasKimaldi tarjeta = new BTarjetasKimaldi();
                tarjeta.CodigoRfid = RFID;
                entities.BTarjetasKimaldi.Add(tarjeta);
                try
                {
                    entities.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    return null;
                }
                return tarjeta;
            }
        }
        public static string EncryptStringFromBytes_Aes(string Texto)
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
                buff = ASCIIEncoding.ASCII.GetBytes(Texto);
                // Create an Aes object 
                // with the specified key and IV. 
                plaintext = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            return plaintext;
        }
    }
}
