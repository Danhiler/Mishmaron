using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class Update_shifts : System.Web.UI.Page
{
    public bool inter;
    List<worker> AI_workers;
    string[,] AI_mat = new string[7, 3];
    public bool use_jobs;
    DataTable workers_list_db=new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        workers_list_db = ADO.GetFullTable("Workers", "ID=" + Session["ID"]);
        DataTable DOP = ADO.GetFullTable("Options", "ID=" + Session["ID"]);
        inter = (DOP.Rows[0]["intermediate_Shifts"].ToString() == "True");
        use_jobs = bool.Parse(Session["Use_Jobs"].ToString());
        if ((bool)Session["Loged_In"])
        {
            #region save changes
            if (Request.Form["Save_Changes"] != null)
            {
                string sql;
                int al = 0;
                if (Request.Form["AC"] == null)
                    al = 1;
                if (!bool.Parse(Session["Admin"].ToString()))
                {//shifts not ready and the person isnt admin
                    #region update strings
                    
                    DataTable dt = ADO.GetFullTable("Work_Table", " ID=" + Session["ID"] + " And week= 1");
                    string SUM = dt.Rows[0]["sunday_morning"].ToString();
                    string MM = dt.Rows[0]["monday_morning"].ToString();
                    string TUM = dt.Rows[0]["tuesday_morning"].ToString();
                    string WM = dt.Rows[0]["wednesday_morning"].ToString();
                    string THM = dt.Rows[0]["thursday_morning"].ToString();
                    string FM = dt.Rows[0]["friday_morning"].ToString();
                    string SAM = dt.Rows[0]["saturday_morning"].ToString();

                    string SUI = dt.Rows[0]["sunday_intermediate"].ToString();
                    string MI = dt.Rows[0]["monday_intermediate"].ToString();
                    string TUI = dt.Rows[0]["tuesday_intermediate"].ToString();
                    string WI = dt.Rows[0]["wednesday_intermediate"].ToString();
                    string THI = dt.Rows[0]["thursday_intermediate"].ToString();
                    string FI = dt.Rows[0]["friday_intermediate"].ToString();
                    string SAI = dt.Rows[0]["saturday_intermediate"].ToString();
                    
                    string SUE = dt.Rows[0]["sunday_evening"].ToString();
                    string ME = dt.Rows[0]["monday_evening"].ToString();
                    string TUE = dt.Rows[0]["tuesday_evening"].ToString();
                    string WE = dt.Rows[0]["wednesday_evening"].ToString();
                    string THE = dt.Rows[0]["thursday_evening"].ToString();
                    string FE = dt.Rows[0]["friday_evening"].ToString();
                    string SAE = dt.Rows[0]["saturday_evening"].ToString();

                    int Width_Of_Boxes = 13;
                    string name = Session["wname"].ToString();
                    if (bool.Parse(DOP.Rows[0]["Use_Jobs"].ToString()))
                        name = ADO.GetFullTable("Workers","ID="+Session["ID"]+" AND NameW='"+Session["Wname"]+"'").Rows[0]["Job"].ToString() + "|" + Session["wname"].ToString();
                    while (name.Length < 13)
                        name += " ";
                    
                    if (SUM.Contains(name)) SUM = SUM.Remove(SUM.IndexOf(name), Width_Of_Boxes); 
                    if(Request.Form["0_morning"].ToString()=="2")SUM += name; 
                    if (MM.Contains(name))  MM = MM.Remove(MM.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["1_morning"].ToString() == "2") MM += name;   
                    if (TUM.Contains(name))  TUM = TUM.Remove(TUM.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["2_morning"].ToString() == "2") TUM += name; 
                    if (WM.Contains(name)) WM = WM.Remove(WM.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["3_morning"].ToString() == "2") WM += name; 
                    if (THM.Contains(name)) THM = THM.Remove(THM.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["4_morning"].ToString() == "2") THM += name; 
                    if (FM.Contains(name))  FM = FM.Remove(FM.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["5_morning"].ToString() == "2") FM += name;
                    if (SAM.Contains(name))  SAM = SAM.Remove(SAM.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["6_morning"].ToString() == "2") SAM += name;

                    if (inter)
                    {
                        while (SUI.Contains(name)) SUI = SUI.Remove(SUI.IndexOf(name), Width_Of_Boxes * 2);
                        while (MI.Contains(name)) MI = MI.Remove(MI.IndexOf(name), Width_Of_Boxes * 2);
                        while (TUI.Contains(name)) TUI = TUI.Remove(TUI.IndexOf(name), Width_Of_Boxes * 2);
                        while (WI.Contains(name)) WI = WI.Remove(WI.IndexOf(name), Width_Of_Boxes * 2);
                        while (THI.Contains(name)) THI = THI.Remove(THI.IndexOf(name), Width_Of_Boxes * 2);
                        while (FI.Contains(name)) FI = FI.Remove(FI.IndexOf(name), Width_Of_Boxes * 2);
                        while (SAI.Contains(name)) SAI = SAI.Remove(SAI.IndexOf(name), Width_Of_Boxes * 2);

                        if(Request.Form["InterShift"]!=null)
                           foreach( string shift in Request.Form["InterShift"].ToString().Split(','))
                           {
                               string []param=shift.Split('@');
                               if(param[0]=="2")
                               switch (param[1])
                               {
                                   case "SUI":
                                       SUI += name + param[2] + "  ";
                                       break;
                                   case "MI":
                                       MI += name + param[2] + "  ";
                                       break;
                                   case "TUI":
                                       TUI += name + param[2] + "  ";
                                       break;
                                   case "WI":
                                       WI += name + param[2] + "  ";
                                       break;
                                   case "THI":
                                       THI += name + param[2] + "  ";
                                       break;
                                   case "FI":
                                       FI += name + param[2] + "  ";
                                       break;
                                   case "SAI":
                                       SAI += name + param[2] + "  ";
                                       break;
                               }
                            }
                    }
                    if (SUE.Contains(name))  SUE = SUE.Remove(SUE.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["0_evening"].ToString() == "2") SUE += name; 
                    if (ME.Contains(name))  ME = ME.Remove(ME.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["1_evening"].ToString() == "2") ME += name;  
                    if (TUE.Contains(name))  TUE = TUE.Remove(TUE.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["2_evening"].ToString() == "2") TUE += name; 
                    if (WE.Contains(name))  WE = WE.Remove(WE.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["3_evening"].ToString() == "2") WE += name; 
                    if (THE.Contains(name))  THE = THE.Remove(THE.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["4_evening"].ToString() == "2") THE += name; 
                    if (FE.Contains(name))  FE = FE.Remove(FE.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["5_evening"].ToString() == "2") FE += name; 
                    if (SAE.Contains(name))  SAE = SAE.Remove(SAE.IndexOf(name), Width_Of_Boxes);
                    if (Request.Form["6_evening"].ToString() == "2") SAE += name; 

                    sql = "Update Work_Table Set sunday_morning='" + SUM +
                                                 "', monday_morning='" + MM +
                                                 "', tuesday_morning='" + TUM +
                                                 "', wednesday_morning='" + WM +
                                                 "', thursday_morning='" + THM +
                                                 "', friday_morning='" + FM +
                                                 "', saturday_morning='" + SAM;
                    if (inter)
                    {
                        sql += "', sunday_intermediate='" + SUI +
                                                  "', monday_intermediate='" +MI +
                                                  "', tuesday_intermediate='" + TUI +
                                                  "', wednesday_intermediate='" + WI +
                                                  "', thursday_intermediate='" + THI +
                                                  "', friday_intermediate='" + FI +
                                                  "', saturday_intermediate='" + SAI;
                    }
                    sql += "', sunday_evening='" + SUE +
                                       "', monday_evening='" + ME +
                                       "', tuesday_evening='" + TUE +
                                       "', wednesday_evening='" + WE +
                                       "', thursday_evening='" + THE +
                                       "', friday_evening='" + FE +
                                       "', saturday_evening='" + SAE +
                                       "', Allow_Changes='" + al +
                                       "' where ID=" + Session["ID"] + " And week=" + Request.Form["Week"].ToString();

                    ADO.ExecuteNonQuery(sql);
                    #endregion
                  Update_Swichs();

                }
                else
                {

                    sql = "Update Work_Table Set sunday_morning='" + ADO.filter(Request.Form["Sunday_Morning"].ToString()) +
                                                 "', monday_morning='" + ADO.filter(Request.Form["Monday_Morning"].ToString()) +
                                                 "', tuesday_morning='" + ADO.filter(Request.Form["Tuesday_Morning"].ToString()) +
                                                 "', wednesday_morning='" + ADO.filter(Request.Form["Wednesday_Morning"].ToString()) +
                                                 "', thursday_morning='" + ADO.filter(Request.Form["Thursday_Morning"].ToString()) +
                                                 "', friday_morning='" + ADO.filter(Request.Form["Friday_Morning"].ToString()) +
                                                 "', saturday_morning='" + ADO.filter(Request.Form["Saturday_Morning"].ToString());
                    if (inter)
                    {
                        sql += "', sunday_intermediate='" + ADO.filter(Request.Form["Sunday_intermediate"].ToString()) +
                                                  "', monday_intermediate='" + ADO.filter(Request.Form["Monday_intermediate"].ToString()) +
                                                  "', tuesday_intermediate='" + ADO.filter(Request.Form["Tuesday_intermediate"].ToString()) +
                                                  "', wednesday_intermediate='" + ADO.filter(Request.Form["Wednesday_intermediate"].ToString()) +
                                                  "', thursday_intermediate='" + ADO.filter(Request.Form["Thursday_intermediate"].ToString()) +
                                                  "', friday_intermediate='" + ADO.filter(Request.Form["Friday_intermediate"].ToString()) +
                                                  "', saturday_intermediate='" + ADO.filter(Request.Form["Saturday_intermediate"].ToString());
                    }
                    sql += "', sunday_evening='" + ADO.filter(Request.Form["Sunday_Evening"].ToString()) +
                                       "', monday_evening='" + ADO.filter(Request.Form["Monday_Evening"].ToString()) +
                                       "', tuesday_evening='" + ADO.filter(Request.Form["Tuesday_Evening"].ToString()) +
                                       "', wednesday_evening='" + ADO.filter(Request.Form["Wednesday_Evening"].ToString()) +
                                       "', thursday_evening='" + ADO.filter(Request.Form["Thursday_Evening"].ToString()) +
                                       "', friday_evening='" + ADO.filter(Request.Form["Friday_Evening"].ToString()) +
                                       "', saturday_evening='" + ADO.filter(Request.Form["Saturday_Evening"].ToString()) +
                                       "', Allow_Changes='" + al +
                                       "' where ID=" + Session["ID"] + " And week=" + Request.Form["Week"].ToString();

                    ADO.ExecuteNonQuery(sql);
                }
            
                
                if ((bool)Session["Admin"] == true)
                {
                    sql = "Update Options Set Last_Updated='" + DateTime.Now + "' where ID=" + Session["ID"];
                    ADO.ExecuteNonQuery(sql);
                }
                if (Request.Form["Week"] == "0")
                    Response.Redirect("Shifts_this_week.aspx");
                else
                    Response.Redirect("Shifts_next_week.aspx");
            }
            #endregion
            if ((bool)Session["Admin"] == true)
            {
                #region erase
                if (Request.Form["Erase_All"] != null)
                {
                    string sql = "Update Work_Table Set sunday_morning='', monday_morning='', tuesday_morning='', wednesday_morning='', thursday_morning='', friday_morning='', saturday_morning='', sunday_intermediate='', monday_intermediate='', tuesday_intermediate='', wednesday_intermediate='', thursday_intermediate='', friday_intermediate='', saturday_intermediate='', sunday_evening='', monday_evening='', tuesday_evening='', wednesday_evening='', thursday_evening='', friday_evening='', saturday_evening='' where ID=" + Session["ID"] + " And week=" + Request.Form["Week"].ToString();
                    ADO.ExecuteNonQuery(sql);

                    if (Request.Form["Week"] == "0")
                        Response.Redirect("Shifts_this_week.aspx");
                    else
                        Response.Redirect("Shifts_next_week.aspx");
                }
                #endregion
                #region set conse
                if (Request.Form["set_const"] != null)
                {
                    DataRow dt = ADO.GetFullTable("Work_Table", "week=2 And ID=" + Session["ID"]).Rows[0];

                    string sql = "Update Work_Table Set sunday_morning='" + dt["sunday_morning"] + "', monday_morning='" + dt["monday_morning"] + "', tuesday_morning='" + dt["tuesday_morning"] + "', wednesday_morning='" + dt["wednesday_morning"] + "', thursday_morning='" + dt["thursday_morning"] + "', friday_morning='" + dt["friday_morning"] + "', saturday_morning='" + dt["saturday_morning"] + "', sunday_intermediate='" + dt["sunday_intermediate"] + "', monday_intermediate='" + dt["monday_intermediate"] + "', tuesday_intermediate='" + dt["tuesday_intermediate"] + "', wednesday_intermediate='" + dt["wednesday_intermediate"] + "', thursday_intermediate='" + dt["thursday_intermediate"] + "', friday_intermediate='" + dt["friday_intermediate"] + "', saturday_intermediate='" + dt["saturday_intermediate"] + "', sunday_evening='" + dt["sunday_evening"] + "', monday_evening='" + dt["monday_evening"] + "', tuesday_evening='" + dt["tuesday_evening"] + "', wednesday_evening='" + dt["wednesday_evening"] + "', thursday_evening='" + dt["thursday_evening"] + "', friday_evening='" + dt["friday_evening"] + "', saturday_evening='" + dt["saturday_evening"] + "' where ID=" + Session["ID"] + " And week=" + Request.Form["Week"].ToString();

                    ADO.ExecuteNonQuery(sql);
                    if (Request.Form["Week"] == "0")
                        Response.Redirect("Shifts_this_week.aspx");
                    else
                        Response.Redirect("Shifts_next_week.aspx");
                }
                #endregion
                #region Arange Shifts
                if (Request.Form["AI_shift"] != null)
                {

                    for (int i = 0; i < 7; i++)
                        for (int j = 0; j < 3; j++)
                            AI_mat[i, j] = "";
                    TakeConstShifts();
                    DataTable workers = ADO.GetFullTable("Workers", "ID="+Session["ID"]);
                    AI_workers = new List<worker>();
                    foreach (DataRow worker in workers.Rows)
                    {
                        string name = worker["NameW"].ToString();
                        if (use_jobs) name = worker["Job"].ToString() + "|" + worker["NameW"].ToString();

                        string shifts="";
                        if (Request.Form["Sunday_Morning"].Contains(name)) shifts += "sum@";
                        if (Request.Form["Monday_Morning"].Contains(name) )shifts += "mom@";
                        if (Request.Form["Tuesday_Morning"].Contains(name)) shifts += "tum@";
                        if (Request.Form["wednesday_Morning"].Contains(name)) shifts += "wem@";
                        if (Request.Form["Thursday_Morning"].Contains(name)) shifts += "thm@";
                        if (Request.Form["Friday_Morning"].Contains(name)) shifts += "frm@";
                        if (Request.Form["Saturday_Morning"].Contains(name)) shifts += "sam@";
                        if (inter)
                        {
                            if (Request.Form["Sunday_Intermediate"].Contains(name))
                                shifts += "sui#" + Request.Form["Sunday_Intermediate"].Substring(Request.Form["Sunday_Intermediate"].IndexOf(name)+13,11) + "@";
                            if (Request.Form["Monday_Intermediate"].Contains(name))
                                shifts += "moi#" + Request.Form["Monday_Intermediate"].Substring(Request.Form["Monday_Intermediate"].IndexOf(name) + 13, 11) + "@";
                            if (Request.Form["Tuesday_Intermediate"].Contains(name))
                                shifts += "tui#" + Request.Form["Tuesday_Intermediate"].Substring(Request.Form["Tuesday_Intermediate"].IndexOf(name) + 13, 11) + "@";
                            if (Request.Form["Wednesday_Intermediate"].Contains(name))
                                shifts += "wei#" + Request.Form["Wednesday_Intermediate"].Substring(Request.Form["Wednesday_Intermediate"].IndexOf(name) + 13, 11) + "@";
                            if (Request.Form["Thursday_Intermediate"].Contains(name))
                                shifts += "thi#" + Request.Form["Thursday_Intermediate"].Substring(Request.Form["Thursday_Intermediate"].IndexOf(name) + 13, 11) + "@";
                            if (Request.Form["Friday_Intermediate"].Contains(name))
                                shifts += "fri#" + Request.Form["Friday_Intermediate"].Substring(Request.Form["Friday_Intermediate"].IndexOf(name) + 13, 11) + "@";
                            if (Request.Form["saturday_Intermediate"].Contains(name))
                                shifts += "sai#" + Request.Form["saturday_Intermediate"].Substring(Request.Form["saturday_Intermediate"].IndexOf(name) + 13, 11) + "@";
                        }
                        if (Request.Form["Sunday_Evening"].Contains(name)) shifts += "sue@";
                        if (Request.Form["Monday_Evening"].Contains(name)) shifts += "moe@";
                        if (Request.Form["Tuesday_Evening"].Contains(name)) shifts += "tue@";
                        if (Request.Form["Wednesday_Evening"].Contains(name)) shifts += "wee@";
                        if (Request.Form["Thursday_Evening"].Contains(name)) shifts += "the@";
                        if (Request.Form["Friday_Evening"].Contains(name)) shifts += "fre@";
                        if (Request.Form["Saturday_Evening"].Contains(name)) shifts += "sae@";

                        if (shifts != "")
                        {
                            shifts = shifts.Remove(shifts.Length - 1);
                            AI_workers.Add(new worker(worker["NameW"].ToString(), worker["Job"].ToString(), shifts, shifts.Split('@').Length,worker["Shifts_Cant_Next"].ToString()));
                        }
                    }
                    Sort S = new Sort();
                    AI_workers = S.Arrange_list(AI_workers);
                    AI_Automat_Shifts(AI_workers);
                    Fill_Lacks();
                    AI_mat = S.SortTable(AI_mat);

                                      string  sql = "Update Work_Table Set sunday_morning='" + AI_mat[0,0] +
                                                 "', monday_morning='" + AI_mat[1, 0] +
                                                 "', tuesday_morning='" + AI_mat[2, 0] +
                                                 "', wednesday_morning='" + AI_mat[3, 0] +
                                                 "', thursday_morning='" + AI_mat[4, 0] +
                                                 "', friday_morning='" + AI_mat[5, 0] +
                                                 "', saturday_morning='" + AI_mat[6, 0]+
                                                "', sunday_intermediate='" + AI_mat[0, 1] +
                                                  "', monday_intermediate='" + AI_mat[1, 1] +
                                                  "', tuesday_intermediate='" + AI_mat[2, 1] +
                                                  "', wednesday_intermediate='" + AI_mat[3, 1] +
                                                  "', thursday_intermediate='" + AI_mat[4, 1] +
                                                  "', friday_intermediate='" + AI_mat[5, 1] +
                                                  "', saturday_intermediate='" + AI_mat[6, 1]+
                                                "', sunday_evening='" + AI_mat[0, 2] +
                                                "', monday_evening='" + AI_mat[1, 2] +
                                                "', tuesday_evening='" + AI_mat[2, 2] +
                                                "', wednesday_evening='" + AI_mat[3, 2] +
                                                "', thursday_evening='" + AI_mat[4, 2] +
                                                "', friday_evening='" + AI_mat[5, 2] +
                                                "', saturday_evening='" + AI_mat[6, 2] +
                                                "', Allow_Changes=FALSE" +
                                                " where ID=" + Session["ID"] + " And week=" + Request.Form["Week"].ToString();

                    ADO.ExecuteNonQuery(sql);
                    
                }


                #endregion
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }

    private void TakeConstShifts()
    {
        DataRow dt = ADO.GetFullTable("Work_Table", "week=2 AND ID=" + Session["ID"]).Rows[0];
        bool const_shift = bool.Parse(dt["allow_changes"].ToString());
        if (const_shift)
            for (int i = 0; i < 21; i++)
                AI_mat[i % 7, i / 7] += dt[3 + i].ToString();
    }
    public void AI_Automat_Shifts(List<worker> AI_workers)
    {
        if (AI_workers.Count != 0)
        {
            for (int j = 0; j < AI_workers[AI_workers.Count - 1].Num_Of_Shifts_requested; j++)
            {
                for (int i = 0; i < AI_workers.Count; i++)
                {

                    worker W = AI_workers[i];
                    string[] arr = W.Shifts.Split('@');
                    bool got_shift = false;
                    int shiftnum = 1;
                    while (!got_shift && arr.Length >= shiftnum)
                    {
                        string time = FindTime(arr[shiftnum - 1]);
                        int day = int.Parse(time[0].ToString());
                        int section = int.Parse(time[1].ToString());
                        if (check_available(W, shiftnum, day, section))
                        {
                            Add_Shift(W, shiftnum, day, section);
                            W.Num_Of_Shifts++;
                            got_shift = true;
                        }
                        else
                            shiftnum++;
                    }
                }
            }
        }
    }
    public string FindTime(string shift)
    {
        string time = "";
        switch (shift.Split('#')[0])
        {
            case "sum":
                time = "00";
                break;
            case "mom":
                time = "10";
                break;
            case "tum":
                time = "20";
                break;
            case "wem":
                time = "30";
                break;
            case "thm":
                time = "40";
                break;
            case "frm":
                time = "50";
                break;
            case "sam":
                time = "60";
                break;
            case "sui":
                time = "01";
                break;
            case "moi":
                time = "11";
                break;
            case "tui":
                time = "21";
                break;
            case "wei":
                time = "31";
                break;
            case "thi":
                time = "41";
                break;
            case "fri":
                time = "51";
                break;
            case "sai":
                time = "61";
                break;
            case "sue":
                time = "02";
                break;
            case "moe":
                time = "12";
                break;
            case "tue":
                time = "22";
                break;
            case "wee":
                time = "32";
                break;
            case "the":
                time = "42";
                break;
            case "fre":
                time = "52";
                break;
            case "sae":
                time = "62";
                break;
        }
        return time;
    }
    private void Add_Shift(worker w, int shiftnum, int day, int section)
    {
        string name = w.name;
        if (use_jobs) name = w.job + "|" + w.name;
        while(name.Length<13)
            name+=" ";
        if (section != 1)
            AI_mat[day, section] += name;
        else
            AI_mat[day, section] += name+w.Shifts.Split('@')[shiftnum-1].Split('#')[1]+"  ";
    }

    public bool better_shift(worker W, int day, int Currentsection, int LastSection, Shift Cur_match_need, Shift Last_match_need)
    {
        int[] mone = new int[2];
        string strCurrSection = "", strLastSection = "";
        #region fill string
        if (Currentsection == 2)
            strCurrSection = "e";
        else
            strCurrSection = "i";
        if (LastSection == 0)
            strLastSection = "m";
        else
            strLastSection = "i";
        string strday = "";
        switch (day)
        {
            case 0:
                strday = "su";
                break;
            case 1:
                strday = "mo";
                break;
            case 2:
                strday = "tu";
                break;
            case 3:
                strday = "we";
                break;
            case 4:
                strday = "th";
                break;
            case 5:
                strday = "fr";
                break;
            case 6:
                strday = "sa";
                break;
        }
        #endregion
        foreach (worker worker in AI_workers)
        {
            if (worker.Shifts.Contains(strday + strLastSection))
                mone[0]++;
            if (worker.Shifts.Contains(strday + strCurrSection))
                mone[1]++;
        }
        if ((mone[0] > Last_match_need.num_of_workers) && (mone[1] > Cur_match_need.num_of_workers))
            return false;
        if ((mone[0] > Last_match_need.num_of_workers) && (mone[1] <= Cur_match_need.num_of_workers))
        {
            string name = W.name;
            if (use_jobs)
                name = W.job + "|" + W.name;
            AI_mat[day, LastSection] = AI_mat[day, LastSection].Remove(AI_mat[day, LastSection].IndexOf(name), 13);
            W.Num_Of_Shifts--;
            return true;
        }
        return false;
    }
    private bool check_available(worker W, int shiftnum,int day, int section)
    {
         Shift match_need = new Shift();
         DataRow AI = ADO.GetFullTable("AI_Optionts", "ID=" + Session["ID"]).Rows[0];
         string str = AI[section + 1].ToString();
         if (str == "") return false;//no shifts
         foreach (string need in str.Split('#'))
         {
             string[] param = need.Split('@');
             if (use_jobs)
             {
                 if (param[1] == W.job)
                     if (int.Parse(param[0].ToString()) == day)
                         if (section == 1)
                         {
                             if (param[3] == W.Shifts.Split('@')[shiftnum - 1].Split('#')[1])
                                 match_need = new Shift(int.Parse(param[2]), param[1], param[3]);
                         }
                         else
                             match_need = new Shift(int.Parse(param[2]), param[1], "");
             }
             else
             {
                 if (int.Parse(param[0].ToString()) == day)
                     if (section == 1)
                     {
                         if (param[3] == W.Shifts.Split('@')[shiftnum - 1].Split('#')[1])
                             match_need = new Shift(int.Parse(param[2]), param[1], param[3]);
                     }
                     else
                         match_need = new Shift(int.Parse(param[2]), param[1], "");
             }
         }
             if (section == 1)
             {
                 if (GetNumOfWorkersIsShift(AI_mat[day, section],match_need.job,match_need.hours ,true)== match_need.num_of_workers) return false;
             }
             else
             {
                 if (GetNumOfWorkersIsShift(AI_mat[day, section], match_need.job,match_need.hours, false) >= match_need.num_of_workers) return false;
             }
             string name = W.name;
             if (use_jobs) 
                 name = W.job + "|" + W.name;
                 if (AI_mat[day, 0].Contains(name))
                 return better_shift(W, day, section, 0, match_need, FindMatchNeed(W,day,0,AI,""));
                 if (AI_mat[day, 1].Contains(name))
                     return better_shift(W, day, section, 1, match_need, FindMatchNeed(W, day, 1, AI, AI_mat[day, 1].Substring(AI_mat[day, 1].IndexOf(name) + 13, 11)));
                if (AI_mat[day, 2].Contains(name))
            return better_shift(W, day, section, 2, match_need, FindMatchNeed(W, day, 2, AI, ""));
        return true;
    }//fill regular
    private bool check_available(string name, int day, string job)//fill lacks
    {
        if ((!AI_mat[day, 0].ToString().Contains(name)) &&
            (!AI_mat[day, 1].ToString().Contains(name)) &&
            (!AI_mat[day, 2].ToString().Contains(name)))
            if (bool.Parse(Session["Use_Jobs"].ToString()))
                return (name.Split('|')[0] == job);
            else
                return true;

        return false;

    }

    public Shift FindMatchNeed(worker W, int day, int section, DataRow AI_Needs, string hours)
    {
        Shift match_need = null;
        string str = AI_Needs[1 + section].ToString();
        foreach (string need in str.Split('#'))
        {
            string[] param = need.Split('@');
            if (use_jobs)
            {
                if (param[1] == W.job)
                    if (int.Parse(param[0].ToString()) == day)
                        if (section == 1)
                        {
                            if (param[3] == hours)
                                match_need = new Shift(int.Parse(param[2]), param[1], param[3]);
                        }
                        else
                            match_need = new Shift(int.Parse(param[2]), param[1], "");
            }
            else
            {
                if (int.Parse(param[0].ToString()) == day)
                    if (section == 1)
                    {
                        if (param[3] == hours)
                            match_need = new Shift(int.Parse(param[2]), param[1], param[3]);
                    }
                    else
                        match_need = new Shift(int.Parse(param[2]), param[1], "");
            }
        }
        return match_need;
    }
    private int GetNumOfWorkersIsShift(string txt, string job, string hours, bool inter)
    {
        int mone = 0;
        if (inter)
        {
            if (job == "")
            {
                while (txt.Contains(hours))
                {
                    mone++;
                    txt = txt.Remove(txt.IndexOf(hours), 13);
                }
            }
            else
            {
                while (txt.Length > 0)
                {
                    string sub = txt.Substring(0, 26);
                    if (sub.Contains(job) && sub.Contains(hours)) mone++;
                    txt = txt.Remove(0, 26);
                }
            }
        }
        else
        {
            if (job == "")
                return txt.Length / 13;
            else
            {
                while (txt.Contains(job))
                {
                    mone++;
                    txt = txt.Remove(txt.IndexOf(job), 13);
                }

            }
        }
        return mone;
    }

    private void Update_Swichs()
    {
        string sql="";// shifts that worker can work in
        string dsql = "";// shifts that worker cant work in

        if (Request.Form["0_morning"].ToString() == "2") sql += "SUM@";
        if (Request.Form["0_morning"].ToString() == "0") dsql += "SUM@";
        if (Request.Form["1_morning"].ToString() == "2") sql += "MOM@";
        if (Request.Form["1_morning"].ToString() == "0") dsql += "MOM@";
        if (Request.Form["2_morning"].ToString() == "2") sql += "TUM@";
        if (Request.Form["2_morning"].ToString() == "0") dsql += "TUM@";
        if (Request.Form["3_morning"].ToString() == "2") sql += "WEM@";
        if (Request.Form["3_morning"].ToString() == "0") dsql += "WEM@";
        if (Request.Form["4_morning"].ToString() == "2") sql += "THM@";
        if (Request.Form["4_morning"].ToString() == "0") dsql += "THM@";
        if (Request.Form["5_morning"].ToString() == "2") sql += "FRM@";
        if (Request.Form["5_morning"].ToString() == "0") dsql += "FRM@";
        if (Request.Form["6_morning"].ToString() == "2") sql += "SAM@";
        if (Request.Form["6_morning"].ToString() == "0") dsql += "SAM@";
        if (inter)
        {
            if(Request.Form["InterShift"]!=null)
                           foreach( string shift in Request.Form["InterShift"].ToString().Split(','))
                           {
                               string []param=shift.Split('@');
                               if(param[0]=="2")
                               switch (param[1])
                               {
                                   case "SUI":
                                       sql += "SUI#"+param[2]+"@"; 
                                       break;
                                   case "MI":
                                       sql += "MOI#" + param[2] + "@";
                                       break;
                                   case "TUI":
                                       sql += "TUI#" + param[2] + "@";
                                       break;
                                   case "WI":
                                       sql += "WEI#" + param[2] + "@";
                                       break;
                                   case "THI":
                                       sql += "THI#" + param[2] + "@";
                                       break;
                                   case "FI":
                                       sql += "FRI#" + param[2] + "@";
                                       break;
                                   case "SAI":
                                       sql += "SAI#" + param[2] + "@";
                                       break;
                               }
                               if(param[0]=="0")
                                   switch (param[1])
                                   {
                                       case "SUI":
                                           dsql += "SUI#" + param[2] + "@";
                                           break;
                                       case "MI":
                                           dsql += "MOI#" + param[2] + "@";
                                           break;
                                       case "TUI":
                                           dsql += "TUI#" + param[2] + "@";
                                           break;
                                       case "WI":
                                           dsql += "WEI#" + param[2] + "@";
                                           break;
                                       case "THI":
                                           dsql += "THI#" + param[2] + "@";
                                           break;
                                       case "FI":
                                           dsql += "FRI#" + param[2] + "@";
                                           break;
                                       case "SAI":
                                           dsql += "SAI#" + param[2] + "@";
                                           break;
                                   }
                            }
                    
            }
        if (Request.Form["0_evening"].ToString() == "2") sql += "SUE@";
        if (Request.Form["0_evening"].ToString() == "0") dsql += "SUE@";
        if (Request.Form["1_evening"].ToString() == "2") sql += "MOE@";
        if (Request.Form["1_evening"].ToString() == "0") dsql += "MOE@";
        if (Request.Form["2_evening"].ToString() == "2") sql += "TUE@";
        if (Request.Form["2_evening"].ToString() == "0") dsql += "TUE@";
        if (Request.Form["3_evening"].ToString() == "2") sql += "WEE@";
        if (Request.Form["3_evening"].ToString() == "0") dsql += "WEE@";
        if (Request.Form["4_evening"].ToString() == "2") sql += "THE@";
        if (Request.Form["4_evening"].ToString() == "0") dsql += "THE@";
        if (Request.Form["5_evening"].ToString() == "2") sql += "FRE@";
        if (Request.Form["5_evening"].ToString() == "0") dsql += "FRE@";
        if (Request.Form["6_evening"].ToString() == "2") sql += "SAE@";
        if (Request.Form["6_evening"].ToString() == "0") dsql += "SAE@";

        if (sql != "")
            sql = sql.Remove(sql.Length - 1, 1);
        if( dsql != "")
            dsql = dsql.Remove(dsql.Length - 1, 1);

        if(Request.Form["week"].ToString()=="1")
            ADO.ExecuteNonQuery("Update Workers Set Shifts_Next='" + sql + "', Shifts_Cant_Next='"+dsql+"' WHERE ID=" + Session["ID"] + " AND NameW='" + Session["wname"].ToString() + "'");
        else
            ADO.ExecuteNonQuery("Update Workers Set Shifts_This='" + sql + "', Shifts_Cant_This='" + dsql + "' WHERE ID=" + Session["ID"] + " AND NameW='" + Session["wname"].ToString() + "'");
    }
    public string Trans_To_english(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            str = str.Replace('א', 't');
            str = str.Replace('ב', 'c');
            str = str.Replace('ג', 'd');
            str = str.Replace('ד', 's');
            str = str.Replace('ה', 'v');
            str = str.Replace('ו', 'u');
            str = str.Replace('ז', 'z');
            str = str.Replace('ח', 'j');
            str = str.Replace('ט', 'y');
            str = str.Replace('י', 'h');
            str = str.Replace('כ', 'f');
            str = str.Replace('ל', 'k');
            str = str.Replace('מ', 'n');
            str = str.Replace('נ', 'b');
            str = str.Replace('ס', 'x');
            str = str.Replace('ע', 'g');
            str = str.Replace('פ', 'p');
            str = str.Replace('צ', 'm');
            str = str.Replace('ק', 'e');
            str = str.Replace('ר', 'r');
            str = str.Replace('ש', 'a');
            str = str.Replace('ת', ',');

            str = str.Replace(' ', '_');
            str = str.Replace('ם', 'w');
            str = str.Replace('ן', 'q');
            str = str.Replace('ף', '[');
            str = str.Replace('ך', ']');
            str = str.Replace('ץ', '(');
        }
        return str;
    }

    public void print_workers_table()
    {
        if (Request.Form["AI_shift"] != null)
        {
            AI_workers.Sort(delegate(worker p1, worker p2) { return p1.job.CompareTo(p2.job); });
            Response.Write("<table class='sample' align='center' width='300'>");
            Response.Write("<tr><th>שם עובד</th>");
            if(use_jobs)
                Response.Write("<th>תפקיד</th>");
            Response.Write("<th>ביקש</th><th>קיבל</th><th>קיבל ולא יכול</th></tr>");
            foreach (worker w in AI_workers)
            {
                Response.Write("<tr><td align='center'>" + w.name + "</td>");
                if(use_jobs)
                    Response.Write("<td align='center'>" + w.job + "</td>");
                Response.Write("<td align='center'>" + w.Num_Of_Shifts_requested + "</td><td align='center'>" + w.Num_Of_Shifts + "</td>");
                Response.Write("<td align='center'>" + Get_imposible_shift(w) + "</td></tr>");
            }
            Response.Write("</table>");


        }
    }

    private int Get_imposible_shift(worker w)
    {
        int mone = 0;
        foreach (string shift in w.Shifts.Split('@'))
        if(w.shift_cant_work.ToString().Contains(shift))
            mone++;
        return mone;
    }

    public void Fill_Lacks()
    {
            DataRow AI = ADO.GetFullTable("AI_Optionts", "ID=" + Session["ID"]).Rows[0];
                        
                        Random rnd = new Random();
                        Sort S = new Sort();
            for (int i = 1; i <= 3; i++)
                foreach (string need in AI[i].ToString().Split('#'))
                {
                    if(need!="")
                    {
                    string[] param = need.Split('@');
                    Shift shift = new Shift(int.Parse(param[2]), param[1], param[3]);
                    int spare_workers = GetNumOfWorkersIsShift(AI_mat[int.Parse(param[0]), i - 1], shift.job,shift.hours, (i == 2)) - shift.num_of_workers;
                    if (spare_workers < 0)
                    {
                            List<worker> possible_workers = new List<worker>();
                            List<worker> impossible_workers = new List<worker>();
                            foreach (DataRow worker in workers_list_db.Rows)
                                if (!worker["Shifts_Cant_Next"].ToString().Contains(Get_Shift_String(int.Parse(param[0]), GetSession(i, shift))))
                                    possible_workers.Add(new worker(worker["NameW"].ToString(), worker["Job"].ToString(), worker["Shifts_Cant_Next"].ToString(), 0,""));
                                else
                                    impossible_workers.Add(new worker(worker["NameW"].ToString(), worker["Job"].ToString(), worker["Shifts_Cant_Next"].ToString(), 0,""));

                            possible_workers = S.Shuffle(possible_workers);//shuffeling
                            impossible_workers = S.Shuffle(impossible_workers);//shuffeling
                            for (int w = 0; w < (spare_workers * -1); w++)
                            {
                                bool flag = false;//shift taken
                                int j = 0;
                                while (!flag && possible_workers.Count > j)//choose workers that can work this lack
                                {
                                    string name = possible_workers[j].name;
                                    if (bool.Parse(Session["Use_Jobs"].ToString()))
                                        name = possible_workers[j].job + "|" + possible_workers[j].name;
                                    while (name.Length < 13)
                                        name += " ";
                                    if (check_available(name,int.Parse(param[0]), shift.job))
                                    {
                                        int ses_number = i-1;
                                        AI_mat[int.Parse(param[0]), ses_number] += name;
                                        if (ses_number == 1)
                                            AI_mat[int.Parse(param[0]), ses_number] += shift.hours + "  ";
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
                                    if (check_available(name, int.Parse(param[0]), shift.job))
                                    {
                                        int ses_number = i-1;
                                        AI_mat[int.Parse(param[0]), ses_number] += name;
                                        if (ses_number == 1)
                                            AI_mat[int.Parse(param[0]), ses_number] += shift.hours + "  ";
                                        flag = true;
                                    }
                                    j++;
                                }
                            }
                           
                        }

                      
                    }
                    }
                }

    private string Get_Shift_String(int day, string session)
    {
        string str = "";
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
            default: str += "I#" + Session; break;
        }
        return str;
    }
    private string GetDay(int day)
{
    switch (day)
    {
        case 0:
            return "ראשון";
        case 1:
            return "שני";
        case 2:
            return "שלישי";
        case 3:
            return "רביעי";
        case 4:
            return "חמישי";
        case 5:
            return "שישי";
        case 6:
            return "שבת";
        default:
            return "";

    }
}
    private string GetSession(int i, Shift shift)
    {
        if (i == 1)
            return "בוקר";

        if (i == 3)
            return "ערב";
        return shift.hours;
    }

    
}
