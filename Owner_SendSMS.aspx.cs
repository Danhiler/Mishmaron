using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Owner_SendSMS : System.Web.UI.Page
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

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SMS_Message ss = new SMS_Message(TextBox2.Text, TextBox1.Text, TextBox3.Text);
        if (ss.Check_Message())
        {
            if (ss.Send())
            {
                Label1.Text = "ההודעה נשלחה בהצלחה";
                ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS=" + (int.Parse(ADO.GetFullTable("Options", "ID=29").Rows[0]["Num_Of_SMS"].ToString()) - 1)+" Where ID=29");
            }
            else
                Label1.Text = "שליחת ההודעה נכשלה";
        }
        else
            Label1.Text = "הודעה לא תקינה";
        
    }
}
