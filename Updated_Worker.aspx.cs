using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Updated_Worker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                if (Session["Loged_In"]!=null && (bool)Session["Loged_In"])
        {
            if (((bool)Session["Admin"] == true) || (ADO.GetFullTable("Workers", "ID=" + Session["ID"] + " And NameW='" + Session["Wname"].ToString() + "'").Rows[0]["UserID"].ToString() == Request.Form["Old_ID"].ToString().TrimEnd(' ')))
            {
                DataTable dtUseru = new DataTable();
                DataTable dtUserw = new DataTable();
                if (Request.Form["Old_ID"].ToString().TrimEnd(' ') != Request.Form["worker_ID"].ToString().TrimEnd(' '))
                {
                    dtUseru = ADO.GetFullTable("Users", "UserName='" + hashmd5.getMd5Hash(ADO.filter(Request.Form["worker_ID"].ToString())) + "'");
                    dtUserw = ADO.GetFullTable("Workers", "UserID='" + ADO.filter(Request.Form["worker_ID"].ToString()) + "'");
                }
                if ((dtUseru.Rows.Count > 0) || (dtUserw.Rows.Count > 0))
                {
                    Response.Write("<script language='javascript'>alert('שם המשתמש שבחרת קיים כבר במערכת');history.go(-1)</script>");
                }
                else
                {
                    if (Request.Form["Old_ID"].ToString().TrimEnd(' ') != Request.Form["worker_ID"].ToString().TrimEnd(' '))
                    {
                        dtUserw = ADO.GetFullTable("Workers", "NameW='" + ADO.filter(Request.Form["worker_name"].ToString()) + "'");
                    }
                    if (dtUserw.Rows.Count > 0)
                    {
                        Response.Write("<script language='javascript'>alert('שם עובד זה כבר קיים אצלך בעסק');history.go(-1)</script>");
                    }
                    else
                    {
                        string sql = "";
                        string phone = "";
                        if (Request.Form["worker_Phone"].ToString() != "")
                            phone = ADO.filter(Request.Form["Phone_Start"]) + "-" + ADO.filter(Request.Form["worker_Phone"].ToString().TrimEnd(' '));
                        if (Request.Form["job"] != null)
                        {
                            sql = "Update Workers Set NameW='" + ADO.filter(Request.Form["worker_name"].ToString().TrimEnd(' ')) +
                                                             "', UserID='" + ADO.filter(Request.Form["worker_ID"].ToString().TrimEnd(' ')) +
                                                             "', PassW='" + ADO.filter(Request.Form["Worker_PassW"].ToString().TrimEnd(' ')) +
                                                             "', Phone='" + phone +
                                                             "', Job='" + ADO.filter(Request.Form["job"]) +
                                                             "' where UserID='" + Request.Form["Old_ID"].ToString().TrimEnd(' ') + "'";
                        }
                        else
                        {
                            sql = "Update Workers Set NameW='" + ADO.filter(Request.Form["worker_name"].ToString().TrimEnd(' ')) +
                                                            "', UserID='" + ADO.filter(Request.Form["worker_ID"].ToString().TrimEnd(' ')) +
                                                            "', PassW='" + ADO.filter(Request.Form["Worker_PassW"].ToString().TrimEnd(' ')) +
                                                            "', Phone='" + phone +
                                                            "', E_Mail='" + ADO.filter(Request.Form["E_mail"].ToString().TrimEnd(' ')) +
                                                            "' where UserID='" + Request.Form["Old_ID"].ToString().TrimEnd(' ') + "'";
                        }
                        ADO.ExecuteNonQuery(sql);

                        if (!(bool)Session["Admin"]) Session["Wname"] = ADO.filter(Request.Form["worker_name"].ToString().TrimEnd(' '));
                        Response.Redirect("List_Of_Workers.aspx");
                    }
                }
            }
        }
                else
                {
                    Session.Abandon();
                    Response.Redirect("Default.aspx");
                  
                }
    }
}
