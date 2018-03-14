using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Change_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }
    public void Prit_Table()
    {
                if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
        DataTable dt = ADO.GetFullTable("Users", "ID=" + Session["ID"]);
       
        Response.Write("<table width='400' class='sample'>");
        Response.Write("<tr>");
        Response.Write("<th>ססמא</th>");
        Response.Write("<th>*******</th>");
        Response.Write("<td> <a href ='Update_User.aspx?C=" + 2 + "'><img src='Pictures/edit.gif' border='0'></a></td>");
        Response.Write("</tr>");

        Response.Write("<tr>");
        Response.Write("<th>שם מלא</th>");
        Response.Write("<th>" + dt.Rows[0]["FName"] + "</th>");
        Response.Write("<td> <a href ='Update_User.aspx?C=" + 3 + "'><img src='Pictures/edit.gif' border='0'></a></td>");
        Response.Write("</tr>");

        Response.Write("<tr>");
        Response.Write("<th>שם חברה</th>");
        Response.Write("<th>" + dt.Rows[0]["CName"] + "</th>");
        Response.Write("<td> <a href ='Update_User.aspx?C=" + 4 + "'><img src='Pictures/edit.gif' border='0'></a></td>");
        Response.Write("</tr>");

        Response.Write("<tr>");
        Response.Write("<th>פלאפון</th>");
        Response.Write("<th>" + dt.Rows[0]["Phone"] + "</th>");
        Response.Write("<td> <a href ='Update_User.aspx?C=" + 7 + "'><img src='Pictures/edit.gif' border='0'></a></td>");
        Response.Write("</tr>");

        Response.Write("<tr>");
        Response.Write("<th>אימייל</th>");
        Response.Write("<th>" + dt.Rows[0]["Email"] + "</th>");
        Response.Write("<td> <a href ='Update_User.aspx?C=" + 5 + "'><img src='Pictures/edit.gif' border='0'></a></td>");
        Response.Write("</tr>");

        DateTime dat = DateTime.Parse(dt.Rows[0]["Date_Of_Birth"].ToString());
        Response.Write("<tr>");
        Response.Write("<th >תאריך לידה</th>");
        Response.Write("<th>" +dat.Day+"/"+dat.Month+"/"+dat.Year + "</th>");
        Response.Write("<td> <a href ='Update_User.aspx?C=" + 6 + "'><img src='Pictures/edit.gif' border='0'></a></td>");
        Response.Write("</tr>");

        //Response.Write("<tr>");
        //Response.Write("<th >ימים שנותרו</th>");
        //if (dt.Rows[0]["Days_Left"].ToString().Equals(""))
        //{
        //    Response.Write("<th> ללא הגבלה! </th>");
        //}
        //else
        //{
        //    DateTime de = DateTime.Parse(dt.Rows[0]["Days_Left"].ToString());
        //    Response.Write("<th>"+sum_of_days(de).ToString()+"</th>");
            
        //    //"<th>" + de.Day + "/" + de.Month + "/" + de.Year + "</th>"
        //}
        //Response.Write("</tr>");
       
             
        Response.Write("</table>");

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
        count += dob.DayOfYear-DateTime.Now.DayOfYear;

        return count;
    }
}
