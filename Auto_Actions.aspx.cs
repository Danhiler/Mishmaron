using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Auto_Actions : System.Web.UI.Page
{
    public List<worker> AI_workers;
    string[,] AI_mat = new string[7, 3];
    public bool use_jobs;
    public int ID;
    public DataTable workers;
    public DataRow option;

    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime time = DateTime.Now;
        
        if ((time.DayOfWeek.ToString() == "Sunday") && (!bool.Parse(Application["Week_Changed"].ToString())))
        #region switch week
        {
            //get NEXT WEEK to THIS WEEK
            ADO.ExecuteNonQuery("Update Work_Table Set week=-1 Where week = 1");
            ADO.ExecuteNonQuery("Update Work_Table Set week=1 Where week = 0 ");
            ADO.ExecuteNonQuery("Update Work_Table Set week=0 Where week = -1");
            ADO.ExecuteNonQuery("Update Work_Table Set Allow_Changes=TRUE Where week = 1");
            ADO.ExecuteNonQuery("Update Work_Table Set Allow_Changes=FALSE Where week = 0");

            //update workers requests
            ADO.ExecuteNonQuery("Update Workers Set Shifts_This=Shifts_Next And Shifts_Cant_This=Shifts_Cant_Next");
            ADO.ExecuteNonQuery("Update Workers Set Shifts_Next='' AND Shifts_Cant_Next=''");


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
            Label1.ForeColor = System.Drawing.Color.Green;
            Label1.Text = "שבוע התחלף בהצלחה!";
        }
        //sunday but already changed
        if ((time.DayOfWeek.ToString() == "Sunday") && (bool.Parse(Application["Week_Changed"].ToString())))
            Label1.ForeColor = System.Drawing.Color.Green;
            Label1.Text = "שבוע התחלף כבר!";

        //not sunday
        if (time.DayOfWeek.ToString() != "Sunday")
        {
            Application["Week_Changed"] = false;
        }
        #endregion
       

        if ((time.DayOfWeek.ToString() == "Wednesday") && (!bool.Parse(Application["Shifts_Ready"].ToString())))
            #region shifts ready
        {
            
            string sql = "Update Work_Table Set allow_changes=FALSE where week=1";
            ADO.ExecuteNonQuery(sql);

        }
        //Thursday but already changed
        if ((time.DayOfWeek.ToString() == "Thursday") && (bool.Parse(Application["Shifts_Ready"].ToString())))
        {
            Label1.ForeColor = System.Drawing.Color.Green;
            Label1.Text = "הסידורים מוכנים כבר!";
        }
        //not thursday
        if (time.DayOfWeek.ToString() != "Thursday")
        {
            Application["Shifts_Ready"] = false;
        }
            #endregion
    }
}
