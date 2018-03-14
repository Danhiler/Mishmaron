using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Save_Const_Shifts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            if (Request.Form["Save_Changes"] != null)
            {

                string sql = "Update Work_Table Set sunday_morning='" + ADO.filter(Request.Form["Sunday_Morning"].ToString()) +
                                               "', monday_morning='" + ADO.filter(Request.Form["Monday_Morning"].ToString()) +
                                               "', tuesday_morning='" + ADO.filter(Request.Form["Tuesday_Morning"].ToString()) +
                                               "', wednesday_morning='" + ADO.filter(Request.Form["Wednesday_Morning"].ToString()) +
                                               "', thursday_morning='" + ADO.filter(Request.Form["Thursday_Morning"].ToString()) +
                                               "', friday_morning='" + ADO.filter(Request.Form["Friday_Morning"].ToString()) +
                                               "', saturday_morning='" + ADO.filter(Request.Form["Saturday_Morning"].ToString());
                if (ADO.GetFullTable("Options", "ID=" + Session["ID"]).Rows[0]["intermediate_Shifts"].ToString() == "True")
                {
                    sql += "', sunday_intermediate='" + ADO.filter(Request.Form["Sunday_intermediate"].ToString()) +
                                              "', monday_intermediate='" + ADO.filter(Request.Form["Monday_intermediate"].ToString()) +
                                              "', tuesday_intermediate='" + ADO.filter(Request.Form["Tuesday_intermediate"].ToString()) +
                                              "', wednesday_intermediate='" + ADO.filter(Request.Form["Wednesday_intermediate"].ToString()) +
                                              "', thursday_intermediate='" + ADO.filter(Request.Form["Thursday_intermediate"].ToString()) +
                                              "', friday_intermediate='" + ADO.filter(Request.Form["Friday_intermediate"].ToString()) +
                                              "', saturday_intermediate='" + ADO.filter(Request.Form["Saturday_intermediate"].ToString());
                }
                sql += "', sunday_evening='" + ADO.filter(Request.Form["Sunday_Evening"].ToString()) +
                                   "', monday_evening='" + ADO.filter(Request.Form["Monday_Evening"].ToString()) +
                                   "', tuesday_evening='" + ADO.filter(Request.Form["Tuesday_Evening"].ToString()) +
                                   "', wednesday_evening='" + ADO.filter(Request.Form["Wednesday_Evening"].ToString()) +
                                   "', thursday_evening='" + ADO.filter(Request.Form["Thursday_Evening"].ToString()) +
                                   "', friday_evening='" + ADO.filter(Request.Form["Friday_Evening"].ToString()) +
                                   "', saturday_evening='" + ADO.filter(Request.Form["Saturday_Evening"].ToString()) +
                                   "' where ID=" + Session["ID"] + " And week=2";

                try {
                 ADO.ExecuteNonQuery(sql); 
                Label1.Text = "השינויים נשמרו בהצלחה!";
                }
                catch(Exception x)
                {
                Label1.Text = "התרחשה שגיאה";
                }
                
            }
            if (Request.Form["Erase_All"] != null)
            {
                string sql = "Update Work_Table Set sunday_morning='', monday_morning='', tuesday_morning='', wednesday_morning='', thursday_morning='', friday_morning='', saturday_morning='', sunday_intermediate='', monday_intermediate='', tuesday_intermediate='', wednesday_intermediate='', thursday_intermediate='', friday_intermediate='', saturday_intermediate='', sunday_evening='', monday_evening='', tuesday_evening='', wednesday_evening='', thursday_evening='', friday_evening='', saturday_evening='' where ID=" + Session["ID"] + " And week=2";

                ADO.ExecuteNonQuery(sql);
                Response.Redirect("Const_Shifts.aspx");
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }
}
