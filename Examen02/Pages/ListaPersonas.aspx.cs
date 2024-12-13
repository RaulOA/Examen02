using Examen02.Data;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen02
{
    public partial class ListaPersonas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPersonas();
            }
        }

        private void CargarPersonas()
        {
            using (var db = new PV_Examen02Entities())
            {
                var personas = db.spConsultarTodasLasPersonas().ToList();
                GridViewPersonas.DataSource = personas;
                GridViewPersonas.DataBind();
            }
        }

        // Método para calcular la edad
        protected int CalculateAge(object fechaNacimiento)
        {
            if (fechaNacimiento != null)
            {
                DateTime birthDate = Convert.ToDateTime(fechaNacimiento);
                int age = DateTime.Now.Year - birthDate.Year;

                if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                {
                    age--;
                }
                return age;
            }
            return 0;
        }

        // Método para determinar la generación
        protected string DetermineGeneration(object fechaNacimiento)
        {
            if (fechaNacimiento != null)
            {
                DateTime birthDate = Convert.ToDateTime(fechaNacimiento);
                int birthYear = birthDate.Year;

                if (birthYear >= 1994 && birthYear <= 2010)
                    return "Generación Z";
                if (birthYear >= 1981 && birthYear <= 1993)
                    return "Generación Y";
                if (birthYear >= 1969 && birthYear <= 1980)
                    return "Generación X";
                if (birthYear >= 1949 && birthYear <= 1968)
                    return "Generación Baby Boomers";
                if (birthYear >= 1930 && birthYear <= 1948)
                    return "Generación silenciosa";
                else
                    return "N/D";
            }
            return "N/D";
        }

        protected void GridViewPersonas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Customización adicional si se necesita.
        }
    }
}
