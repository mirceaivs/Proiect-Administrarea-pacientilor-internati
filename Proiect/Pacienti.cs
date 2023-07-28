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
    public partial class Pacienti : Form
    {
        public Pacienti()
        {
            InitializeComponent();
        }

        private void Pacienti_Load(object sender, EventArgs e)
        {
            A1();

        }

        private void A1()
        {

            //Umple cu date obiectele DataTable: Persoane, Localitati (din DataSet):
            pacientiTableAdapter.Fill(dataSet1.Pacienti);

            //Configurare PB
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            //Protectie grid 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            //Protectie txtIdPersoana
            txtIdPacient.ReadOnly = true;

            A3();
        }

        private void A2()
        {
            //Configurare butoane
            configureazaButoane(false);

            //Dezlegare controale Panel
            legareControale(false);

            //Ridicare protectie controale Panel
            protectiePanel(false);

            //Modifcare lblOp
            lblOp.Text = "ADAUGARE";

            //Pozitionare cursor pe primul camp
            txtNumePacient.Focus();

            // Golire campuri
            golireCampuri();
        }


        private void A3()
        {
            //Initializare lblOp
            lblOp.Text = "";

            //Çonfigurare(butoane)
            configureazaButoane(true);

            //Protectie componente Panel
            protectiePanel(true);

            //Legare controale
            legareControale(true);
        }

        private void A4()
        {
            if (lblOp.Text == "ADAUGARE")
            {
                if (!validareCampuriObligatorii()) return;

                adauga_inregistrare();

                golireCampuri();

                //Pune cursor pe primul camp
                txtNumePacient.Focus();
                refresh_grid(pacientiBindingSource.Position);
            }
            else if (lblOp.Text == "MODIFICARE")
            {
                modifica_inregistrare();
                refresh_grid(pacientiBindingSource.Position);
                A3();
            }
            else
                MessageBox.Show("Operatie actualizare neefectuata");
        }


        private void A5(TextBox txtB)
        {
 
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            if (lblOp.Text == "") return;
            if (txtB.Text == "") return;
            if (btnRenuntare.Focused) return;

            con.ConnectionString = pacientiTableAdapter.Connection.ConnectionString;
            cmd.Connection = con;

            if (lblOp.Text == "ADAUGARE")
            {
                cmd.CommandText = "Select NumePacient From Pacienti where CNP=" +"'"+ txtCNP.Text+"'";
                con.Open();
                r = cmd.ExecuteReader();
                if (r.Read())
                {
                    MessageBox.Show("Datele sunt  deja existente");
                    txtCNP.Focus();
                }
                con.Close();

              
            }

            else if (lblOp.Text == "MODIFICARE")
            {
                cmd.CommandText = "Select NumePacient From Pacienti where CNP=" + txtCNP.Text +
                                  " and IdPacient  <> " + txtIdPacient.Text;
                con.Open();
                r = cmd.ExecuteReader();
                if (r.Read())
                {
                    MessageBox.Show("Cod CNP deja existent");
                    txtCNP.Focus();
                }
                con.Close();

                cmd.CommandText = "Select NumePacient From Pacienti where NrTelefon=" + txtNrTelefon.Text +
                                  " and IdPacient  <> " + txtIdPacient.Text;
                con.Open();
                r = cmd.ExecuteReader();
                if (r.Read())
                {
                    MessageBox.Show("Nr Telefon deja existent");
                    txtCNP.Focus();
                }
                con.Close();
            }
        }


        private void A6()
        {
            if (lblOp.Text == "")
                return;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSpPoza.Text = openFileDialog1.FileName;
                pb.ImageLocation = txtSpPoza.Text;
            }
        }


        private void A7()
        {
            //Configurare butoane
            configureazaButoane(false);

            //Dezlegare controale Panel
            legareControale(false);

            //Ridicare protectie controale Panel
            protectiePanel(false);

            //Modifcare lblOp
            lblOp.Text = "MODIFICARE";

            //Pozitionare cursor pe primul camp
            txtNumePacient.Focus();
        }



        private void A8()
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            con.ConnectionString = pacientiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            cmd.CommandText = "Select IdPacient From Internare where IdPacient=" + txtIdPacient.Text;
            con.Open();
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                MessageBox.Show("Pacient referit in tabela Internare! Nu se poate sterge!");
                con.Close();
                return;
            }
            con.Close();

            cmd.CommandText = "Delete From Pacienti Where IdPacient = " + txtIdPacient.Text;



            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            refresh_grid(pacientiBindingSource.Position);

        }


        private void configureazaButoane(bool v)
        {
            btnRenuntare.Visible = !v;
            btnConfirmare.Visible = !v;

            btnAdaugare.Enabled = v;
            btnModificare.Enabled = v;
            btnStergere.Enabled = v;
        }


        private void legareControale(bool v)
        {
            if (v)
            {
                txtNumePacient.DataBindings.Add("Text", pacientiBindingSource, "NumePacient");
                txtCNP.DataBindings.Add("Text", pacientiBindingSource, "CNP");
                txtNrTelefon.DataBindings.Add("Text", pacientiBindingSource, "NrTelefon");
                txtAdresa.DataBindings.Add("Text", pacientiBindingSource, "Adresa");
                txtSpPoza.DataBindings.Add("Text", pacientiBindingSource, "SplImagine");
                txtIdPacient.DataBindings.Add("Text", pacientiBindingSource, "IdPacient");
                pb.DataBindings.Add("ImageLocation", pacientiBindingSource, "SplImagine");
            }
            else
            {
                txtNumePacient.DataBindings.Clear();
                txtCNP.DataBindings.Clear();
                txtNrTelefon.DataBindings.Clear();
                txtAdresa.DataBindings.Clear();
                txtSpPoza.DataBindings.Clear();
                txtIdPacient.DataBindings.Clear();
                pb.DataBindings.Clear();
            }
        }


        private void protectiePanel(bool v)
        {
            txtNumePacient.ReadOnly = v;
            txtCNP.ReadOnly = v;
            txtNrTelefon.ReadOnly = v;
            txtAdresa.ReadOnly = v;
            txtSpPoza.ReadOnly = v;
        }
        private void golireCampuri()
        {
            txtNumePacient.Text = "";
            txtCNP.Text = "";
            txtIdPacient.Text = "";
            txtNrTelefon.Text = "";
            txtAdresa.Text = "";
            txtSpPoza.Text = "";
            pb.ImageLocation = "";
        }
        private bool validareCampuriObligatorii()
        {
            //Validare de completare obligatorie campurile: Nume, CNP, Salariu, Localitate
            if (txtNumePacient.Text == "")
            {
                MessageBox.Show("Completati Nume Pacient !");
                txtNumePacient.Focus();
                return false;
            }
            if (txtCNP.Text == "")
            {
                MessageBox.Show("Completati CNP !");
                txtCNP.Focus();
                return false;
            }
            if (txtNrTelefon.Text == "")
            {
                MessageBox.Show("Completati Nr Telefon !");
                txtNrTelefon.Focus();
                return false;
            }

            if (txtAdresa.Text == "")
            {
                MessageBox.Show("Completati Adresa !");
                txtAdresa.Focus();
                return false;
            }
            return true;
        }

        private void adauga_inregistrare()
        {
            string listaCampuri;
            string listaValori;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = pacientiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            listaCampuri = "NumePacient, CNP, NrTelefon, Adresa, SplImagine";
            listaValori = "'" + txtNumePacient.Text + "'" +
                          ",'" + txtCNP.Text +
                          "','" + txtNrTelefon.Text + "'" +
                          ",'" + txtAdresa.Text + "'" +
                          ",'" + txtSpPoza.Text + "';";

            cmd.CommandText = "Insert into Pacienti(" + listaCampuri + ") " +
                              "Select " + listaValori;

  

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
            refresh_grid(pacientiBindingSource.Position);
        }
        private void refresh_grid(int p)
        {
            pacientiTableAdapter.Fill(dataSet1.Pacienti);
            pacientiBindingSource.Position = p;
        }
        private void modifica_inregistrare()
        {
            string listaSet;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = pacientiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            listaSet = "NumePacient = '" + txtNumePacient.Text + "'," +
                       "CNP = '" + txtCNP.Text + "'," +
                       "NrTelefon = '" + txtNrTelefon.Text + "'," +
                       "Adresa = '" + txtAdresa.Text + "'," +
                       "SplImagine = '" + txtSpPoza.Text + "'";

            cmd.CommandText = "Update Pacienti Set " + listaSet + " Where IdPacient=" + txtIdPacient.Text;



            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            A2();
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            A7();
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) return;
            A8();

        }

        private void btnConfirmare_Click(object sender, EventArgs e)
        {
            A4();
        }

        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            A3();
        }

        private void txtSpPoza_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            A6();
        }

        private void txtCNP_Leave(object sender, EventArgs e)
        {
            A5(txtCNP);
        }

        private void txtNrTelefon_Leave(object sender, EventArgs e)
        {
            A5(txtNrTelefon);
        }
    }
}
