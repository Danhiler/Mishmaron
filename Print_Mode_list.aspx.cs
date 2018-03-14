using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Print_Mode_list : System.Web.UI.Page
{
    public string date;
    public bool use_jobs;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!(((bool)Session["Loged_In"]) && ((bool)Session["Admin"])))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
           
        }
        date = edit_date(DateTime.Now);
    }
      public void  PrintList()
    {
        
        int i = 1;
                use_jobs = bool.Parse(Session["Use_Jobs"].ToString());
        DataTable dt = ADO.GetFullTable("Workers","ID="+Session["ID"]);
        Response.Write( " <table id='Table1' border='1' dir='rtl' class='sample' align='center' style='font-family: Arial; font-size: medium; width: 600px;'><tr>");
        Response.Write("<th width='10'></th>");
        Response.Write( "<th>שם עובד</th>");
            Response.Write("<th>שם משתמש</th>");
            Response.Write("<th>ססמא</th>");
            if (use_jobs)
                Response.Write("<th>תפקיד</th>");
        Response.Write("<th>פלאפון</th>");
       
        Response.Write( "</tr>");

        foreach (DataRow dr in dt.Rows){
             Response.Write("<tr>");
                Response.Write("<td>" + i + "</td>");
                Response.Write("<td align='center'>" + dr["NameW"].ToString() + "&nbsp;</td>");
                if ((bool)Session["Admin"])
                {
                    Response.Write("<td align='center'>" + dr["UserID"].ToString() + "&nbsp;</td>");
                    Response.Write("<td align='center'>" + dr["PassW"].ToString() + "&nbsp;</td>");
                }
                if (use_jobs)
                    Response.Write("<td align='center'>" + dr["Job"].ToString() + "&nbsp;</td>");
                Response.Write("<td align='center'>" + dr["Phone"].ToString() + "&nbsp;</td>");

              
                  
         
                Response.Write("</tr>");
                i++;
            }
        Response.Write("</table>");


    

    }
            public string edit_date(DateTime str)//12/02/2010 12:07:35
            {
                return str.Day + "/" + str.Month+"/" + str.Year;

            }

}
