using Gestión_Puertas.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestión_Puertas
{
    public partial class Form6 : Form
    {
        BPersonas persona;
        public Form6(BPersonas persona)
        {
            InitializeComponent();
            this.persona = persona;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = "dd/MM/yyyy HH:mm:ss";
            using (EntitiesContext entities = new EntitiesContext())
            {
                using (EntitiesContext ent = new EntitiesContext())
                {
                    // Create a new ListView control.
                    //this.listDisp = new ListView();
                    this.listFich = new System.Windows.Forms.ListView();
                    //listFich.Bounds = new Rectangle(new Point(this.textBox1.Bounds.Right + 50, 20), new Size(this.Bounds.Width / 2, this.Bounds.Height - 100));

                    // Set the view to show details.
                    listFich.View = View.Details;
                    // Allow the user to edit item text.
                    listFich.LabelEdit = true;
                    // Allow the user to rearrange columns.
                    listFich.AllowColumnReorder = true;
                    // Display check boxes.
                    listFich.CheckBoxes = false;
                    // Select the item and subitems when selection is made.
                    listFich.FullRowSelect = true;
                    // Display grid lines.
                    listFich.GridLines = true;
                    // Sort the items in the list in ascending order.
                    listFich.Sorting = SortOrder.None;

                    // Create columns for the items and subitems.
                    // Width of -2 indicates auto-s
                    listFich.Columns.Add("Fecha", -2, HorizontalAlignment.Left);
                    listFich.Columns.Add("Dispositivo", -2, HorizontalAlignment.Left);
                    listFich.Columns.Add("Tarjeta", -2, HorizontalAlignment.Left);
                    ListViewItem item;
                    if (persona != null)
                    {
                        listFich.Bounds = new Rectangle(new Point(this.textBox1.Bounds.Right + 50, 20), new Size(this.Bounds.Width / 2, this.Bounds.Height - 100));
                        foreach (CpFichajes fi in entities.CpFichajes.Where(x => x.FoTrabajador == persona.Id).OrderByDescending(x=>x.FechaHoraEntrada).Take(500))
                        {
                            item = new ListViewItem(fi.FechaHoraEntrada.ToString());
                            if (fi.FoDispositivo != null)
                            {
                                var ndis = ent.CfgDispositivos.Find(fi.FoDispositivo).Nombre;
                                if (ndis != null)
                                {
                                    item.SubItems.Add(ndis);
                                }
                                else
                                {
                                    item.SubItems.Add("NULL");
                                }
                            }
                            else
                            {
                                item.SubItems.Add("NULL");
                            }
                            item.SubItems.Add(fi.Tarjeta);
                            listFich.Items.Add(item);
                        }
                    }
                    else
                    {
                        listFich.Bounds = new Rectangle(new Point(this.textBox1.Bounds.Right + 50, 20), new Size(this.Bounds.Width-255 , this.Bounds.Height - 100));
                        listFich.Columns.Add("Persona", -2, HorizontalAlignment.Left);
                        foreach (CpFichajes fi in entities.CpFichajes.OrderByDescending(x=>x.FechaHoraEntrada).Take(500))
                        {
                            item = new ListViewItem(fi.FechaHoraEntrada.ToString());
                            if (fi.FoDispositivo != null)
                            {
                                var ndis = ent.CfgDispositivos.Find(fi.FoDispositivo).Nombre;
                                if (ndis != null)
                                {
                                    item.SubItems.Add(ndis);
                                }
                                else
                                {
                                    item.SubItems.Add("NULL");
                                }
                            }
                            else
                            {
                                item.SubItems.Add("NULL");
                            }
                            item.SubItems.Add(fi.Tarjeta);
                            using (EntitiesContext enti = new EntitiesContext())
                            {
                                if (fi.FoTrabajador != null)
                                {
                                    var ntrab = item.SubItems.Add(enti.BPersonas.Find(fi.FoTrabajador).Nombre);
                                    if (ntrab != null)
                                    {
                                        item.SubItems.Add(ntrab);
                                    }
                                    else
                                    {
                                        item.SubItems.Add("NULL");
                                    }
                                }
                                else
                                {
                                    item.SubItems.Add("NULL");
                                }
                                
                            }
                            listFich.Items.Add(item);

                        }
                    }
                    this.Controls.Add(listFich);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = Convert.ToDateTime(textBox1.Text);
                this.Controls.Remove(listFich);
                using (EntitiesContext entities = new EntitiesContext())
                {
                    using (EntitiesContext ent = new EntitiesContext())
                    {
                        // Create a new ListView control.
                        //this.listDisp = new ListView();
                        this.listFich = new System.Windows.Forms.ListView();
                        //listFich.Bounds = new Rectangle(new Point(this.textBox1.Bounds.Right + 50, 20), new Size(this.Bounds.Width / 2, this.Bounds.Height - 100));

                        // Set the view to show details.
                        listFich.View = View.Details;
                        // Allow the user to edit item text.
                        listFich.LabelEdit = true;
                        // Allow the user to rearrange columns.
                        listFich.AllowColumnReorder = true;
                        // Display check boxes.
                        listFich.CheckBoxes = false;
                        // Select the item and subitems when selection is made.
                        listFich.FullRowSelect = true;
                        // Display grid lines.
                        listFich.GridLines = true;
                        // Sort the items in the list in ascending order.
                        listFich.Sorting = SortOrder.None;

                        // Create columns for the items and subitems.
                        // Width of -2 indicates auto-s
                        listFich.Columns.Add("Fecha", -2, HorizontalAlignment.Left);
                        listFich.Columns.Add("Dispositivo", -2, HorizontalAlignment.Left);
                        listFich.Columns.Add("Tarjeta", -2, HorizontalAlignment.Left);
                        ListViewItem item;
                        if (persona != null)
                        {
                            listFich.Bounds = new Rectangle(new Point(this.textBox1.Bounds.Right + 50, 20), new Size(this.Bounds.Width / 2, this.Bounds.Height - 100));
                            foreach (CpFichajes fi in entities.CpFichajes.Where(x => x.FoTrabajador == persona.Id && x.FechaHoraEntrada <= Convert.ToDateTime(textBox1.Text)).OrderByDescending(x => x.FechaHoraEntrada).Take(500))
                            {
                                item = new ListViewItem(fi.FechaHoraEntrada.ToString());
                                if (fi.FoDispositivo != null)
                                {
                                    var ndis = ent.CfgDispositivos.Find(fi.FoDispositivo).Nombre;
                                    if (ndis != null)
                                    {
                                        item.SubItems.Add(ndis);
                                    }
                                    else
                                    {
                                        item.SubItems.Add("NULL");
                                    }
                                }
                                else
                                {
                                    item.SubItems.Add("NULL");
                                }
                                item.SubItems.Add(fi.Tarjeta);
                                listFich.Items.Add(item);
                            }
                        }
                        else
                        {
                            listFich.Bounds = new Rectangle(new Point(this.textBox1.Bounds.Right + 50, 20), new Size(this.Bounds.Width-255, this.Bounds.Height - 100));
                            listFich.Columns.Add("Persona", -2, HorizontalAlignment.Left);
                            foreach (CpFichajes fi in entities.CpFichajes.Where(x => x.FechaHoraEntrada <= Convert.ToDateTime(textBox1.Text)).OrderByDescending(x => x.FechaHoraEntrada).Take(500))
                            {
                                item = new ListViewItem(fi.FechaHoraEntrada.ToString());
                                if (fi.FoDispositivo != null)
                                {
                                    var ndis = ent.CfgDispositivos.Find(fi.FoDispositivo).Nombre;
                                    if (ndis != null)
                                    {
                                        item.SubItems.Add(ndis);
                                    }
                                    else
                                    {
                                        item.SubItems.Add("NULL");
                                    }
                                }
                                else
                                {
                                    item.SubItems.Add("NULL");
                                }
                                item.SubItems.Add(fi.Tarjeta);
                                using (EntitiesContext enti = new EntitiesContext())
                                {
                                    if (fi.FoTrabajador != null)
                                    {
                                        var ntrab = item.SubItems.Add(enti.BPersonas.Find(fi.FoTrabajador).Nombre);
                                        if (ntrab != null)
                                        {
                                            item.SubItems.Add(ntrab);
                                        }
                                        else
                                        {
                                            item.SubItems.Add("NULL");
                                        }
                                    }
                                    else
                                    {
                                        item.SubItems.Add("NULL");
                                    }

                                }
                                listFich.Items.Add(item);

                            }
                        }
                        this.Controls.Add(listFich);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fecha Introducida incorrectamente","Error al buscar", MessageBoxButtons.OK);
            }
        }
    }
    
}
