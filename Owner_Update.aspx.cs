using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Owner_Update : System.Web.UI.Page
{
    public string ID;
    public string UserName;
    public string PassW;
    public string Max_Workers;
    public string Num_Of_SMS;
    public string Max_Jobs;
    public string Exp_Date;
    protected void Page_Load(object sender, EventArgs e)
    {
          if (Session["Wname"] == null || Session["Cname"] == null || Session["Wname"].ToString() == "" || Session["Cname"].ToString() == "")
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        if ((!Session["Wname"].ToString().Equals("5410c239adb1b45866f162e5ec829ca9")) ||
             (!Session["Cname"].ToString().Equals("2cb6e810b21db557600c5bd1ddba81b2")))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        if (Request.QueryString["id"] != null && ADO.filter(Request.QueryString["id"].ToString()) != "")
        {
            DataTable dt = ADO.GetFullTable("Users", "ID=" + Request.QueryString["ID"]);
            DataTable dr = ADO.GetFullTable("Options", "ID=" + Request.QueryString["ID"]);
            ID = Request.QueryString["ID"].ToString();
            UserName = dt.Rows[0]["UserName"].ToString();
            PassW = dt.Rows[0]["Passw"].ToString();
            Exp_Date = edit_date(dt.Rows[0]["Days_Left"].ToString());
            Max_Workers = dr.Rows[0]["Max_Workers"].ToString();
            Num_Of_SMS = dr.Rows[0]["Num_Of_SMS"].ToString();
            Max_Jobs = dr.Rows[0]["Max_Jobs"].ToString();
            
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

    }
    private string edit_date(string p)
    {
        try
        {
            DateTime date = DateTime.Parse(p);
            return (date.Day + "." + date.Month + "." + date.Year);
        }
        catch {
            if (p == "") return "ללא הגבלה!";
            return p; 
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = hashmd5.getMd5Hash(TextBox1.Text);
    }
}
