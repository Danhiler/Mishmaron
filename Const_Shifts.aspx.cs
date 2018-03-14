using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Const_Shifts : System.Web.UI.Page
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
    public string intermediate_Shifts;
    public int Width_Of_Boxes;
    public bool use_jobs;
    public string short_job;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            DataTable dt = ADO.GetFullTable("Work_Table", " ID=" + Session["ID"] + " And week= 2");

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


            dt = ADO.GetFullTable("Options", "ID=" + (int)Session["ID"]);
            SM = dt.Rows[0]["start_morning_shift"].ToString();
            EM = dt.Rows[0]["end_morning_shift"].ToString();
            SE = dt.Rows[0]["start_evening_shift"].ToString();
            EE = dt.Rows[0]["end_evening_shift"].ToString();
            Length_Of_Boxes = int.Parse(dt.Rows[0]["Length_Of_Boxes"].ToString());
            Length_Of_T_Boxes = int.Parse(dt.Rows[0]["Length_Of_Temp_Boxes"].ToString());
            intermediate_Shifts = dt.Rows[0]["intermediate_Shifts"].ToString();
            use_jobs = bool.Parse(dt.Rows[0]["Use_Jobs"].ToString());
            if (use_jobs && !bool.Parse(Session["Admin"].ToString()))
                short_job = ADO.GetFullTable("Workers", "ID=" + Session["ID"] + " AND NameW='" + Session["Wname"] + "'").Rows[0]["Job"].ToString();

            Width_Of_Boxes = 13;
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }


    }
    public void Workers()
    {
        DataTable dt = ADO.GetFullTable("Workers", "ID=" + Session["ID"]);
        for (int i = 0; i < dt.Rows.Count; i++)
            Response.Write("<option value='" + dt.Rows[i]["NameW"] + "'>" + dt.Rows[i]["NameW"] + "</option>");
    }


}
