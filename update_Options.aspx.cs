using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class update_Options : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
          

            int al = 1;
            if (Request.Form["intermediate_Shifts"] == null)
                al = 0;

            int uj = 1;
            Session["Use_Jobs"] = true;
            if (Request.Form["use_job"] == null)
            {
                uj = 0;
                Session["Use_Jobs"] = false;
            }
            string sql = "Update Options Set start_morning_shift='" + ADO.filter(Request.Form["SM2"].ToString()) +":"+ADO.filter(Request.Form["SM1"].ToString())+
                                            "', end_morning_shift='"+ADO.filter(Request.Form["EM2"].ToString())+":"+ADO.filter(Request.Form["EM1"].ToString())+
                                            "', start_evening_shift='"+ADO.filter(Request.Form["SE2"].ToString())+":"+ADO.filter(Request.Form["SE1"].ToString())+
                                            "', end_evening_shift='" + ADO.filter(Request.Form["EE2"].ToString()) + ":" + ADO.filter(Request.Form["EE1"].ToString()) +
                                            "', Length_Of_Boxes='" +ADO.filter(Request.Form["LOB"].ToString())+
                                            "', Length_Of_Temp_Boxes='" +(int.Parse(ADO.filter(Request.Form["LOTB"].ToString()))*2)+
                                            "', intermediate_Shifts='" + al +
                                            "', shift_until='" + ADO.filter(Request.Form["deadline"].ToString()) +
                                            "', Use_Jobs='" + uj +
                                                 "' where ID=" + Session["ID"];


            ADO.ExecuteNonQuery(sql);
            al = 1;
            if (Request.Form["const_Shifts"] == null)
                al = 0;
            
           sql = "Update Work_Table Set Allow_Changes='" +al+ "' where ID=" + Session["ID"]+" And week=2";

            ADO.ExecuteNonQuery(sql);

            Response.Redirect("Shifts_next_week.aspx");

        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            
        }

    }
}
