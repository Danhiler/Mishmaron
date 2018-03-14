using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Updated_User : System.Web.UI.Page
{
    public string userid;
    public string userpass;
    public string full_name;
    public string phone;
    public string company_name;
    public string E_mail;
    public int day;
    public int month;
    public int year;
    public string c;

        protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
        c = Request.Form["C"].ToString();
        DataRow dt = ADO.GetFullTable("Users", "ID=" + Session["ID"]).Rows[0];
        userid = dt["UserName"].ToString();
        userpass = dt["Passw"].ToString();
        full_name = dt["FName"].ToString();
        phone = dt["Phone"].ToString();
        company_name = dt["CName"].ToString();
        E_mail = dt["Email"].ToString();
        day = DateTime.Parse(dt["Date_Of_Birth"].ToString()).Day;
        month = DateTime.Parse(dt["Date_Of_Birth"].ToString()).Month;
        year = DateTime.Parse(dt["Date_Of_Birth"].ToString()).Year;


            DataTable dtUseru=ADO.GetFullTable("Users");
            DataTable dtUserw = ADO.GetFullTable("Workers");
        if (c == "1")
        {
             dtUseru = ADO.GetFullTable("Users", " UserName='" + ADO.filter(Request.Form["USER_ID"].ToString().TrimEnd(' ')) + "'");
             dtUserw = ADO.GetFullTable("Workers", " UserID='" + ADO.filter(Request.Form["USER_ID"].ToString().TrimEnd(' ')) + "'");
        }
        if ((c=="1")&&((dtUseru.Rows.Count > 0) || (dtUserw.Rows.Count > 0)))
            Label1.Text="שם המשתמש שבחרת קיים כבר במערכת";
        else if (!Request.Form["Password2"].ToString().TrimEnd(' ').Equals(ADO.GetFullTable("Users", "ID=" + Session["ID"]).Rows[0]["Passw"].ToString()))
        {
            Label1.Text = "הססמא שהכנסת לא נכונה";
        }
        else
        {
                string sql = "Update Users Set"; 
                switch(int.Parse(c)){
                    case 1:
                        sql += " UserName='" + ADO.filter(Request.Form["USER_ID"].ToString().TrimEnd(' '))+"'";
                            break;
                    case 2:
                           sql += " Passw='" + ADO.filter(Request.Form["Password"].ToString().TrimEnd(' ')) +"'";
                           break;
                    case 3:
                          sql += " FName='" + ADO.filter(Request.Form["Full_Name"].ToString()) +"'";
                          break;
                    case 5:
                        sql += " Email='" + ADO.filter(Request.Form["E_Mail"].ToString().TrimEnd(' ')) +"'";
                          break;
                    case 4:
                        sql += " Cname='" + ADO.filter(Request.Form["Company_Name"].ToString()) +"'";
                        break;
                    case 7:
                        sql += " Phone='"+ADO.filter(Request.Form["phone_start"]) + "-" + ADO.filter(Request.Form["Phone"].ToString()) + "'";
                        break;
                    case 6:
                        sql += " Date_Of_Birth='" + Request.Form["Day"] + "/" + Request.Form["Month"] + "/" + Request.Form["Year"] + "'";
                        break;
                        }
                          sql += " where ID=" + Session["ID"];
                ADO.ExecuteNonQuery(sql);

              dt = ADO.GetFullTable("Users", "ID=" + Session["ID"]).Rows[0];
            Session["Cname"] = dt["CName"];
            Session["Wname"] = dt["FName"];
                Response.Redirect("Change_Details.aspx");
             }
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
                Response.Write("<option>" + i + "</option>");
        }
        public void months()
        {
            for (int i = 1; i < 13; i++)
                Response.Write("<option>" + i + "</option>");
        }
        public void years()
        {
            for (int i = 2010; i > 1900; i--)
                Response.Write("<option>" + i + "</option>");
        }
        public void Area_Codes()
        {
            Response.Write("<option value =050>050</option>");
            Response.Write("<option value =052>052</option>");
            Response.Write("<option value =054>054</option>");
            Response.Write("<option value =056>056</option>");
            Response.Write("<option value =057>057</option>");
            Response.Write("<option value =059>059</option>");
            Response.Write("<option value =1-700>1-700</option>");
            Response.Write("<option value =077>077</option>");
            Response.Write("<option value =09>09</option>");
            Response.Write("<option value =04>04</option>");
            Response.Write("<option value =03>03</option>");
            Response.Write("<option value =02>02</option>");
            Response.Write("<option value =08>08</option>");
        }
}
