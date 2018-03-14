using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class purchase_SMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {

        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }

    
}
