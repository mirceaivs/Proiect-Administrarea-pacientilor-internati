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
    public partial class FInternareAct : Form
    {
        private OleDbConnection con = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbDataReader rdr;
        private int idIntern;
        public BindingSource bs1;
        public BindingSource bs2;



        public FInternareAct()
        {
            InitializeComponent();
        }

        public void completeazaTitlu(String titlu)
        {
            lblOp.Text = titlu;
        }

        private void completeazaInternarea()
        {
           
            DataRowView current = (DataRowView)bs1.Current;

            idIntern = (int)current["IdInternare"];
            txtNrInternare.Text = Convert.ToString(current["NrInternare"]);

            cmbPacient.Text = current["NumePacient"].ToString();
            txtTotal.Text = current["Total"].ToString();


            dateTimePicker1.Value = Convert.ToDateTime(current["DataInternare"]);
            dateTimePicker2.Value = Convert.ToDateTime(current["DataExternare"]);

            bs2.MoveFirst();

            dataSet1.InternareContinutManevra.Clear();


            for (int i = 1; i <= bs2.Count; i++)
            {
                current = (DataRowView)bs2.Current;

                DataSet1.InternareContinutManevraRow r = dataSet1.InternareContinutManevra.NewInternareContinutManevraRow();
                r.NrCrt = Convert.ToInt16(current["NrCrt"]);
                r.DenumireServici = Convert.ToString(current["DenumireServici"]);
                r.UM = Convert.ToString(current["UM"]);
                r.Tarif = Convert.ToDecimal(current["Tarif"]);
                r.Cantitate = Convert.ToDecimal(current["Cantitate"]);
                r.IdServici = Convert.ToInt32(current["IdServici"]);
                r.Valoare = Convert.ToDecimal(current["Valoare"]);

                dataSet1.InternareContinutManevra.Rows.Add(r);
                bs2.MoveNext();
            }
        }


        private void A1()
        {
            //Incarcare DataTable Servicii
            serviciiTableAdapter.Fill(dataSet1.Servicii);
            //Incarcare DataTable Pacienti
            pacientiTableAdapter.Fill(dataSet1.Pacienti);

            // Protectie la modificare
            txtNrInternare.ReadOnly = true;
            txtTotal.ReadOnly = true;
            nrCrtDataGridViewTextBoxColumn.ReadOnly = true;
            uMDataGridViewTextBoxColumn.ReadOnly = true;
            tarifDataGridViewTextBoxColumn.ReadOnly = true;
            idServiciDataGridViewTextBoxColumn.ReadOnly = true;


            if (lblOp.Text == "MODIFICARE INTERNARE") completeazaInternarea();
            else if (lblOp.Text == "INTERNARE NOUA") cmbPacient.SelectedIndex = -1;

        }

        private void A2()
        {
            if (!validareCampuriObligatorii()) return;
            if (lblOp.Text == "MODIFICARE INTERNARE")
            {
                modificaInregistrare();
                stergeContinut();
                adaugaInregistrariInternariContinut();
                this.Close();
            }
            else if (lblOp.Text == "INTERNARE NOUA")
            {
                generez_nr_cda();
                adaugaInregistrareInternare();
                cautaInregistrare();
                adaugaInregistrariInternariContinut();
                golireCampuri();
            }
        }

        private void A3()
        {
            // Generare NrCrt
            DataRowView current = (DataRowView)internareContinutManevraBindingSource.Current;
            try { current["NrCrt"] = internareContinutManevraBindingSource.Position + 1; }
            catch { }
        }

        private void A4()
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    DataRowView current = (DataRowView)serviciiBindingSource.Current;
                    dataGridView1.CurrentRow.Cells[2].Value = current["UM"];
                    dataGridView1.CurrentRow.Cells[3].Value = current["Tarif"];
                    dataGridView1.CurrentRow.Cells[6].Value = current["IdServici"];
                    
                    calcTotal();
                }
                if (dataGridView1.CurrentCell.ColumnIndex == 4)
                {
                    internareContinutManevraBindingSource.EndEdit();
                    calcTotal();
                }
            }
            catch { }
        }

        private void A5(DataGridViewRowCancelEventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) e.Cancel = true;
        }





        private void FInternareAct_Load(object sender, EventArgs e)
        {
            A1();
        }

        private void internareContinutManevraBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            A3();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            A4();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            A5(e);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Format ernoat");
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            calcTotal();
        }

        private void btnConfirmare_Click(object sender, EventArgs e)
        {
            A2();
        }

        private void calcTotal()
        {
            decimal t = 0;
            foreach (DataRow r in dataSet1.InternareContinutManevra)
            {
                if (r["Valoare"] != DBNull.Value)
                    t += (decimal)r["Valoare"];
            }
            txtTotal.Text = Convert.ToString(t);
        }


        private void generez_nr_cda()
        {
            con.ConnectionString = serviciiTableAdapter.Connection.ConnectionString;
            cmd.Connection = con;
            cmd.CommandText = "SELECT Max(Internare.NrInternare) AS NrMax FROM Internare";
            con.Open();
            rdr = cmd.ExecuteReader();
            rdr.Read();
            txtNrInternare.Text = Convert.ToString(rdr.GetInt32(0) + 1);
            rdr.Close();
            con.Close();
        }

        private bool validareCampuriObligatorii()
        {
            //Validare de completare obligatorie campul Client
            if (cmbPacient.Text == "")
            {
                MessageBox.Show("Completati Pacient !");
                cmbPacient.Focus();
                return false;
            }
            // Validare completare continut
            if (internareContinutManevraBindingSource.Count == 0)
            {
                MessageBox.Show("Completati continut internare !");
                dataGridView1.Focus();
                return false;
            }
            return true;
        }


        //CRUD

        private void adaugaInregistrareInternare()
        {
            string listaCampuri;
            string listaValori;
            DateTime d = dateTimePicker1.Value;
            DateTime d1 = dateTimePicker2.Value;

            listaCampuri = "NrInternare, DataInternare, DataExternare, IdPacient, Sectie, Diagnostic, Total";
            listaValori = txtNrInternare.Text +
                          ",#" + Convert.ToString(d.Month) + "/"
                               + Convert.ToString(d.Day) + "/"
                               + Convert.ToString(d.Year) + "#,"
                               + "#" + Convert.ToString(d1.Month) + "/"
                               + Convert.ToString(d1.Day) + "/"
                               + Convert.ToString(d1.Year) + "#,"
                               + cmbPacient.SelectedValue+","
                               +"'"+txtSectie.Text+"','"
                               + txtDiagnostic.Text + "',"
                               + txtTotal.Text;

            cmd.CommandText = "Insert into Internare(" + listaCampuri + ") " +
                              "Select " + listaValori;


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void cautaInregistrare()
        {
            cmd.CommandText = "SELECT IdInternare From Internare Where NrInternare = " + txtNrInternare.Text;

            con.Open();
            rdr = cmd.ExecuteReader();
            rdr.Read();

            idIntern = rdr.GetInt32(0);
            rdr.Close();
            con.Close();
        }

        private void adaugaInregistrariInternariContinut()
        {
            string listaCampuri = "IdInternare, Nrc, IdServici, Cantitate, Tarif";
            string listaValori;

            con.Open();
            foreach (DataRow r in dataSet1.InternareContinutManevra)
            {
                listaValori = idIntern + "," + r["NrCrt"] + "," + r["IdServici"] + "," + r["Cantitate"] + "," + r["Tarif"];

                cmd.CommandText = "Insert into InternareContinut(" + listaCampuri + ") " + "Select " + listaValori;

  
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private void golireCampuri()
        {
            txtNrInternare.Text = "";
            cmbPacient.SelectedIndex = -1;
            txtTotal.Text = "";
            dataSet1.InternareContinutManevra.Clear();
        }

        private void modificaInregistrare()
        {
            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = dateTimePicker2.Value;

            con.ConnectionString = serviciiTableAdapter.Connection.ConnectionString;
            cmd.Connection = con;

            string clauzaWhere = " Where IdInternare = " + idIntern;

            string clauzaSet = "Set DataInternare = #" + d1.Month + "/"
                               + d1.Day + "/"
                               + d1.Year + "#,"
                               + "DataExternare = #" +d2.Month + "/"
                               + d2.Day + "/"
                               + d2.Year + "#,"
                               + "IdPacient = " + cmbPacient.SelectedValue
                               + ",Sectie = '" + txtSectie.Text + "',Diagnostic = '"
                               + txtDiagnostic.Text + "'";

            cmd.CommandText = "Update Internare " + clauzaSet + clauzaWhere;

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void stergeContinut()
        {
            cmd.CommandText = "Delete from InternareContinut Where IdInternare = " + idIntern;

            con.Open();

 

            cmd.ExecuteNonQuery();

            con.Close();
        }

    }
}
