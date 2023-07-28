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
    public partial class Servicii : Form
    {
        const int IdServici = 0;
        const int DenumireServiciIndex = 1;
        const int UMIndex = 2;
        const int TarifIndex = 3;




        public Servicii()
        {
            InitializeComponent();
        }


        private void config(bool v)
        {
            dataGridView1.AllowUserToAddRows = !v;
            dataGridView1.AllowUserToDeleteRows = !v;

            //Protectie coloane
            dataGridView1.Columns[DenumireServiciIndex].ReadOnly = v;
            dataGridView1.Columns[UMIndex].ReadOnly = v;
            dataGridView1.Columns[TarifIndex].ReadOnly = v;

            btnActualizare.Enabled = v;
            btnSalvare.Visible = !v;
            btnRenuntare.Visible = !v;
        }


        private void refresh()
        {
            serviciiTableAdapter.Fill(dataSet1.Servicii);

        }


        private Boolean test(DataGridView dataGridView1)
        {
            DataGridViewRow firstRow = dataGridView1.Rows[0];
            if (firstRow.Cells[0].Value != null)
            {
                string firstValue = firstRow.Cells[0].Value.ToString();
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader r;

                con.ConnectionString = serviciiTableAdapter.Connection.ConnectionString;
                cmd.Connection = con;
                
                cmd.CommandText = "Select DenumireServici From Servicii where DenumireServici=" + "'" + firstValue + "'";
                con.Open();
                r = cmd.ExecuteReader();
                if (r.Read())
                {
                    con.Close();
                    return false;
                }

            }
            else
                return false;
            return true;
        }

        private bool completareCampuri()
        {
            bool raspuns = true;
            foreach (DataRow r in dataSet1.Servicii)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                

                if (r["DenumireServici"] == DBNull.Value)
                {
                    MessageBox.Show("Completati DenumireServici la linia cu Id " + r["IdServici"]);
                    raspuns = false;
                }
            
                if (r["UM"] == DBNull.Value)
                {
                    MessageBox.Show("Completati UM la linia cu Id " + r["IdServici"]);
                    raspuns = false;
                }
                if (r["Tarif"] == DBNull.Value)
                {
                    MessageBox.Show("Completati Tarif la linia cu Id " + r["IdServici"]);
                    raspuns = false;
                }



            }
            return raspuns;
        }



        private void Servicii_Load(object sender, EventArgs e)
        {
            config(true);
            refresh();
            dataGridView1.Columns[IdServici].ReadOnly = true;

        }

      
        private void btnActualizare_Click(object sender, EventArgs e)
        {
            config(false);
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
           
            if (!completareCampuri()) return;
            if (!test(dataGridView1)) return;
            try
            {
                if(test(dataGridView1));
                serviciiTableAdapter.Update(dataSet1.Servicii);
                config(true);
                refresh();


            }
            catch (Exception exc)
            {
                string s = exc.Message;

                if (s.IndexOf("duplicate values") > 0)
                    MessageBox.Show("Inregistrare deja existenta !");
                else if (s.IndexOf("cannot be deleted") > 0)
                    MessageBox.Show("Ati sters inregistrari referite in alte tabele !");
            }

        }

        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            config(true);
            refresh();

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (btnRenuntare.Focused)
            {
                dataGridView1.CancelEdit();
                //A3
                config(true);
                refresh();

                return;
            }
            MessageBox.Show("Format eronat");

        }

    

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) e.Cancel = true;

        }

    }
}
