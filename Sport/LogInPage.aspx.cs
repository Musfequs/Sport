using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sport
{
    public partial class LogInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            TxtBox_UserID.Text = "";
            TxtBox_Password.Text = "";
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT UserID, UserPassword, UserFName FROM UserInfo WHERE UserID= @UserID AND UserPassword = @UserPassword";

                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.NVarChar).Value = TxtBox_UserID.Text.Trim();
                cmd.Parameters.Add("@UserPassword", System.Data.SqlDbType.NVarChar).Value = TxtBox_Password.Text.Trim();
                cmd.Connection = conn;



                

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
               // conn.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["UserID"]= TxtBox_UserID.Text;
                    Session["UserFName"] = dt.Rows[0][2].ToString();

                    cmd.CommandText = "Update UserInfo SET IsUserLoggedIn=1 WHERE UserID=@UserID";
                    //cmd.Parameters.Add("@UserID", System.Data.SqlDbType.NVarChar).Value = (string)(Session["UserID"]);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Lbl_UserLogin.Text = "Invalid User ID and Password.";
                }
            }
            catch (Exception ex)
            {
                Lbl_UserLogin.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}