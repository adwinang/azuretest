using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testSQL
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnName_Click(object sender, EventArgs e)
        {
            string cntString = "Server=tcp:relevium-p2.database.windows.net,1433;Initial Catalog=relevium;Persist Security Info=False;User ID=relevium;Password=Pr0jectRelev1um;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(cntString);
            try
            {
                conn.Open();
                string sql = String.Format("INSERT INTO TestData(Name) VALUES(@name)");

                SqlCommand cmd = new SqlCommand("INSERT INTO TestData (Name) " + "OUTPUT INSERTED.TestID " + "VALUES ( @name )", conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                int res = cmd.ExecuteNonQuery();

                lblInfo.Text = res.ToString();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}