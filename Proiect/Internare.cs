using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Proiect
{
    public partial class Internare : Form
    {
        public Internare()
        {
            InitializeComponent();
        }

        private void refreshGrid()
        {
            internareTableAdapter.Fill(dataSet1.Internare);
            internareContinutTableAdapter.Fill(dataSet1.InternareContinut);
        }

        private void filtreazaDetaliu()
        {
            try
            {
                internareContinutBindingSource.Filter = "IdInternare=" + txtIdInternare.Text;
            }
            catch { }
        }


        private void Internare_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Internare' table. You can move, or remove it, as needed.
            this.internareTableAdapter.Fill(this.dataSet1.Internare);
            // TODO: This line of code loads data into the 'dataSet1.Internare' table. You can move, or remove it, as needed.
            this.internareTableAdapter.Fill(this.dataSet1.Internare);
            refreshGrid();
            filtreazaDetaliu();

        }


        private void internareBindingSource_PositionChanged_1(object sender, EventArgs e)
        {
            filtreazaDetaliu();
        }

        private void btnInternareNoua_Click(object sender, EventArgs e)
        {
            FInternareAct f = new FInternareAct();
            f.completeazaTitlu("INTERNARE NOUA");
            f.ShowDialog();
            refreshGrid();

        }

        private void btnModificareInternare_Click(object sender, EventArgs e)
        {
            FInternareAct f = new FInternareAct();
            f.completeazaTitlu("MODIFICARE INTERNARE");
            f.bs1 = internareBindingSource;
            f.bs2 = internareContinutBindingSource;
            f.ShowDialog();
            refreshGrid();

        }

        private void btnStergeInternare_Click(object sender, EventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";

            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) return;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = internareTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            // Sterg continut comanda
            cmd.CommandText = "Delete From InternareContinut Where IdInternare = " + txtIdInternare.Text;

  

            con.Open();

            cmd.ExecuteNonQuery();

            // Sterg comanda
            cmd.CommandText = "Delete From Internare Where IdInternare = " + txtIdInternare.Text;

            cmd.ExecuteNonQuery();

            con.Close();

            // Refresh grid-uri
            refreshGrid();
            filtreazaDetaliu();

        }

        
    }
}
