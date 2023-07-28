
namespace Proiect
{
    partial class Internare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.internareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Proiect.DataSet1();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idInternareDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idServiciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantitateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.internareContinutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.internareContinutTableAdapter = new Proiect.DataSet1TableAdapters.InternareContinutTableAdapter();
            this.txtIdInternare = new System.Windows.Forms.TextBox();
            this.btnInternareNoua = new System.Windows.Forms.Button();
            this.btnModificareInternare = new System.Windows.Forms.Button();
            this.btnStergeInternare = new System.Windows.Forms.Button();
            this.internareTableAdapter = new Proiect.DataSet1TableAdapters.InternareTableAdapter();
            this.idInternareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPacientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataInternareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataExternareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diagnosticDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrInternareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internareContinutBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idInternareDataGridViewTextBoxColumn,
            this.idPacientDataGridViewTextBoxColumn,
            this.dataInternareDataGridViewTextBoxColumn,
            this.dataExternareDataGridViewTextBoxColumn,
            this.sectieDataGridViewTextBoxColumn,
            this.diagnosticDataGridViewTextBoxColumn,
            this.nrInternareDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.internareBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(25, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(664, 248);
            this.dataGridView1.TabIndex = 0;
            // 
            // internareBindingSource
            // 
            this.internareBindingSource.DataMember = "Internare";
            this.internareBindingSource.DataSource = this.dataSet1;
            this.internareBindingSource.PositionChanged += new System.EventHandler(this.internareBindingSource_PositionChanged_1);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idInternareDataGridViewTextBoxColumn1,
            this.nrcDataGridViewTextBoxColumn,
            this.idServiciDataGridViewTextBoxColumn,
            this.tarifDataGridViewTextBoxColumn,
            this.cantitateDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.internareContinutBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(25, 299);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(625, 159);
            this.dataGridView2.TabIndex = 1;
            // 
            // idInternareDataGridViewTextBoxColumn1
            // 
            this.idInternareDataGridViewTextBoxColumn1.DataPropertyName = "IdInternare";
            this.idInternareDataGridViewTextBoxColumn1.HeaderText = "IdInternare";
            this.idInternareDataGridViewTextBoxColumn1.Name = "idInternareDataGridViewTextBoxColumn1";
            this.idInternareDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idInternareDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idInternareDataGridViewTextBoxColumn1.Visible = false;
            // 
            // nrcDataGridViewTextBoxColumn
            // 
            this.nrcDataGridViewTextBoxColumn.DataPropertyName = "Nrc";
            this.nrcDataGridViewTextBoxColumn.HeaderText = "Nrc";
            this.nrcDataGridViewTextBoxColumn.Name = "nrcDataGridViewTextBoxColumn";
            this.nrcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idServiciDataGridViewTextBoxColumn
            // 
            this.idServiciDataGridViewTextBoxColumn.DataPropertyName = "IdServici";
            this.idServiciDataGridViewTextBoxColumn.HeaderText = "IdServici";
            this.idServiciDataGridViewTextBoxColumn.Name = "idServiciDataGridViewTextBoxColumn";
            this.idServiciDataGridViewTextBoxColumn.ReadOnly = true;
            this.idServiciDataGridViewTextBoxColumn.Visible = false;
            // 
            // tarifDataGridViewTextBoxColumn
            // 
            this.tarifDataGridViewTextBoxColumn.DataPropertyName = "Tarif";
            this.tarifDataGridViewTextBoxColumn.HeaderText = "Tarif";
            this.tarifDataGridViewTextBoxColumn.Name = "tarifDataGridViewTextBoxColumn";
            this.tarifDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantitateDataGridViewTextBoxColumn
            // 
            this.cantitateDataGridViewTextBoxColumn.DataPropertyName = "Cantitate";
            this.cantitateDataGridViewTextBoxColumn.HeaderText = "Cantitate";
            this.cantitateDataGridViewTextBoxColumn.Name = "cantitateDataGridViewTextBoxColumn";
            this.cantitateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // internareContinutBindingSource
            // 
            this.internareContinutBindingSource.DataMember = "InternareContinut";
            this.internareContinutBindingSource.DataSource = this.dataSet1;
            // 
            // internareContinutTableAdapter
            // 
            this.internareContinutTableAdapter.ClearBeforeFill = true;
            // 
            // txtIdInternare
            // 
            this.txtIdInternare.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.internareBindingSource, "IdInternare", true));
            this.txtIdInternare.Location = new System.Drawing.Point(762, 82);
            this.txtIdInternare.Name = "txtIdInternare";
            this.txtIdInternare.Size = new System.Drawing.Size(83, 20);
            this.txtIdInternare.TabIndex = 2;
            // 
            // btnInternareNoua
            // 
            this.btnInternareNoua.Location = new System.Drawing.Point(770, 121);
            this.btnInternareNoua.Name = "btnInternareNoua";
            this.btnInternareNoua.Size = new System.Drawing.Size(75, 43);
            this.btnInternareNoua.TabIndex = 3;
            this.btnInternareNoua.Text = "Internare Noua";
            this.btnInternareNoua.UseVisualStyleBackColor = true;
            this.btnInternareNoua.Click += new System.EventHandler(this.btnInternareNoua_Click);
            // 
            // btnModificareInternare
            // 
            this.btnModificareInternare.Location = new System.Drawing.Point(770, 170);
            this.btnModificareInternare.Name = "btnModificareInternare";
            this.btnModificareInternare.Size = new System.Drawing.Size(75, 41);
            this.btnModificareInternare.TabIndex = 4;
            this.btnModificareInternare.Text = "Modificare Internare";
            this.btnModificareInternare.UseVisualStyleBackColor = true;
            this.btnModificareInternare.Click += new System.EventHandler(this.btnModificareInternare_Click);
            // 
            // btnStergeInternare
            // 
            this.btnStergeInternare.Location = new System.Drawing.Point(770, 217);
            this.btnStergeInternare.Name = "btnStergeInternare";
            this.btnStergeInternare.Size = new System.Drawing.Size(75, 57);
            this.btnStergeInternare.TabIndex = 5;
            this.btnStergeInternare.Text = "Sterge Internare";
            this.btnStergeInternare.UseVisualStyleBackColor = true;
            this.btnStergeInternare.Click += new System.EventHandler(this.btnStergeInternare_Click);
            // 
            // internareTableAdapter
            // 
            this.internareTableAdapter.ClearBeforeFill = true;
            // 
            // idInternareDataGridViewTextBoxColumn
            // 
            this.idInternareDataGridViewTextBoxColumn.DataPropertyName = "IdInternare";
            this.idInternareDataGridViewTextBoxColumn.HeaderText = "IdInternare";
            this.idInternareDataGridViewTextBoxColumn.Name = "idInternareDataGridViewTextBoxColumn";
            this.idInternareDataGridViewTextBoxColumn.ReadOnly = true;
            this.idInternareDataGridViewTextBoxColumn.Visible = false;
            // 
            // idPacientDataGridViewTextBoxColumn
            // 
            this.idPacientDataGridViewTextBoxColumn.DataPropertyName = "IdPacient";
            this.idPacientDataGridViewTextBoxColumn.HeaderText = "IdPacient";
            this.idPacientDataGridViewTextBoxColumn.Name = "idPacientDataGridViewTextBoxColumn";
            this.idPacientDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPacientDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataInternareDataGridViewTextBoxColumn
            // 
            this.dataInternareDataGridViewTextBoxColumn.DataPropertyName = "DataInternare";
            this.dataInternareDataGridViewTextBoxColumn.HeaderText = "DataInternare";
            this.dataInternareDataGridViewTextBoxColumn.Name = "dataInternareDataGridViewTextBoxColumn";
            this.dataInternareDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataExternareDataGridViewTextBoxColumn
            // 
            this.dataExternareDataGridViewTextBoxColumn.DataPropertyName = "DataExternare";
            this.dataExternareDataGridViewTextBoxColumn.HeaderText = "DataExternare";
            this.dataExternareDataGridViewTextBoxColumn.Name = "dataExternareDataGridViewTextBoxColumn";
            this.dataExternareDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sectieDataGridViewTextBoxColumn
            // 
            this.sectieDataGridViewTextBoxColumn.DataPropertyName = "Sectie";
            this.sectieDataGridViewTextBoxColumn.HeaderText = "Sectie";
            this.sectieDataGridViewTextBoxColumn.Name = "sectieDataGridViewTextBoxColumn";
            this.sectieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diagnosticDataGridViewTextBoxColumn
            // 
            this.diagnosticDataGridViewTextBoxColumn.DataPropertyName = "Diagnostic";
            this.diagnosticDataGridViewTextBoxColumn.HeaderText = "Diagnostic";
            this.diagnosticDataGridViewTextBoxColumn.Name = "diagnosticDataGridViewTextBoxColumn";
            this.diagnosticDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrInternareDataGridViewTextBoxColumn
            // 
            this.nrInternareDataGridViewTextBoxColumn.DataPropertyName = "NrInternare";
            this.nrInternareDataGridViewTextBoxColumn.HeaderText = "NrInternare";
            this.nrInternareDataGridViewTextBoxColumn.Name = "nrInternareDataGridViewTextBoxColumn";
            this.nrInternareDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrInternareDataGridViewTextBoxColumn.Visible = false;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Internare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 472);
            this.Controls.Add(this.btnStergeInternare);
            this.Controls.Add(this.btnModificareInternare);
            this.Controls.Add(this.btnInternareNoua);
            this.Controls.Add(this.txtIdInternare);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Internare";
            this.Text = "Internare";
            this.Load += new System.EventHandler(this.Internare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internareContinutBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource internareContinutBindingSource;
        private DataSet1TableAdapters.InternareContinutTableAdapter internareContinutTableAdapter;
        private System.Windows.Forms.TextBox txtIdInternare;
        private System.Windows.Forms.Button btnInternareNoua;
        private System.Windows.Forms.Button btnModificareInternare;
        private System.Windows.Forms.Button btnStergeInternare;
        private System.Windows.Forms.BindingSource internareBindingSource;
        private DataSet1TableAdapters.InternareTableAdapter internareTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInternareDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idServiciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarifDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantitateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInternareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPacientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataInternareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataExternareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagnosticDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrInternareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
    }
}