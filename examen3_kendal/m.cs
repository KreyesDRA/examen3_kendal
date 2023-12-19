using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Encuesta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        int id = 0;
        int.TryParse(Request.QueryString["id"], out id);
        int.TryParse(txtedad.Text, out int edad);
        if (txtnombre.Text != "" && edad >= 18 && edad <= 50 && txtcorreo.Text != "" && ddlpartido.SelectedIndex != 0)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insertar_encuesta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", txtnombre.Text);
            cmd.Parameters.AddWithValue("@edad", edad);
            cmd.Parameters.AddWithValue("@correo", txtcorreo.Text);
            cmd.Parameters.AddWithValue("@partido", ddlpartido.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Gracias.aspx");
        }
        else
        {
            Response.Write("<script>alert('Debe llenar todos los campos correctamente')</script>");
        }
    }
}