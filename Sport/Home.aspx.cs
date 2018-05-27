using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sport
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Lbl_TaskID.Text = "New";
            if (Session["UserID"] == null) {
                Response.Redirect("LigInPage.aspx");
            }

        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (TxtBox_TaskDate.Text.Trim() == "")
            {
                Lbl_Task.Text = "Please enter Task Date.";
                return;
            }
            if (TxtBox_TaskDetails.Text.Trim() == "")
            {
                Lbl_Task.Text = "Please enter Task Details.";
                return;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();


                if (Btn_Save.Text == "Save")
                {
                    cmd.CommandText = "INSERT INTO TaskDetailsInfo (TaskDate, TaskDetails, CreatedBy, CreatedOn, ReminderOn, SharedWith) VALUES " +
                        "(@TaskDate, @TaskDetails, @CreatedBy, @CreatedOn, @ReminderOn, @SharedWith)";

                    cmd.Parameters.Add("@TaskDate", System.Data.SqlDbType.DateTime).Value = TxtBox_TaskDate.Text.Trim();
                    cmd.Parameters.Add("@TaskDetails", System.Data.SqlDbType.NText).Value = TxtBox_TaskDetails.Text.Trim();
                    cmd.Parameters.Add("@CreatedBy", System.Data.SqlDbType.NVarChar).Value = (string)(Session["UserID"]); 
                    cmd.Parameters.Add("@CreatedOn", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@ReminderOn", System.Data.SqlDbType.DateTime).Value = (TxtBox_Reminder.Text=="")? "1900-01-01": TxtBox_Reminder.Text.Trim();
                    cmd.Parameters.Add("@SharedWith", System.Data.SqlDbType.NVarChar).Value = DDL_SharedWith.SelectedValue.ToString();
                }
                else if(Btn_Save.Text=="Edit")
                {
                    cmd.CommandText = "Update TaskDetailsInfo SET TaskDate=@TaskDate, TaskDetails=@TaskDetails, EditedBy=@EditedBy, EditedOn=@EditedOn, ReminderOn=@ReminderOn, SharedWith=@SharedWith WHERE TaskID=@TaskID";

                    cmd.Parameters.Add("@TaskDate", System.Data.SqlDbType.DateTime).Value = TxtBox_TaskDate.Text.Trim();
                    cmd.Parameters.Add("@TaskDetails", System.Data.SqlDbType.NText).Value = TxtBox_TaskDetails.Text.Trim();
                    cmd.Parameters.Add("@EditedBy", System.Data.SqlDbType.NVarChar).Value = (string)(Session["UserID"]);
                    cmd.Parameters.Add("@EditedOn", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@ReminderOn", System.Data.SqlDbType.DateTime).Value = (TxtBox_Reminder.Text == "") ? "1900-01-01" : TxtBox_Reminder.Text.Trim();
                    cmd.Parameters.Add("@SharedWith", System.Data.SqlDbType.NVarChar).Value = DDL_SharedWith.SelectedValue.ToString();
                    cmd.Parameters.Add("@TaskID", System.Data.SqlDbType.Int).Value = Lbl_TaskID.Text;

                }
                else if (Btn_Save.Text == "Delete")
                {
                    cmd.CommandText = "Update TaskDetailsInfo SET IsDeleted=1, DeletedBy=@DeletedBy, DeletedOn=@DeletedOn WHERE TaskID=@TaskID";
                    cmd.Parameters.Add("@DeletedBy", System.Data.SqlDbType.NVarChar).Value = (string)(Session["UserID"]);
                    cmd.Parameters.Add("@DeletedOn", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@TaskID", System.Data.SqlDbType.Int).Value = Lbl_TaskID.Text;

                }

                cmd.Connection = conn;

                conn.Open();

                cmd.ExecuteNonQuery();
                Lbl_Task.Text = "Task is "+ Btn_Save.Text.ToLower()+"d successfully.";
                GridView1.DataBind();
                ClearData();
            }
            catch (Exception ex)
            {
                Lbl_Task.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            TxtBox_TaskDate.Text = "";
            TxtBox_TaskDetails.Text = "";
            TxtBox_Reminder.Text = "";
            Calendar_TaskDate.Visible = false;
            Calendar_Reminder.Visible = false;
            DDL_SharedWith.SelectedIndex = 0;
            Lbl_TaskID.Text = "New";
            Lbl_Task.Text = "";
            Btn_Save.Text = "Save";

        }


        private void ClearData() {

            TxtBox_TaskDate.Text = "";
            TxtBox_TaskDetails.Text = "";
            TxtBox_Reminder.Text = "";
            Calendar_TaskDate.Visible = false;
            Calendar_Reminder.Visible = false;
            DDL_SharedWith.SelectedIndex = 0;
            Lbl_TaskID.Text = "New";
            
            Btn_Save.Text = "Save";
        }


        protected void show_date(object sender, ImageClickEventArgs e)
        {
            if (Calendar_TaskDate.Visible)
            {
                Calendar_TaskDate.Visible = false;
            }
            else {
                Calendar_TaskDate.Visible = true;
                TxtBox_TaskDate.Text = "";
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TxtBox_TaskDate.Text = Calendar_TaskDate.SelectedDate.ToShortDateString();
            Calendar_TaskDate.Visible = false;
        }

        protected void ImageButton_Reminder_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar_Reminder.Visible)
            {
                Calendar_Reminder.Visible = false;
            }
            else
            {
                Calendar_Reminder.Visible = true;
                TxtBox_Reminder.Text = "";
            }
        }

        protected void Calendar_Reminder_SelectionChanged(object sender, EventArgs e)
        {
            TxtBox_Reminder.Text = Calendar_Reminder.SelectedDate.ToShortDateString();
            Calendar_Reminder.Visible = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView1.EditIndex = -1;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Lbl_TaskID.Text = row.Cells[0].Text;
            TxtBox_TaskDate.Text = row.Cells[1].Text;
            TxtBox_TaskDetails.Text = row.Cells[2].Text;
            TxtBox_Reminder.Text = (row.Cells[5].Text.Trim() == "N/A") ? "" : row.Cells[5].Text.Trim();

            if (row.Cells[6].Text.Trim() == "N/A")
            {
                DDL_SharedWith.SelectedIndex = 0;
            }
            else
            {
                DDL_SharedWith.ClearSelection();
                DDL_SharedWith.Items.FindByText(row.Cells[6].Text).Selected = true;
            }

            if (e.CommandName == "MyEdit")
            {
                Btn_Save.Text = "Edit";
            }
            if (e.CommandName == "MyDelete")
            {
                Btn_Save.Text = "Delete";
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Data.DataRow row = ((System.Data.DataRowView)e.Row.DataItem).Row;
                if (row["ReminderOn"].ToString().Trim() != "N/A")
                {
                    DateTime dateTime15;   
                    bool isSuccess5 = DateTime.TryParseExact(row["ReminderOn"].ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime15);

                    if (dateTime15 == DateTime.Today)
                        e.Row.BackColor = System.Drawing.Color.Orange;

                    else if (dateTime15 < DateTime.Today)
                        e.Row.BackColor = System.Drawing.Color.Red;

                }
            }

        }
    }
}