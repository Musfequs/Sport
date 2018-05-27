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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            TxtBox_FName.Text = "";
            TxtBox_LName.Text = "";
            TxtBox_Password.Text = "";
            TxtBox_rePassword.Text = "";
            TxtBox_UserID.Text = "";
            RFV_UserID.ErrorMessage = "";
            RFV_Password1.ErrorMessage = "";
            RFV_Password2.ErrorMessage = "";
            ComV_retypePass.ErrorMessage = "";
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO UserInfo (UserID, UserPassword, UserFName, UserLName) VALUES (@UserID, @UserPassword, @UserFName, @UserLName)";

                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.NVarChar).Value = TxtBox_UserID.Text.Trim();
                cmd.Parameters.Add("@UserPassword", System.Data.SqlDbType.NVarChar).Value = TxtBox_Password.Text.Trim();
                cmd.Parameters.Add("@UserFName", System.Data.SqlDbType.NVarChar).Value = TxtBox_FName.Text.Trim();
                cmd.Parameters.Add("@UserLName", System.Data.SqlDbType.NVarChar).Value = TxtBox_LName.Text.Trim();
                cmd.Connection = conn;

                conn.Open();

                cmd.ExecuteNonQuery();
                Lbl_NewUser.Text = "User created successfully.";

                TxtBox_FName.Text = "";
                TxtBox_LName.Text = "";
                TxtBox_Password.Text = "";
                TxtBox_rePassword.Text = "";
                TxtBox_UserID.Text = "";
                RFV_UserID.ErrorMessage = "";
                RFV_Password1.ErrorMessage = "";
                RFV_Password2.ErrorMessage = "";
                ComV_retypePass.ErrorMessage = "";
            }
            catch(Exception ex) {
                Lbl_NewUser.Text = ex.Message;
            }
            finally {
                conn.Close();
            }
        }
    }
}