using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen02.Data;

namespace Examen02
{
    public partial class EditarPersona : Page
    {
        private int? personaId = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si existe el parámetro "id" en la querystring
            if (Request.QueryString["idPersona"] != null)
            {
                personaId = int.Parse(Request.QueryString["idPersona"]);
            }

            if (!IsPostBack)
            {
                // Cargar las provincias en el DropDownList
                CargarProvincias();

                // Si el ID de la persona está presente, cargar los datos
                if (personaId.HasValue)
                {
                    CargarPersona(personaId.Value);
                }

                
            }
        }

        // Método para cargar la persona que se va a editar
        private void CargarPersona(int id)
        {
            using (var context = new PV_Examen02Entities())
            {
                var persona = context.spConsultarPersonaPorId(id).FirstOrDefault();
                if (persona != null)
                {
                    txtNombreCompleto.Text = persona.nombreCompleto;
                    txtTelefono.Text = persona.telefono;
                    txtFechaNacimiento.Text = persona.fechaNacimiento.ToString("yyyy-MM-dd");
                    txtSalario.Text = persona.salario.ToString("F2");

                    // Seleccionar la provincia en el DropDownList
                    ddlProvincia.SelectedValue = persona.idProvincia.ToString();
                }
            }
        }

        // Método para cargar las provincias en el DropDownList
        private void CargarProvincias()
        {
            using (var context = new PV_Examen02Entities())
            {
                var provincias = context.spConsultarTodasLasProvincias().ToList();
                ddlProvincia.DataSource = provincias;
                ddlProvincia.DataTextField = "nombre";
                ddlProvincia.DataValueField = "idProvincia";
                ddlProvincia.DataBind();
            }
        }

        // Método que maneja el clic del botón "Editar"
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    using (var context = new PV_Examen02Entities())
                    {
                        var resultado = context.spEditarPersona(
                            personaId,
                            int.Parse(ddlProvincia.SelectedValue),
                            txtNombreCompleto.Text,
                            txtTelefono.Text,
                            DateTime.Parse(txtFechaNacimiento.Text),
                            decimal.Parse(txtSalario.Text)
                        );

                        // Redirigir a la página de mensaje después de editar
                        Response.Redirect("Mensaje.aspx?mensaje=Ha editado correctamente los datos de una persona en la base de datos");
                    }
                }
                catch (Exception ex)
                {
                    // Manejar error
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }

        // Método que maneja el clic del botón "Eliminar"
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new PV_Examen02Entities())
                {
                    // Llamar al procedimiento almacenado para eliminar la persona
                    context.spEliminarPersona(personaId);

                    // Redirigir a la página de mensaje después de eliminar
                    Response.Redirect("Mensaje.aspx?mensaje=Ha borrado correctamente la información de la persona en la base de datos");
                }
            }
            catch (Exception ex)
            {
                // Manejar error
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        // Método que maneja el clic del botón "Cancelar" (redirección)
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de lista de personas
            Response.Redirect("ListaPersonas.aspx");
        }
    }
}
