namespace seminarioProyecto
{
    partial class confPreguntas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(confPreguntas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbRespuestas = new System.Windows.Forms.GroupBox();
            this.dgvRes = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPreg = new System.Windows.Forms.DataGridView();
            this.cbPuestos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbPregunta = new System.Windows.Forms.TextBox();
            this.btnRealizarEntrevista = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbRespuestas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbRespuestas);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvPreg);
            this.panel1.Controls.Add(this.cbPuestos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 669);
            this.panel1.TabIndex = 0;
            // 
            // gbRespuestas
            // 
            this.gbRespuestas.Controls.Add(this.btnRealizarEntrevista);
            this.gbRespuestas.Controls.Add(this.tbPregunta);
            this.gbRespuestas.Controls.Add(this.dgvRes);
            this.gbRespuestas.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRespuestas.Location = new System.Drawing.Point(22, 293);
            this.gbRespuestas.Name = "gbRespuestas";
            this.gbRespuestas.Size = new System.Drawing.Size(982, 314);
            this.gbRespuestas.TabIndex = 23;
            this.gbRespuestas.TabStop = false;
            this.gbRespuestas.Text = "Respuestas";
            // 
            // dgvRes
            // 
            this.dgvRes.AllowUserToAddRows = false;
            this.dgvRes.AllowUserToDeleteRows = false;
            this.dgvRes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRes.Location = new System.Drawing.Point(6, 19);
            this.dgvRes.Name = "dgvRes";
            this.dgvRes.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvRes.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRes.Size = new System.Drawing.Size(459, 286);
            this.dgvRes.TabIndex = 20;
            this.dgvRes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRes_CellClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(22, 637);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Ver preguntas por puesto";
            // 
            // dgvPreg
            // 
            this.dgvPreg.AllowUserToAddRows = false;
            this.dgvPreg.AllowUserToDeleteRows = false;
            this.dgvPreg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreg.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPreg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPreg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreg.Location = new System.Drawing.Point(22, 108);
            this.dgvPreg.Name = "dgvPreg";
            this.dgvPreg.ReadOnly = true;
            this.dgvPreg.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvPreg.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPreg.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreg.Size = new System.Drawing.Size(982, 165);
            this.dgvPreg.TabIndex = 20;
            this.dgvPreg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreg_CellClick);
            // 
            // cbPuestos
            // 
            this.cbPuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPuestos.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPuestos.FormattingEnabled = true;
            this.cbPuestos.Location = new System.Drawing.Point(22, 78);
            this.cbPuestos.Name = "cbPuestos";
            this.cbPuestos.Size = new System.Drawing.Size(982, 24);
            this.cbPuestos.TabIndex = 19;
            this.cbPuestos.SelectedIndexChanged += new System.EventHandler(this.cbPuestos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "PREGUNTAS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1016, 669);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbPregunta
            // 
            this.tbPregunta.Location = new System.Drawing.Point(508, 114);
            this.tbPregunta.Name = "tbPregunta";
            this.tbPregunta.Size = new System.Drawing.Size(430, 21);
            this.tbPregunta.TabIndex = 21;
            // 
            // btnRealizarEntrevista
            // 
            this.btnRealizarEntrevista.BackColor = System.Drawing.Color.White;
            this.btnRealizarEntrevista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRealizarEntrevista.Enabled = false;
            this.btnRealizarEntrevista.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRealizarEntrevista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnRealizarEntrevista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRealizarEntrevista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizarEntrevista.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnRealizarEntrevista.ForeColor = System.Drawing.Color.Black;
            this.btnRealizarEntrevista.Location = new System.Drawing.Point(616, 161);
            this.btnRealizarEntrevista.Name = "btnRealizarEntrevista";
            this.btnRealizarEntrevista.Size = new System.Drawing.Size(177, 30);
            this.btnRealizarEntrevista.TabIndex = 22;
            this.btnRealizarEntrevista.Text = "Agregar pregunta";
            this.btnRealizarEntrevista.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRealizarEntrevista.UseVisualStyleBackColor = false;
            // 
            // confPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 669);
            this.Controls.Add(this.panel1);
            this.Name = "confPreguntas";
            this.Text = "confPreguntas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbRespuestas.ResumeLayout(false);
            this.gbRespuestas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPreg;
        private System.Windows.Forms.ComboBox cbPuestos;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox gbRespuestas;
        private System.Windows.Forms.DataGridView dgvRes;
        private System.Windows.Forms.TextBox tbPregunta;
        private System.Windows.Forms.Button btnRealizarEntrevista;
    }
}