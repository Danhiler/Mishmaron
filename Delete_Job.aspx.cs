using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delete_Job : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
           if (Request.QueryString["SJ"] == null || Request.QueryString["SJ"] == "")
               Response.Redirect("jobs.aspx");

            string Short_Job = Trans_To_hebrew(ADO.filter(Request.QueryString["SJ"]));
            string sql = "DELETE FROM jobs WHERE Short_Job ='" + Short_Job + "'";
            ADO.ExecuteNonQuery(sql);
            Response.Redirect("jobs.aspx");
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }
    public string Trans_To_hebrew(string str)
    {
        for (int i = 0; i < str.Length; i++)
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
        }
        return str;
    }
}
