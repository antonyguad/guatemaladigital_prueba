using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guatemaladigitalp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                Loadcats();
            }
        }

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loadcats();
        }

        //CARGAR CATEGORIAS

        private void Loadcats()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT Nombre FROM dbo.Categoria WHERE CodigoCategoria IN(SELECT p.CodigoCategoria FROM dbo.Producto p INNER JOIN dbo.Venta v ON p.CodigoProducto = v.CodigoProducto WHERE YEAR(CONVERT(DATE,V.Fecha,103))=2019)";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                ddlcat.DataSource = reader;
                ddlcat.DataTextField = "Nombre";
                ddlcat.DataBind();
                reader.Close();
            }
        }

        protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlcat.SelectedValue))
            {
                Showventa(ddlcat.SelectedValue);
            }
            else { 
                nohay.DataSource = null;
                nohay.DataBind();
            }
        }

        // mostrar las Ventas

        private void Showventa(string cats)
        { 
            string selectYear=ddlyear.SelectedValue;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                String query = $"SELECT c.Nombre AS Categoria, p.Nombre AS Producto FROM dbo.Venta v JOIN dbo.Producto p ON v.CodigoProducto = p.CodigoProducto JOIN dbo.Categoria c ON p.CodigoCategoria = c.CodigoCategoria WHERE c.Nombre = '{cats}'";

                //filtro anios

                if (!String.IsNullOrEmpty(selectYear))
                {
                    query += $"AND YEAR(CONVERT(DATE,v.Fecha,103))={selectYear}";
                }
                query += " ORDER BY c.Nombre, p.Nombre";

                SqlCommand command = new SqlCommand (query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                nohay.DataSource = reader;
                nohay.DataBind();
                reader.Close();
            }
        }


    }
}