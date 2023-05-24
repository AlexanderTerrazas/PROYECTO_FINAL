namespace ProyectoCompilador
{
    partial class Reporte
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
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnXLSX = new System.Windows.Forms.Button();
            this.CbUsuario = new System.Windows.Forms.CheckBox();
            this.CbLenguaje = new System.Windows.Forms.CheckBox();
            this.CbFecha = new System.Windows.Forms.CheckBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.TxtLenguaje = new System.Windows.Forms.TextBox();
            this.DtpInicio = new System.Windows.Forms.DateTimePicker();
            this.DtpFin = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 124);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.Size = new System.Drawing.Size(477, 290);
            this.dgvReport.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Location = new System.Drawing.Point(99, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "TXT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCSV.Location = new System.Drawing.Point(214, 432);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(75, 35);
            this.btnCSV.TabIndex = 2;
            this.btnCSV.Text = "CSV";
            this.btnCSV.UseVisualStyleBackColor = false;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnXLSX
            // 
            this.btnXLSX.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnXLSX.Location = new System.Drawing.Point(326, 432);
            this.btnXLSX.Name = "btnXLSX";
            this.btnXLSX.Size = new System.Drawing.Size(75, 35);
            this.btnXLSX.TabIndex = 3;
            this.btnXLSX.Text = "XLSX";
            this.btnXLSX.UseVisualStyleBackColor = false;
            this.btnXLSX.Click += new System.EventHandler(this.btnXLSX_Click);
            // 
            // CbUsuario
            // 
            this.CbUsuario.AutoSize = true;
            this.CbUsuario.Location = new System.Drawing.Point(52, 11);
            this.CbUsuario.Name = "CbUsuario";
            this.CbUsuario.Size = new System.Drawing.Size(62, 17);
            this.CbUsuario.TabIndex = 4;
            this.CbUsuario.Text = "Usuario";
            this.CbUsuario.UseVisualStyleBackColor = true;
            this.CbUsuario.CheckedChanged += new System.EventHandler(this.CbUsuario_CheckedChanged);
            // 
            // CbLenguaje
            // 
            this.CbLenguaje.AutoSize = true;
            this.CbLenguaje.Location = new System.Drawing.Point(200, 11);
            this.CbLenguaje.Name = "CbLenguaje";
            this.CbLenguaje.Size = new System.Drawing.Size(70, 17);
            this.CbLenguaje.TabIndex = 5;
            this.CbLenguaje.Text = "Lenguaje";
            this.CbLenguaje.UseVisualStyleBackColor = true;
            this.CbLenguaje.CheckedChanged += new System.EventHandler(this.CbLenguaje_CheckedChanged);
            // 
            // CbFecha
            // 
            this.CbFecha.AutoSize = true;
            this.CbFecha.Location = new System.Drawing.Point(378, 11);
            this.CbFecha.Name = "CbFecha";
            this.CbFecha.Size = new System.Drawing.Size(56, 17);
            this.CbFecha.TabIndex = 6;
            this.CbFecha.Text = "Fecha";
            this.CbFecha.UseVisualStyleBackColor = true;
            this.CbFecha.CheckedChanged += new System.EventHandler(this.CbFecha_CheckedChanged);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(36, 35);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtUsuario.TabIndex = 7;
            // 
            // TxtLenguaje
            // 
            this.TxtLenguaje.Location = new System.Drawing.Point(189, 34);
            this.TxtLenguaje.Name = "TxtLenguaje";
            this.TxtLenguaje.Size = new System.Drawing.Size(100, 20);
            this.TxtLenguaje.TabIndex = 8;
            // 
            // DtpInicio
            // 
            this.DtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpInicio.Location = new System.Drawing.Point(326, 35);
            this.DtpInicio.Name = "DtpInicio";
            this.DtpInicio.Size = new System.Drawing.Size(80, 20);
            this.DtpInicio.TabIndex = 9;
            // 
            // DtpFin
            // 
            this.DtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFin.Location = new System.Drawing.Point(412, 35);
            this.DtpFin.Name = "DtpFin";
            this.DtpFin.Size = new System.Drawing.Size(80, 20);
            this.DtpFin.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Location = new System.Drawing.Point(200, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 11;
            this.button2.Text = "Aplicar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 497);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DtpFin);
            this.Controls.Add(this.DtpInicio);
            this.Controls.Add(this.TxtLenguaje);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.CbFecha);
            this.Controls.Add(this.CbLenguaje);
            this.Controls.Add(this.CbUsuario);
            this.Controls.Add(this.btnXLSX);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvReport);
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button btnXLSX;
        private System.Windows.Forms.CheckBox CbUsuario;
        private System.Windows.Forms.CheckBox CbLenguaje;
        private System.Windows.Forms.CheckBox CbFecha;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.TextBox TxtLenguaje;
        private System.Windows.Forms.DateTimePicker DtpInicio;
        private System.Windows.Forms.DateTimePicker DtpFin;
        private System.Windows.Forms.Button button2;
    }
}