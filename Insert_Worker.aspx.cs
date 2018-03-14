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

public partial class Insert_Worker : System.Web.UI.Page
{
    public bool use_jobs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            int workers = ADO.GetFullTable("Workers", "ID=" + Session["ID"]).Rows.Count;
            DataTable dt = ADO.GetFullTable("Options", "ID=" + Session["ID"]);
            int max_workers = (int)dt.Rows[0]["Max_Workers"];
            Random rnd = new Random();
            string username = "m" + rnd.Next(1000, 100000);
            string password = rnd.Next(1000, 10000).ToString();
            use_jobs = bool.Parse(dt.Rows[0]["Use_Jobs"].ToString());
            if (workers < max_workers)
            {
                if (Request.Form["worker_name"] != null)
                {
                    DataTable dtUseru = ADO.GetFullTable("Users", " UserName='" + hashmd5.getMd5Hash(username) + "'");
                    DataTable dtUserw = ADO.GetFullTable("Workers", " UserID='" +username + "'");
                    if ((dtUseru.Rows.Count > 0) || (dtUserw.Rows.Count > 0))
                        Response.Write("<script language='javascript'>alert('שם המשתמש שבחרת קיים כבר המערכת');history.go(-1)</script>");
                    else
                    {
                        dtUserw = ADO.GetFullTable("Workers", "NameW='" + ADO.filter(Request.Form["worker_name"].ToString()) + "'");
                        if (dtUserw.Rows.Count > 0)
                        {
                            Label1.Text = "שם עובד זה כבר קיים אצלך בעסק";
                        }
                        else
                        {
                            string phone_number="";
                            if (ADO.filter(Request.Form["worker_Phone"].TrimEnd(' ')) != "")
                                phone_number = ADO.filter(Request.Form["Phone_Start"]) + "-" + ADO.filter(Request.Form["worker_Phone"].TrimEnd(' '));
                            string strSQL = "";
                            
                            if (Request.Form["job"] != null)
                            {
                              strSQL = "Insert INTO  Workers (ID, NameW, UserID, PassW, Job, Phone, Last_Wach, Shifts_Next)" +
                                                            " values ('" + Session["ID"] + "','" +
                                                                           ADO.filter(Request.Form["worker_name"]) + "','" +
                                                                          username + "','" +
                                                                          password + "','" +
                                                                          ADO.filter(Request.Form["job"]) + "','" +
                                                                          phone_number + "','" +
                                                                           new DateTime(1111, 1, 1) + "','*')";
                            }
                            else
                            {
                                strSQL = "Insert INTO  Workers (ID, NameW, UserID, PassW, Phone, Last_Wach)" +
                              " values ('" + Session["ID"] + "','" +
                                             ADO.filter(Request.Form["worker_name"]) + "','" +
                                            username + "','" +
                                            password + "','" +
                                            phone_number + "','" +
                                            DateTime.Now + "')";
                            }


                            ADO.ExecuteNonQuery(strSQL);
                            workers++;
                            Label1.Text = Request.Form["worker_name"] + " הוסף/ה בהצלחה";
                            Label1.Text += "  " + workers + "/" + max_workers;
                        }
                    }
                }
            }
            else
            {
                Label1.Text = "הגעת למספר העובדים המקסימלי שניתן להוסיף";
            }

        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
            
        }
    }
    public void Area_Codes()
    {
        Response.Write("<option value ='050'>050</option>");
        Response.Write("<option value ='052'>052</option>");
        Response.Write("<option value ='054'>054</option>");
        Response.Write("<option value ='056'>056</option>");
        Response.Write("<option value ='057'>057</option>");
        Response.Write("<option value ='059'>059</option>");
    }
    public void Add_Jobs()
    {
        DataTable dt = ADO.GetFullTable("jobs", "ID=" + Session["ID"].ToString());
        foreach (DataRow dr in dt.Rows)
            Response.Write("<option value ='" + dr["Short_Job"].ToString() + "'>" + dr["Short_Job"].ToString() + "</option>");

    }
    }


