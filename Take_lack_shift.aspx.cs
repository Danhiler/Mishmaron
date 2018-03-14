using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Take_lack_shift : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Loged_In"] && (Request.QueryString["ID"] != null) && ADO.filter(Request.QueryString["ID"].ToString()) != "" && Request.QueryString["name"] != null && ADO.filter(Request.QueryString["name"].ToString()) != "")
        {
            string lackID = ADO.filter(Request.QueryString["ID"]);
            DataRow dr = ADO.GetFullTable("shift_lacks", "Lack_ID=" + lackID+"").Rows[0];
            DataTable dt = ADO.GetFullTable("Work_Table", "ID=" + Session["ID"] + " AND week=1");
            string day = GetNameOfDayE(int.Parse(dr["day_s"].ToString()));
            string session = GetSession(dr["session_s"].ToString());
            string name= Trans_To_hebrew(ADO.filter(Request.QueryString["name"]));
            if (!dt.Rows[0][day + "_" + session].ToString().Contains(name))
            {
                string Update_Shift = dt.Rows[0][day + "_" + session].ToString();
                //check if there is a lack
                Shift match_need = FindMatchNeed(dr["job"].ToString(), int.Parse(dr["day_s"].ToString()), GetSessionNum(dr["session_s"].ToString()), ADO.GetFullTable("AI_Optionts", "ID=" + Session["ID"]).Rows[0], dr["session_s"].ToString());
                    if(GetNumOfWorkersIsShift(Update_Shift, dr["job"].ToString() ,dr["session_s"].ToString(),(session=="intermediate"))<match_need.num_of_workers)
                    {
                Sort S = new Sort();
                if (session == "intermediate")
                {
                    Update_Shift += name + dr["session_s"] + "  ";
                    Update_Shift = S.SortString(Update_Shift,true);
                }
                else
                {
                    Update_Shift += name;
                    Update_Shift = S.SortString(Update_Shift,false);
                }
                ADO.ExecuteNonQuery("Update Work_Table Set "+day+"_"+session+"='"+Update_Shift+"' Where ID="+Session["ID"]+" And week=1");
                if (int.Parse(dr["num_of_workers"].ToString()) == 1)
                {
                    ADO.ExecuteNonQuery("Delete From shift_lacks Where Lack_ID=" + lackID);

                }
                else
                    ADO.ExecuteNonQuery("Update shift_lacks Set num_of_workers=" + (int.Parse(dr["num_of_workers"].ToString()) - 1) + " Where Lack_ID=" + lackID);
                    }
            }
            Response.Redirect("lacks.aspx");
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }
    private int GetNumOfWorkersIsShift(string txt, string job, string hours, bool inter)
    {
        int mone = 0;
        if (inter)
        {
            if (job == "")
            {
                while (txt.Contains(hours))
                {
                    mone++;
                    txt = txt.Remove(txt.IndexOf(hours), 13);
                }
            }
            else
            {
                while (txt.Length > 0)
                {
                    string sub = txt.Substring(0, 26);
                    if (sub.Contains(job) && sub.Contains(hours)) mone++;
                    txt = txt.Remove(0, 26);
                }
            }
        }
        else
        {
            if (job == "")
                return txt.Length / 13;
            else
            {
                while (txt.Contains(job))
                {
                    mone++;
                    txt = txt.Remove(txt.IndexOf(job), 13);
                }
                
            }
        }
        return mone;
    }

    private int GetSessionNum(string session)
    {
        if (session == "בוקר")
            return 0;
        if (session == "ערב")
            return 2;
        return 1;
        
    }
    public Shift FindMatchNeed(string job, int day, int section, DataRow AI_Needs, string hours)
    {
        Shift match_need = null;
        string str = AI_Needs[1 + section].ToString();
        foreach (string need in str.Split('#'))
        {
            string[] param = need.Split('@');
            if (job!="")
            {
                if (param[1] == job)
                    if (int.Parse(param[0].ToString()) == day)
                        if (section == 1)
                        {
                            if (param[3] == hours)
                                match_need = new Shift(int.Parse(param[2]), param[1], param[3]);
                        }
                        else
                            match_need = new Shift(int.Parse(param[2]), param[1], "");
            }
            else
            {
                if (int.Parse(param[0].ToString()) == day)
                    if (section == 1)
                    {
                        if (param[3] == hours)
                            match_need = new Shift(int.Parse(param[2]), param[1], param[3]);
                    }
                    else
                        match_need = new Shift(int.Parse(param[2]), param[1], "");
            }
        }
        return match_need;
    }
    private string GetSession(string session)
    {
        if (session == "בוקר")
            return "morning";
        if (session == "ערב")
            return "evening";
        else
            return "intermediate";
    }
    private string GetNameOfDayE(int day)
    {
        switch (day)
        {
            case 0:
                return "sunday";
            case 1:
                return "monday";
            case 2:
                return "tuesday";
            case 3:
                return "wednesday";
            case 4:
                return "thursday";
            case 5:
                return "friday";
            case 6:
                return "saturday";
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
