using System;
using System.Web.UI;

namespace Examen02
{
    public partial class Mensaje : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el mensaje de la query string y mostrarlo en la etiqueta
                string mensaje = Request.QueryString["mensaje"];
                if (!string.IsNullOrEmpty(mensaje))
                {
                    lblMensaje.Text = mensaje;
                }
                else
                {
                    lblMensaje.Text = "No se ha especificado ningún mensaje.";
                }
            }
        }
    }
}