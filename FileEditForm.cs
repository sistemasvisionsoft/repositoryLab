using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Objects;
using Common;

namespace I_DApplicationInstaller
{
	public partial class FileEditForm : Form
	{

		#region --[Propiedades]--
		/// <summary>
		/// propiedad que contiene una instancia de la clase fileEditConfig.
		/// </summary>
		private FileEditTask _objFileEditTask = new FileEditTask();

		/// <summary>
		/// propiedad por la cual recibe y devuelve valores del tipo Generic.
		/// </summary>
		public Task ObjTask { get; set; }

		#endregion


		#region --[Eventos]--

		public FileEditForm()
		{
			InitializeComponent();
		}

		private void EditConfigLoad(object sender, EventArgs e)
		{
			if (ObjTask != null)
			{
				_objFileEditTask = (FileEditTask) ObjTask;
				CargarPantalla();
			}
		}

		
		public void FunctionDummy(){
			
			string hola = "homa";
			
			
		}
		
		private void BtnArchivoClick(object sender, EventArgs e)
		{
			SeleccionarArchivo();
		}

		private void BtnAgregarClick(object sender, EventArgs e)
		{
			
			if (!ValidarPathOrigen()) return;

			FileEditSection objSection = MostrarDialogoEdicion(null);
			if (objSection != null)
				_objFileEditTask.EditConfigSectionList.Add(objSection); 
			CargarGrid();
		}

		private void GvwModificacionesCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{

			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				DataGridViewRow r = gvwModificaciones.Rows[e.RowIndex];

				int posicion = int.Parse(r.Cells["Position"].Value.ToString());
				FileEditSection obj = _objFileEditTask.EditConfigSectionList.First(x => x.Position == posicion);
				int index = _objFileEditTask.EditConfigSectionList.IndexOf(obj);

				obj = MostrarDialogoEdicion(obj);

				if (obj != null)
				{
					_objFileEditTask.EditConfigSectionList.RemoveAt(index);
					_objFileEditTask.EditConfigSectionList.Insert(index, obj);
					CargarGrid();
				}
			}
		}

		protected void GvwModificacionesCurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (gvwModificaciones.IsCurrentCellDirty)
			{
				gvwModificaciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		protected void GvwAccionesCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (gvwModificaciones.Columns[e.ColumnIndex].Name == "Seleccion")
			{
				DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)gvwModificaciones.Rows[e.RowIndex].Cells["Seleccion"];
				if (checkCell.Value != null && bool.Parse(checkCell.Value.ToString()))
				{
					foreach (DataGridViewRow chk in gvwModificaciones.Rows)
					{
						if (chk.Index != e.RowIndex)
							chk.Cells["Seleccion"].Value = false;
					}
				}
			}
		}

		private void BtnUpClick(object sender, EventArgs e)
		{
			int index = SubirModificacion();
			CargarGrid();
			SelectRowGridModificaciones(index);
		}


		private void BtnDownClick(object sender, EventArgs e)
		{
			int index = BajarModificacion();
			CargarGrid();
			SelectRowGridModificaciones(index);
		}

		private void BtnDeleteClick(object sender, EventArgs e)
		{
			EliminarAccion();
			CargarGrid();
		}

		private void BtnCancelarClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void BtnAceptarClick(object sender, EventArgs e)
		{
			if (!ValidarForm()) return;
			GuardarValores();
			DialogResult = DialogResult.OK;
		}

		#endregion

		#region --[Metodos Propios]--

		/// <summary>
		/// carga en pantalla un objeto del la propiedad ObjGenericConfig
		/// </summary>
		private void CargarPantalla()
		{
			txtPathArchivo.Text = _objFileEditTask.TargetPath;
			txtDescripcion.Text = _objFileEditTask.ActionDescription;
			chkBackup.Checked = _objFileEditTask.EnableBackupRollback;
			CargarGrid();
		}

		/// <summary>
		/// carga el grid con las modificaciones en _objFileEditTask.EditConfigSectionList
		/// </summary>
		private void CargarGrid()
		{
			const string ToolTipDescripcion = "Doble click para editar o check para eliminar o mover.";

			gvwModificaciones.Rows.Clear();
			foreach (FileEditSection obj in _objFileEditTask.EditConfigSectionList)
			{
				gvwModificaciones.Rows.Add();

				int rowIndex = gvwModificaciones.RowCount - 1;
				DataGridViewRow r = gvwModificaciones.Rows[rowIndex];

				obj.Position = rowIndex + 1;

				r.Cells["Seleccion"].Value = false;
				r.Cells["Seleccion"].ToolTipText = ToolTipDescripcion;
				r.Cells["Seleccion"].ReadOnly = false;

				r.Cells["Position"].Value = obj.Position;
				r.Cells["Position"].ToolTipText = ToolTipDescripcion;

				r.Cells["EditDescription"].Value = obj.EditDescription;
				r.Cells["EditDescription"].ToolTipText = ToolTipDescripcion;

				r.Cells["OldText"].Value = obj.OldText;
				r.Cells["OldText"].ToolTipText = obj.OldText;

				r.Cells["NewText"].Value = obj.NewText;
				r.Cells["NewText"].ToolTipText = obj.NewText;

			}

			txtCantidad.Text = gvwModificaciones.RowCount.ToString(CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// selecciona un archivo y setea el path en pantalla
		/// </summary>
		private void SeleccionarArchivo()
		{
			DialogResult dialogResult = ofdFileDialog.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				String pathApuntado = ofdFileDialog.FileName;

				txtPathArchivo.Text = pathApuntado;
			}

		}

		/// <summary>
		/// Muestra la pantalla de edicion en un dialog Form y devuelve el file config resultante o null
		/// si no se completa la operacion
		/// </summary>
		/// <param name="objSection"></param>
		/// <returns></returns>
		private FileEditSection MostrarDialogoEdicion(FileEditSection objSection)
		{
			FileEditSection obj;
			using (FileSectionEditForm myForm = new FileSectionEditForm())
			{
				myForm.FilePath = txtPathArchivo.Text;
				if (objSection != null) myForm.ObjEditSection = objSection;
				DialogResult dialogResult = myForm.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					obj = myForm.ObjEditSection;
					return obj;
				}
				return null;
			}
		}
			
		/// <summary>
		/// valida que se encuentre el path del archivo
		/// </summary>
		/// <returns></returns>
		private Boolean ValidarPathOrigen()
		{
			if(txtPathArchivo.Text.IsNullOrWhiteSpace() || txtPathArchivo.Text.Equals("{?}"))
			{
				MessageBox.Show("Debe especificar la ruta del archivo de configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		/// <summary>
		/// valida que tenga modificaciones agregadas.
		/// </summary>
		/// <returns></returns>
		private Boolean ValidarContenidoGrid()
		{
			if(gvwModificaciones.RowCount <= 0)
			{
				MessageBox.Show("Debe agregar alguna modificación antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		/// <summary>
		/// valida el contenido del form.
		/// </summary>
		/// <returns></returns>
		private Boolean ValidarForm()
		{
			if (txtDescripcion.Text.IsNullOrWhiteSpace())
			{
				MessageBox.Show("La descripción es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return ValidarPathOrigen() && ValidarContenidoGrid();
		}

		/// <summary>
		/// sube de posicion la modificacion q este chequeada.
		/// </summary>
		private int SubirModificacion()
		{
			int posicionActual = 0;
			foreach (DataGridViewRow row in gvwModificaciones.Rows)
			{
				if (row.Cells["Seleccion"] != null && bool.Parse(row.Cells["Seleccion"].Value.ToString()))
				{
					posicionActual = int.Parse(row.Cells["Position"].Value.ToString());
				}
				if (posicionActual > 1)
				{
					FileEditSection objToMove = _objFileEditTask.EditConfigSectionList.First(x => x.Position == posicionActual);
					_objFileEditTask.EditConfigSectionList.Remove(objToMove);
					_objFileEditTask.EditConfigSectionList.Insert(posicionActual - 2, objToMove);
					return posicionActual - 2;
				}
			}
			return posicionActual - 1;

		}

		/// <summary>
		/// baja de posicion una modificacion q esta chequeada.
		/// </summary>
		private int BajarModificacion()
		{
			int posicionActual = gvwModificaciones.RowCount;
			int maxPosicionPosible = gvwModificaciones.RowCount;
			Boolean encontrado = false;
			foreach (DataGridViewRow row in gvwModificaciones.Rows)
			{
				if (row.Cells["Seleccion"] != null && bool.Parse(row.Cells["Seleccion"].Value.ToString()))
				{
					posicionActual = int.Parse(row.Cells["Position"].Value.ToString());
					encontrado = true;
				}
				if (posicionActual < maxPosicionPosible)
				{
					FileEditSection objToMove = _objFileEditTask.EditConfigSectionList.First(x => x.Position == posicionActual);
					_objFileEditTask.EditConfigSectionList.Remove(objToMove);
					_objFileEditTask.EditConfigSectionList.Insert(posicionActual, objToMove);
					return posicionActual;
				}
			}
			return encontrado ? posicionActual - 1 : posicionActual;
		}


		/// <summary>
		/// busca una accion q este chequeada y la elimina.
		/// </summary>
		private void EliminarAccion()
		{
			int posicion = 0;
			foreach (DataGridViewRow row in gvwModificaciones.Rows)
			{
				if (row.Cells["Seleccion"] != null && bool.Parse(row.Cells["Seleccion"].Value.ToString()))
					posicion = int.Parse(row.Cells["Position"].Value.ToString());
			}
			if (posicion != 0)
			{
				FileEditSection obj = _objFileEditTask.EditConfigSectionList.First(x => x.Position == posicion);
				int index = _objFileEditTask.EditConfigSectionList.IndexOf(obj);
				_objFileEditTask.EditConfigSectionList.RemoveAt(index);
			}
		}

		/// <summary>
		/// guarda los valores para retornarlos fuera del form.
		/// </summary>
		private void GuardarValores()
		{
			if(_objFileEditTask == null) _objFileEditTask = new FileEditTask();
			_objFileEditTask.ActionDescription = txtDescripcion.Text;
			_objFileEditTask.TargetPath = txtPathArchivo.Text;
			_objFileEditTask.EnableBackupRollback = chkBackup.Checked;
			ObjTask = _objFileEditTask;
		}


		/// <summary>
		/// selecciona un grid en item en el grid.
		/// </summary>
		private void SelectRowGridModificaciones(int index)
		{
			if (index >= 0 && index <= gvwModificaciones.RowCount - 1)
			{
				gvwModificaciones.Rows[index].Cells["Seleccion"].Value = true;
				gvwModificaciones.Rows[index].Cells["Seleccion"].Selected = true;
			}
		}

		#endregion

	}
}
