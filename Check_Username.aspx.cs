using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Check_Username : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["User_ID"] != null)
        {
            string Username = ADO.filter(Request.QueryString["User_ID"].ToString());
            bool flag = true;
            Response.Write("<script language='javascript'>");
           if (Username.Length < 3 || Username.Length > 15)
            {
                flag = false;
                Response.Write("opener.Registar_Request.USER_ID.style.backgroundColor = '#FF7777';");
                Response.Write("opener.Registar_Request.user_ans2.style.color = 'red';");
            }
           else
               Response.Write("opener.Registar_Request.user_ans2.style.color = '';");

            if (!CheckNameForLetterse(Username))
            {
                flag = false;
                Response.Write("opener.Registar_Request.USER_ID.style.backgroundColor = '#FF7777';");
                Response.Write("opener.Registar_Request.user_ans1.style.color = 'red';");
            }
            else
                Response.Write("opener.Registar_Request.user_ans1.style.color = '';");
            if(flag)
            {
                DataTable dtUseru = ADO.GetFullTable("Users", " UserName='" + hashmd5.getMd5Hash(ADO.filter(Username)) + "'");
                DataTable dtUserw = ADO.GetFullTable("Workers", " UserID='" + ADO.filter(Username) + "'");
                if ((dtUseru.Rows.Count > 0) || (dtUserw.Rows.Count > 0))
                {
                    Response.Write("opener.Registar_Request.USER_ID.style.backgroundColor = '#FF7777';");
                    Response.Write("opener.Registar_Request.user_ans.style.color = 'red';");
                    Response.Write("opener.Registar_Request.user_ans.value = 'תפוס!';");
                }
                else
                {
                    Response.Write("opener.Registar_Request.USER_ID.style.backgroundColor = '#99FF99';");
                    Response.Write("opener.Registar_Request.user_ans.style.color = 'green';");
                    Response.Write("opener.Registar_Request.user_ans.value = 'פנוי!';");
                }
            }
            Response.Write("self.close()</script>");
        }
    }
    public bool CheckNameForLetterse( string Text) {
        string Let = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        for (int i = 0; i < Text.Length; i++) {
            if (Let.IndexOf(Text[i]) == -1)
                return false;
        }
        return true;
    }
}
