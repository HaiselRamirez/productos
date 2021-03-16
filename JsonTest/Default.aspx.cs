using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace JsonTest
{
	public partial class Default : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
		}


		[WebMethod]
		public static string getProducts()
		{
			string resp = null;
			try
			{
				SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
				DataTable dt= new DataTable();
				SqlCommand cmd = new SqlCommand();
				SqlDataAdapter da;
				JavaScriptSerializer js = new JavaScriptSerializer();
				List<Dictionary<string, object>> filas = new List<Dictionary<string, object>>();
				Dictionary<string, object> fila;
				con.Open();
				string query = "SELECT ProductID as id, ProductName as Producto FROM products; ";
				cmd.CommandText = query;
				cmd.CommandType = CommandType.Text;
				cmd.Connection = con;
				da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				con.Close();
				foreach (DataRow dr in dt.Rows)
				{
					fila = new Dictionary<string, object>();
					foreach(DataColumn col in dt.Columns)
					{
						fila.Add(col.ColumnName, dr[col]);
					}
					filas.Add(fila);
				}

				resp = js.Serialize(filas);
				return resp;

			}
			catch (Exception)
			{
				return null;
			}
			finally
			{
			}

		}
	}
}