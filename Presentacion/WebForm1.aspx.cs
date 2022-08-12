using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Data.SqlClient;



namespace Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Nego objNeg = new Nego();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataReader idCliente = objNeg.ObtenerTablas("Cliente");
                SqlDataReader idAuto = objNeg.ObtenerTablas("Automovil");
                SqlDataReader idMarca = objNeg.ObtenerTablas("Marcas");
                SqlDataReader idMecanico = objNeg.ObtenerTablas("Mecanico");

                DropDownList1.Items.Clear();
                DropDownList2.Items.Clear();
                DropDownList3.Items.Clear();
                DropDownList4.Items.Clear();

                DropDownList1.Items.Add("Seleccione el Cliente");
                DropDownList2.Items.Add("Seleccione el Automovil");
                DropDownList3.Items.Add("Seleccione el Marca");
                DropDownList4.Items.Add("Seleccione el Mecanico");

                while (idCliente.Read())
                {
                    DropDownList1.Items.Add(new ListItem(idCliente[1].ToString() + " " + idCliente[2].ToString() + " " + idCliente[3].ToString(), idCliente[0].ToString()));
                }
                while (idAuto.Read())
                {
                    DropDownList2.Items.Add(new ListItem(idAuto[1].ToString() + " " + idAuto[2].ToString() + " " + idAuto[3].ToString(), idAuto[0].ToString()));
                }
                while (idMarca.Read())
                {
                    DropDownList3.Items.Add(new ListItem(idMarca[1].ToString(), idMarca[0].ToString()));
                }
                while (idMecanico.Read())
                {
                    DropDownList4.Items.Add(new ListItem(idMecanico[1].ToString() + " " + idMecanico[2].ToString() + " " + idMecanico[3].ToString(), idMecanico[0].ToString()));
                }

                GridView1.DataSource = objNeg.ConsultaConexion();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(DropDownList1.SelectedIndex != 0 || DropDownList2.SelectedIndex != 0 || DropDownList3.SelectedIndex != 0 || DropDownList4.SelectedIndex != 0)
                {
                    objNeg.InsertaConexion(new Entidades.Conexion()
                    {
                        Cliente = Convert.ToInt32(DropDownList1.SelectedValue),
                        Auto = Convert.ToInt32(DropDownList2.SelectedValue),
                        Marca = Convert.ToInt32(DropDownList3.SelectedValue),
                        Mecanico = Convert.ToInt32(DropDownList4.SelectedValue),
                        Fecha = TextBox1.Text,
                        Descripcion = TextBox2.Text
                    });
                    Response.Redirect("WebForm1.aspx");
                }
                else
                {
                    Label1.Text = "Seleccione una de las opciones por favor";
                }

            }
            catch(Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}