using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Sort
/// </summary>
public class Sort
{
	public Sort()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<worker> Arrange_list(List<worker> lst)
    {
        worker temp;
        for (int i = 0; i < lst.Count; i++)
            for (int j = 0; j < lst.Count-1; j++)
                if (lst[j].Num_Of_Shifts_requested > lst[j + 1].Num_Of_Shifts_requested)
            {
                temp = lst[j];
                lst[j] = lst[j + 1];
                lst[j + 1] = temp;
            }
                return lst;
    }


    public string[,] SortTable(string[,] AI_mat)
    {
        for (int i = 0; i < 7; i++)
            for (int j = 0; j < 3; j++)
                if(j==1)
                AI_mat[i, j] = SortString(AI_mat[i, j],true);
                else
                    AI_mat[i, j] = SortString(AI_mat[i, j], false);
        return AI_mat;
    }

    public string SortString(string txt,bool intermediate)
    {
        string[] wis;
        int Lenth_Of_Shift = 13;
        if (intermediate)
            Lenth_Of_Shift = 26;
        wis = new string[txt.Length / Lenth_Of_Shift];
        for(int i =0;i<wis.Length;i++)
        {
            wis[i] = txt.Substring(0, Lenth_Of_Shift);
            txt = txt.Remove(0, Lenth_Of_Shift);
        }
        Array.Sort(wis);
        txt = "";
        for (int i = 0; i < wis.Length; i++)
            txt += wis[i];
        return txt;
    }

    public List<worker> Shuffle(List<worker> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 0)
        {
            n--;
            int k = rng.Next(n + 1);
            worker value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }
}
