using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddWorker : System.Web.UI.Page
{
    public bool use_jobs;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!((bool)Session["Loged_In"]))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        use_jobs = bool.Parse(Session["Use_Jobs"].ToString());

    }
    public void Area_Codes()
    {
        Response.Write("<option value ='050'>050</option>");
        Response.Write("<option value ='052'>052</option>");
        Response.Write("<option value ='054'>054</option>");
        Response.Write("<option value ='056'>056</option>");
        Response.Write("<option value ='057'>057</option>");
        Response.Write("<option value ='059'>059</option>");       
    }
    public void Add_Jobs()
    {
        DataTable dt = ADO.GetFullTable("jobs", "ID=" + Session["ID"].ToString());
        foreach (DataRow dr in dt.Rows)
            Response.Write("<option value ='" + dr["Short_Job"].ToString() + "'>" + dr["Short_Job"].ToString() + "</option>");

    }
}
