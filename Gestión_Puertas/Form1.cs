using Gestión_Puertas.Models.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Gestión_Puertas
{
    public partial class Form1 : Form
    {
        Dictionary<int, IPersonasAccesos> PersonaAccesoId;
        public static BPersonas personaActual;
        List<int> DispositivosActualizar = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (EntitiesContext entities = new EntitiesContext())
            {
                if (listDisp!=null&& personaActual!=null) {
                    Cambios(PersonaAccesoId, personaActual);
                    MessageBox.Show("Se cambió correctamente");
                }
                else
                {
                    MessageBox.Show("Seleccione usuario");
                }
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            //listBox1.Bounds=new Rectangle( new Point( Left+50,Top+20), new Size(this.Bounds.Width / 3, this.Bounds.Height - 100)) ;
            using (EntitiesContext entities = new EntitiesContext())
            {
                foreach(BPersonas per in entities.BPersonas.OrderBy(BPersonas=> BPersonas.Nombre)){
                    listBox1.Items.Add(per);
                    listBox1.DisplayMember = "Nombre";
                }/*
                listBox1.DataSource = entities.BPersonas.ToList();
                listBox1.DisplayMember= "Nombre";
                listBox1.ValueMember = "Id";*/
            }
            CreateMyListView(null);
            this.Controls.Add(listDisp);
            label2.Text = "ninguna";
        }

        
        private void CreateMyListView(object Person)
        {

            using (EntitiesContext entities = new EntitiesContext())
            {
                // Create a new ListView control.
                //this.listDisp = new ListView();
                this.listDisp = new System.Windows.Forms.ListView();
                listDisp.Bounds = new Rectangle(new Point(this.listBox1.Bounds.Right + 220, 20), new Size(this.Bounds.Width / 3,425));

                // Set the view to show details.
                listDisp.View = View.Details;
                // Allow the user to edit item text.
                listDisp.LabelEdit = true;
                // Allow the user to rearrange columns.
                listDisp.AllowColumnReorder = true;
                // Display check boxes.
                listDisp.CheckBoxes = true;
                // Select the item and subitems when selection is made.
                listDisp.FullRowSelect = true;
                // Display grid lines.
                listDisp.GridLines = true;
                // Sort the items in the list in ascending order.
                listDisp.Sorting = SortOrder.Ascending;

                // Create columns for the items and subitems.
                // Width of -2 indicates auto-s
                listDisp.Columns.Add("Nombre", -2, HorizontalAlignment.Left);
                listDisp.Columns.Add("ID", -2, HorizontalAlignment.Left);
                listDisp.Columns.Add("IP", -2, HorizontalAlignment.Center);

                PersonaAccesoId = new Dictionary<int, IPersonasAccesos>();// <fo_disp,Id>
                List<int> listIdDisp = new List<int>();
                List<int> nullID = new List<int>();
                ArrayList dispositivosPersona = new ArrayList(20);
                List<CfgDispositivos> lst = (from d in entities.CfgDispositivos
                                             join t in entities.CfgTipoDispositivo on d.FoTipoDispositivo equals t.Id
                                             where (t.EsKretaAcceso || t.EsFlexyAcceso) && !d.FechaBaja.HasValue
                                             select d).ToList();
                if (Person != null)
                {
                    BPersonas Persona = (BPersonas)Person;
                    //ListViewItem[] items = new ListViewItem[entities.CfgDispositivos.ToArray().Length];// reducir O(n) 
                    ListViewItem item;
                    
                    foreach (IPersonasAccesos b in entities.IPersonasAccesos)

                        if (b.FoPersona == Persona.Id)
                        {
                            listIdDisp.Add(b.FoDispositivo);
                            PersonaAccesoId.Add(b.FoDispositivo, b);
                        }
                    foreach (int a in listIdDisp)
                    {

                        dispositivosPersona.Add(entities.CfgDispositivos.Find(a)); // es not null


                    }
                    //entities.CfgDispositivos.Where(x => x.CfgTipoDispositivo);

                    foreach (CfgDispositivos dis in lst)
                    {
                        bool contiene = false;
                        if (dispositivosPersona.Contains(dis))
                        {
                            contiene = true;
                        }
                        item = new ListViewItem(dis.Nombre);
                        item.Checked = contiene;
                        item.SubItems.Add(dis.Id.ToString());
                        item.SubItems.Add(dis.Ip);
                        listDisp.Items.Add(item);
                    }
                }
                else {
                    ListViewItem item;
                    foreach (CfgDispositivos dis in lst)
                    {
                        item = new ListViewItem(dis.Nombre);
                        item.Checked = false;
                        item.SubItems.Add(dis.Id.ToString());
                        item.SubItems.Add(dis.Ip);
                        listDisp.Items.Add(item);
                    }
                }


                



            }
        }




        private void btn_show_Click_1(object sender, EventArgs e)
        {
            for(int i=0; i < Application.OpenForms.Count;i++ )
            {
                if (Application.OpenForms[i].Text== "Añadir Usuario")
                {
                    return;
                }
            }
                var formPopup = new Form2();
                formPopup.Show(this);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            if (this.listDisp != null)
            {
                //this.listDisp.Items.Clear();
                //this.listDisp.Clear();
                this.Controls.Remove(listDisp);
            }
            personaActual = (BPersonas)listbox.SelectedItem;
            if (personaActual != null) {
                CreateMyListView(listbox.SelectedItem);
                this.Controls.Add(listDisp);
                label2.Text = personaActual.FoTarjeta.ToString();
            }
            

            //MessageBox.Show(listbox.SelectedItem.ToString());
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Cambios(Dictionary<int, IPersonasAccesos> PersonaAccesoId , BPersonas Persona)
        {
            using (EntitiesContext entities = new EntitiesContext())
            {
                List<string> dispositivopersonaActualiz = new List<string>();
                //BPersonas Persona = new BPersonas();
                foreach (ListViewItem it in this.listDisp.Items)
                {
                    int id = int.Parse(it.SubItems[1].Text);
                    if (it.Checked == true)
                    {
                        if (!PersonaAccesoId.ContainsKey(id))
                        {
                            IPersonasAccesos newAcc = new IPersonasAccesos();
                            //newAcc.Id = it.Text.GetHashCode() * Persona.Id.GetHashCode();
                            newAcc.FoPersona = Persona.Id;
                            newAcc.FoDispositivo = id;
                            newAcc.TieneAcceso = true;
                            entities.IPersonasAccesos.Add(newAcc);
                            entities.SaveChanges();
                            PersonaAccesoId[id] = newAcc;
                            if (!DispositivosActualizar.Contains(id))
                            {
                                DispositivosActualizar.Add(id);
                            }
                        }
                    }
                    else if (it.Checked == false)
                    {
                        if (PersonaAccesoId.ContainsKey(id))
                        {
                            IPersonasAccesos value = PersonaAccesoId[id];
                            entities.IPersonasAccesos.Remove(value);
                            entities.SaveChanges();
                            PersonaAccesoId.Remove(id);
                            if (!DispositivosActualizar.Contains(id))
                            {
                                DispositivosActualizar.Add(id);
                            }

                        }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            using (EntitiesContext entities = new EntitiesContext())
            {
                foreach (BPersonas per in entities.BPersonas)
                {
                    if (per.Nombre.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        listBox1.Items.Add(per);
                        listBox1.DisplayMember = "Nombre";
                    }
                }
            }
        }

        private void btn_elim_Click(object sender, EventArgs e)
        {
            if (personaActual != null)
            {
                using (EntitiesContext entities = new EntitiesContext())
                {
                    foreach (ListViewItem it in this.listDisp.Items)
                    {
                        int id = int.Parse(it.SubItems[1].Text);
                        //int id = str;
                        if (PersonaAccesoId.ContainsKey(id))
                        {
                            IPersonasAccesos value = PersonaAccesoId[id];
                            entities.IPersonasAccesos.Remove(value);
                            PersonaAccesoId.Remove(id);
                            if (!DispositivosActualizar.Contains(id))
                            {
                                DispositivosActualizar.Add(id);
                            }
                        }
                    }

                    var persona = entities.BPersonas.SingleOrDefault(b => b.Id == personaActual.Id);
                    persona.EsBaja = true;
                    persona.FoTarjeta = 92;
                    persona.CodigoRfid = "0";
                    persona.CodigoTarjeta= "0"; 
                    string message = "Seguro que desea dar de baja a este usuario?";
                    string title = "Baja Usuario";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message,title, buttons);
                    if (result == DialogResult.No)
                    {
                        
                    }
                    else if (result == DialogResult.Yes) {
                        entities.SaveChanges();
                        listBox1.Items.Clear();
                        foreach (BPersonas per in entities.BPersonas.OrderBy(BPersonas => BPersonas.Nombre))
                        {
                            listBox1.Items.Add(per);
                            listBox1.DisplayMember = "Nombre";
                        }
                    }                    
                }
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (personaActual != null)
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i].Text == "Editar Usuario")
                    {
                        return;
                    }
                }
                var formPopup = new Form3(false);
                formPopup.Show(this);
            }
        }

        private void btn_tarjeta_Click(object sender, EventArgs e)
        {
            using (EntitiesContext entities = new EntitiesContext())
             
            {
                if (personaActual != null)
                {
                    foreach (int i in DispositivosActualizar)
                    {
                        var disp = entities.CfgDispositivos.SingleOrDefault(b => b.Id == i);
                        disp.SolicitudActualizacion = true;


                    }
                    DispositivosActualizar.Clear();
                    entities.SaveChanges();
                    MessageBox.Show("Ordenes de actualización enviadas");
                }
                else
                {
                    foreach( ListViewItem item in this.listDisp.Items)
                    {
                        if (item.Checked)
                        {
                            var disp = entities.CfgDispositivos.SingleOrDefault(b => b.Id == int.Parse(item.SubItems[1].Text));
                            disp.SolicitudActualizacion = true;
                        }
                    }
                    entities.SaveChanges();
                    MessageBox.Show("Ordenes de actualización enviadas");
                }
            }
        }

        private void text_RFID_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            using (EntitiesContext entities = new EntitiesContext())
            {
                foreach (BPersonas per in entities.BPersonas)
                {
                    if (per.CodigoRfid == text_RFID.Text)
                    {
                        listBox1.Items.Add(per);
                        listBox1.DisplayMember = "Nombre";
                    }
                }
            }
        }

        private void btn_añade_disp_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Text == "Añadir Dispositivo")
                {
                    return;
                }
            }
            var formPopup = new Form5();
            formPopup.Show(this);
        }

        private void btn_entradas_Click(object sender, EventArgs e)
        {
            var formPopup = new Form6(personaActual);
                formPopup.Show(this);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            personaActual = null;
            listBox1.Items.Clear();
            using (EntitiesContext entities = new EntitiesContext())
            {
                foreach (BPersonas per in entities.BPersonas.OrderBy(BPersonas => BPersonas.Nombre))
                {
                    listBox1.Items.Add(per);
                    listBox1.DisplayMember = "Nombre";
                }
            }
            if (this.listDisp != null)
            {
                //this.listDisp.Items.Clear();
                //this.listDisp.Clear();
                this.Controls.Remove(listDisp);
            }
            CreateMyListView(null);
            this.Controls.Add(listDisp);
            label2.Text = "ninguna";
        }
    }
}