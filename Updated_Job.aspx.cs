using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Updated_Job : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
           if (((bool)Session["Loged_In"])&&((bool)Session["Admin"]))
        {

            if (ADO.filter(Request.Form["Old_SJ"].ToString()) != ADO.filter(Request.Form["short_job"].ToString()))
            {
                if (ADO.GetFullTable("jobs", "ID=" + Session["ID"] + "AND Short_Job='" + ADO.filter(Request.Form["short_job"].ToString()) + "'").Rows.Count > 0)
                    Response.Write("<script language='javascript'>alert('קיצור תפקיד זה קיים כבר אצלך בעסק');history.go(-1)</script>");
            }

                string sql = "Update jobs Set Short_job='" + ADO.filter(Request.Form["short_job"].ToString()) +
                                                  "', Job='" + ADO.filter(Request.Form["job"].ToString()) +
                                                  "' where Short_Job='" + Request.Form["Old_SJ"].ToString() + "' AND ID=" + Session["ID"] + "";


                ADO.ExecuteNonQuery(sql);
                Response.Redirect("jobs.aspx");

           
        }
                else
                {
                    Session.Abandon();
                    Response.Redirect("Default.aspx");
                  
                }
    }

    
}
