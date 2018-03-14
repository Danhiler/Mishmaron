using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Insert_job : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            int jobs = ADO.GetFullTable("Jobs", "ID=" + Session["ID"]).Rows.Count;
            int max_jobs = (int)ADO.GetFullTable("Options", "ID=" + Session["ID"]).Rows[0]["Max_Jobs"];


            if (jobs < max_jobs)
            {
                if (Request.Form["short_job"] != null)
                {
                    if(ADO.GetFullTable("jobs", "ID=" + Session["ID"] +"AND Short_Job='" + ADO.filter(Request.Form["short_job"].ToString()) + "'").Rows.Count>0)
                    
                        Response.Write("<script language='javascript'>alert('קיצור התפקיד שבחרת קיים כבר אצלך בעסק');history.go(-1)</script>");
                    else
                    {

                        string strSQL = "Insert INTO  jobs (ID, Short_Job, Job, Description)" +
                                                        " values ('" + Session["ID"] + "','" +
                                                                       ADO.filter(Request.Form["short_job"]) + "','" +
                                                                      ADO.filter(Request.Form["job"]) + "','" +
                                                                      ADO.filter(Request.Form["job_desc"]) + "')";
                            ADO.ExecuteNonQuery(strSQL);
                            jobs++;
                            Label1.Text = "התפקיד " + ADO.filter(Request.Form["short_job"]) + " הוסף בהצלחה";
                            Label1.Text += "  " + jobs + "/" + max_jobs;
                        
                    }
                }
            }
            else
            {
                Label1.Text = "הגעת למספר התפקידים המקסימלי שניתן להוסיף";
            }

        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }

    }
}
