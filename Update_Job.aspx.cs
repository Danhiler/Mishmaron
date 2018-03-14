using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Update_Job : System.Web.UI.Page
{
    public string short_job;
    public string job;

    protected void Page_Load(object sender, EventArgs e)
    {
        if( ((bool)Session["Loged_In"])&&((bool)Session["Admin"]))
        {

            
            if (Request.QueryString["SJ"] == null || Request.QueryString["SJ"].ToString() == "")
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");

            }
            string query = ADO.filter(Trans_To_hebrew(Request.QueryString["SJ"]));
            DataTable dt = ADO.GetFullTable("jobs", "Short_Job='" + query.ToString() + "'");
            if (dt.Rows.Count >= 1)
            {
                short_job= dt.Rows[0]["Short_Job"].ToString();
                job = dt.Rows[0]["Job"].ToString();
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");

            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }

    }
    public string Trans_To_hebrew(string str)
    {
        str = str.Replace('t', 'א');
        str = str.Replace('c', 'ב');
        str = str.Replace('d', 'ג');
        str = str.Replace('s', 'ד');
        str = str.Replace('v', 'ה');
        str = str.Replace('u', 'ו');
        str = str.Replace('z', 'ז');
        str = str.Replace('j', 'ח');
        str = str.Replace('y', 'ט');
        str = str.Replace('h', 'י');
        str = str.Replace('f', 'כ');
        str = str.Replace('k', 'ל');
        str = str.Replace('n', 'מ');
        str = str.Replace('b', 'נ');
        str = str.Replace('x', 'ס');
        str = str.Replace('g', 'ע');
        str = str.Replace('p', 'פ');
        str = str.Replace('m', 'צ');
        str = str.Replace('e', 'ק');
        str = str.Replace('r', 'ר');
        str = str.Replace('a', 'ש');
        str = str.Replace(',', 'ת');
        str = str.Replace('w', 'ם');
        str = str.Replace('q', 'ן');
        str = str.Replace('[', 'ף');
        str = str.Replace(']', 'ך');
        str = str.Replace('(', 'ץ');
        str = str.Replace('_', ' ');
        return str;
    }
}
