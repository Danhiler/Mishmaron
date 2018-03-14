using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class Send_Emergency : System.Web.UI.Page
{
    public int Width_Of_Boxes;
    public List<SMS_Message> sms_list;
    public int sms_left;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(((bool)Session["Loged_In"]) && ((bool)Session["Admin"])))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        Width_Of_Boxes = 13;
    }
    public void Print_Resualt()
    {
        int i = 0;
        DataTable dt = ADO.GetFullTable("Workers", "ID=" + Session["ID"] + "");
        DataTable da = ADO.GetFullTable("Users", "ID=" + Session["ID"]);
        DataTable dOptions = ADO.GetFullTable("Options", "ID=" + (int)Session["ID"]);
        sms_list = new List<SMS_Message>();
        sms_left = int.Parse(dOptions.Rows[0]["Num_Of_SMS"].ToString());

        //checking Amount of SMS need
        int count = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (Request.Form["sms" + i + ""] != null)
                count++;
            i++;
        }
        if (count > sms_left)
            Response.Write("<script language='javascript'>alert('אין ברשותך מספיק אס אמ אסים');history.go(-1)</script>");

        i = 0;
        Response.Write("<table width='300' class='sample' align='center' >");
        Response.Write("<tr>");
        Response.Write("<th bgcolor='92a4b6'>שם עובד</th>");
        Response.Write("<th bgcolor='92a4b6'>SMS</th>");
        Response.Write("</tr>");
        foreach (DataRow dr in dt.Rows)
        {
            Response.Write("<tr>");
            Response.Write("<td>" + dr["NameW"] + "</td>");
            
            Response.Write("<td ");
            if (Request.Form["sms" + i + ""] != null)//sending sms
            {
                Response.Write(Send_Emergency_sms(dr["Phone"].ToString().Replace("-", ""), da));
            }
            else
                Response.Write(" align='center' >לא נשלח");
            Response.Write("</td> ");
            i++;
        }
        Response.Write("</table>");
        //updating DB
        sms_left = int.Parse(dOptions.Rows[0]["Num_Of_SMS"].ToString()) - sms_list.Count;
        ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS=" + sms_left + " where ID=" + Session["ID"] + "");
        Session["SMS_Left"] = sms_left;
    }

   
    public string Send_Emergency_sms(string Phone, DataTable da)
    {
        try
        {
            string str = "התגלו חוסרים בעובדים במהלך קביעת סידור העבודה. אנא התחבר לאתר בדחיפות";
                SMS_Message sm = new SMS_Message(Phone, da.Rows[0]["Phone"].ToString().Replace("-", ""), str);
                if (sms_left > 0)
                {
                    if (sm.Check_Message())
                    {
                        if (!sm.Send()) return "bgcolor='#FF7777' align='center'>נכשל(שגיאה)";
                        sms_left--;
                        sms_list.Add(sm);
                    }
                    else
                        return "bgcolor='#FF7777' align='center'>נכשל(לא חוקי)";
                }
                else
                    return "bgcolor='#FF7777' align='center'>נכשל(אין הודעות)";
                return "bgcolor='#99FF99' align='center' >נשלח";//sucsses
        }
        catch (Exception)
        {
            return "bgcolor='#FF7777' align='center'>נכשל";//fail
        }
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
