using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Send_Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // Makes new MailMessage class, with the adminstrator email.
        MailMessage mm = new MailMessage(new MailAddress(Request.Form["E_Mail"].ToString()), new MailAddress(Request.Form["TO"]));
        // Sets the subject of the e-mail.
        mm.Subject = "משמרון - צור קשר ";
        if((bool)Session["Admin"])
            mm.Subject += Request.Form["id"].ToString();
        // Sets the body of the e-mail.
        mm.IsBodyHtml = true;
        mm.Body = "שלום מנהל, זוהי הודעה מאת דף צור הקשר מהאתר משמרון<br>";
        mm.Body += Request.Form["Comment"].ToString();
        
        // Making new e-mail server.
        SmtpClient client = new SmtpClient("80.179.155.4");
            

        // Trying to send & notify the status.
        try
        {
            client.Send(mm);
            
        }
        catch (Exception ex)
        {
            
        }
        if (Request.Form["id"] == null)
            Response.Redirect("Default.aspx");
        Response.Redirect("shifts_next_week.aspx");


        
    }
}
