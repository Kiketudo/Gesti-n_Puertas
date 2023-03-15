using Gestión_Puertas.Models.Data;
using Microsoft.Data.SqlClient;
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
    public partial class Form2 : Form
    {
        private bool usada = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NombreBox.BackColor= Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Acept_Click(object sender, EventArgs e)
        {
            if (NombreBox.Text.Length > 0)
            {
                //if (RFIDBox.Text == TarjetaBox.Text) {
                    using (EntitiesContext entities = new EntitiesContext())
                    {
                        BPersonas newpersona = new BPersonas();
                        newpersona.Nombre = NombreBox.Text;
                        newpersona.CodigoRfid = RFIDBox.Text;
                        newpersona.CodigoTarjeta = RFIDBox.Text;
                        newpersona.EsVisita = checkVisita.Checked;
                        newpersona.EsBaja = checkValAl.Checked;
                        var tarj = ExistTarj(RFIDBox.Text);
                        if (tarj != null)
                        {
                            newpersona.FoTarjeta = tarj.Id;
                        }
                        else if(usada){
                            usada=false;
                            return;
                        }else
                        {
                            tarj = CreaTarj(RFIDBox.Text);
                            if (tarj != null)
                            {
                                newpersona.FoTarjeta = tarj.Id;
                                tarj = entities.BTarjetasKimaldi.SingleOrDefault(b => b.Id == tarj.Id);
                                tarj.FlxUserId = Convert.ToInt16(tarj.Id);
                            }
                        }
                        entities.BPersonas.Add(newpersona);
                        try
                        {
                            entities.SaveChanges();
                            MessageBox.Show("Se añadió correctamente");
                            this.Close();
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                        {
                            //-2146232060
                            //
                            MessageBox.Show(ex.InnerException.Message, "Error al introducir cambios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        
                        //rehace la listbox
                        Form1 obj = (Form1)Application.OpenForms["Form1"];
                        obj.listBox1.Items.Clear();
                        foreach (BPersonas per in entities.BPersonas.OrderBy(BPersonas => BPersonas.Nombre))
                        {
                            obj.listBox1.Items.Add(per);
                            obj.listBox1.DisplayMember = "Nombre";
                        }
                    }

                //}
                /*else
                {
                    MessageBox.Show("Codigo RFID y codigo tarjeta no coinciden");
                }*/
            }
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

                                    DialogResult result = MessageBox.Show("La tarjeta ya está asignada a otra persona:\n" + p.Nombre + "\n ¿Desea continuar? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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

                            return tj;
                        }
                    }
            }
            return null;
        }
        private void btn_Mas_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Text == "Editar Usuario")
                {
                    return;
                }
            }
            var formPopup = new Form3();
            formPopup.Show(this);
        }
    }
}
