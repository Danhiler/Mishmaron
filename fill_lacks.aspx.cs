using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class fill_lacks : System.Web.UI.Page
{
    public string[,]Shifts_Table;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((bool)Session["Loged_In"]) && ((bool)Session["Admin"]))
        {
            DataTable dt = ADO.GetFullTable("Work_Table","ID="+Session["ID"]+" AND week=1");
            Shifts_Table = new string[7,3];
            for(int i=0;i<21;i++)
            Shifts_Table[i%7,i/7] = dt.Rows[0][i+3].ToString();
            DataTable lacks = ADO.GetFullTable("shift_lacks", "ID=" + Session["ID"]);
            dt = ADO.GetFullTable("Workers", "ID=" + Session["ID"]);
            Random rnd = new Random();
            Sort S = new Sort();
            foreach (DataRow lack in lacks.Rows)
            {
                List<worker> possible_workers = new List<worker>();
                List<worker> impossible_workers = new List<worker>();
                ////foreach (DataRow worker in dt.Rows)
                ////    if (!worker["Shifts_Cant_Next"].ToString().Contains(Get_Shift_String(int.Parse(lack["day_S"].ToString()), lack["Session_S"].ToString())))
                ////        possible_workers.Add(new worker(worker["NameW"].ToString(), worker["Job"].ToString(), worker["Shifts_Cant_Next"].ToString(), 0));
                ////    else 
                ////        impossible_workers.Add(new worker(worker["NameW"].ToString(), worker["Job"].ToString(), worker["Shifts_Cant_Next"].ToString(), 0));

                possible_workers = S.Shuffle(possible_workers);//shuffeling
                impossible_workers = S.Shuffle(impossible_workers);//shuffeling
                bool lack_gone = true;
                for (int i = 0; i < int.Parse(lack["num_of_workers"].ToString()); i++)
                {
                    bool flag = false;//shift taken
                    int j=0;
                    while (!flag && possible_workers.Count >j)//choose workers that can work this lack
                    {
                    string name = possible_workers[j].name;
                    if (bool.Parse(Session["Use_Jobs"].ToString()))
                    name = possible_workers[j].job + "|" + possible_workers[j].name;
                    while (name.Length < 13)
                    name += " ";
                        if (check_available(name,lack)){
                            int ses_number = Get_Session_Numb(lack["Session_S"].ToString());
                            Shifts_Table[int.Parse(lack["Day_S"].ToString()),ses_number]+= name;
                            if (ses_number == 1)
                                Shifts_Table[int.Parse(lack["Day_S"].ToString()), ses_number] += lack["Session_S"].ToString() + "  ";
                            flag = true;
                        }
                        j++;
                    }
                    j = 0;
                    while (!flag && impossible_workers.Count > j)//choose workers that cant work this lack
                    {
                        string name = impossible_workers[j].name;
                        if (bool.Parse(Session["Use_Jobs"].ToString()))
                            name = impossible_workers[j].job + "|" + impossible_workers[j].name;
                        while (name.Length < 13)
                            name += " ";
                        if (check_available(name, lack))
                        {
                            int ses_number = Get_Session_Numb(lack["Session_S"].ToString());
                            Shifts_Table[int.Parse(lack["Day_S"].ToString()), ses_number] += name;
                            if (ses_number == 1)
                                Shifts_Table[int.Parse(lack["Day_S"].ToString()), ses_number] += lack["Session_S"].ToString() + "  ";
                            flag = true;
                        }
                        j++;
                    }
                    if (!flag) lack_gone = false;
                }
                if(lack_gone)
                    ADO.ExecuteNonQuery("DELETE FROM shift_lacks Where Lack_ID=" + lack["Lack_ID"].ToString());
            }
            
            Shifts_Table = S.SortTable(Shifts_Table);
            string sql = "Update Work_Table Set sunday_morning='" + Shifts_Table[0, 0] +
           "', monday_morning='" + Shifts_Table[1, 0] +
           "', tuesday_morning='" + Shifts_Table[2, 0] +
           "', wednesday_morning='" + Shifts_Table[3, 0] +
           "', thursday_morning='" + Shifts_Table[4, 0] +
           "', friday_morning='" + Shifts_Table[5, 0] +
           "', saturday_morning='" + Shifts_Table[6, 0] +
          "', sunday_intermediate='" + Shifts_Table[0, 1] +
            "', monday_intermediate='" + Shifts_Table[1, 1] +
            "', tuesday_intermediate='" + Shifts_Table[2, 1] +
            "', wednesday_intermediate='" + Shifts_Table[3, 1] +
            "', thursday_intermediate='" + Shifts_Table[4, 1] +
            "', friday_intermediate='" + Shifts_Table[5, 1] +
            "', saturday_intermediate='" + Shifts_Table[6, 1] +
          "', sunday_evening='" + Shifts_Table[0, 2] +
          "', monday_evening='" + Shifts_Table[1, 2] +
          "', tuesday_evening='" + Shifts_Table[2, 2] +
          "', wednesday_evening='" + Shifts_Table[3, 2] +
          "', thursday_evening='" + Shifts_Table[4, 2] +
          "', friday_evening='" + Shifts_Table[5, 2] +
          "', saturday_evening='" + Shifts_Table[6, 2] +
          "', Allow_Changes=FALSE" +
          " where ID=" + Session["ID"] + " And week=1";
            ADO.ExecuteNonQuery(sql);

            Response.Redirect("Shifts_Next_Week.aspx");
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }

    }
    private string Get_Shift_String(int day, string session)
    {
        string str="";
        switch (day)
        {
            case 0: str = "SU"; break;
            case 1: str = "MO"; break;
            case 2: str = "TU"; break;
            case 3: str = "WE"; break;
            case 4: str = "TH"; break;
            case 5: str = "FR"; break;
            case 6: str = "SA"; break;
            default: str = ""; break;
        }
        switch (session)
        {
            case "בוקר": str += "M"; break;
            case "ערב": str += "E"; break;
            default: str += "I#"+Session; break;
        }
        return str;
    }
    private int Get_Session_Numb(string ses)
    {
        switch (ses)
        {
            case "בוקר":
                return 0;
            case "ערב":
                return 2;
            default:
                return 1;
        }
    }
    private bool check_available(string name, DataRow lack)
    {
        string day_name= Get_Day_Name(int.Parse(lack["Day_S"].ToString()));
        if ((!Shifts_Table[int.Parse(lack["Day_S"].ToString()),0].ToString().Contains(name)) &&
            (!Shifts_Table[int.Parse(lack["Day_S"].ToString()), 1].ToString().Contains(name)) &&
            (!Shifts_Table[int.Parse(lack["Day_S"].ToString()),2].ToString().Contains(name)))
            if (bool.Parse(Session["Use_Jobs"].ToString()))
                return (name.Split('|')[0] == lack["Job"].ToString());
            else
            return true;

            return false;

    }
    private string Get_Day_Name(int day)
    {
        switch (day)
        {
            case 0:
                return "sunday";
                
            case 1:
                return "monday";
                
            case 2:
                return "tuesday";
                
            case 3:
                return "wednesday";
                
            case 4:
                return "thursday";
                
            case 5:
                return "friday";
                
            case 6:
                return "saturday";
                
        }
        return "";
    }
}
