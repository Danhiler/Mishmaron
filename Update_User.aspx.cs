using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Update_User : System.Web.UI.Page
{
    public string userid;
    public string userpass;
    public string full_name;
    public string company_name;
    public string phone;
    public string E_mail;
    public int day;
    public int month;
    public int year;
    public string c;
    protected void Page_Load(object sender, EventArgs e)
    {
                if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            if ((!(bool)Session["Admin"]) || (Request.QueryString["C"] == null) || (Request.QueryString["C"] == "") || (int.Parse(Request.QueryString["C"]) > 7) || (int.Parse(Request.QueryString["C"]) <2))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
           
        }
        c = Request.QueryString["C"];
        DataRow dt = ADO.GetFullTable("Users", "ID=" + Session["ID"]).Rows[0];
        this.userid = dt["UserName"].ToString();
        this.userpass = dt["Passw"].ToString();
        this.full_name = dt["FName"].ToString();
        this.company_name = dt["CName"].ToString();
        this.phone = dt["Phone"].ToString();
        this.E_mail = dt["Email"].ToString();
        this.day= DateTime.Parse(dt["Date_Of_Birth"].ToString()).Day;
        this.month = DateTime.Parse(dt["Date_Of_Birth"].ToString()).Month;
        this.year = DateTime.Parse(dt["Date_Of_Birth"].ToString()).Year;

        }
                else
                {
                    Session.Abandon();
                    Response.Redirect("Default.aspx");
                   
                }
    }
    public void days()
    {
        for (int i = 1; i < 32; i++)
            Response.Write("<option value="+i+">"+ + i + "</option>");
    }
    public void months()
    {
        for (int i = 1; i < 13; i++)
            Response.Write("<option value=" + i + ">" + i + "</option>");
    }
    public void years()
    {
        for (int i = 2010; i > 1900; i--)
            Response.Write("<option value=" + i + ">" + i + "</option>");
    }
    public void Area_Codes()
    {
        Response.Write("<option value =050>050</option>");
        Response.Write("<option value =052>052</option>");
        Response.Write("<option value =054>054</option>");
        Response.Write("<option value =056>056</option>");
        Response.Write("<option value =057>057</option>");
        Response.Write("<option value =059>059</option>");
    }
}
