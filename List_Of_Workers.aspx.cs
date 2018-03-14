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

public partial class List_Of_Workers : System.Web.UI.Page
{
    public DateTime last_updated;
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (!((bool)Session["Loged_In"]))
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
                
            }
    }



    public void PrintAdmin()
    {
        DataRow dt=ADO.GetFullTable("Users", "ID=" + Session["ID"]).Rows[0];
        Response.Write( "<table border='2' width='600' class='sample' align='center'><tr>");
        Response.Write( "<th bgcolor='92a4b6'>שם מנהל</th>");
        Response.Write("<th bgcolor='92a4b6'>פלאפון</th>");
        Response.Write("<th bgcolor='92a4b6'>אימייל</th>");
        Response.Write("</tr><tr>");
        Response.Write("<td align='center'>" + dt["FName"].ToString() + "&nbsp;</td>");
        Response.Write("<td align='center'>" + dt["Phone"].ToString() + "&nbsp;</td>");
        Response.Write("<td align='center'><a href='mailto:" + dt["Email"].ToString() + "'>" + dt["Email"].ToString() + "</a>&nbsp;</td>");
        Response.Write("</tr>");
                
        Response.Write("</table>");
    }

    
    public void  PrintList()
    {
        DataTable doption = ADO.GetFullTable("Options", "ID=" + Session["ID"]);
        bool use_jobs = bool.Parse(doption.Rows[0]["Use_Jobs"].ToString());
        last_updated = DateTime.Parse(doption.Rows[0]["Last_Updated"].ToString());
        int i = 1;
        DataTable dt = ADO.GetFullTable("Workers", "ID=" + Session["ID"] + " Order by Job");

                       if (Session["Admin"] != null && (bool)Session["Admin"])
            { 
         Response.Write("<h2><a href='AddWorker.aspx'>הוספת עובדים</a></h2>");
         Response.Write("<table width='80%'><tr><td>");
         Response.Write("מספר עובדים: " + dt.Rows.Count);
         Response.Write("</td><td><a href='Print_Mode_list.aspx' target='_blank' >גרסת הדפסה</a></td>");
       Response.Write("<td><a href='Print_boxs_workers.aspx' target='_blank' >גרסת הדפסה לעובדים</a></td>");
       Response.Write("</tr>");
       Response.Write("</table>");
       } 
        else
                           Response.Write("מספר עובדים: " + dt.Rows.Count);
        Response.Write("<table border='2' width='800' class='sample'><tr>");
        Response.Write("<th bgcolor='92a4b6' width='10'></th>");
        Response.Write( "<th bgcolor='92a4b6'>שם עובד</th>");
        if ((bool)Session["Admin"])
        {
            Response.Write("<th bgcolor='92a4b6'>שם משתמש</th>");
            Response.Write("<th bgcolor='92a4b6'>ססמא</th>");
        }
if(use_jobs)
    Response.Write("<th bgcolor='92a4b6'>תפקיד</th>");
        Response.Write("<th bgcolor='92a4b6'>פלאפון</th>");
        Response.Write("<th bgcolor='92a4b6'>צפה בסידור</th>");
        if ((bool)Session["Admin"])
        {
            Response.Write("<th bgcolor='92a4b6'>ערוך</th>");
            Response.Write("<th bgcolor='92a4b6'>מחק</th>");
        }
        Response.Write( "</tr>");
        if (dt.Rows.Count == 0) {
            Response.Write("<tr>");
             Response.Write("<th colspan='10'><center>");
             Response.Write("אין כרגע עובדים");
             Response.Write("</center></th>");
             Response.Write("</tr>");
        }

        else
            foreach (DataRow dr in dt.Rows)
            {
                Response.Write("<tr>");
                Response.Write("<td align='center'>" + i + "</td>");
                Response.Write("<td align='center'>" + dr["NameW"].ToString() + "&nbsp;</td>");
                if ((bool)Session["Admin"])
                {
                    Response.Write("<td align='center'>" + dr["UserID"].ToString() + "&nbsp;</td>");
                    Response.Write("<td align='center'>" + dr["PassW"].ToString() + "&nbsp;</td>");
                }
                if (use_jobs)
                    Response.Write("<td align='center'>" + dr["Job"].ToString() + "&nbsp;</td>");
                Response.Write("<td align='center'>" + dr["Phone"].ToString() + "&nbsp;</td>");
                Response.Write("<td align='center' ");

                if (Is_First_Before(last_updated, DateTime.Parse(dr["Last_Wach"].ToString())))
                    Response.Write(" bgcolor='#8BE28B'");
                if(dr["Last_wach"].ToString()=="01/01/1111 00:00:00")//never logged in
                    Response.Write(">לא צפה</td>");
                else Response.Write(">" + edit_date(DateTime.Parse(dr["Last_Wach"].ToString())) + "</td>");
                if ((bool)Session["Admin"])
                {
                    Response.Write("<td align='center'> <a href ='Update_Worker.aspx?ID=" + dr["UserID"].ToString() + "'><center><img src='Pictures/edit.gif' border='0'></center></a></td>");
                    Response.Write("<td align='center'> <a href ='Delete_Worker.aspx?ID=" + dr["UserID"].ToString() + "'><center><img src='Pictures/del.gif' border='0'></center></a></td>");
                }
                Response.Write("</tr>");
                i++;
            }
        Response.Write("</table>");
        Response.Write("<table width='600'><tr><td>");
        Response.Write("התאריך האחרון שבו סידור העבודה נערך:" + edit_date(last_updated));
        Response.Write("</td>");

            Response.Write("<td>");
          
           Response.Write("<a href='publish_details.aspx'>הפצת פרטי התחברות(באמצעות SMS)</a>");
            Response.Write("</td>");
       
        Response.Write("</tr></table>");

        
    }

    public string edit_date(DateTime str)//12/02/2010 12:07:35
    {
        return str.Hour + ":" + addzero(str.Minute) + " " + str.Day + "/" + str.Month;
         
    }

    private string addzero(int p)
    {
       if (p.ToString().Length==1)return "0"+p;
       return p.ToString();
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
