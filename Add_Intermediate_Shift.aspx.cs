using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Add__Intermediate_Shift : System.Web.UI.Page
{
    public int day;
    public string txt;
    public string name;
    public int Length_Of_T_Boxes;
    public int Width_Of_Boxes;
    public bool use_jobs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!((bool)Session["Loged_In"]))
        {
            Response.Write("<script type='text/javascript' language='javascript'>self.close();</script>");
        }
        if (!(Request.QueryString["Day"] != null && Request.QueryString["IS"] != null && Request.QueryString["Day"].ToString() != "" && Request.QueryString["name"].ToString() != "" && Request.QueryString["name"] != null))
        {
            Response.Write("<script type='text/javascript' language='javascript'>self.close();</script>");

        }
        name = Trans_To_hebrew(Request.QueryString["name"].ToString());
        day = int.Parse(Request.QueryString["Day"]);
        txt = Trans_To_hebrew(Request.QueryString["IS"].ToString());
        DataTable dt = ADO.GetFullTable("Options", "ID=" + (int)Session["ID"]);
        use_jobs = bool.Parse(dt.Rows[0]["Use_Jobs"].ToString());
        Length_Of_T_Boxes = (int)dt.Rows[0]["Length_Of_Temp_Boxes"];
        Width_Of_Boxes = 13;
    }

    public void Print_admin_view()
    {
        bool flag = false;
        Response.Write("<table dir='rtl' align='center' >");
        DataTable AI = ADO.GetFullTable("AI_Optionts", "ID=" + Session["ID"]);
        string[] param = AI.Rows[0]["intermediate"].ToString().Split('#');
        for (int i = 0; i < param.Length ; i++)
        {
            string[] pratim = param[i].Split('@');
            if (day == int.Parse(pratim[0]) + 1)
            {
                flag = true;
                if (use_jobs)
                {
                    if (pratim[1] == name.Split('|')[0])
                        Response.Write("<tr><td width='10'><input id='radio1' type='radio' name='shift' value='" + pratim[3] + "' ></td><td>" + pratim[3] + "</td></tr>");
                }
                else
                {
                    Response.Write("<tr><td width='10'><input id='radio1' type='radio' name='shift' value='" + pratim[3] + "' ></td><td>" + pratim[3] + "</td></tr>");
                }
            }

        }
        if (flag) Response.Write("<tr><td colspan='2' align='center'><input id='Button1' type='button' value='הוסף' onclick=\"INSWorker('" + name + "')\" /></td></tr>");
        Response.Write("</table>");
    }

    public void Print_worker_view()
    {
        bool flag = false;
        Response.Write("<table dir='rtl' align='center'><tr><td colspan='2'>בחר משמרת ביניים ביום "+name_of_day(day)+":</td></tr>");
        DataTable AI = ADO.GetFullTable("AI_Optionts", "ID=" + Session["ID"]);
        string[] param = AI.Rows[0]["intermediate"].ToString().Split('#');
        for (int i = 0; i < param.Length; i++)
        {
            string[] pratim = param[i].Split('@');
            if (day == int.Parse(pratim[0])+1)
            {
                flag = true;
                if (use_jobs)
                {
                    if (pratim[1] == name.Split('|')[0])
                        Response.Write("<tr><td width='10'><input id='radio1' type='radio' name='shift' value='" + pratim[3] + "' ></td><td>" + pratim[3] + "</td></tr>");
                }
                else
                {
                    Response.Write("<tr><td width='10'><input id='radio1' type='radio' name='shift' value='" + pratim[3] + "' ></td><td>" + pratim[3] + "</td></tr>");
                }
            }
            
        }
        if (!flag) Response.Write("<tr><td><font color='red'>אין צורך במשמרות ביניים ביום זה</font></td></tr>");
        else
        Response.Write("<tr><td colspan='2' align='center'><table><tr><td><input id='Button1' type='button' value='הוסף' onclick=\"INSWorker('" + name + "')\" /></td>");
        if (txt.Contains(name)) 
        Response.Write("<td><input type='button' name='submit3' value='הסר את עצמך' onclick=\"remove('" + txt + "',"+txt.IndexOf(name)+",26)\" /></td>");
        Response.Write("</tr></table></td></tr>");
        Response.Write("</table>");
    }

    public string name_of_day(int day)
    {
        switch (day)
        { 
            case 1:
                return "ראשון";
            case 2:
                return "שני";
            case 3:
                return "שלישי";
            case 4:
                return "רבעי";
            case 5:
                return "חמישי";
            case 6:
                return "שישי";
            case 7:
                return "שבת";
            default:
                return "";
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
