using Examen02.Data;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen02
{
    public partial class CrearPersona : Page
    {
        private PV_Examen02Entities db = new PV_Examen02Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
            }
        }

        protected void CargarProvincias()
        {
            try
            {
                // Llamar al procedimiento almacenado para obtener todas las provincias
                var provincias = db.spConsultarTodasLasProvincias().ToList();
                ddlProvincia.DataSource = provincias;
                ddlProvincia.DataTextField = "nombre"; // Cambia esto según el nombre exacto del campo
                ddlProvincia.DataValueField = "idProvincia";
                ddlProvincia.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("Error al cargar provincias: " + ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                    string nombreCompleto = txtNombreCompleto.Text;
                    string telefono = txtTelefono.Text;
                    DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                    decimal salario = Convert.ToDecimal(txtSalario.Text);

                    // Llamar al procedimiento almacenado para crear la persona
                    db.spCrearPersona(idProvincia, nombreCompleto, telefono, fechaNacimiento, salario);

                    // Redireccionar a la página de mensaje
                    Response.Redirect("Mensaje.aspx?mensaje=Ha registrado correctamente los datos de una persona en la base de datos");
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Response.Write("Error al guardar la persona: " + ex.Message);
                }
            }
        }
    }
}
