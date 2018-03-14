using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Swichers_Page : System.Web.UI.Page
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
    public bool use_jobs;
    public string short_job;

    public string week;


    public string un;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!((bool)Session["Loged_In"]))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
        if(Request.QueryString["week"]==null)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
        if (ADO.filter(Request.QueryString["week"]) != "1" && ADO.filter(Request.QueryString["week"]) != "0")
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        week = ADO.filter(Request.QueryString["week"]);
        DataTable dr = ADO.GetFullTable("Options", "ID=" + (int)Session["ID"]);
        SM = dr.Rows[0]["start_morning_shift"].ToString();
        EM = dr.Rows[0]["end_morning_shift"].ToString();
        SE = dr.Rows[0]["start_evening_shift"].ToString();
        EE = dr.Rows[0]["end_evening_shift"].ToString();
        Length_Of_Boxes = (int)dr.Rows[0]["Length_Of_Boxes"];
        Length_Of_T_Boxes = (int)dr.Rows[0]["Length_Of_Temp_Boxes"];
        use_jobs = bool.Parse(dr.Rows[0]["Use_Jobs"].ToString());
        intermediate_Shifts = bool.Parse(dr.Rows[0]["intermediate_Shifts"].ToString());
        Width_Of_Boxes = 13;
        DataTable workers = ADO.GetFullTable("Workers", "ID=" + Session["ID"]);
        DataTable dt = ADO.GetFullTable("Work_Table", " ID=" + Session["ID"] + " And week=" + week);
        string the_week = "Shifts_This";
        if (week == "1")
            the_week = "Shifts_Next";
        foreach (DataRow worker in workers.Rows)
        {
            string Wname;
            if(use_jobs)
                Wname = worker["Job"].ToString() + "|" + worker["NameW"].ToString();
            else
             Wname = worker["NameW"].ToString();
            for (int i = Wname.Length; i < 13; i++)
                Wname += " ";

            string[] param = worker[the_week].ToString().Split('@');
            for (int i = 0; i < param.Length; i++)
            {
                switch (param[i].Split('#')[0])
                {
                    case "SUM": if (!dt.Rows[0]["sunday_morning"].ToString().Contains(Wname)) SUM += Wname; break;
                    case "MOM": if (!dt.Rows[0]["monday_morning"].ToString().Contains(Wname)) MM += Wname; break;
                    case "TUM": if (!dt.Rows[0]["tuesday_morning"].ToString().Contains(Wname)) TUM += Wname; break;
                    case "WEM": if (!dt.Rows[0]["wednesday_morning"].ToString().Contains(Wname)) WM += Wname; break;
                    case "THM": if (!dt.Rows[0]["thursday_morning"].ToString().Contains(Wname)) THM += Wname; break;
                    case "FRM": if (!dt.Rows[0]["friday_morning"].ToString().Contains(Wname)) FM += Wname; break;
                    case "SAM": if (!dt.Rows[0]["saturday_morning"].ToString().Contains(Wname)) SAM += Wname; break;

                    case "SUI": if (!dt.Rows[0]["sunday_intermediate"].ToString().Contains(Wname)) SUI += Wname+param[i].Split('#')[1].ToString(); break;
                    case "MOI": if (!dt.Rows[0]["monday_intermediate"].ToString().Contains(Wname)) MI += Wname + param[i].Split('#')[1].ToString(); break;
                    case "TUI": if (!dt.Rows[0]["tuesday_intermediate"].ToString().Contains(Wname)) TUI += Wname + param[i].Split('#')[1].ToString(); break;
                    case "WEI": if (!dt.Rows[0]["wednesday_intermediate"].ToString().Contains(Wname)) WI += Wname + param[i].Split('#')[1].ToString(); break;
                    case "THI": if (!dt.Rows[0]["thursday_intermediate"].ToString().Contains(Wname)) THI += Wname + param[i].Split('#')[1].ToString(); break;
                    case "FRI": if (!dt.Rows[0]["friday_intermediate"].ToString().Contains(Wname)) FI += Wname + param[i].Split('#')[1].ToString(); break;
                    case "SAI": if (!dt.Rows[0]["saturday_intermediate"].ToString().Contains(Wname)) SAI += Wname + param[i].Split('#')[1].ToString(); break;

                    case "SUE": if (!dt.Rows[0]["sunday_evening"].ToString().Contains(Wname)) SUE += Wname; break;
                    case "MOE": if (!dt.Rows[0]["monday_evening"].ToString().Contains(Wname)) ME += Wname; break;
                    case "TUE": if (!dt.Rows[0]["tuesday_evening"].ToString().Contains(Wname)) TUE += Wname; break;
                    case "WEE": if (!dt.Rows[0]["wednesday_evening"].ToString().Contains(Wname)) WE += Wname; break;
                    case "THE": if (!dt.Rows[0]["thursday_evening"].ToString().Contains(Wname)) THE += Wname; break;
                    case "FRE": if (!dt.Rows[0]["friday_evening"].ToString().Contains(Wname)) FE += Wname; break;
                    case "SAE": if (!dt.Rows[0]["saturday_evening"].ToString().Contains(Wname)) SAE += Wname; break;

                }
            }
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
