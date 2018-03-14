using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Options : System.Web.UI.Page
{
    public string sm;
    public string em;
    public string se;
    public string ee;
    public int Length_Of_Boxes;
    public int Length_Of_T_Boxes;
    public bool intermediate_Shifts;
    public bool const_Shifts;
    public int max_workers;
    public bool use_jobs;
    public int deadline;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            DataTable dt = ADO.GetFullTable("Options", "ID=" + (int)Session["ID"]);
            this.sm = dt.Rows[0]["start_morning_shift"].ToString();
            this.em = dt.Rows[0]["end_morning_shift"].ToString();
            this.se = dt.Rows[0]["start_evening_shift"].ToString();
            this.ee = dt.Rows[0]["end_evening_shift"].ToString();
            max_workers = int.Parse(dt.Rows[0]["Max_Workers"].ToString());
            Length_Of_Boxes = (int)dt.Rows[0]["Length_Of_Boxes"];
            Length_Of_T_Boxes = (int.Parse(dt.Rows[0]["Length_Of_Temp_Boxes"].ToString())/2);
            intermediate_Shifts = bool.Parse(dt.Rows[0]["intermediate_Shifts"].ToString());
            const_Shifts = bool.Parse(ADO.GetFullTable("Work_Table", "week=2 And ID=" + (int)Session["ID"]).Rows[0]["Allow_Changes"].ToString());
            use_jobs = bool.Parse(dt.Rows[0]["Use_Jobs"].ToString());
            deadline = int.Parse(dt.Rows[0]["shift_until"].ToString());
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
           
        }

    }
    public void deadlines()
    {
        Response.Write("<option value ='"+deadline+"'>"+getday(deadline)+"</option>");
        for (int i = 1; i < 8; i++)
            Response.Write("<option value ='" + i + "'>" + getday(i) + "</option>");
    
    }

    private string getday(int p)
    {
        switch (p)
        {
            case 1: return "ראשון";
            case 2: return "שני"; 
            case 3: return "שלישי"; 
            case 4: return "רביעי"; 
            case 5: return "חמישי"; 
            case 6: return "שישי"; 
            case 7: return "שבת"; 
            default: return "error";
        }
    }
}
