using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Owner_Insert_Down_Mes : System.Web.UI.Page
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
        int a_admin = 1, a_worker = 1;
        if (Request.Form["admin"].ToString() == null)
            a_admin = 0;
        if (Request.Form["worker"].ToString() == null)
            a_worker = 0;
        ADO.ExecuteNonQuery("Insert INTO  Messages(A_Admin, A_Worker, Msg, Link) values('"+a_admin+"','"+a_worker+"','" + ADO.filter(Request.Form["Msg"].ToString()) + "','" + ADO.filter(Request.Form["Link"].ToString()) + "')");
        Response.Redirect("Owner_Page.ASPX");
    }
}
