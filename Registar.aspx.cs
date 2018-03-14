using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Registar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void days()
    {
        for (int i = 1; i < 32; i++)
            Response.Write("<option value = "+i+">" + i + "</option>");
    }
    public void months()
    {
        for (int i = 1; i <13; i++)
            Response.Write("<option value = " + i + ">" + i + "</option>");
    }
    public void years()
    {
        for (int i = 2010; i >1900; i--)
            Response.Write("<option value = " + i + ">" + i + "</option>");
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
}
