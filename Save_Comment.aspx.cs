using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Save_Comment : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            int al = 1;
            if (Request.Form["show_comment"] == null)      
                    al = 0;
            string sql = "Update Options Set Comment='" + ADO.filter(Request.Form["Comment"].ToString()) +"', Show_Comment="+al+" Where ID=" + Session["ID"];


                ADO.ExecuteNonQuery(sql);

                Response.Redirect("Shifts_next_week.aspx");

        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            
        }
        

        
    }
}
