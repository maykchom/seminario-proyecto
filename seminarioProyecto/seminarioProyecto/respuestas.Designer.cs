namespace seminarioProyecto
{
    partial class respuestas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(respuestas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRes = new System.Windows.Forms.DataGridView();
            this.btnGuardarRes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRespuesta = new System.Windows.Forms.TextBox();
            this.btnEditarRes = new System.Windows.Forms.Button();
            this.btnEliminarRes = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRes);
            this.panel1.Controls.Add(this.btnGuardarRes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbRespuesta);
            this.panel1.Controls.Add(this.btnEditarRes);
            this.panel1.Controls.Add(this.btnEliminarRes);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 669);
            this.panel1.TabIndex = 0;
            // 
            // dgvRes
            // 
            this.dgvRes.AllowUserToAddRows = false;
            this.dgvRes.AllowUserToDeleteRows = false;
            this.dgvRes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRes.BackgroundColor = System.Drawing.Color.White;
            this.dgvRes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRes.Location = new System.Drawing.Point(68, 229);
            this.dgvRes.Name = "dgvRes";
            this.dgvRes.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvRes.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRes.ShowCellErrors = false;
            this.dgvRes.Size = new System.Drawing.Size(879, 295);
            this.dgvRes.TabIndex = 20;
            this.dgvRes.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRes_CellBeginEdit);
            this.dgvRes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRes_CellClick);
            this.dgvRes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRes_DataError);
            // 
            // btnGuardarRes
            // 
            this.btnGuardarRes.BackColor = System.Drawing.Color.Black;
            this.btnGuardarRes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarRes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardarRes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnGuardarRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnGuardarRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarRes.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarRes.ForeColor = System.Drawing.Color.White;
            this.btnGuardarRes.Location = new System.Drawing.Point(767, 149);
            this.btnGuardarRes.Name = "btnGuardarRes";
            this.btnGuardarRes.Size = new System.Drawing.Size(177, 30);
            this.btnGuardarRes.TabIndex = 24;
            this.btnGuardarRes.Text = "Guardar respuesta";
            this.btnGuardarRes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarRes.UseVisualStyleBackColor = false;
            this.btnGuardarRes.Click += new System.EventHandler(this.btnGuardarRes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ingresar respuesta*";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbRespuesta
            // 
            this.tbRespuesta.BackColor = System.Drawing.Color.Gainsboro;
            this.tbRespuesta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRespuesta.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRespuesta.Location = new System.Drawing.Point(73, 110);
            this.tbRespuesta.Name = "tbRespuesta";
            this.tbRespuesta.Size = new System.Drawing.Size(871, 24);
            this.tbRespuesta.TabIndex = 21;
            // 
            // btnEditarRes
            // 
            this.btnEditarRes.BackColor = System.Drawing.Color.Black;
            this.btnEditarRes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarRes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditarRes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnEditarRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEditarRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarRes.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarRes.ForeColor = System.Drawing.Color.White;
            this.btnEditarRes.Location = new System.Drawing.Point(770, 569);
            this.btnEditarRes.Name = "btnEditarRes";
            this.btnEditarRes.Size = new System.Drawing.Size(177, 30);
            this.btnEditarRes.TabIndex = 24;
            this.btnEditarRes.Text = "Guardar cambios";
            this.btnEditarRes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditarRes.UseVisualStyleBackColor = false;
            this.btnEditarRes.Visible = false;
            this.btnEditarRes.Click += new System.EventHandler(this.btnEditarRes_Click);
            // 
            // btnEliminarRes
            // 
            this.btnEliminarRes.BackColor = System.Drawing.Color.White;
            this.btnEliminarRes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarRes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminarRes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnEliminarRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminarRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRes.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarRes.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarRes.Location = new System.Drawing.Point(587, 569);
            this.btnEliminarRes.Name = "btnEliminarRes";
            this.btnEliminarRes.Size = new System.Drawing.Size(177, 30);
            this.btnEliminarRes.TabIndex = 22;
            this.btnEliminarRes.Text = "Eliminar respuesta";
            this.btnEliminarRes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarRes.UseVisualStyleBackColor = false;
            this.btnEliminarRes.Visible = false;
            this.btnEliminarRes.Click += new System.EventHandler(this.btnEliminarRes_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(21, 637);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
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
            // respuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 669);
            this.Controls.Add(this.panel1);
            this.Name = "respuestas";
            this.Text = "Respuestas";
            this.Load += new System.EventHandler(this.respuestas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEditarRes;
        private System.Windows.Forms.Button btnGuardarRes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminarRes;
        private System.Windows.Forms.TextBox tbRespuesta;
        private System.Windows.Forms.DataGridView dgvRes;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}