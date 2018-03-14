using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class publish_emergency : System.Web.UI.Page
{
    public string week;
    public int num_of_sms;
    public int Width_Of_Boxes;
    public DataTable lacks;
    public DataTable table;
    public bool use_jobs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(((bool)Session["Loged_In"]) && ((bool)Session["Admin"])))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        DataTable doption= ADO.GetFullTable("Options", "ID=" + Session["ID"]);
        use_jobs = bool.Parse(doption.Rows[0]["Use_Jobs"].ToString());
        num_of_sms = int.Parse(doption.Rows[0]["Num_Of_SMS"].ToString());
        lacks = ADO.GetFullTable("shift_lacks", "ID="+Session["ID"]);
        table = ADO.GetFullTable("Work_Table","ID="+Session["ID"]+" And Week =1");
        Width_Of_Boxes = 13;

    }
    public void Print_Table()
    {
        int i = 0;
        DataTable dt = ADO.GetFullTable("Workers", "ID=" + Session["ID"] + "");
        Response.Write("<table width='300' class='sample'>");
        Response.Write("<tr>");
        Response.Write("<th bgcolor='92a4b6'>שם עובד</th>");
        Response.Write("<th bgcolor='92a4b6'>אימייל</th>");
        Response.Write("<th bgcolor='92a4b6'>SMS</th>");
        Response.Write("</tr>");
        foreach (DataRow dr in dt.Rows)
        {
            Response.Write("<tr>");
            Response.Write("<td>" + dr["NameW"].ToString() + "</td>");
            Response.Write("<td align='center'><input id='Checkboxe" + i + "' name='email" + i + "' type='checkbox' ");
            if (dr["E_Mail"].ToString() == "")
                Response.Write("disabled='disabled' ");
            else
                Response.Write("checked='checked' ");
            Response.Write("/></td>");
            Response.Write("<td align='center'> <input id='Checkboxs" + i + "'name='sms" + i + "' type='checkbox' ");
            if (dr["Phone"].ToString() == "") Response.Write("disabled='disabled' ");
            string name = dr["NameW"].ToString();
            if (use_jobs)
                name = dr["job"].ToString() + "|" + dr["NameW"].ToString();
            if (check_available(name)) Response.Write("checked='checked' ");
            Response.Write(" ></td>");
            Response.Write("</tr>");
            i++;
        }
        Response.Write("</table>");

    }
    private bool check_available(string name)
    {
        foreach (DataRow lack in lacks.Rows)
        {
            string day = GetNameOfDayE(int.Parse(lack["day_s"].ToString()));
            if (!table.Rows[0][day + "_morning"].ToString().Contains(name)&&!table.Rows[0][day + "_intermediate"].ToString().Contains(name)&&!table.Rows[0][day + "_evening"].ToString().Contains(name)&&((name.Contains(lack["job"].ToString())) || (!name.Contains('|'))))
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
}
