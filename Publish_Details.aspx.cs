using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Publish_Details : System.Web.UI.Page
{
    public int num_of_sms;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(((bool)Session["Loged_In"]) && ((bool)Session["Admin"])))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
       
        num_of_sms = int.Parse(ADO.GetFullTable("Options", "ID=" + Session["ID"]).Rows[0]["Num_Of_SMS"].ToString()); 
    }
    public void Print_Table()
    {
        int i = 0;
        DataTable dt = ADO.GetFullTable("Workers", "ID=" + Session["ID"]+"");
        Response.Write("<table width='300' class='sample'>");
        Response.Write("<tr>");
        Response.Write("<th bgcolor='92a4b6'>שם עובד</th>");
        Response.Write("<th bgcolor='92a4b6'>SMS</th>");
        Response.Write("</tr>");
        foreach (DataRow dr in dt.Rows)
        {
            Response.Write("<tr>");
            Response.Write("<td>" + dr["NameW"].ToString() + "</td>");
            Response.Write("<td align='center'> <input id='Checkboxs" + i + "'name='sms" + i + "' type='checkbox' ");
            if (dr["Phone"].ToString() == "")
                Response.Write("disabled='disabled' ");
            int sms_Required = Check_SMS_Required(dr["NameW"].ToString(), dr["UserID"].ToString(), dr["PassW"].ToString());
            Response.Write(" value='" + sms_Required + "' /></td>");
            Response.Write("</tr>");
            i++;
        }
        Response.Write("</table>");

    }
    public int Check_SMS_Required(string Worker_Name, string Worker_User, string Worker_Password)
    {
            string str = Get_Shifts_String(Worker_Name, Worker_User,  Worker_Password);

            if (str.Length == 6)//no shifts
                return 0;
            if(str.Length%70!=0)
                return ((str.Length / 70) + 1);
            else
                return (str.Length / 70);
    }

    private string Get_Shifts_String(string Worker_Name, string Worker_User, string Worker_Password)
    {
        string htr = "www.mishmaron.com\n";//hebrew
        htr += "שם משתמש: " + Worker_User + "\n";
        htr += "ססמא: " + Worker_Password ;

        return htr;

    
    }
}