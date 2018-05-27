using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sport
{
    public partial class MyMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserID"] != null)
                    Lbl_UserName.Text = "Welcome " + Session["UserFName"].ToString();
                else
                    Response.Redirect("LoginPage.aspx");
            }
        }

        protected void LnkBtn_LogOut_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Update UserInfo SET IsUserLoggedIn=0 WHERE UserID=@UserID";
                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.NVarChar).Value = (string)(Session["UserID"]);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                conn.Close();
            }

            Session.Clear();
            Response.Redirect("LogInPage.aspx");
        }
    }
}