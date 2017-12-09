

//This is the first comment by me.
namespace I_DApplicationInstaller
{
	partial class FileDeleteForm
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
			this.lblPathBorrado = new System.Windows.Forms.Label();
			this.txtPathBorrado = new System.Windows.Forms.TextBox();
			this.chkEnableBackup = new System.Windows.Forms.CheckBox();
			this.btnArchivo = new System.Windows.Forms.Button();
			this.fbdFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.ofdFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnCarpeta = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.grpBorrado = new System.Windows.Forms.GroupBox();
			this.grpBorrado.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblPathBorrado
			// 
			this.lblPathBorrado.AutoSize = true;
			this.lblPathBorrado.Location = new System.Drawing.Point(14, 71);
			this.lblPathBorrado.Name = "lblPathBorrado";
			this.lblPathBorrado.Size = new System.Drawing.Size(32, 13);
			this.lblPathBorrado.TabIndex = 0;
			this.lblPathBorrado.Text = "Path:";
			// 
			// txtPathBorrado
			// 
			this.txtPathBorrado.Location = new System.Drawing.Point(86, 67);
			this.txtPathBorrado.Name = "txtPathBorrado";
			this.txtPathBorrado.Size = new System.Drawing.Size(221, 20);
			this.txtPathBorrado.TabIndex = 1;
			this.txtPathBorrado.Text = "{?}";
			// 
			// chkEnableBackup
			// 
			this.chkEnableBackup.AutoSize = true;
			this.chkEnableBackup.Location = new System.Drawing.Point(86, 103);
			this.chkEnableBackup.Name = "chkEnableBackup";
			this.chkEnableBackup.Size = new System.Drawing.Size(63, 17);
			this.chkEnableBackup.TabIndex = 5;
			this.chkEnableBackup.Text = "Backup";
			this.chkEnableBackup.UseVisualStyleBackColor = true;
			// 
			// btnArchivo
			// 
			this.btnArchivo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnArchivo.Image = global::I_DApplicationInstaller.Properties.Resources.Files_New_File_icon;
			this.btnArchivo.Location = new System.Drawing.Point(372, 65);
			this.btnArchivo.Name = "btnArchivo";
			this.btnArchivo.Size = new System.Drawing.Size(40, 24);
			this.btnArchivo.TabIndex = 3;
			this.btnArchivo.UseVisualStyleBackColor = false;
			this.btnArchivo.Click += new System.EventHandler(this.BtnBuscarArchivoClick);
			// 
			// ofdFileDialog
			// 
			this.ofdFileDialog.FileName = "openFileDialog1";
			// 
			// btnCarpeta
			// 
			this.btnCarpeta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCarpeta.Image = global::I_DApplicationInstaller.Properties.Resources.Folder_Open_icon;
			this.btnCarpeta.Location = new System.Drawing.Point(322, 65);
			this.btnCarpeta.Name = "btnCarpeta";
			this.btnCarpeta.Size = new System.Drawing.Size(40, 24);
			this.btnCarpeta.TabIndex = 2;
			this.btnCarpeta.UseVisualStyleBackColor = false;
			this.btnCarpeta.Click += new System.EventHandler(this.BtnBuscarCarpetaClick);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(33, 231);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 6;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.BtnAceptarClick);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(366, 231);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.AutoSize = true;
			this.lblDescripcion.Location = new System.Drawing.Point(14, 34);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
			this.lblDescripcion.TabIndex = 7;
			this.lblDescripcion.Text = "Descripcion:";
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(86, 31);
			this.txtDescripcion.MaxLength = 500;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(221, 20);
			this.txtDescripcion.TabIndex = 4;
			// 
			// grpBorrado
			// 
			this.grpBorrado.Controls.Add(this.txtPathBorrado);
			this.grpBorrado.Controls.Add(this.txtDescripcion);
			this.grpBorrado.Controls.Add(this.lblPathBorrado);
			this.grpBorrado.Controls.Add(this.lblDescripcion);
			this.grpBorrado.Controls.Add(this.chkEnableBackup);
			this.grpBorrado.Controls.Add(this.btnArchivo);
			this.grpBorrado.Controls.Add(this.btnCarpeta);
			this.grpBorrado.Location = new System.Drawing.Point(20, 30);
			this.grpBorrado.Name = "grpBorrado";
			this.grpBorrado.Size = new System.Drawing.Size(446, 168);
			this.grpBorrado.TabIndex = 9;
			this.grpBorrado.TabStop = false;
			this.grpBorrado.Text = "Configuración de borrado";
			// 
			// FileDeleteForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(488, 285);
			this.Controls.Add(this.grpBorrado);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "FileDeleteForm";
			this.Text = "Borrado de archivos";
			this.Load += new System.EventHandler(this.DeleteConfigLoad);
			this.grpBorrado.ResumeLayout(false);
			this.grpBorrado.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblPathBorrado;
		private System.Windows.Forms.TextBox txtPathBorrado;
		private System.Windows.Forms.CheckBox chkEnableBackup;
		private System.Windows.Forms.Button btnArchivo;
		private System.Windows.Forms.FolderBrowserDialog fbdFolderBrowser;
		private System.Windows.Forms.OpenFileDialog ofdFileDialog;
		private System.Windows.Forms.Button btnCarpeta;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.GroupBox grpBorrado;
	}
}