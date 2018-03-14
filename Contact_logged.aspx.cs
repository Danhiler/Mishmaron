using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact_logged : System.Web.UI.Page
{
    public string email;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Loged_In"])
        {

            if ((Session["Admin"] != null) && ((bool)Session["Admin"]))
            {
                email = ADO.GetFullTable("Users", " ID=" + Session["ID"]).Rows[0]["Email"].ToString();
            }
            else
            {
                email = ADO.GetFullTable("Workers", "ID=" + Session["ID"] + " And NameW='" + Session["Wname"].ToString() + "'").Rows[0]["E_Mail"].ToString();
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            
        }
    }
}
