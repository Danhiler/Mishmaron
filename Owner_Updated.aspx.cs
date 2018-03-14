using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Owner_Updated : System.Web.UI.Page
{
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
        if(ADO.filter(Request.Form["UserName"].ToString())!=ADO.filter(Request.Form["Old_UserName"].ToString()))
        {
        DataTable dtUseru = ADO.GetFullTable("Users", "UserName='" + ADO.filter(Request.Form["UserName"].ToString()) + "'");
        if (dtUseru.Rows.Count > 0)
        {
            Response.Write("<script language='javascript'>alert('שם המשתמש שבחרת קיים כבר במערכת');history.go(-1)</script>");
        }
        }
            DataTable dt = ADO.GetFullTable("Users", "ID=" + ADO.filter(Request.Form["ID"].ToString()));
            DataTable dr = ADO.GetFullTable("Options", "ID=" + ADO.filter(Request.Form["ID"].ToString()));
            
            //date
            string exp_date = dt.Rows[0]["Days_Left"].ToString() ;
            if (int.Parse(Request.Form["Exp_days"].ToString()) != 0)
            {
                exp_date = DateTime.Now.AddDays(double.Parse(Request.Form["Exp_days"].ToString())).ToString();
                if (dt.Rows[0]["Days_Left"].ToString() != "")
                    exp_date = DateTime.Parse(dt.Rows[0]["Days_Left"].ToString()).AddDays(double.Parse(Request.Form["Exp_days"].ToString())).ToString();
            }
            if (exp_date != "")
                exp_date = ", Days_Left='" + exp_date + "'";
            //SMS
            int system_sms = int.Parse(ADO.GetFullTable("Options", "ID=29").Rows[0]["Num_Of_SMS"].ToString());
            int your_sms = int.Parse(dr.Rows[0]["Num_Of_SMS"].ToString());
            if (ADO.filter(Request.Form["ID"].ToString()) != "1")// add sms for the member
            {
                system_sms -= int.Parse(Request.Form["Num_Of_SMS"].ToString());
                ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS="+system_sms+" where ID=29");
            }
                your_sms += int.Parse(Request.Form["Num_Of_SMS"].ToString());

                string sql_o = "Update Options Set Num_Of_SMS=" + your_sms +
                    ", Max_Workers=" + ADO.filter(Request.Form["Max_Workers"].ToString()) +
                    ", Max_Jobs=" + ADO.filter(Request.Form["Max_Jobs"].ToString()) +
                    " where ID=" + ADO.filter(Request.Form["ID"].ToString()) + "";
            ADO.ExecuteNonQuery(sql_o);

            string sql_u = "Update Users Set UserName='" + ADO.filter(Request.Form["UserName"].ToString()) +
                "', Passw='"+ADO.filter(Request.Form["Passw"].ToString())+
                "'"+exp_date+" where ID=" + ADO.filter(Request.Form["ID"].ToString()) + "";
            ADO.ExecuteNonQuery(sql_u);

            Response.Redirect("Owner_Page.aspx");
        
    }
}
