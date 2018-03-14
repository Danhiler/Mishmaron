using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Add_Comment : System.Web.UI.Page
{
   public string com;
   public string show_Comment;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = ADO.GetFullTable("Options", "ID=" + (int)Session["ID"]);
        com = dt.Rows[0]["Comment"].ToString();
        show_Comment = dt.Rows[0]["Show_Comment"].ToString();
        
    }
}
