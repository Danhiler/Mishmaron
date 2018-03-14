using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delete_Worker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            if (Request.QueryString["ID"] == null || Request.QueryString["ID"] == "")
                Response.Redirect("List_Of_Workers.aspx");
            string ID = ADO.filter(Request.QueryString["ID"]);
            string sql = "DELETE FROM Workers WHERE UserID ='" + ID + "'";
            if(int.Parse(ADO.GetFullTable("Workers","USERID='"+ ID +"'").Rows[0]["ID"].ToString())==int.Parse(Session["ID"].ToString()))
            ADO.ExecuteNonQuery(sql);

            Response.Redirect("List_Of_Workers.aspx");

        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            
        }
    }
}