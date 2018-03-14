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
using System.Net.Mail;


public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Request.Form["USER_ID"] != null)
            {
                DateTime dob = new DateTime(int.Parse(Request.Form["Year"]), int.Parse(Request.Form["Month"]), int.Parse(Request.Form["Day"]));
               
                string strSQL = "Insert INTO  Users (UserName, Passw, FName, Phone, Email, Cname, Date_Of_Birth, Reg_Date, Days_Left)" +
                                " values ('" + hashmd5.getMd5Hash(ADO.filter(Request.Form["USER_ID"].ToString().TrimEnd(' '))) + "','" +
                                               ADO.filter(Request.Form["Password"].ToString().TrimEnd(' ')) + "','" +
                                               ADO.filter(Request.Form["Full_Name"].ToString()) + "','" +
                                               ADO.filter(Request.Form["phone_start"])+"-"+ADO.filter(Request.Form["Phone"].ToString()) + "','" +
                                               ADO.filter( Request.Form["E_Mail"].ToString().TrimEnd(' ')) + "','" +
                                               ADO.filter(Request.Form["Company_Name"].ToString()) + "','" +
                                               dob + "','"+
                                               DateTime.Now + "','"+
                                              DateTime.Now.AddDays(14)+"')";
                ADO.ExecuteNonQuery(strSQL);

                DataTable dt = ADO.GetFullTable("Users", " UserName='" + hashmd5.getMd5Hash(ADO.filter(Request.Form["USER_ID"].ToString().TrimEnd(' '))) + "'");
                strSQL = "Insert INTO  Work_Table(Allow_Changes, week, ID) values('0','0','" + dt.Rows[0][0] + "')";
                ADO.ExecuteNonQuery(strSQL);
                strSQL = "Insert INTO  Work_Table(Allow_Changes, week, ID) values('1','1','" + dt.Rows[0][0] + "')";
                ADO.ExecuteNonQuery(strSQL);
                strSQL = "Insert INTO  Work_Table(Allow_Changes, week, ID) values('0','2','" + dt.Rows[0][0] + "')";
                ADO.ExecuteNonQuery(strSQL);
                strSQL = "Insert INTO  Options(ID, start_morning_shift, end_morning_shift, start_evening_shift, end_evening_shift, Length_Of_Boxes, Length_Of_Temp_Boxes, intermediate_Shifts, Max_Workers, Max_Jobs, Last_Updated, AL_Sunday, AL_Monday, AL_Tuesday, AL_Wednesday, AL_Thursday, AL_Friday, AL_Saturday) values('" + dt.Rows[0][0] + "','10:00','17:00','17:00','23:00','8' ,'4', '0',30 , 5 ,'"+DateTime.Now+"',1,1,1,1,0,0,0)";
                ADO.ExecuteNonQuery(strSQL);
                strSQL = "Insert INTO  AI_Optionts(ID) values('" + dt.Rows[0][0] + "')";
                ADO.ExecuteNonQuery(strSQL);

                send_email();

                //update sessions
                Session["ID"] = dt.Rows[0][0];
                Session["Admin"] = true;
                Session["Cname"] = dt.Rows[0]["CName"];
                Session["Wname"] = dt.Rows[0]["FName"];
                Session["Loged_In"] = true;
                Session["Use_Jobs"] = false;
                Session["SMS_Left"] = 0;
                Session["Days_Left"] = sum_of_days(DateTime.Parse(dt.Rows[0]["Days_Left"].ToString()));

                //redirect to Guide page
                Response.Redirect("Guide_Admin.aspx");


            
        }
        
    }
    public int sum_of_days(DateTime dob)//return the number of days until this date
    {
        int count = 0;
        int year = DateTime.Now.Year;
        while (dob.Year > year)
        {
            count += 365;
            year++;
        }
        count += dob.DayOfYear - DateTime.Now.DayOfYear;

        return count;
    }
    public void send_email()
    {
        try
        {
        // Makes new MailMessage class, with the adminstrator email.
        MailMessage mm = new MailMessage(new MailAddress("info@mishmaron.com"), new MailAddress(Request.Form["E_Mail"].ToString().TrimEnd(' ')));
        // Sets the subject of the e-mail.
        mm.SubjectEncoding = System.Text.Encoding.UTF8;
        mm.Subject = "משמרון - תודה שנרשמת ";
        // Sets the body of the e-mail.
        mm.BodyEncoding = System.Text.Encoding.UTF8;
        mm.IsBodyHtml = true;
        mm.Body = "<b>";
        mm.Body +="שלום ";
        mm.Body += Request.Form["Full_Name"].ToString();
        mm.Body += "</b>";
        mm.Body += "<br>";
        mm.Body +="אנחנו שמחים שנרשמת למשמרון. מעכשיו תוכל לארגן סידור עבודה לעבודיך בקלות וביעילות.  ";
        mm.Body += "<br>";
        mm.Body += "<br>";
        mm.Body += "שם המשתמש שלך באתר הוא :";
        mm.Body += Request.Form["USER_ID"].ToString();
        mm.Body += "<br>";
        mm.Body += "הססמא שלך באתר היא :";
        mm.Body += Request.Form["Password"].ToString();
        mm.Body += "<br>";
        mm.Body += "<br>";
        mm.Body += "צוות האתר יעשה כל שביכולתו כדי לספק לך את השירות הטוב ביותר.";
        mm.Body += "<br>";
        mm.Body += "אם הינך נתקל בבעיה כלשהי או לכל צורך אחר שלח אי-מייל לכתובת: ";
        mm.Body += "info@mishmaron.com";
        mm.Body += "<br>";
        mm.Body += "<br>";
        mm.Body += "<a href='www.mishmaron.com'>www.mishmaron.com</a>";
        mm.Body += "<br>";
        mm.Body += "בכבוד רב";
        mm.Body += "<br>";
        mm.Body += "צוות משמרון";


        // Making new e-mail server.
        SmtpClient client = new SmtpClient("localhost");


        // Trying to send & notify the status.
            client.Send(mm);
        }
        catch (Exception)
        {
        }
    }
}
