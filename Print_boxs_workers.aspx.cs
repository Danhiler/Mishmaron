using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Print_boxs_workers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!(((bool)Session["Loged_In"]) && ((bool)Session["Admin"])))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            
        }
    }
    public void PrintList()
    {

        int i = 0;
        DataTable dt = ADO.GetFullTable("Workers", "ID=" + Session["ID"]);
        Response.Write("<table width='700' border='0' cellspacing='25' align='center' >");
        foreach (DataRow dr in dt.Rows)
        {
            if (i % 4 == 0)
            {
                Response.Write("<tr>");
            }
            Response.Write("<td>");
            Response.Write(" <table id='Table1' border='1' dir='rtl' class='sample' align='center' style='font-family: Arial; font-size: medium; '><tr>");
            Response.Write("<td colspan='2'>www.mishmaron.com</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
        Response.Write("<th>שם עובד</th>");
        Response.Write("<td>" + dr.ItemArray[1].ToString() + "</td>");
        Response.Write("</tr><tr>");
        Response.Write("<th>שם משתמש</th>");
        Response.Write("<td>" + dr.ItemArray[2].ToString() + "</td>");
        Response.Write("</tr><tr>");
        Response.Write("<th>ססמא</th>");
        Response.Write("<td>" + dr.ItemArray[3].ToString() + "</td>");



      
            Response.Write("</tr>");

            Response.Write("</td>");
            if (i % 3 == 0)
            {
                Response.Write("</tr>");
            }
            Response.Write("</table>");
            i++;
        }
        Response.Write("</table>");

    }
}
