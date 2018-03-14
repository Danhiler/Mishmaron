using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class jobs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!((bool)Session["Loged_In"]))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }

    }

    public void PrintList()
    {
     
        DataTable dt = ADO.GetFullTable("Jobs", "ID=" + Session["ID"]);
        int i = 1;
        Response.Write("<br><font size=4>");
        Response.Write("מספר תפקידים: " + dt.Rows.Count);
        Response.Write("</font>");
        Response.Write("<table border='2' width='600' class='sample'><tr>");
        Response.Write("<th bgcolor='92a4b6' width='10'></th>");
        Response.Write("<th bgcolor='92a4b6'>קיצור</th>");
        Response.Write("<th bgcolor='92a4b6'>תפקיד</th>");
        if ((bool)Session["Admin"])
        {
            Response.Write("<th bgcolor='92a4b6'>ערוך</th>");
            Response.Write("<th bgcolor='92a4b6'>מחק</th>");
        }
        Response.Write("</tr>");
        if (dt.Rows.Count == 0)
        {
            Response.Write("<tr>");
            Response.Write("<th colspan='6'><center>");
            Response.Write("לא הוגדרו תפקידים");
            Response.Write("</center></th>");
            Response.Write("</tr>");
        }

        else
            foreach (DataRow dr in dt.Rows)
            {
                Response.Write("<tr>");
                Response.Write("<td>" + i + "</td>");
                Response.Write("<td>" + dr["Short_Job"].ToString() + "&nbsp;</td>");
                Response.Write("<td>" + dr["Job"].ToString() + "&nbsp;</td>");
                if ((bool)Session["Admin"])
                {
                    Response.Write("<td> <a href ='Update_Job.aspx?SJ=" + Trans_To_english(dr["Short_Job"].ToString()) + "'><center><img src='Pictures/edit.gif' border='0'></center></a></td>");
                    Response.Write("<td> <a href ='Delete_Job.aspx?SJ=" + Trans_To_english(dr["Short_Job"].ToString()) + "'><center><img src='Pictures/del.gif' border='0'></center></a></td>");
                }
                Response.Write("</tr>");
                i++;
            }
        Response.Write("</table>");


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
