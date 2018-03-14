using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Owner_Delete_Mes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Wname"] == null || Session["Cname"] == null || Session["Wname"].ToString() == "" || Session["Cname"].ToString() == "")
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        if ((!Session["Wname"].ToString().Equals("5410c239adb1b45866f162e5ec829ca9")) ||
             (!Session["Cname"].ToString().Equals("2cb6e810b21db557600c5bd1ddba81b2")))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        if (Request.QueryString["id"] != null && ADO.filter(Request.QueryString["id"].ToString()) != "")
        {
            
            
            
                string sql = "DELETE FROM Messages WHERE ID =" + ADO.filter(Request.QueryString["id"].ToString());
                ADO.ExecuteNonQuery(sql);
                

            }
            
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        Response.Redirect("Owner_Page.aspx");
    }
}
