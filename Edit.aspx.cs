using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace WebInserteEdit
{
    public partial class Edit : System.Web.UI.Page
    {
        String connectionString = @"Data Source=DESKTOP-KR6N1AN;Initial Catalog=EditDb;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulaterGridview();
            }
        }
        void PopulaterGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM UserRegistration", sqlcon);
                sqlDa.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    gvUserRegistration.DataSource = dtbl;
                    gvUserRegistration.DataBind();
                }
                else
                {
                    dtbl.Rows.Add(dtbl.NewRow());
                    gvUserRegistration.DataSource = dtbl;
                    gvUserRegistration.DataBind();
                    gvUserRegistration.Rows[0].Cells.Clear();
                    gvUserRegistration.Rows[0].Cells.Add(new TableCell());
                    gvUserRegistration.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                    gvUserRegistration.Rows[0].Cells[0].Text = "No Data Found ... ";
                    gvUserRegistration.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }

        protected void gvUserRegistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if
           (e.CommandName.Equals("add"))
                {
                    using (SqlConnection sqlcon = new SqlConnection(connectionString))
                    {
                        sqlcon.Open();
                        string query = "INSERT INTO UserRegistration (firstname,lastname,contact,Email) VALUES(@firstname,@lastname,@contact,@Email)";
                        SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                        sqlcmd.Parameters.AddWithValue("@firstname", (gvUserRegistration.FooterRow.FindControl("txtfirstnamefooter") as TextBox).Text.Trim());

                        sqlcmd.Parameters.AddWithValue("@lastname", (gvUserRegistration.FooterRow.FindControl("txtlastnamefooter") as TextBox).Text.Trim());

                        sqlcmd.Parameters.AddWithValue("@contact", (gvUserRegistration.FooterRow.FindControl("txtcontactfooter") as TextBox).Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Email", (gvUserRegistration.FooterRow.FindControl("txtEmailfooter") as TextBox).Text.Trim());
                        sqlcmd.ExecuteNonQuery();
                        PopulaterGridview();
                        //iblsuccessMessage.Text = "NEW RECORD WAS ADDED ";
                        Response.Write("<script>alert('REGISTRATION WAS SUCCESSFULL')</script>");
                        iblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                iblsuccessMessage.Text = "";
                iblErrorMessage.Text = "ex.message";
            }
        }

        protected void gvUserRegistration_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUserRegistration.EditIndex = e.NewEditIndex;
            PopulaterGridview();
        }

        protected void gvUserRegistration_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUserRegistration.EditIndex = -1;
            PopulaterGridview();
        }

        protected void gvUserRegistration_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                    using (SqlConnection sqlcon = new SqlConnection(connectionString))
                    {
                        sqlcon.Open();
                        string query = "UPDATE  UserRegistration SET firstname=@firstname,lastname=@lastname,contact=@contact,Email=@Email WHERE EditDb= @id";
                       SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                       sqlcmd.Parameters.AddWithValue("@firstname", (gvUserRegistration.Rows[e.RowIndex].FindControl("txtfirstname") as TextBox).Text.Trim());
                       sqlcmd.Parameters.AddWithValue("@lastname", (gvUserRegistration.Rows[e.RowIndex].FindControl("txtlastname") as TextBox).Text.Trim());
                       sqlcmd.Parameters.AddWithValue("@contact", (gvUserRegistration.Rows[e.RowIndex].FindControl("txtcontact") as TextBox).Text.Trim());
                       sqlcmd.Parameters.AddWithValue("@Email", (gvUserRegistration.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                       sqlcmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvUserRegistration.DataKeys[e.RowIndex].Value.ToString()));
                       sqlcmd.ExecuteNonQuery();
                       gvUserRegistration.EditIndex = -1;
                       PopulaterGridview();
                       //iblsuccessMessage.Text = "selected Record update";
                    Response.Write("<script>alert('REGISTRATION WAS UPDATE')</script>");
                    iblErrorMessage.Text = "";
                    }
            }
            catch (Exception ex)
            {
                iblsuccessMessage.Text = "";
                iblErrorMessage.Text = "ex.message";
            }
        }

        protected void gvUserRegistration_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //try
            //{
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    string query = "DELETE FROM UserRegistration WHERE EditDb = @id";
                    SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvUserRegistration.DataKeys[e.RowIndex].Value.ToString()));
                    sqlcmd.ExecuteNonQuery();
                    PopulaterGridview();
                    //iblsuccessMessage.Text = "selected Record Deleted";
                    Response.Write("<script>alert('SELECTED RECORD DELETED')</script>");
                    iblErrorMessage.Text = "";
                }
            //}
            //catch (Exception ex)
            //{
            //    iblsuccessMessage.Text = "";
            //    iblErrorMessage.Text = "ex.message";
            //}
        }
    }
}