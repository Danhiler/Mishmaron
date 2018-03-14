using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;

public partial class Send_Shifts : System.Web.UI.Page
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
        sms_left=int.Parse(dOptions.Rows[0]["Num_Of_SMS"].ToString());

        //checking Amount of SMS need
         int count = 0;
        foreach (DataRow dr in dt.Rows)
        {  
            if (Request.Form["sms" + i + ""] != null)
                count += int.Parse(Request.Form["sms" + i + ""].ToString());
        i++;
        }
        if(count>sms_left)
            Response.Write("<script language='javascript'>alert('אין ברשותך מספיק אס אמ אסים');history.go(-1)</script>");

        i=0;
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
                string Wname="";
                if (bool.Parse(dOptions.Rows[0]["Use_Jobs"].ToString()))//use jobs
                {
                   Wname=dr["Job"].ToString()+"|"+dr["NameW"].ToString();
                }
                else
                {
                    Wname=dr["NameW"].ToString();
                }
                for(int j =Wname.Length;j<Width_Of_Boxes;j++)
                    Wname+=" ";

                    Response.Write(Send_Shifts_sms(dr["Phone"].ToString().Replace("-", ""), Wname, da));

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

   
    public string Send_Shifts_sms(string Phone,string Worker_Name, DataTable da)
    {
        try
        {
            string str = Get_Shifts_String(Worker_Name);
            if (str.Length == 6) return "bgcolor='#FF7777' align='center'>נכשל(אין משמרות)";// no shifts
             
            if (str.Length > 70 )
            {
                //Split_Messages
                List <SMS_Message> msgs =new List<SMS_Message>();
                string str2="";
                while (str.Length > 70)
                {
                    str2 = str.Substring(0, 70 );
                while (str2[str2.Length - 1] != '<')
                   str2= str2.Remove(str2.Length - 1, 1);
                str2 = str2.Remove(str2.Length - 1, 1);
                msgs.Add(new SMS_Message(Phone, da.Rows[0]["Phone"].ToString().Replace("-", ""), str2));
                str = str.Replace(str2, "");
                str = str.Remove(str.Length - 4, 4);
                }
                SMS_Message sm = new SMS_Message(Phone, da.Rows[0]["Phone"].ToString().Replace("-", ""), str);
                if (sms_left > 0)
                {
                    if (sm.Check_Message())
                    {
                        if (!sm.Send()) return "bgcolor='#FF7777' align='center'>נכשל(שגיאה)" ;
                        sms_left--;
                        sms_list.Add(sm);
                    }
                    else
                        return "bgcolor='#FF7777' align='center'>נכשל(לא חוקי)";

                }
                else
                    return "bgcolor='#FF7777' align='center'>נכשל(אין הודעות)";
                

                if (sms_left >= msgs.Count)
                {
                    foreach (SMS_Message ss in msgs)
                        if (ss.Check_Message())
                        {
                            if (!ss.Send()) return "bgcolor='#FF7777' align='center'>נכשל(שגיאה)"; 
                            sms_left--;
                            sms_list.Add(ss);
                        }
                        else
                            return "bgcolor='#FF7777' align='center'>נכשל(לא חוקי)";
                }
                else
                    return "bgcolor='#FF7777' align='center'>נכשל(אין הודעות)";
                       
               
                    return "bgcolor='#99FF99' align='center' >נשלח("+(msgs.Count+1)+" הודעות)";//sucsses
             
            }
            else
            {
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
        }
        catch (Exception)
        {
            return "bgcolor='#FF7777' align='center'>נכשל";//fail
        }
    }
    
    private string Get_Shifts_String(string Worker_Name)
    {
        string htr = "משמרון:\n";//hebrew
        DataTable dt = ADO.GetFullTable("Work_Table", "ID=" + Session["ID"] + " AND week="+Request.Form["week"]);
        DateTime date = DateTime.Now;
        if(Request.Form["week"].ToString()=="1")
            while (date.DayOfWeek.ToString() != "Sunday")
               date= date.AddDays(1);
        else
            while (date.DayOfWeek.ToString() != "Sunday")
                date =date.AddDays(-1);

        if (dt.Rows[0]["sunday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " א-בוקר\n";  }
        while (dt.Rows[0]["sunday_intermediate"].ToString().Contains(Worker_Name))
        {
            try 
            {
                htr += date.Day + " א-" + dt.Rows[0]["sunday_intermediate"].ToString().Substring(dt.Rows[0]["sunday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes-2)+"\n";
                
                dt.Rows[0]["sunday_intermediate"] = dt.Rows[0]["sunday_intermediate"].ToString().Remove(dt.Rows[0]["sunday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex) 
            {
               htr += date.Day + " א-ביניים\n";
                
            }
        }
        if (dt.Rows[0]["sunday_evening"].ToString().Contains(Worker_Name)) {  htr += date.Day + " א-ערב\n";  }

        date = date.AddDays(1);
        if (dt.Rows[0]["monday_morning"].ToString().Contains(Worker_Name)) {  htr += date.Day + " ב-בוקר\n";  }
        while (dt.Rows[0]["monday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                 htr += date.Day + " ב-" + dt.Rows[0]["monday_intermediate"].ToString().Substring(dt.Rows[0]["monday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";
                
                dt.Rows[0]["monday_intermediate"] = dt.Rows[0]["monday_intermediate"].ToString().Remove(dt.Rows[0]["monday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ב-ביניים\n";
                
            }
        }
        if (dt.Rows[0]["monday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ב-ערב\n";  }

        date = date.AddDays(1);
        if (dt.Rows[0]["tuesday_morning"].ToString().Contains(Worker_Name)) {  htr += date.Day + " ג-בוקר\n";  }
        while (dt.Rows[0]["tuesday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
               htr += date.Day + " ג-" + dt.Rows[0]["tuesday_intermediate"].ToString().Substring(dt.Rows[0]["tuesday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";
                
                dt.Rows[0]["tuesday_intermediate"] = dt.Rows[0]["tuesday_intermediate"].ToString().Remove(dt.Rows[0]["tuesday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ג-ביניים\n";
                
            }
        }
        if (dt.Rows[0]["tuesday_evening"].ToString().Contains(Worker_Name)) {  htr += date.Day + " ג-ערב\n";  }

        date = date.AddDays(1);
        if (dt.Rows[0]["wednesday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ד-בוקר\n";  }
        while (dt.Rows[0]["wednesday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                 htr += date.Day + " ד-" + dt.Rows[0]["wednesday_intermediate"].ToString().Substring(dt.Rows[0]["wednesday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";
                
                dt.Rows[0]["wednesday_intermediate"] = dt.Rows[0]["wednesday_intermediate"].ToString().Remove(dt.Rows[0]["wednesday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ד-ביניים\n";
                
            }
        }
        if (dt.Rows[0]["wednesday_evening"].ToString().Contains(Worker_Name)) {  htr += date.Day + " ד-ערב\n";  }

        date = date.AddDays(1);
        if (dt.Rows[0]["thursday_morning"].ToString().Contains(Worker_Name)) {  htr += date.Day + " ה-בוקר\n";  }
        while (dt.Rows[0]["thursday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " ה-" + dt.Rows[0]["thursday_intermediate"].ToString().Substring(dt.Rows[0]["thursday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";
                
                dt.Rows[0]["thursday_intermediate"] = dt.Rows[0]["thursday_intermediate"].ToString().Remove(dt.Rows[0]["thursday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ה-ביניים\n";
                
            }
        }
        if (dt.Rows[0]["thursday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ה-ערב\n";  }

        date = date.AddDays(1);
        if (dt.Rows[0]["friday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ו-בוקר\n";  }
        while (dt.Rows[0]["friday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
               htr += date.Day + " ו-" + dt.Rows[0]["friday_intermediate"].ToString().Substring(dt.Rows[0]["friday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";
                
                dt.Rows[0]["friday_intermediate"] = dt.Rows[0]["friday_intermediate"].ToString().Remove(dt.Rows[0]["friday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ו-ביניים\n";
                
            }
        }
        if (dt.Rows[0]["friday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ו-ערב\n";  }

        date = date.AddDays(1);
        if (dt.Rows[0]["saturday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ש-בוקר\n";  }
        while (dt.Rows[0]["saturday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " ש-" + dt.Rows[0]["saturday_intermediate"].ToString().Substring(dt.Rows[0]["saturday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";
                
                dt.Rows[0]["saturday_intermediate"] = dt.Rows[0]["saturday_intermediate"].ToString().Remove(dt.Rows[0]["saturday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ש-ביניים\n";       
            }
        }
        if (dt.Rows[0]["saturday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ש-ערב\n";  }
        if (htr.Length == 0) return "";
        htr = htr.Remove(htr.Length - 2, 2);

       
            return htr;

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