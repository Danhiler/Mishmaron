using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;


public partial class Send_Lost_Password : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (ADO.GetFullTable("Workers", "UserID='" + ADO.filter(Request.Form["userid"].ToString()) + "'").Rows.Count != 0)
        { Label1.Text = "צור קשר עם המנהל שלך על מנת לקבל את ססמתך"; }
        else
        {
            DataTable dt = ADO.GetFullTable("Users", "UserName='" + hashmd5.getMd5Hash(ADO.filter(Request.Form["userid"].ToString())) + "'");
            if (dt.Rows.Count == 0 )
            {
                Label1.Text = "שם המשתמש לא קיים במערכת";
            }
            else
            {
                // Makes new MailMessage class, with the adminstrator email.
                MailMessage mm;
                mm = new MailMessage(new MailAddress("info@mishmaron.com"), new MailAddress(dt.Rows[0]["email"].ToString()));
                // Sets the subject of the e-mail.
                mm.SubjectEncoding = System.Text.Encoding.UTF8;
                mm.Subject = "משמרון - שחזור ססמא";
                // Sets the body of the e-mail.
                mm.BodyEncoding = System.Text.Encoding.UTF8;
                mm.IsBodyHtml = true;
                mm.Body = "שלום משתמש יקר!";
                mm.Body += "<br>";
                mm.Body += "הססמא שלך לאתר משמרון היא: ";
                mm.Body += dt.Rows[0]["Passw"].ToString();
                mm.Body += "<br><br>";
                mm.Body += "עבור כל שאלה\\הצעה\\בעיה\\תקלה אתם יכולים לפנות אלינו לאימייל info@mishmaron.com<br> או דרך טופס יצירת קשר באתר ";
                mm.Body += "<a href ='www.mishmaron.com'>www.mishmaron.com</a>";
                mm.Body += "<br>";
                mm.Body += "בכבוד רב";
                mm.Body += "<br>";
                mm.Body += "צוות התמיכה";

                // Making new e-mail server.
                SmtpClient client = new SmtpClient("localhost");
                try
                {
                    client.Send(mm);
                    Label1.Text = "אימייל נשלח בהצלחה";
                }
                catch (Exception x)
                {
                    Label1.Text = "האימייל לא נשלח. אנא פנה אלינו דרך דף יצירת הקשר";
                }


            }
        }
        


    }
}
