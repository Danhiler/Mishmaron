using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class lacks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if ((bool)Session["Loged_In"])
         {
         
         
         }
         else
         {
             Session.Abandon();
             Response.Redirect("Default.aspx");
         }

    }
    public void Print_Lacks()
    {
        bool use_jobs = bool.Parse(Session["Use_Jobs"].ToString());
        DataTable dt = ADO.GetFullTable("shift_lacks", "ID="+Session["ID"]);
        DataTable table = ADO.GetFullTable("Work_Table", "ID=" + Session["ID"] + " AND week=1");
        bool flag = false;
        string job="";
       if(use_jobs && !bool.Parse(Session["Admin"].ToString()))
           job = ADO.GetFullTable("workers", "UserID='"+Session["UserID"]+"'").Rows[0]["job"].ToString();
       string name = Session["Wname"].ToString();
       if (use_jobs &&(!bool.Parse(Session["Admin"].ToString())))
           name = job + "|" + Session["Wname"].ToString();
       while (name.Length < 13) name += " ";
        Response.Write("<table class='sample' width='500' ><tr>");
        Response.Write("<th>תאריך</th><th>יום</th><th>שעה</th><th>כמות</th>");
        if (use_jobs)
            Response.Write("<th>תפקיד</th>");
        Response.Write("<th>קח משמרת</th>");
        Response.Write("</tr>");
        foreach (DataRow dr in dt.Rows)
        {
            if (bool.Parse(Session["Admin"].ToString()) || ((job == dr["job"].ToString() || dr["job"].ToString() == "")) && (check_available(table, GetNameOfDayE(int.Parse(dr["day_s"].ToString())), name)))
            {
                Response.Write("<tr>");
                Response.Write("<td align='center'>" + GetDate(int.Parse(dr["day_s"].ToString())) + "</td>");
                Response.Write("<td align='center'>" + GetDay(int.Parse(dr["day_s"].ToString())) + "</td>");
                Response.Write("<td align='center'>" + dr["session_s"].ToString() + "</td>");
                Response.Write("<td align='center'>" + dr["num_of_workers"].ToString() + "</td>");
                if (use_jobs)
                    Response.Write("<td align='center'>" + dr["job"].ToString() + "</td>");
                Response.Write("<td align='center'><a href='Take_lack_shift.aspx?ID=" + dr["Lack_ID"].ToString() + "&name="+Trans_To_english(name)+"'><img src='Pictures/edit.gif' border='0'></a></td>");
                Response.Write("</tr>");
                flag = true;
            }
        }
        if(!flag)
            Response.Write("<tr><td colspan='6' align='center'>אין חוסרים במשמרות</td></tr>");
        Response.Write("</table>");
    }

    private bool check_available(DataTable table, string day, string name)
    {
        if (table.Rows[0][day + "_morning"].ToString().Contains(name))
            return false;
        if (table.Rows[0][day + "_intermediate"].ToString().Contains(name))
            return false;
        if (table.Rows[0][day + "_evening"].ToString().Contains(name))
            return false;
        return true;
    }

    private string GetDate(int day)
    {
        DateTime date = DateTime.Now;
        date = date.AddDays(1);
        while (date.DayOfWeek.ToString() != "Sunday")
            date = date.AddDays(1);
        while (GetNameOfDayE(day) != date.DayOfWeek.ToString())
            date = date.AddDays(1);
        return date.Day + "." + date.Month;
    }

    private string GetNameOfDayE(int day)
    {
        switch (day)
        {
            case 0:
                return "Sunday";
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thursday";
            case 5:
                return "Friday";
            case 6:
                return "Saturday";
            default:
                return "";

        }
    }
    private string GetDay(int day)
    {
        switch (day)
        {
            case 0:
                return "ראשון";
            case 1:
                return "שני";
            case 2:
                return "שלישי";
            case 3:
                return "רביעי";
            case 4:
                return "חמישי";
            case 5:
                return "שישי";
            case 6:
                return "שבת";
            default:
                return "";

        }
    }
    private string GetSession(int i, Shift shift)
    {
        if (i == 1)
            return "בוקר";

        if (i == 3)
            return "ערב";
        return shift.hours;
    }
    public string Trans_To_english(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            str = str.Replace('א', 't');
            str = str.Replace('ב', 'c');
            str = str.Replace('ג', 'd');
            str = str.Replace('ד', 's');
            str = str.Replace('ה', 'v');
            str = str.Replace('ו', 'u');
            str = str.Replace('ז', 'z');
            str = str.Replace('ח', 'j');
            str = str.Replace('ט', 'y');
            str = str.Replace('י', 'h');
            str = str.Replace('כ', 'f');
            str = str.Replace('ל', 'k');
            str = str.Replace('מ', 'n');
            str = str.Replace('נ', 'b');
            str = str.Replace('ס', 'x');
            str = str.Replace('ע', 'g');
            str = str.Replace('פ', 'p');
            str = str.Replace('צ', 'm');
            str = str.Replace('ק', 'e');
            str = str.Replace('ר', 'r');
            str = str.Replace('ש', 'a');
            str = str.Replace('ת', ',');

            str = str.Replace(' ', '_');
            str = str.Replace('ם', 'w');
            str = str.Replace('ן', 'q');
            str = str.Replace('ף', '[');
            str = str.Replace('ך', ']');
            str = str.Replace('ץ', '(');
        }
        return str;
    }
}
