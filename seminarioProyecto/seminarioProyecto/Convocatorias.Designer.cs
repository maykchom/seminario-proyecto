namespace seminarioProyecto
{
    partial class convocatorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(convocatorias));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btCrearConvo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbPuestoAgregar = new System.Windows.Forms.ComboBox();
            this.tbObser1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFI1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFI2 = new System.Windows.Forms.DateTimePicker();
            this.dgvConvo = new System.Windows.Forms.DataGridView();
            this.gbAgregarConvo = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConvo)).BeginInit();
            this.gbAgregarConvo.SuspendLayout();
            this.SuspendLayout();
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
            // btCrearConvo
            // 
            this.btCrearConvo.BackColor = System.Drawing.Color.White;
            this.btCrearConvo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCrearConvo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btCrearConvo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btCrearConvo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btCrearConvo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCrearConvo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btCrearConvo.Location = new System.Drawing.Point(721, 623);
            this.btCrearConvo.Name = "btCrearConvo";
            this.btCrearConvo.Size = new System.Drawing.Size(133, 30);
            this.btCrearConvo.TabIndex = 2;
            this.btCrearConvo.Text = "Historial";
            this.btCrearConvo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCrearConvo.UseVisualStyleBackColor = false;
            this.btCrearConvo.Visible = false;
            this.btCrearConvo.Click += new System.EventHandler(this.btCrearConvo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Black;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(755, 102);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(177, 30);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar convocatoria";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(31, 633);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // cbPuestoAgregar
            // 
            this.cbPuestoAgregar.BackColor = System.Drawing.Color.LightGray;
            this.cbPuestoAgregar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPuestoAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPuestoAgregar.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.cbPuestoAgregar.FormattingEnabled = true;
            this.cbPuestoAgregar.Location = new System.Drawing.Point(719, 43);
            this.cbPuestoAgregar.Name = "cbPuestoAgregar";
            this.cbPuestoAgregar.Size = new System.Drawing.Size(245, 24);
            this.cbPuestoAgregar.TabIndex = 5;
            // 
            // tbObser1
            // 
            this.tbObser1.BackColor = System.Drawing.Color.LightGray;
            this.tbObser1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbObser1.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.tbObser1.Location = new System.Drawing.Point(17, 102);
            this.tbObser1.Multiline = true;
            this.tbObser1.Name = "tbObser1";
            this.tbObser1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObser1.Size = new System.Drawing.Size(705, 118);
            this.tbObser1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbAgregarConvo);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btCrearConvo);
            this.panel1.Controls.Add(this.dgvConvo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 669);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fecha de inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(379, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha de finalización";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(716, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Puesto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Observaciones";
            // 
            // dtpFI1
            // 
            this.dtpFI1.Location = new System.Drawing.Point(17, 44);
            this.dtpFI1.Name = "dtpFI1";
            this.dtpFI1.Size = new System.Drawing.Size(231, 21);
            this.dtpFI1.TabIndex = 10;
            // 
            // dtpFI2
            // 
            this.dtpFI2.Location = new System.Drawing.Point(382, 44);
            this.dtpFI2.Name = "dtpFI2";
            this.dtpFI2.Size = new System.Drawing.Size(234, 21);
            this.dtpFI2.TabIndex = 10;
            // 
            // dgvConvo
            // 
            this.dgvConvo.AllowUserToAddRows = false;
            this.dgvConvo.AllowUserToDeleteRows = false;
            this.dgvConvo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConvo.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvConvo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConvo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConvo.Location = new System.Drawing.Point(24, 69);
            this.dgvConvo.Name = "dgvConvo";
            this.dgvConvo.RowHeadersVisible = false;
            this.dgvConvo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConvo.Size = new System.Drawing.Size(969, 267);
            this.dgvConvo.TabIndex = 11;
            this.dgvConvo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConvo_CellClick);
            // 
            // gbAgregarConvo
            // 
            this.gbAgregarConvo.Controls.Add(this.btnEditar);
            this.gbAgregarConvo.Controls.Add(this.btnEliminar);
            this.gbAgregarConvo.Controls.Add(this.btNuevo);
            this.gbAgregarConvo.Controls.Add(this.cbPuestoAgregar);
            this.gbAgregarConvo.Controls.Add(this.btnGuardar);
            this.gbAgregarConvo.Controls.Add(this.label1);
            this.gbAgregarConvo.Controls.Add(this.label2);
            this.gbAgregarConvo.Controls.Add(this.dtpFI2);
            this.gbAgregarConvo.Controls.Add(this.label3);
            this.gbAgregarConvo.Controls.Add(this.dtpFI1);
            this.gbAgregarConvo.Controls.Add(this.tbObser1);
            this.gbAgregarConvo.Controls.Add(this.label4);
            this.gbAgregarConvo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAgregarConvo.Location = new System.Drawing.Point(24, 342);
            this.gbAgregarConvo.Name = "gbAgregarConvo";
            this.gbAgregarConvo.Size = new System.Drawing.Size(972, 237);
            this.gbAgregarConvo.TabIndex = 12;
            this.gbAgregarConvo.TabStop = false;
            this.gbAgregarConvo.Text = "Agregar convocatoria";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Black;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(755, 138);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(177, 30);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Guardar cambios";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.Location = new System.Drawing.Point(860, 623);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(133, 30);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir afiche";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btCrearConvo_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.BackColor = System.Drawing.Color.White;
            this.btNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNuevo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNuevo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btNuevo.Location = new System.Drawing.Point(755, 174);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(86, 30);
            this.btNuevo.TabIndex = 2;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btNuevo.UseVisualStyleBackColor = false;
            this.btNuevo.Visible = false;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(846, 174);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 30);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // convocatorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1016, 669);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Name = "convocatorias";
            this.Text = "Convocatorias";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConvo)).EndInit();
            this.gbAgregarConvo.ResumeLayout(false);
            this.gbAgregarConvo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btCrearConvo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbPuestoAgregar;
        private System.Windows.Forms.TextBox tbObser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFI2;
        private System.Windows.Forms.DateTimePicker dtpFI1;
        private System.Windows.Forms.GroupBox gbAgregarConvo;
        private System.Windows.Forms.DataGridView dgvConvo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.Button btnEliminar;
    }
}