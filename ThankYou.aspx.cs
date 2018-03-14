using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ThankYou_SMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if((bool)Session["Admin"])
        {
        DataRow dr = ADO.GetFullTable("Users", "ID=" + Session["ID"]).Rows[0];
        DataTable dt = ADO.GetFullTable("Payments", "Full_name='" + dr["FName"].ToString() + "'");
        foreach (DataRow payment in dt.Rows)
        {
            int System_sms = int.Parse(ADO.GetFullTable("Options", "ID=29").Rows[0]["Num_Of_SMS"].ToString());
            int Your_sms = int.Parse(ADO.GetFullTable("Options", "ID=" + Session["ID"]).Rows[0]["Num_Of_SMS"].ToString());
            if(!((bool)payment["redeemed"]))
            switch (int.Parse(payment["Amount"].ToString()))
            {
                case 29://sms small
                    ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS=" + (System_sms - 40) + " Where ID=29");
                    ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS=" + (Your_sms + 40) + " Where ID=" + Session["ID"]);
                    ADO.ExecuteNonQuery("Update Payments Set redeemed =1, redeemed_ID='" + Session["ID"] + "' WHERE Payment_ID='" + payment["Payment_ID"] + "'");
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "אימות הרכישה בוצעה בהצלחה!";
                    Label1.Text += "<br> חשבונך זוכה ב 40 הודעות";
                    Session["SMS_Left"] = 40 + int.Parse(Session["SMS_Left"].ToString());
                    break;

                case 49://sms medium
                    ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS=" + (System_sms - 90) + " Where ID=29");
                    ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS=" + (Your_sms + 90) + " Where ID=" + Session["ID"]);
                    ADO.ExecuteNonQuery("Update Payments Set redeemed =1, redeemed_ID='" + Session["ID"] + "' WHERE Payment_ID='" + payment["Payment_ID"] + "'");
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "אימות הרכישה בוצעה בהצלחה!";
                    Label1.Text += "<br> חשבונך זוכה ב 90 הודעות";
                    Session["SMS_Left"] = 90 + int.Parse(Session["SMS_Left"].ToString());
                    break;

                case 69://sms big
                    ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS=" + (System_sms - 150) + " Where ID=29");
                    ADO.ExecuteNonQuery("Update Options Set Num_Of_SMS=" + (Your_sms + 150) + " Where ID=" + Session["ID"]);
                    ADO.ExecuteNonQuery("Update Payments Set redeemed =1, redeemed_ID='" + Session["ID"] + "' WHERE Payment_ID='" + payment["Payment_ID"] + "'");
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "אימות הרכישה בוצעה בהצלחה!";
                    Label1.Text += "<br> חשבונך זוכה ב 150 הודעות";
                    Session["SMS_Left"] = 150 + int.Parse(Session["SMS_Left"].ToString());
                    break;

                case 147://license small
                    if(Is_First_Before(DateTime.Parse(dr["Days_Left"].ToString()),DateTime.Now))
                        ADO.ExecuteNonQuery("Update Users Set Days_Left='" + DateTime.Now.AddDays(90) + "' Where ID=" + Session["ID"]);
                else
                    ADO.ExecuteNonQuery("Update Users Set Days_Left='" + DateTime.Parse(dr["Days_Left"].ToString()).AddDays(90) + "' Where ID=" + Session["ID"]);
                    ADO.ExecuteNonQuery("Update Payments Set redeemed =1, redeemed_ID='" + Session["ID"] + "' WHERE Payment_ID='" + payment["Payment_ID"] + "'");
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "אימות הרכישה בוצעה בהצלחה!";
                    Label1.Text += "<br>חשבונך זוכה ב 90 ימים ";
                    Session["Loged_In"] = true;
                    Session["Days_Left"] = sum_of_days(DateTime.Parse(dr["Days_Left"].ToString()).AddDays(90));
                    break;

                case 264://license medium
                    if (Is_First_Before(DateTime.Parse(dr["Days_Left"].ToString()), DateTime.Now))
                        ADO.ExecuteNonQuery("Update Users Set Days_Left='" + DateTime.Now.AddDays(180) + "' Where ID=" + Session["ID"]);
                    else
                        ADO.ExecuteNonQuery("Update Users Set Days_Left='" + DateTime.Parse(dr["Days_Left"].ToString()).AddDays(180) + "' Where ID=" + Session["ID"]);
                    ADO.ExecuteNonQuery("Update Payments Set redeemed =1, redeemed_ID='" + Session["ID"] + "' WHERE Payment_ID='" + payment["Payment_ID"] + "'");
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "אימות הרכישה בוצעה בהצלחה!";
                    Label1.Text += "<br> חשבונך זוכה ב180 ימים";
                    Session["Loged_In"] = true;
                    Session["Days_Left"] = sum_of_days(DateTime.Parse(dr["Days_Left"].ToString()).AddDays(180));
                    break;

                case 399://license big
                    if (Is_First_Before(DateTime.Parse(dr["Days_Left"].ToString()), DateTime.Now))
                        ADO.ExecuteNonQuery("Update Users Set Days_Left='" + DateTime.Now.AddDays(360) + "' Where ID=" + Session["ID"]);
                    else
                        ADO.ExecuteNonQuery("Update Users Set Days_Left='" + DateTime.Parse(dr["Days_Left"].ToString()).AddDays(360) + "' Where ID=" + Session["ID"]);
                    ADO.ExecuteNonQuery("Update Payments Set redeemed =1, redeemed_ID='" + Session["ID"] + "' WHERE Payment_ID='" + payment["Payment_ID"] + "'");
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "אימות הרכישה בוצעה בהצלחה!";
                    Label1.Text += "<br> חשבונך זוכה ב 360 ימים";
                    Session["Loged_In"] = true;
                    Session["Days_Left"] = sum_of_days(DateTime.Parse(dr["Days_Left"].ToString()).AddDays(360));
                    break;

                default:
                    break;
            }
        }
        }
            else
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");

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
