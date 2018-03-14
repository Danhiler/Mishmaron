using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Print_Mode : System.Web.UI.Page
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
    public string company_name;

    public string SM;
    public string EM;
    public string SE;
    public string EE;
    public int Length_Of_Boxes;
    public int Length_Of_T_Boxes;
    public int Width_Of_Boxes;
    public string intermediate_Shifts;
    public int week;
    protected void Page_Load(object sender, EventArgs e)
    {
        if((Request.QueryString["week"] !=null) && (ADO.filter(Request.QueryString["week"].ToString()) =="1" ||ADO.filter( Request.QueryString["week"].ToString())=="0"))
            if ((Request.QueryString["ID"] != null) && (ADO.filter(Request.QueryString["ID"].ToString())!=""))
                if ((Request.QueryString["name"] != null) && (ADO.filter(Request.QueryString["name"].ToString()) != ""))
                {
                     DataTable dt = ADO.GetFullTable("Users", "UserName='" + ADO.filter(Request.QueryString["ID"].ToString())+"'");
                    int id = int.Parse(dt.Rows[0]["ID"].ToString());
                    company_name = dt.Rows[0]["Cname"].ToString();
                                            if (Request.QueryString["watch"] != null && ADO.filter(Request.QueryString["watch"].ToString()) != ""  &&ADO.filter(Request.QueryString["week"].ToString())=="1" )
                        {
                            try
                            {
                                string sql = "Update Workers Set Last_Wach='" + DateTime.Now + "' Where ID=" + dt.Rows[0]["ID"] + " And UserID='" + ADO.filter(Request.QueryString["watch"].ToString()) + "'";
                                ADO.ExecuteNonQuery(sql);
                            }
                            catch { }
                            
                        }
                    if (ADO.GetFullTable("Users", "ID=" + id).Rows[0]["FName"].ToString().Equals(Trans_To_hebrew(ADO.filter(Request.QueryString["name"].ToString()))))
                    {
                        week = int.Parse(ADO.filter(Request.QueryString["week"].ToString()));
                        dt = ADO.GetFullTable("Work_Table", " ID=" + id + " And week=" + week);

                        SUM = dt.Rows[0]["sunday_morning"].ToString();
                        MM = dt.Rows[0]["monday_morning"].ToString();
                        TUM = dt.Rows[0]["tuesday_morning"].ToString();
                        WM = dt.Rows[0]["wednesday_morning"].ToString();
                        THM = dt.Rows[0]["thursday_morning"].ToString();
                        FM = dt.Rows[0]["friday_morning"].ToString();
                        SAM = dt.Rows[0]["saturday_morning"].ToString();

                        SUI = dt.Rows[0]["sunday_intermediate"].ToString();
                        MI = dt.Rows[0]["monday_intermediate"].ToString();
                        TUI = dt.Rows[0]["tuesday_intermediate"].ToString();
                        WI = dt.Rows[0]["wednesday_intermediate"].ToString();
                        THI = dt.Rows[0]["thursday_intermediate"].ToString();
                        FI = dt.Rows[0]["friday_intermediate"].ToString();
                        SAI = dt.Rows[0]["saturday_intermediate"].ToString();

                        SUE = dt.Rows[0]["sunday_evening"].ToString();
                        ME = dt.Rows[0]["monday_evening"].ToString();
                        TUE = dt.Rows[0]["tuesday_evening"].ToString();
                        WE = dt.Rows[0]["wednesday_evening"].ToString();
                        THE = dt.Rows[0]["thursday_evening"].ToString();
                        FE = dt.Rows[0]["friday_evening"].ToString();
                        SAE = dt.Rows[0]["saturday_evening"].ToString();

                        dt = ADO.GetFullTable("Options", "ID=" +id);
                        SM = dt.Rows[0]["start_morning_shift"].ToString();
                        EM = dt.Rows[0]["end_morning_shift"].ToString();
                        SE = dt.Rows[0]["start_evening_shift"].ToString();
                        EE = dt.Rows[0]["end_evening_shift"].ToString();
                        Length_Of_Boxes = (int)dt.Rows[0]["Length_Of_Boxes"];
                        Length_Of_T_Boxes = (int)dt.Rows[0]["Length_Of_Temp_Boxes"];
                        intermediate_Shifts = dt.Rows[0]["intermediate_Shifts"].ToString();
                        Width_Of_Boxes = 13;
                    }

                    else
                    {
                        Session.Abandon();
                        Response.Redirect("Default.aspx");
                        
                    }
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
