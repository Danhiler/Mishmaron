<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["Mone_Mevakrim"] = 0;
        Application["Week_Changed"] = true;//change database every sunday
        Application["Auto_Shifts"] = true;//arrange shifts every wednesday
        Application["Shifts_Ready"] = true;// shifts ready every Thursday
        Application["Use_Down_Msg"] = false;
    }

   
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //Session["Admin"] =false;//if admin
        //Session["UserID"] = "";//user id
        //Session["Wname"] = "";// user name
       // Session["ID"] = "";// index of user
       // Session["Cname"] = "";// company name
       // Session["Days_Left"] = "";// days left
      //  Session["SMS_Left"] = "";// sms left
      //  Session["Use_Jobs"] = false;//using jobs?
     //   Session["Loged_In"] = false;//user logged in?
      //  Application["Mone_Mevakrim"]=int.Parse(Application["Mone_Mevakrim"].ToString())+1;// num of users in site
        
        Session["Admin"] = true;//if admin
        Session["UserID"] = "mishmaron";//user id
        Session["Wname"] = "sss";// user name
        Session["ID"] = "29";// index of user
        Session["Cname"] = "sss";// company name
        Session["Days_Left"] = "";// days left
        Session["SMS_Left"] = "1000000";// sms left
        Session["Use_Jobs"] = true;//using jobs?
        Session["Loged_In"] = true;//user logged in?
        Application["Mone_Mevakrim"] = int.Parse(Application["Mone_Mevakrim"].ToString()) + 1;// num of users in site
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application["Mone_Mevakrim"] = int.Parse(Application["Mone_Mevakrim"].ToString()) - 1;
    }
       
</script>
