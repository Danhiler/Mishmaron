using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Shifts_this_week : System.Web.UI.Page
{
    public string SUM;
    public string MM;
    public string TUM;
    public string WM;
    public string THM;
    public string FM;
    public string SAM;

    public string SUI;
    public string MI;
    public string TUI;
    public string WI;
    public string THI;
    public string FI;
    public string SAI;

    public string SUE;
    public string ME;
    public string TUE;
    public string WE;
    public string THE;
    public string FE;
    public string SAE;

    public string SM;
    public string EM;
    public string SE;
    public string EE;
    public int Length_Of_Boxes;
    public int Length_Of_T_Boxes;
    public int Width_Of_Boxes;
    public bool intermediate_Shifts;
    public string trance_name;
    public string AL_Days;

    public bool shifts_ready;
    public bool first_log_in_week;
    public bool Allow_Changes;
    public bool use_jobs;
    public string short_job;
    public string[] events;

    public DataTable worker;
    public DataTable dt;

    public string un;

    protected void Page_Load(object sender, EventArgs e)
    {
                if ((bool)Session["Loged_In"])
        {
        dt = ADO.GetFullTable("Work_Table", " ID=" + Session["ID"]+" And week= 0");
        SUM = dt.Rows[0]["sunday_morning"].ToString();
        MM = dt.Rows[0]["monday_morning"].ToString();
        TUM = dt.Rows[0]["tuesday_morning"].ToString();
        WM = dt.Rows[0]["wednesday_morning"].ToString();
        THM = dt.Rows[0]["thursday_morning"].ToString();
        FM = dt.Rows[0]["friday_morning"].ToString();
        SAM = dt.Rows[0]["saturday_morning"].ToString();

       SUI= dt.Rows[0]["sunday_intermediate"].ToString();
       MI= dt.Rows[0]["monday_intermediate"].ToString();
       TUI= dt.Rows[0]["tuesday_intermediate"].ToString();
       WI= dt.Rows[0]["wednesday_intermediate"].ToString();
       THI= dt.Rows[0]["thursday_intermediate"].ToString();
       FI = dt.Rows[0]["friday_intermediate"].ToString();
       SAI = dt.Rows[0]["saturday_intermediate"].ToString();

        SUE = dt.Rows[0]["sunday_evening"].ToString();
        ME = dt.Rows[0]["monday_evening"].ToString();
        TUE = dt.Rows[0]["tuesday_evening"].ToString();
        WE = dt.Rows[0]["wednesday_evening"].ToString();
        THE = dt.Rows[0]["thursday_evening"].ToString();
        FE = dt.Rows[0]["friday_evening"].ToString();
        SAE = dt.Rows[0]["saturday_evening"].ToString();

        DataTable dr = ADO.GetFullTable("Options", "ID=" + (int)Session["ID"]);
        shifts_ready = !bool.Parse(dt.Rows[0]["Allow_Changes"].ToString());
        Allow_Changes = (!shifts_ready) && (Get_Day_Num(DateTime.Now.DayOfWeek.ToString()) < int.Parse(dr.Rows[0]["shift_until"].ToString()));
       
    


        SM = dr.Rows[0]["start_morning_shift"].ToString();
        EM = dr.Rows[0]["end_morning_shift"].ToString();
        SE = dr.Rows[0]["start_evening_shift"].ToString();
        EE = dr.Rows[0]["end_evening_shift"].ToString();
        Length_Of_Boxes = (int)dr.Rows[0]["Length_Of_Boxes"];
        Length_Of_T_Boxes = (int)dr.Rows[0]["Length_Of_Temp_Boxes"];


        
        if (!bool.Parse(Session["Admin"].ToString()))
        {
            worker = ADO.GetFullTable("Workers", "ID=" + Session["ID"] + " AND NameW='" + Session["Wname"] + "'");
            use_jobs = bool.Parse(dr.Rows[0]["Use_Jobs"].ToString());
            if (use_jobs)
                short_job = worker.Rows[0]["Job"].ToString();
        }

        intermediate_Shifts = bool.Parse(dr.Rows[0]["intermediate_Shifts"].ToString());

        Width_Of_Boxes = 13;
        trance_name = Trans_To_english(Session["wname"].ToString());

        if ((!shifts_ready) && (!bool.Parse(Session["Admin"].ToString()))&&(!first_log_in_week))
        {//shifts not ready and the person isnt admin
            string name = "";
            if (use_jobs)
                name = short_job + "|" + Session["wname"].ToString();
            else
                name = Session["wname"].ToString();

            if (SUM.Contains(name)) { SUM = SUM.Substring(SUM.IndexOf(name), Width_Of_Boxes); } else { SUM = ""; }
            if (MM.Contains(name)) { MM = MM.Substring(MM.IndexOf(name), Width_Of_Boxes); } else { MM = ""; }
            if (TUM.Contains(name)) { TUM = TUM.Substring(TUM.IndexOf(name), Width_Of_Boxes); } else { TUM = ""; }
            if (WM.Contains(name)) { WM = WM.Substring(WM.IndexOf(name), Width_Of_Boxes); } else { WM = ""; }
            if (THM.Contains(name)) { THM = THM.Substring(THM.IndexOf(name), Width_Of_Boxes); } else { THM = ""; }
            if (FM.Contains(name)) { FM = FM.Substring(FM.IndexOf(name), Width_Of_Boxes); } else { FM = ""; }
            if (SAM.Contains(name)) { SAM = SAM.Substring(SAM.IndexOf(name), Width_Of_Boxes); } else { SAM = ""; }

            #region intermediat...
            string temp = SUI;
            SUI = "";
            while (temp.Contains(name))
            {
                SUI += temp.Substring(temp.IndexOf(name), Width_Of_Boxes * 2);
                temp = temp.Remove(temp.IndexOf(name), Width_Of_Boxes * 2);
            }
            temp = MI;
            MI = "";
            while (temp.Contains(name))
            {
                MI += temp.Substring(temp.IndexOf(name), Width_Of_Boxes * 2);
                temp = temp.Remove(temp.IndexOf(name), Width_Of_Boxes * 2);
            }
            temp = TUI;
            TUI = "";
            while (temp.Contains(name))
            {
                TUI += temp.Substring(temp.IndexOf(name), Width_Of_Boxes * 2);
                temp = temp.Remove(temp.IndexOf(name), Width_Of_Boxes * 2);
            }
            temp = WI;
            WI = "";
            while (temp.Contains(name))
            {
                WI += temp.Substring(temp.IndexOf(name), Width_Of_Boxes * 2);
                temp = temp.Remove(temp.IndexOf(name), Width_Of_Boxes * 2);
            }
            temp = THI;
            THI = "";
            while (temp.Contains(name))
            {
                THI += temp.Substring(temp.IndexOf(name), Width_Of_Boxes * 2);
                temp = temp.Remove(temp.IndexOf(name), Width_Of_Boxes * 2);
            }
            temp = FI;
            FI = "";
            while (temp.Contains(name))
            {
                FI += temp.Substring(temp.IndexOf(name), Width_Of_Boxes * 2);
                temp = temp.Remove(temp.IndexOf(name), Width_Of_Boxes * 2);
            }
            temp = SAI;
            SAI = "";
            while (temp.Contains(name))
            {
                SAI += temp.Substring(temp.IndexOf(name), Width_Of_Boxes * 2);
                temp = temp.Remove(temp.IndexOf(name), Width_Of_Boxes * 2);
            }
            #endregion

            if (SUE.Contains(name)) { SUE = SUE.Substring(SUE.IndexOf(name), Width_Of_Boxes); } else { SUE = ""; }
            if (ME.Contains(name)) { ME = ME.Substring(ME.IndexOf(name), Width_Of_Boxes); } else { ME = ""; }
            if (TUE.Contains(name)) { TUE = TUE.Substring(TUE.IndexOf(name), Width_Of_Boxes); } else { TUE = ""; }
            if (WE.Contains(name)) { WE = WE.Substring(WE.IndexOf(name), Width_Of_Boxes); } else { WE = ""; }
            if (THE.Contains(name)) { THE = THE.Substring(THE.IndexOf(name), Width_Of_Boxes); } else { THE = ""; }
            if (FE.Contains(name)) { FE = FE.Substring(FE.IndexOf(name), Width_Of_Boxes); } else { FE = ""; }
            if (SAE.Contains(name)) { SAE = SAE.Substring(SAE.IndexOf(name), Width_Of_Boxes); } else { SAE = ""; }
        }

        un = ADO.GetFullTable("Users", "ID=" + (int)Session["ID"]).Rows[0]["UserName"].ToString();
        events = new string[7];
        HebrewCalendar heb = new HebrewCalendar();
        DateTime date = DateTime.Now;

        while (date.DayOfWeek.ToString() != "Sunday")
            date = date.AddDays(-1);
        DataTable holydays;
        if (heb.IsLeapYear(heb.GetYear(date)))
            holydays = ADO.GetFullTable("Holiday", "day=" + heb.GetDayOfMonth(date) + " AND leap_month=" + heb.GetMonth(date)
                                                   + " OR day=" + heb.GetDayOfMonth(date.AddDays(1)) + " AND leap_month=" + heb.GetMonth(date.AddDays(1))
                                                   + " OR day=" + heb.GetDayOfMonth(date.AddDays(2)) + " AND leap_month=" + heb.GetMonth(date.AddDays(2))
                                                   + " OR day=" + heb.GetDayOfMonth(date.AddDays(3)) + " AND leap_month=" + heb.GetMonth(date.AddDays(3))
                                                   + " OR day=" + heb.GetDayOfMonth(date.AddDays(4)) + " AND leap_month=" + heb.GetMonth(date.AddDays(4))
                                                   + " OR day=" + heb.GetDayOfMonth(date.AddDays(5)) + " AND leap_month=" + heb.GetMonth(date.AddDays(5))
                                                   + " OR day=" + heb.GetDayOfMonth(date.AddDays(6)) + " AND leap_month=" + heb.GetMonth(date.AddDays(6)) + "");
        else
            holydays = ADO.GetFullTable("Holiday", "day=" + heb.GetDayOfMonth(date) + " AND month=" + heb.GetMonth(date)
                                                     + " OR day=" + heb.GetDayOfMonth(date.AddDays(1)) + " AND month=" + heb.GetMonth(date.AddDays(1))
                                                     + " OR day=" + heb.GetDayOfMonth(date.AddDays(2)) + " AND month=" + heb.GetMonth(date.AddDays(2))
                                                     + " OR day=" + heb.GetDayOfMonth(date.AddDays(3)) + " AND month=" + heb.GetMonth(date.AddDays(3))
                                                     + " OR day=" + heb.GetDayOfMonth(date.AddDays(4)) + " AND month=" + heb.GetMonth(date.AddDays(4))
                                                     + " OR day=" + heb.GetDayOfMonth(date.AddDays(5)) + " AND month=" + heb.GetMonth(date.AddDays(5))
                                                     + " OR day=" + heb.GetDayOfMonth(date.AddDays(6)) + " AND month=" + heb.GetMonth(date.AddDays(6)) + "");
        foreach (DataRow holyday in holydays.Rows)
            for (int i = 0; i < 7; i++)
                if (heb.GetDayOfMonth(date.AddDays(i)) == int.Parse(holyday["day"].ToString()))
                {
                    if (holyday["Link"].ToString() != "")
                        events[i] = "<a href='" + holyday["Link"].ToString() + "' target='_blank'>" + holyday["name_of_holiday"].ToString() + "</a>";
                    else
                        events[i] = holyday["name_of_holiday"].ToString();
                }
        }
                else
                {
                    Session.Abandon();
                    Response.Redirect("Default.aspx");
                    
                }

    }
    private int Get_Day_Num(string day)
    {
        switch (day)
        {
            case "Sunday": return 0;
            case "Monday": return 1;
            case "Tuesday": return 2;
            case "Wednesday": return 3;
            case "Thursday": return 4;
            case "Friday": return 5;
            case "Saturday": return 6;
            default: return -1;
        }

    }
    public void Print_Table_for_workers()
    {
        Response.Write("<tr><td>בוקר<br />" + SM + "-" + EM + "</td>");
        for (int i = 0; i < 7; i++)
        {
            Response.Write("<td><select style='width: 100px' id='select1' name='" + i + "_morning' size='3' onclick='allow_save()' " + Disable_Shift() + ">" + Print_Options(i, 0, "") + "</select>");
        }
        Response.Write("</tr>");
        #region intermediate
        string needs = ADO.GetFullTable("AI_Optionts", "ID=" + Session["ID"]).Rows[0]["intermediate"].ToString();
        // IF there's not intermediate..
        if (!(needs == null || needs == ""))
        {
            string[] arr = new string[7];
            for (int i = 0; i < 7; i++)
                arr[i] = "";
            foreach (string need in needs.Split('#'))
            {
                string[] param = need.Split('@');
                if (param[1] == "" || param[1] == short_job)
                    arr[int.Parse(param[0])] += param[3] + "@";
            }
            for (int i = 0; i < 7; i++)
                if (arr[i] != "")
                    arr[i] = arr[i].Remove(arr[i].Length - 1, 1);//remove last @

            Response.Write("<tr><td>ביניים</td>");
            for (int i = 0; i < 7; i++)
            {
                Response.Write("<td>");
                if (arr[i] != "")
                    foreach (string shif in arr[i].Split('@'))
                        Response.Write("<table border='3'><tr><td>" + shif + "</td></tr><tr><td><select style='width: 95px' id='select1' name='InterShift' size='3' onclick='allow_save()' " + Disable_Shift() + ">" + Print_Options(i, 1, shif) + "</select></td></tr></table>");
                Response.Write("</td>");
            }
            Response.Write("</tr>");
        }
        #endregion
        Response.Write("<tr><td>ערב<br />" + SE + "-" + EE + "</td>");
        for (int i = 0; i < 7; i++)
        {
            Response.Write("<td><select style='width: 100px' id='select1' name='" + i + "_evening' size='3' onclick='allow_save()' " + Disable_Shift() + ">" + Print_Options(i, 2, "") + "</select>");
        }
        Response.Write("</tr>");

    }
    private string Print_Options(int day, int session, string hours)
    {
        string short_temp = "";
        string temp = "";
        string interstr = "";

        switch (day)
        {
            case 0: temp = "sunday"; short_temp = "SU"; break;
            case 1: temp = "monday"; short_temp = "MO"; break;
            case 2: temp = "tuesday"; short_temp = "TU"; break;
            case 3: temp = "wednesday"; short_temp = "WE"; break;
            case 4: temp = "thursday"; short_temp = "TH"; break;
            case 5: temp = "friday"; short_temp = "FR"; break;
            case 6: temp = "saturday"; short_temp = "SA"; break;
        }
        temp += "_";
        switch (session)
        {
            case 0: temp += "morning"; short_temp += "M"; break;
            case 1: temp += "intermediate"; short_temp += "I#" + hours; interstr = "@" + short_temp.Split('#')[0] + "@" + hours; break;
            case 2: temp += "evening"; short_temp += "E"; break;
        }
        temp = dt.Rows[0][temp].ToString();
        string name = Session["Wname"].ToString();
        if (use_jobs)
            name = short_job + "|" + Session["Wname"].ToString();

        if (temp.Contains(name))
            return "<option value='2" + interstr + "' selected>רוצה</option><option value='1" + interstr + "'>פנוי</option><option value='0" + interstr + "'>לא יכול</option>";
        if (worker.Rows[0]["Shifts_Cant_This"].ToString().Contains(short_temp))
            return "<option value='2" + interstr + "'>רוצה</option><option value='1" + interstr + "'>פנוי</option><option value='0" + interstr + "' selected>לא יכול</option>";
        return "<option value='2" + interstr + "'>רוצה</option><option value='1" + interstr + "' selected>פנוי</option><option value='0" + interstr + "'>לא יכול</option>";

    }

    private string Disable_Shift()
    {
        if (!Allow_Changes)
            return "disabled = 'disabled'";
        return "";
    }
    private string Is_Already_cheaked(int day, string hours)
    {
        string temp = "";
        switch (day)
        {
            case 0: temp = SUI; break;
            case 1: temp = MI; break;
            case 2: temp = TUI; break;
            case 3: temp = WI; break;
            case 4: temp = THI; break;
            case 5: temp = FI; break;
            case 6: temp = SAI; break;

        }
        while (temp != "")
            if (temp.Substring(0, 26).Contains(Session["Wname"].ToString()) && temp.Substring(0, 26).Contains(hours))
                return "checked='checked'";
            else
                temp = temp.Remove(0, 26);
        return "";
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
