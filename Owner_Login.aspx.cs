using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Owner_Login : System.Web.UI.Page
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
            DataTable dtU = ADO.GetFullTable("Users", " UserName='" + ADO.filter(Request.QueryString["id"].ToString()) + "'");
            if (dtU.Rows.Count > 0)
            {

                Session["Use_Jobs"] = bool.Parse(ADO.GetFullTable("Options", "ID=" + dtU.Rows[0][0]).Rows[0]["use_jobs"].ToString());
                Session["ID"] = dtU.Rows[0][0];
                Session["Admin"] = true;
                Session["Cname"] = dtU.Rows[0]["CName"];
                Session["Wname"] = dtU.Rows[0]["FName"];
                Session["Loged_In"] = true;


                Response.Redirect("Shifts_next_week.aspx");
            }
            else
            {
                DataTable dtW = ADO.GetFullTable("Workers", "UserID='" + ADO.filter(Request.QueryString["id"].ToString()) + "'");
                if (dtW.Rows.Count > 0)
                {
                    
                    Session["UserID"] = dtW.Rows[0]["UserID"];
                    Session["Use_Jobs"] = bool.Parse(ADO.GetFullTable("Options", "ID=" + dtW.Rows[0][0]).Rows[0]["use_jobs"].ToString());
                    Session["ID"] = dtW.Rows[0][0];
                    Session["Admin"] = false;
                    Session["Wname"] = dtW.Rows[0]["NameW"];
                    Session["Cname"] = ADO.GetFullTable("Users", "ID=" + dtW.Rows[0][0]).Rows[0]["CName"];
                    Session["Loged_In"] = true;
                    Response.Redirect("Shifts_next_week.aspx");

                }
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

    }
}
