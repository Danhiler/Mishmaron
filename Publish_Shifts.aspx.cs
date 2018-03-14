using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Publish_Shifts : System.Web.UI.Page
{
    public string week;
    public int num_of_sms;
    public int Width_Of_Boxes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(((bool)Session["Loged_In"]) && ((bool)Session["Admin"])))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        if ((ADO.filter(Request.QueryString["week"]) == null) || (ADO.filter(Request.QueryString["week"].ToString()) != "1" && ADO.filter(Request.QueryString["week"].ToString()) != "0"))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        week = ADO.filter(Request.QueryString["week"].ToString());
        num_of_sms = int.Parse(ADO.GetFullTable("Options", "ID=" + Session["ID"]).Rows[0]["Num_Of_SMS"].ToString());
        Width_Of_Boxes = 13;
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
            int sms_Required = Check_SMS_Required(dr["NameW"].ToString());
            Response.Write(" value='" + sms_Required + "' />(" + sms_Required + ")</td>");
            Response.Write("</tr>");
            i++;
        }
        Response.Write("</table>");

    }
    public int Check_SMS_Required(string Worker_Name)
    {
            string str = Get_Shifts_String(Worker_Name);

            if (str.Length == 6)//no shifts
                return 0;
            if(str.Length%70!=0)
                return ((str.Length / 70) + 1);
            else
                return (str.Length / 70);
    }

    private string Get_Shifts_String(string Worker_Name)
    {
        string htr = "משמרון:\n";//hebrew
        DataTable dt = ADO.GetFullTable("Work_Table", "ID=" + Session["ID"] + " AND week=" + week);
        DateTime date = DateTime.Now;
        if (week == "1")
            while (date.DayOfWeek.ToString() != "Sunday")
                date = date.AddDays(1);
        else
            while (date.DayOfWeek.ToString() != "Sunday")
                date = date.AddDays(-1);

        if (dt.Rows[0]["sunday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " א-בוקר\n"; }
        while (dt.Rows[0]["sunday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " א-" + dt.Rows[0]["sunday_intermediate"].ToString().Substring(dt.Rows[0]["sunday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";

                dt.Rows[0]["sunday_intermediate"] = dt.Rows[0]["sunday_intermediate"].ToString().Remove(dt.Rows[0]["sunday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " א-ביניים\n";

            }
        }
        if (dt.Rows[0]["sunday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " א-ערב\n"; }

        date = date.AddDays(1);
        if (dt.Rows[0]["monday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ב-בוקר\n"; }
        while (dt.Rows[0]["monday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " ב-" + dt.Rows[0]["monday_intermediate"].ToString().Substring(dt.Rows[0]["monday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";

                dt.Rows[0]["monday_intermediate"] = dt.Rows[0]["monday_intermediate"].ToString().Remove(dt.Rows[0]["monday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ב-ביניים\n";

            }
        }
        if (dt.Rows[0]["monday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ב-ערב\n"; }

        date = date.AddDays(1);
        if (dt.Rows[0]["tuesday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ג-בוקר\n"; }
        while (dt.Rows[0]["tuesday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " ג-" + dt.Rows[0]["tuesday_intermediate"].ToString().Substring(dt.Rows[0]["tuesday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";

                dt.Rows[0]["tuesday_intermediate"] = dt.Rows[0]["tuesday_intermediate"].ToString().Remove(dt.Rows[0]["tuesday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ג-ביניים\n";

            }
        }
        if (dt.Rows[0]["tuesday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ג-ערב\n"; }

        date = date.AddDays(1);
        if (dt.Rows[0]["wednesday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ד-בוקר\n"; }
        while (dt.Rows[0]["wednesday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " ד-" + dt.Rows[0]["wednesday_intermediate"].ToString().Substring(dt.Rows[0]["wednesday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";

                dt.Rows[0]["wednesday_intermediate"] = dt.Rows[0]["wednesday_intermediate"].ToString().Remove(dt.Rows[0]["wednesday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ד-ביניים\n";

            }
        }
        if (dt.Rows[0]["wednesday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ד-ערב\n"; }

        date = date.AddDays(1);
        if (dt.Rows[0]["thursday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ה-בוקר\n"; }
        while (dt.Rows[0]["thursday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " ה-" + dt.Rows[0]["thursday_intermediate"].ToString().Substring(dt.Rows[0]["thursday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";

                dt.Rows[0]["thursday_intermediate"] = dt.Rows[0]["thursday_intermediate"].ToString().Remove(dt.Rows[0]["thursday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ה-ביניים\n";

            }
        }
        if (dt.Rows[0]["thursday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ה-ערב\n"; }

        date = date.AddDays(1);
        if (dt.Rows[0]["friday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ו-בוקר\n"; }
        while (dt.Rows[0]["friday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " ו-" + dt.Rows[0]["friday_intermediate"].ToString().Substring(dt.Rows[0]["friday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";

                dt.Rows[0]["friday_intermediate"] = dt.Rows[0]["friday_intermediate"].ToString().Remove(dt.Rows[0]["friday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ו-ביניים\n";

            }
        }
        if (dt.Rows[0]["friday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ו-ערב\n"; }

        date = date.AddDays(1);
        if (dt.Rows[0]["saturday_morning"].ToString().Contains(Worker_Name)) { htr += date.Day + " ש-בוקר\n"; }
        while (dt.Rows[0]["saturday_intermediate"].ToString().Contains(Worker_Name))
        {
            try
            {
                htr += date.Day + " ש-" + dt.Rows[0]["saturday_intermediate"].ToString().Substring(dt.Rows[0]["saturday_intermediate"].ToString().IndexOf(Worker_Name) + Width_Of_Boxes, Width_Of_Boxes - 2) + "\n";

                dt.Rows[0]["saturday_intermediate"] = dt.Rows[0]["saturday_intermediate"].ToString().Remove(dt.Rows[0]["saturday_intermediate"].ToString().IndexOf(Worker_Name), Width_Of_Boxes * 2);
            }
            catch (Exception ex)
            {
                htr += date.Day + " ש-ביניים\n";

            }
        }

        if (dt.Rows[0]["saturday_evening"].ToString().Contains(Worker_Name)) { htr += date.Day + " ש-ערב\n"; }
        if (htr.Length == 0) return "";
        htr = htr.Remove(htr.Length - 2, 2);


        return htr;

    }
   
  
    
}
