using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddWorker : System.Web.UI.Page
{
    public System.Data.DataRow dr;
    public string name;
    public string IDw;
    public string pass;
    public string phone;
    public string job;
    public bool use_jobs;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Loged_In"])
        {
            
            //אם לא הועבר מספר משתמש למחיקה
            if (Request.QueryString["ID"] == null || Request.QueryString["ID"].ToString() == "")
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
                
            }
           string query = ADO.filter(Request.QueryString["ID"]);
            DataTable dt = ADO.GetFullTable("Workers", "UserID='" + query.ToString() + "'");
            if (dt.Rows.Count >= 1)
            {
               use_jobs= bool.Parse(Session["Use_Jobs"].ToString());
                name = dt.Rows[0]["nameW"].ToString();
                IDw = dt.Rows[0]["UserID"].ToString().TrimEnd(' ');
                pass = dt.Rows[0]["PassW"].ToString().TrimEnd(' ');
                phone = dt.Rows[0]["Phone"].ToString().TrimEnd(' ');
                job = dt.Rows[0]["Job"].ToString().TrimEnd(' ');
                if (phone == "") phone = "בחר-";
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

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
