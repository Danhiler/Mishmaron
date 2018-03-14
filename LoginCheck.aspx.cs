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
using System.Security.Cryptography;
using System.Text;

public partial class LoginCheck : System.Web.UI.Page
{
    public string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["UN"] != null)
        {
            DataTable dtU = ADO.GetFullTable("Users", " UserName='" + hashmd5.getMd5Hash(ADO.filter(Request.Form["UN"])) +
                                                     "' And Passw='" + ADO.filter(Request.Form["Passw"]) + "'");
                if (dtU.Rows.Count > 0)
                {
                    DataTable doption = ADO.GetFullTable("Options", "ID=" + dtU.Rows[0][0]);
                    Session["ID"] = dtU.Rows[0][0];
                    Session["Admin"] = true;
                    Session["Cname"] = dtU.Rows[0]["CName"];
                    Session["Wname"] = dtU.Rows[0]["FName"];
                    Session["Loged_In"] = true;
                    Session["SMS_Left"] = doption.Rows[0]["Num_Of_SMS"].ToString();
                    Session["Days_Left"] = sum_of_days(DateTime.Parse(dtU.Rows[0]["Days_Left"].ToString()));
                    Session["Use_Jobs"] = bool.Parse(doption.Rows[0]["use_jobs"].ToString());

                    if (Is_First_Before(DateTime.Parse(dtU.Rows[0]["Days_Left"].ToString()), DateTime.Now))
                    {
                        Session["Loged_In"] = false;
                        Response.Write("<script language='javascript'>alert('הרשיון לעסק שלך נגמר, הינך מועבר לדף התשלום על שירותי האתר');window.location =\"http://www.mishmaron.com/Purchase_License.aspx/\";</script>"); 
                    }
                    else
                    Response.Redirect("Shifts_next_week.aspx");
                    

                }
                else
                {
                    DataTable dtW =  ADO.GetFullTable("Workers", " UserID='" + ADO.filter(Request.Form["UN"]) +
                                                         "' And PassW='" + ADO.filter(Request.Form["Passw"]) + "'");
                    if (dtW.Rows.Count > 0)
                    {
                         dtU = ADO.GetFullTable("Users", "ID="+dtW.Rows[0][0]);
                        if (Is_First_Before(DateTime.Parse(dtU.Rows[0]["Days_Left"].ToString()), DateTime.Now))
                        {

                            Label1.Text = "הרשיון לעסק שלך נגמר, צור קשר עם המנהל שלך";
                        }
                        else
                        {
                            DataTable Doption = ADO.GetFullTable("Options", "ID=" + dtW.Rows[0][0]);
                            Session["ID"] = dtW.Rows[0][0];
                            Session["UserID"] = dtW.Rows[0]["UserID"];
                            Session["Admin"] = false;
                            Session["Wname"] = dtW.Rows[0]["NameW"];
                            Session["Cname"] = dtU.Rows[0]["CName"];
                            Session["Loged_In"] = true;
                            Session["Use_Jobs"] = bool.Parse(Doption.Rows[0]["use_jobs"].ToString());
                            Label1.Text = "התחברת בהצלחה, הינך מועבר לדף המשמרות";

                            // check if first login
                            if(DateTime.Parse(dtW.Rows[0]["Last_wach"].ToString()).Year == 1111)
                                Response.Redirect("Guide_worker.aspx");

                            // check if there is any message
                            if (Doption.Rows[0]["Show_Comment"].ToString() == "True")
                                Response.Redirect("Add_Comment.aspx");
                           
                                Response.Redirect("Shifts_next_week.aspx");
                        }
                    }
                    else
                    {
                        if (hashmd5.verifyMd5Hash(Request.Form["UN"], "81dc9bdb52d04dc20036dbd8313ed055") && (hashmd5.verifyMd5Hash(Request.Form["Passw"], "81dc9bdb52d04dc20036dbd8313ed055")))
                        {

                            Session["Wname"] ="5410c239adb1b45866f162e5ec829ca9";
                            Session["Cname"] = "2cb6e810b21db557600c5bd1ddba81b2";
                            Response.Redirect("Owner_page.aspx");
                        }
                        else
                        Label1.Text = "שם משתמש או ססמא שגויים";
                    }
                }
                
            
        }
    }
    private bool check_available(string name)
    {
       DataTable lacks = ADO.GetFullTable("shift_lacks", "ID=" + Session["ID"]);
       DataTable table = ADO.GetFullTable("Work_Table", "ID=" + Session["ID"] + " And Week =1");
        foreach (DataRow lack in lacks.Rows)
        {
            string day = GetNameOfDayE(int.Parse(lack["day_s"].ToString()));
            if (!table.Rows[0][day + "_morning"].ToString().Contains(name) && !table.Rows[0][day + "_intermediate"].ToString().Contains(name) && !table.Rows[0][day + "_evening"].ToString().Contains(name) && ((name.Contains(lack["job"].ToString())) || (!name.Contains('|'))))
                return true;
        }
        return false;
    }
    private string GetNameOfDayE(int day)
    {
        switch (day)
        {
            case 0:
                return "Sunday";
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thursday";
            case 5:
                return "Friday";
            case 6:
                return "Saturday";
            default:
                return "";

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
    public bool Is_First_Before(DateTime str1, DateTime str2)
    {
        if (str1.Year < str2.Year)
            return true;
        if (str1.Year > str2.Year)
            return false;
        if (str1.Month < str2.Month)
            return true;
        if (str1.Month > str2.Month)
            return false;
        if (str1.Day < str2.Day)
            return true;
        if (str1.Day > str2.Day)
            return false;

        if (str1.Hour < str2.Hour)
            return true;
        if (str1.Hour > str2.Hour)
            return false;
        if (str1.Minute < str2.Minute)
            return true;
        if (str1.Minute > str2.Minute)
            return false;

        return false;

    }
}
