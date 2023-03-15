using Gestión_Puertas.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestión_Puertas
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void ComboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = "192.168.15.?";
            using (EntitiesContext entities = new EntitiesContext())
            {
                foreach (CfgTipoDispositivo tp in entities.CfgTipoDispositivo)
                {
                    ComboTipos.Items.Add(tp);
                    ComboTipos.DisplayMember = "Nombre";
                    ComboTipos.ValueMember = "Id";
                }             

            }
            using (EntitiesContext entities = new EntitiesContext())
            {
                foreach (BZonas zn in entities.BZonas)
                {
                    comboZona.Items.Add(zn);
                    comboZona.DisplayMember = "Nombre";
                    comboZona.ValueMember = "Id";
                }
            }
        }

        private void btn_Acp_Click(object sender, EventArgs e)
        {
            using (EntitiesContext entities = new EntitiesContext())
            {
                if (textBox2.Text.Length > 0)
                {
                    try
                    {
                        CfgDispositivos disp = new CfgDispositivos();
                        disp.Nombre = textBox2.Text;
                        disp.Ip = textBox1.Text;
                        disp.FoZona = comboZona.SelectedIndex + 1;
                        disp.FoTipoDispositivo = entities.CfgTipoDispositivo.Where(x => x.Nombre == ComboTipos.Text).ToArray()[0].Id;
                        entities.CfgDispositivos.Add(disp);
                        entities.SaveChanges();
                        MessageBox.Show("Dispositivo añadido correctamente", "Info", MessageBoxButtons.OK);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al introducir cambios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void Btn_Cnl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }
    }
}
