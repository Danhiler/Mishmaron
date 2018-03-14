using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Show_Workers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                if (!(((bool)Session["Loged_In"]) && ((bool)Session["Admin"])))
                {
                    Response.Write("<script type='text/javascript' language='javascript'>self.close();</script>");
                    
                }

    }
    public void Print_Workers()
    {
        DataTable dt=ADO.GetFullTable("Workers","ID="+Session["ID"]+" Order by Job");
        dt.DefaultView.Sort = "Job desc";
        Response.Write("<select size='30' name='ListBox1' id='ListBox1' style='font-family:Arial;font-size:Small;height:100%;width:100%;'>");
        string admin_name = Session["Wname"].ToString();
        if (admin_name.Length > 12)
            admin_name = admin_name.Substring(0, 12);

        Response.Write("<option value='" + admin_name + "'>" + Session["wname"].ToString() + "</option>");
        if(bool.Parse(ADO.GetFullTable("Options","ID="+Session["ID"]+"").Rows[0]["Use_Jobs"].ToString()))
        foreach(DataRow dr in dt.Rows)
            Response.Write("<option value='"+dr["Job"]+"|"+dr["NameW"]+"'>"+dr["Job"]+"| "+dr["NameW"]+"</option>");
        else
            foreach (DataRow dr in dt.Rows)
                Response.Write("<option value='" + dr["NameW"] + "'>" + dr["NameW"] + "</option>");

        Response.Write("</select>");
    }
}
