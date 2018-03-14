using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using il.co.simplesms.ws2;


public partial class Owner_Page : System.Web.UI.Page
{
    public int Num_Of_SMS;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Wname"] == null || Session["Cname"] == null || Session["Wname"].ToString() == "" || Session["Cname"].ToString()=="")
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            
        }
        if ( (!Session["Wname"].ToString().Equals("5410c239adb1b45866f162e5ec829ca9")) ||
             (!Session["Cname"].ToString().Equals("2cb6e810b21db557600c5bd1ddba81b2")))
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            
        }
        ManagmentService ss= new ManagmentService();
      // Num_Of_SMS=ss.GetCredit("danhiler@gmail.com","d1a1n1");
    }

    public void Print_Users()
    {
        DataTable dt = ADO.GetFullTable("Users");
        DataTable dr = ADO.GetFullTable("Options");
        Response.Write("<table border ='1'>");
        Response.Write("<tr><th>ID</th><th>User Name</th><th>Password</th><th>Company</th><th>Full</th><th>Workers</th><th>M_Workers</th><th>SMS</th><th>M_Jobs</th><th>Updated</th><th>Reg date</th><th>Exp date</th><th>login</th><th>update</th><th>delete</th></tr>");
        for (int ID = 0; ID < dt.Rows.Count;ID++ )
        {
            Response.Write("<tr>");
            Response.Write("<td>" + dt.Rows[ID]["ID"] + "</td>");
            Response.Write("<td>" + dt.Rows[ID]["UserName"].ToString() + "</td>");
            Response.Write("<td>" + dt.Rows[ID]["Passw"] + "</td>");
            Response.Write("<td>" + dt.Rows[ID]["CName"] + "</td>");
            Response.Write("<td>" + dt.Rows[ID]["FName"] + "</td>");
            Response.Write("<td>" + ADO.GetFullTable("Workers", "ID=" + dt.Rows[ID]["ID"]).Rows.Count + "</td>");
            Response.Write("<td>" + dr.Rows[ID]["Max_Workers"].ToString() + "</td>");
            Response.Write("<td>" + dr.Rows[ID]["Num_Of_SMS"].ToString() + "</td>");
            Response.Write("<td>" + dr.Rows[ID]["Max_Jobs"].ToString() + "</td>");
            Response.Write("<td>" + dr.Rows[ID]["Last_Updated"].ToString() + "</td>");
            Response.Write("<td>" + edit_date(dt.Rows[ID]["Reg_Date"].ToString()) + "</td>");
            Response.Write("<td>" + edit_date(dt.Rows[ID]["Days_Left"].ToString()) + "</td>");
            Response.Write("<td><a href='Owner_Login.aspx?id=" + dt.Rows[ID]["UserName"] + "'><img src='Pictures/login_icon.png' border='0'></a></td>");
            Response.Write("<td><a href='Owner_Update.aspx?id=" + dt.Rows[ID]["ID"] + "'><img src='Pictures/edit.gif' border='0'></a></td>");
            Response.Write("<td><a href='Owner_delete.aspx?id=" + dt.Rows[ID]["UserName"] + "'><img src='Pictures/del.gif' border='0'></a></td>");
            Response.Write("</tr>");
        }
        Response.Write("</table>");
    }

    private string edit_date(string p)
    {
        try
        {
            DateTime date = DateTime.Parse(p);
            return(date.Day+"."+date.Month+"."+date.Year);
        }
        catch { return p; }
    }

   public void Change_Visible_tables(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {


            if (GridView4.Visible)
            {
                GridView4.Visible = false;
            }
            else
            {
                GridView4.Visible = true;
            }
        }
    }
    public void Change_Visible_Options(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

            if (GridView3.Visible)
            {
                GridView3.Visible = false;
            }
            else
            {
                GridView3.Visible = true;
            }

        }

    }
    public void Change_Visible_payments(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

            if (GridView6.Visible)
            {
                GridView6.Visible = false;
            }
            else
            {
                GridView6.Visible = true;
            }

        }

    }
    public void Change_Visible_Jobs(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

            if (GridView5.Visible)
            {
                GridView5.Visible = false;
            }
            else
            {
                GridView5.Visible = true;
            }

        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
         //get NEXT WEEK to THIS WEEK
            ADO.ExecuteNonQuery("Update Work_Table Set week=-1 Where week = 1");
            ADO.ExecuteNonQuery("Update Work_Table Set week=1 Where week = 0 ");
            ADO.ExecuteNonQuery("Update Work_Table Set week=0 Where week = -1");
            ADO.ExecuteNonQuery("Update Work_Table Set Allow_Changes=TRUE Where week = 1");
            ADO.ExecuteNonQuery("Update Work_Table Set Allow_Changes=FALSE Where week = 0");

            //Changing the Next Week Values
            DataTable dt = ADO.GetFullTable("Work_Table", "week=2");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Allow_Changes"].ToString() == "True")
                {

                    string sql = "Update Work_Table Set sunday_morning='" + dr["sunday_morning"] + "', monday_morning='" + dr["monday_morning"] + "', tuesday_morning='" + dr["tuesday_morning"] + "', wednesday_morning='" + dr["wednesday_morning"] + "', thursday_morning='" + dr["thursday_morning"] + "', friday_morning='" + dr["friday_morning"] + "', saturday_morning='" + dr["saturday_morning"] + "', sunday_intermediate='" + dr["sunday_intermediate"] + "', monday_intermediate='" + dr["monday_intermediate"] + "', tuesday_intermediate='" + dr["tuesday_intermediate"] + "', wednesday_intermediate='" + dr["wednesday_intermediate"] + "', thursday_intermediate='" + dr["thursday_intermediate"] + "', friday_intermediate='" + dr["friday_intermediate"] + "', saturday_intermediate='" + dr["saturday_intermediate"] + "', sunday_evening='" + dr["sunday_evening"] + "', monday_evening='" + dr["monday_evening"] + "', tuesday_evening='" + dr["tuesday_evening"] + "', wednesday_evening='" + dr["wednesday_evening"] + "', thursday_evening='" + dr["thursday_evening"] + "', friday_evening='" + dr["friday_evening"] + "', saturday_evening='" + dr["saturday_evening"] + "' where ID=" + dr["ID"] + " And week=" + 1;
                    ADO.ExecuteNonQuery(sql);
                }
                else
                {
                    string sql = "Update Work_Table Set sunday_morning='', monday_morning='', tuesday_morning='', wednesday_morning='', thursday_morning='', friday_morning='', saturday_morning='', sunday_intermediate='', monday_intermediate='', tuesday_intermediate='', wednesday_intermediate='', thursday_intermediate='', friday_intermediate='', saturday_intermediate='', sunday_evening='', monday_evening='', tuesday_evening='', wednesday_evening='', thursday_evening='', friday_evening='', saturday_evening='' where ID=" + dr["ID"] + " And week=" + 1;
                    ADO.ExecuteNonQuery(sql);

                }
            }
            Application["Week_Changed"] = true;
               
        
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        TextBox1.Text = hashmd5.getMd5Hash(TextBox1.Text);
    }
    protected void change_mes_Click(object sender, EventArgs e)
    {
        if (bool.Parse(Application["Use_Down_Msg"].ToString()))
            Application["Use_Down_Msg"] = false;
        else
            Application["Use_Down_Msg"] = true;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

            if (GridView1.Visible)
            {
                GridView1.Visible = false;
            }
            else
            {
                GridView1.Visible = true;
            }

        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

            if (GridView2.Visible)
            {
                GridView2.Visible = false;
            }
            else
            {
                GridView2.Visible = true;
            }

        }
    }
    protected void Change_Visible_Mes(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

            if (GridView7.Visible)
            {
                GridView7.Visible = false;
            }
            else
            {
                GridView7.Visible = true;
            }

        }
    }
}
