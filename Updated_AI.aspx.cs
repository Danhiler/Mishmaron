using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Updated_AI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            DataTable dr = ADO.GetFullTable("options", "ID=" + Session["ID"]);
            bool use_intermediate = bool.Parse(dr.Rows[0]["intermediate_Shifts"].ToString());
            bool use_jobs = bool.Parse(dr.Rows[0]["Use_Jobs"].ToString());
            DataTable jobs = ADO.GetFullTable("Jobs", "ID="+Session["ID"]);
            
            string[] Morning = new string[7];
            string[] Intermediate = new string[7];
            string[] Evening = new string[7];
            //add too array the needs
            DataTable shifts = ADO.GetFullTable("AI_Optionts", "ID=" + Session["ID"]);
            string[] oaram = shifts.Rows[0]["morning"].ToString().Split('#');
            foreach (string param in oaram)
                Morning[int.Parse(param.Split('@')[0].ToString())] += param + "#";

            oaram = shifts.Rows[0]["intermediate"].ToString().Split('#');
            foreach (string param in oaram)
                Intermediate[int.Parse(param.Split('@')[0].ToString())] += param + "#";

            oaram = shifts.Rows[0]["evening"].ToString().Split('#');
            foreach (string param in oaram)
                Evening[int.Parse(param.Split('@')[0].ToString())] += param + "#";

           //remove the changed days needs
            if (Request.Form["kind"].ToString() == "2")//weekend
            {

                for (int i = 4; i < 7; i++)
                {
                    Morning[i] = "";
                    Evening[i] = "";
                    Intermediate[i] = "";
                }
            }
            else//start of week

                for (int i = 0; i < 4; i++)
                {
                    Morning[i] = "";
                    Evening[i] = "";
                    Intermediate[i] = "";
                }
                for (int i = 0; i < 7; i++)
                {
                    if (!use_jobs)
                    {
                        if ((Request.Form["S_0_" + i + "_0"] != "0") && (Request.Form["S_0_" + i + "_0"] != null))
                            Morning[i] = i + "@@" + Request.Form["S_0_" + i + "_0"] + "@#";
                        if (use_intermediate)
                            for (int count = 0; count < 3; count++)
                                if ((Request.Form["S_1_" + i + "_" + count] != "0") && (Request.Form["S_1_" + i + "_" + count] != null))
                                    if (Request.Form["H_" + i + "_" + count + "_" + 0] != "" && Request.Form["H_" + i + "_" + count + "_" + 1] != "" && Request.Form["H_" + i + "_" + count + "_" + 2] != "" && Request.Form["H_" + i + "_" + count + "_" + 3] != "")
                                        Intermediate[i] += i + "@@" + Request.Form["S_1_" + i + "_" + count] + "@" + Request.Form["H_" + i + "_" + count + "_" + 3] + ":" + Request.Form["H_" + i + "_" + count + "_" + 2] + "-" + Request.Form["H_" + i + "_" + count + "_" + 1] + ":" + Request.Form["H_" + i + "_" + count + "_" + 0] + "#";
                        if ((Request.Form["S_2_" + i + "_0"] != "0") && (Request.Form["S_2_" + i + "_0"] != null))
                            Evening[i] = i + "@@" + Request.Form["S_2_" + i + "_0"] + "@#";
                    }
                    else
                        for (int count = 0; count < jobs.Rows.Count; count++)
                        {
                            if ((Request.Form["S_0_" + i + "_" + count] != "0") && (Request.Form["S_0_" + i + "_" + count] != null))
                                Morning[i] += i + "@" + Request.Form["T_0_" + i + "_" + count] + "@" + Request.Form["S_0_" + i + "_" + count + ""] + "@#";
                            if (use_intermediate)
                                if ((Request.Form["S_1_" + i + "_" + count] != "0") && (Request.Form["S_1_" + i + "_" + count] != null))
                                    if (Request.Form["H_" + i + "_" + count + "_" + 0] != "" && Request.Form["H_" + i + "_" + count + "_" + 1] != "" && Request.Form["H_" + i + "_" + count + "_" + 2] != "" && Request.Form["H_" + i + "_" + count + "_" + 3] != "" && Request.Form["T_1_" + i + "_" + count] != "" && Request.Form["T_1_" + i + "_" + count] != "בחר")
                                        Intermediate[i] += i + "@" + Request.Form["T_1_" + i + "_" + count + ""] + "@" + Request.Form["S_1_" + i + "_" + count] + "@" + Request.Form["H_" + i + "_" + count + "_" + 3] + ":" + Request.Form["H_" + i + "_" + count + "_" + 2] + "-" + Request.Form["H_" + i + "_" + count + "_" + 1] + ":" + Request.Form["H_" + i + "_" + count + "_" + 0] + "#";
                            if ((Request.Form["S_2_" + i + "_" + count] != "0") && (Request.Form["S_2_" + i + "_" + count] != null))
                                Evening[i] += i + "@" + Request.Form["T_2_" + i + "_" + count] + "@" + Request.Form["S_2_" + i + "_" + count] + "@#";
                        }

                }
                        string mornings = "", intermediates = "", evenings = "";
            for (int i = 0; i < 7; i++)
            {
                mornings += Morning[i];
                intermediates += Intermediate[i];
                evenings += Evening[i];
            }
            if (mornings != "") mornings = mornings.Remove(mornings.Length - 1);
            if (intermediates != "") intermediates = intermediates.Remove(intermediates.Length - 1);
            if (evenings != "") evenings = evenings.Remove(evenings.Length - 1);



            string sql = "Update AI_Optionts Set morning='" + mornings + "', intermediate='" + intermediates + "', evening='" + evenings + "' Where ID=" + Session["ID"];
            try
            {
                ADO.ExecuteNonQuery(sql);
                //Label1.Text = "השינויים נשמרו בהצלחה!";
                if (Request.Form["S_0_1_0"] == null)//השינויים התבצעו בסוף השבוע
                Response.Redirect("Update_AI_2.aspx");

                Response.Redirect("Update_AI.aspx");//השינויים התרחשו בתחילת השבוע
            }
            catch (Exception x)
            {
                Label1.Text = "התרחשה שגיאה";
            }

        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }



private int Get_Biggest(int p,int p_2,int p_3)
{
 	int bigest = p;
    if(p_2>bigest)bigest=p_2;
    if(p_3>bigest)bigest= p_3;
    return bigest;
}

    private Array Remove_item(string[] arr, int i)
    {
        List<string> lst = new List<string>(arr);
        lst.RemoveAt(i);
        return lst.ToArray();
    }
}
