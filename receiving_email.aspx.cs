using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenPOP.POP3;
using System.Collections;

public partial class receiving_email : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Admin"])
        {
            ReceivePop3Mail();
            Response.Redirect("ThankYou.aspx");
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
    //receive email from POP3 server
    public void ReceivePop3Mail()
    {
        POPClient popClient = new POPClient(); //new POP client to grab emails
        Hashtable msgs = new Hashtable(); //stores the email messages

       // receive emails
        try
        {
            popClient.Disconnect(); //housekeeping
            //connect to pop mail server and authenticate
            popClient.Connect("pop.gmail.com", 995, true);
            popClient.Authenticate("SMSmishmaron@gmail.com", "sd1ma2sn3");

            int Count = popClient.GetMessageCount(); //number of emails in the inbox
            msgs.Clear(); //clear out the message hashtable

            //iterate through messages
            for (int i = Count; i >= 0; i -= 1)
            {
                try
                {
                    OpenPOP.MIMEParser.Message m = popClient.GetMessage(i, false);//grab a message and its header info

                    if (m != null)
                    {
                        if (m.FromEmail == "contact@paycard.co.il")
                        {
                            msgs.Add("msg" + i.ToString(), m);//put the message in the hashtable
                            string htmlbody = m.MessageBody[0].ToString();

                            int starting_tag = 0, ending_tag = 0, ID = -1;
                            starting_tag = htmlbody.IndexOf("תאריך ושעה");
                            ending_tag = htmlbody.IndexOf("לפרטים נוספים");
                            htmlbody = htmlbody.Substring(starting_tag, ending_tag - starting_tag + 1);
                            htmlbody = htmlbody.Replace("\n", "");
                            htmlbody = htmlbody.Replace("\t", "");

                            DateTime date = DateTime.Parse(htmlbody.Substring(htmlbody.IndexOf("תאריך ושעה") + 12, htmlbody.IndexOf("<br>") - htmlbody.IndexOf("תאריך ושעה") - 12));
                            htmlbody = htmlbody.Remove(htmlbody.IndexOf("תאריך ושעה"), htmlbody.IndexOf("<br>") - htmlbody.IndexOf("תאריך ושעה") + 4);

                            string name = htmlbody.Substring(htmlbody.IndexOf("שם הלקוח המעביר") + 17, htmlbody.IndexOf("<br>") - htmlbody.IndexOf("שם הלקוח המעביר") - 17);
                            htmlbody = htmlbody.Remove(htmlbody.IndexOf("שם הלקוח המעביר"), htmlbody.IndexOf("<br>") - htmlbody.IndexOf("שם הלקוח המעביר") + 4);

                            double amount = double.Parse(htmlbody.Substring(htmlbody.IndexOf("סכום") + 6, htmlbody.IndexOf("<br>") - htmlbody.IndexOf("סכום") - 6));
                            htmlbody = htmlbody.Remove(htmlbody.IndexOf("סכום"), htmlbody.IndexOf("<br>") - htmlbody.IndexOf("סכום") + 4);

                            string payment_id = htmlbody.Substring(htmlbody.IndexOf("מספר פעולה") + 12, htmlbody.IndexOf("<br>") - htmlbody.IndexOf("מספר פעולה") - 12);

                            //updateing DB      
                            ADO.ExecuteNonQuery("Insert INTO Payments (Full_name, Amount, buying_date, Payment_ID) values ('" + name + "'," + amount + ",'" + date + "','" + payment_id + "')");
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                { }
            }
        }
        catch (Exception x)
        {
           
        }
        popClient.Disconnect();

      
    }

}
