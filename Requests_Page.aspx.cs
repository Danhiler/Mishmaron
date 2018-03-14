using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Requests_Page : System.Web.UI.Page
{     
    public string company_name;
    public int week;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            if ((Request.QueryString["week"] != null) && (ADO.filter(Request.QueryString["week"].ToString()) == "1" || ADO.filter(Request.QueryString["week"].ToString()) == "0"))
            { 
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
    public void Print_Table()
    {
        bool use_jobs = bool.Parse(Session["Use_Jobs"].ToString());
        company_name = ADO.GetFullTable("Users", "ID=" + Session["ID"]).Rows[0]["Cname"].ToString();
        week = int.Parse(ADO.filter(Request.QueryString["week"].ToString()));
        DataTable dt = ADO.GetFullTable("Workers", " ID=" + Session["ID"]);
        string the_week = "Shifts_This";
        if (week == 1)
            the_week = "Shifts_Next";

        foreach (DataRow worker in dt.Rows)
        {
            Response.Write("<tr>");
            string Wname;
            if (use_jobs)
                Wname = worker["Job"].ToString() + "|" + worker["NameW"].ToString();
            else
                Wname = worker["NameW"].ToString();

            Response.Write("<th>" + Wname + "</th>");

            Response.Write("<td><table class='reg' align='center'>");
            if (worker[the_week].ToString().Contains("SUM")) Response.Write("<tr><td>בוקר</td></tr>");
            while (worker[the_week].ToString().Contains("SUI"))
            {
                Response.Write("<tr><td>" + worker[the_week].ToString().Substring(worker[the_week].ToString().IndexOf('#', worker[the_week].ToString().IndexOf("SUI")) + 1, 11) + "</td></tr>");
                worker[the_week] = worker[the_week].ToString().Remove(worker[the_week].ToString().IndexOf("SUI"), 15);
            }
            if (worker[the_week].ToString().Contains("SUE")) Response.Write("<tr><td>ערב</td></tr>");
            Response.Write("</table></td>");

            Response.Write("<td><table class='reg' align='center'>");
            if (worker[the_week].ToString().Contains("MOM")) Response.Write("<tr><td>בוקר</td></tr>");
            while (worker[the_week].ToString().Contains("MOI"))
            {
                Response.Write("<tr><td>" + worker[the_week].ToString().Substring(worker[the_week].ToString().IndexOf('#', worker[the_week].ToString().IndexOf("MOI")) + 1, 11) + "</td></tr>");
                worker[the_week] = worker[the_week].ToString().Remove(worker[the_week].ToString().IndexOf("MOI"), 15);
            }
            if (worker[the_week].ToString().Contains("MOE")) Response.Write("<tr><td>ערב</td></tr>");
            Response.Write("</table></td>");

            Response.Write("<td><table class='reg' align='center'>");
            if (worker[the_week].ToString().Contains("TUM")) Response.Write("<tr><td>בוקר</td></tr>");
            while (worker[the_week].ToString().Contains("TUI"))
            {
                Response.Write("<tr><td>" + worker[the_week].ToString().Substring(worker[the_week].ToString().IndexOf('#', worker[the_week].ToString().IndexOf("TUI")) + 1, 11) + "</td></tr>");
                worker[the_week] = worker[the_week].ToString().Remove(worker[the_week].ToString().IndexOf("TUI"), 15);
            }
            if (worker[the_week].ToString().Contains("TUE")) Response.Write("<tr><td>ערב</td></tr>");
            Response.Write("</table></td>");

            Response.Write("<td><table class='reg' align='center'>");
            if (worker[the_week].ToString().Contains("WEM")) Response.Write("<tr><td>בוקר</td></tr>");
            while (worker[the_week].ToString().Contains("WEI"))
            {
                Response.Write("<tr><td>" + worker[the_week].ToString().Substring(worker[the_week].ToString().IndexOf('#', worker[the_week].ToString().IndexOf("WEI")) + 1, 11) + "</td></tr>");
                worker[the_week] = worker[the_week].ToString().Remove(worker[the_week].ToString().IndexOf("WEI"), 15);
            }
            if (worker[the_week].ToString().Contains("WEE")) Response.Write("<tr><td>ערב</td></tr>");
            Response.Write("</table></td>");

            Response.Write("<td><table class='reg' align='center'>");
            if (worker[the_week].ToString().Contains("THM")) Response.Write("<tr><td>בוקר</td></tr>");
            while (worker[the_week].ToString().Contains("THI"))
            {
                Response.Write("<tr><td>" + worker[the_week].ToString().Substring(worker[the_week].ToString().IndexOf('#', worker[the_week].ToString().IndexOf("THI")) + 1, 11) + "</td></tr>");
                worker[the_week] = worker[the_week].ToString().Remove(worker[the_week].ToString().IndexOf("THI"), 15);
            }
            if (worker[the_week].ToString().Contains("THE")) Response.Write("<tr><td>ערב</td></tr>");
            Response.Write("</table></td>");

            Response.Write("<td><table class='reg' align='center'>");
            if (worker[the_week].ToString().Contains("FRM")) Response.Write("<tr><td>בוקר</td></tr>");
            while (worker[the_week].ToString().Contains("FRI"))
            {
                Response.Write("<tr><td>" + worker[the_week].ToString().Substring(worker[the_week].ToString().IndexOf('#', worker[the_week].ToString().IndexOf("FRI")) + 1, 11) + "</td></tr>");
                worker[the_week] = worker[the_week].ToString().Remove(worker[the_week].ToString().IndexOf("FRI"), 15);
            }
            if (worker[the_week].ToString().Contains("FRE")) Response.Write("<tr><td>ערב</td></tr>");
            Response.Write("</table></td>");

            Response.Write("<td><table class='reg' align='center'>");
            if (worker[the_week].ToString().Contains("SAM")) Response.Write("<tr><td>בוקר</td></tr>");
            while (worker[the_week].ToString().Contains("SAI"))
            {
                Response.Write("<tr><td>" + worker[the_week].ToString().Substring(worker[the_week].ToString().IndexOf('#', worker[the_week].ToString().IndexOf("SAI")) + 1, 11) + "</td></tr>");
                worker[the_week] = worker[the_week].ToString().Remove(worker[the_week].ToString().IndexOf("SAI"), 15);
            }
            if (worker[the_week].ToString().Contains("SAE")) Response.Write("<tr><td>ערב</td></tr>");
            Response.Write("</table></td>");


            Response.Write("</tr>");
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

