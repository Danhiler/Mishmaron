using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Update_AI : System.Web.UI.Page
{
     public DataTable dt;
    public DataTable jobs;
    public bool use_intermediate;
    public bool use_jobs;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
        DataTable dr = ADO.GetFullTable("options","ID="+Session["ID"]);
        use_intermediate = bool.Parse(dr.Rows[0]["intermediate_Shifts"].ToString());
        use_jobs = bool.Parse(dr.Rows[0]["Use_Jobs"].ToString()) ;
        jobs = ADO.GetFullTable("Jobs", "ID="+Session["ID"]);
         dt = ADO.GetFullTable("AI_Optionts", "ID=" + Session["ID"]);
          }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }   
    }
    public void print_Morning()
    {//first number: 0=>mornming 1=>intermediate 2=>evening
        //second number: 0=>sunday 6=>saturday
        //third number: sidury
        if (use_jobs && jobs.Rows.Count == 0)//0 jobs
        {
            Response.Write("<td colspan='7' align ='center'><font color='red'><b>בעסק שלך לא הוגדרו תפקידים</b></font</td>");
            return;
        }
        Shift[,] shifts_in_days= new Shift [7,get_max(jobs.Rows.Count,1)];
        for (int i = 0; i <4; i++)
            for (int j = 0; j < get_max(jobs.Rows.Count, 1); j++)
            shifts_in_days[i,j] = new Shift();

        string[] shifts = dt.Rows[0]["morning"].ToString().Split('#');
        if(dt.Rows[0]["morning"].ToString()!="")
            for (int i = 0; i < shifts.Length; i++)
            {
                string[] param = shifts[i].Split('@');
                if (int.Parse(param[0]) < 4)//first page include only 4 first days
                {
                    int j = shifts_in_days[int.Parse(param[0]), 0].num_of_workers;
                    int count = 0;
                    if (use_jobs)
                        while ((param[1] != jobs.Rows[count]["short_job"].ToString() && param[1] != "") && (count <= get_max(jobs.Rows.Count, 1)))
                        {
                            count++;
                            j = shifts_in_days[int.Parse(param[0]), count].num_of_workers;

                        }
                    else
                        while (j != 0)
                        {
                            count++;
                            j = shifts_in_days[int.Parse(param[0]), count].num_of_workers;

                        }
                    shifts_in_days[int.Parse(param[0]), count] = new Shift(int.Parse(param[2]), param[1], param[3]);

                }
            }
        for (int i = 0; i < 4; i++)
        {
            if (i == 3) Response.Write("<td align='center' colspan='2'>");
            else Response.Write("<td align='center'>");
            if (!use_jobs)
                Response.Write("<select id='Select6' name='S_0_" + i + "_0'><option value='" + shifts_in_days[i,0].num_of_workers + "'>" + shifts_in_days[i,0].num_of_workers + "</option>" + Add_Options() + "</select>");
            else
            {
                Response.Write("<table id = 'reg' >");
                int count = 0;
                foreach(DataRow job in jobs.Rows)
                {
                    Response.Write("<tr><td>");
                    Response.Write("<select id='Select6' name='S_0_" + i + "_" + count + "'><option value='" + shifts_in_days[i,count].num_of_workers + "'>" + shifts_in_days[i,count].num_of_workers + "</option>" + Add_Options() + "</select>");
                    Response.Write("</td><td>");
                    Response.Write("<input type='text' dir='rtl' readonly='readonly' name='T_0_"+i+"_"+count+"' style='border-style: none;  width: 30px;' value='" + job["Short_Job"] + "' />");
                    Response.Write("</td></tr>");
                    count++;
                }
                Response.Write("</table>");
            
            }

            Response.Write("</td>");
        }
    
    }
    private int get_max(int p, int p_2)
    {
        if (p > p_2)
            return p;
        return p_2;
    }
    public void print_Intermediate()
        ///S and T index V V V
    {//first number: 0=>mornming 1=>intermediate 2=>evening
        //second number: 0=>sunday 6=>saturday
        //third number: sidury
        ///H index V V V
        //first number: 0=>sunday 6=>saturday
        //second number:sidury
        //third number:1-4 hour/minit start/end
        if (use_jobs && jobs.Rows.Count == 0)//0 jobs
        {
        
           Response.Write("<td colspan='7' align ='center'> </td>");
            return;
        }
        Shift[,] shifts_in_days = new Shift[7, get_max(jobs.Rows.Count, 3)];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < get_max(jobs.Rows.Count, 3); j++)
                shifts_in_days[i, j] = new Shift();

        string[] shifts = dt.Rows[0]["intermediate"].ToString().Split('#');
        if (dt.Rows[0]["intermediate"].ToString() != "")
            for (int i = 0; i < shifts.Length; i++)
            {
                string[] param = shifts[i].Split('@');
                if (int.Parse(param[0]) < 4)//first page include only 4 first days
                {
                    int j = shifts_in_days[int.Parse(param[0]), 0].num_of_workers;
                    int count = 0;
                    while (j != 0)
                    {
                        count++;
                        j = shifts_in_days[int.Parse(param[0]), count].num_of_workers;

                    }
                    shifts_in_days[int.Parse(param[0]), count] = new Shift(int.Parse(param[2]), param[1], param[3]);

                }
            }

        for (int i = 0; i < 4; i++)
        {
            if (i == 3) Response.Write("<td align='center' colspan='2'>");
            else Response.Write("<td align='center'>");
            if (!use_jobs)
                for (int count = 0; count < 3; count++)
                {
                    Response.Write("<table class='reg' /><tr>");
                    Response.Write("<td><select id='Select6' name='S_1_" + i + "_" + count + "'><option value='"+ shifts_in_days[i,count].num_of_workers +"'>" + shifts_in_days[i, count].num_of_workers + "</option>" + Add_Options() + "</select></td>");
                    for(int j =0;j<4;j++)
                    {
                        Response.Write("<td><input name='H_" + i + "_" + count + "_" + j + "' maxlength='2' size='2' type='text' value='" + GetHour(shifts_in_days[i, count].hours,j) + "' /></td>");
                        if(j!=3)
                        if(j%2==0)Response.Write("<td>:</td>");else Response.Write("<td>-</td>");
                    }
                    Response.Write("</tr></table>");
                }
            else
            {
                int count = 0;
                foreach (DataRow job in jobs.Rows)
                {
                    Response.Write("<table class='reg'><tr>");

                    Response.Write("<td><select id='Select6' name='S_1_" + i + "_" + count + "'><option value='"+ shifts_in_days[i,count].num_of_workers +"'>"+ shifts_in_days[i,count].num_of_workers +"</option>" + Add_Options() + "</select></td>");
                    Response.Write("<td><select id='Select6' name='T_1_" + i + "_" + count + "'><option>"+ shifts_in_days[i,count].job +"</option>" + Add_Jobs() + "</select></td>");
                    for (int j = 0; j < 4; j++)
                    {
                        Response.Write("<td><input name='H_" + i + "_" + count + "_" + j + "' maxlength='2' size='2' type='text' style='width: 13px' value='"+ GetHour(shifts_in_days[i,count].hours,j) +"' /></td>");
                        if (j != 3)
                        if (j % 2 == 0) Response.Write("<td>:</td>"); else Response.Write("<td>-</td>");
                    }
                    Response.Write("</tr>");
                    count++;
                }
                Response.Write("</table>");

            }

            Response.Write("</td>");
        }

    }
    private string GetHour(string p, int j)
    {
        p = p.Replace('-', ':');
        try
        {
            return p.Split(':')[3-j];
        }
        catch
        {
            return "";
        }
    }
    public void print_Evening()
    {//first number: 0=>mornming 1=>intermediate 2=>evening
        //second number: 0=>sunday 6=>saturday
        //third number: sidury
        
        Shift[,] shifts_in_days = new Shift[7, get_max(jobs.Rows.Count, 1)];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < get_max(jobs.Rows.Count, 1); j++)
                shifts_in_days[i, j] = new Shift();

        string[] shifts = dt.Rows[0]["evening"].ToString().Split('#');
        if (dt.Rows[0]["evening"].ToString() != "")
            for (int i = 0; i < shifts.Length; i++)
            {
                string[] param = shifts[i].Split('@');
                if (int.Parse(param[0]) < 4)//first page include only 4 first days
                {
                    int j = shifts_in_days[int.Parse(param[0]), 0].num_of_workers;
                    int count = 0;
                    if (use_jobs)
                        while ((param[1] != jobs.Rows[count]["short_job"].ToString() && param[1] != "") && (count <= get_max(jobs.Rows.Count, 1)))
                        {
                            count++;
                            j = shifts_in_days[int.Parse(param[0]), count].num_of_workers;
                        }
                    else
                        while (j != 0)
                        {
                            count++;
                            j = shifts_in_days[int.Parse(param[0]), count].num_of_workers;

                        }
                    shifts_in_days[int.Parse(param[0]), count] = new Shift(int.Parse(param[2]), param[1], param[3]);

                }
            }
        for (int i = 0; i < 4; i++)
        {
            if (i == 3) Response.Write("<td align='center' colspan='2'>");
            else Response.Write("<td align='center'>");
            if (!use_jobs)
                Response.Write("<select id='Select6' name='S_2_" + i + "_0'><option value='"+ shifts_in_days[i,0].num_of_workers +"'>" + shifts_in_days[i, 0].num_of_workers + "</option>" + Add_Options() + "</select>");
            else
            {
                Response.Write("<table class='reg'>");
                int count = 0;
                foreach (DataRow job in jobs.Rows)
                {   
                    Response.Write("<tr><td>");
                    Response.Write("<select name='S_2_" + i + "_" + count + "'><option value='"+ shifts_in_days[i,count].num_of_workers +"'>"+ shifts_in_days[i,count].num_of_workers +"</option>" + Add_Options() + "</select>");
                    Response.Write("</td><td>");
                    Response.Write("<input type='text' dir='rtl' readonly='readonly' name='T_2_" + i + "_" + count + "' style='border-style: none; width: 30px;' value='" + job["short_job"] + "' />");
                    Response.Write("</td></tr>");
                    count++;
                }
                Response.Write("</table>");
            }
            Response.Write("</td>");
        }
    }
    public string Add_Options()
    {
        string str="";
        for (int i = 0; i < 10; i++) 
        str += "<option value='" + i + "'>" + i + "</option>";
        return str;
    }
    public string Add_Jobs()
    {
        string str="";
        foreach(DataRow job in jobs.Rows)
            str += "<option value='" + job["short_job"] + "'>" + job["short_job"] + "</option>";
        return str;
    }
}


