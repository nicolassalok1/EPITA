using MyAirport.Pim.Entities;
using MyAirport.Pim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.FormIhm
{
    public partial class ClientPim : Form
    {
        public ClientPim()
        {
            InitializeComponent();
            this.PimStateChanged += PIM_PimStateChanged;
        }

        private PimState state = PimState.Deconnecter;
        private PimState State
        {
            get { return this.state; }
            set { OnPimStateChanged(value); }
        }

        public event PimStateEventHandler PimStateChanged;
        public delegate void PimStateEventHandler(object sender, PimState state);

        private void OnPimStateChanged(PimState newState)
        {
            if (newState != this.state)
            {
                this.state = newState;
                if (this.PimStateChanged != null)
                {
                    PimStateChanged(this, this.state);
                }
            }
        }
        
        void PIM_PimStateChanged(object sender, PimState state)
        {
            MessageBox.Show("StateChanged");
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                
                var bagageList = Factory.Model.GetBagageIata(textBox7.Text);
              
                BagageDefinition bagage2 = bagageList[0];

                this.textBox3.Text = bagage2.IdBagage.ToString();
                this.textBox3.Enabled = false;
                this.textBox1.Text = bagage2.Prioritaire.ToString();
                this.textBox1.Enabled = false;
                this.textBox6.Text = bagage2.Compagnie;
                this.textBox6.Enabled = false;
                this.textBox2.Text = bagage2.Itineraire;
                this.textBox2.Enabled = false;
                this.textBox3.Text = bagage2.DateVol.ToString();
                this.textBox3.Enabled = false;
                this.textBox5.Text = bagage2.Ligne.ToString();
                this.textBox5.Enabled = false;
                this.checkBox1.Checked = bagage2.EnContinuation;
                this.checkBox1.Enabled = false;
                this.checkBox2.Checked = bagage2.Rush;
                this.checkBox2.Enabled = false;
            }
           /* catch (ApplicationException appEx)
            {
                this.textBox1.Text = this.textBox2.Text = this.textBox3.Text = this.textBox5.Text = this.textBox6.Text = this.textBox7.Text = "";
                this.checkBox1.Checked = this.checkBox2.Checked = false;
                this.textBox1.Enabled = this.textBox2.Enabled = this.textBox3.Enabled = this.textBox5.Enabled = this.textBox6.Enabled =
                     this.textBox7.Enabled = this.checkBox1.Enabled = this.checkBox2.Enabled = true;
            }*/
            catch
            {
                MessageBox.Show("Une erreur s’est produite dans le traitement de votre demande.\nMerci de bien vouloir re tester ultérieurement ou de contacter votre administrateur.", "Erreur dans le traitement de votre demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void réinitialiserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox2.Text = this.textBox3.Text = this.textBox5.Text = this.textBox6.Text = this.textBox7.Text = "";
            this.checkBox1.Checked = this.checkBox2.Checked = false;
            this.textBox1.Enabled = this.textBox2.Enabled = this.textBox3.Enabled = this.textBox5.Enabled = this.textBox6.Enabled =
                 this.textBox7.Enabled = this.checkBox1.Enabled = this.checkBox2.Enabled = true;
        }
    }
}
