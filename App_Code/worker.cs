using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for worker
/// </summary>
public class worker
{
    public string job;
    public int Num_Of_Shifts;
    public int Num_Of_Shifts_requested;
    public string Shifts;
    public string name;
    public string shift_cant_work;

	public worker(string name, string job,string shifts, int num_of_shifts_requested,string shift_cant_work)
	{
        this.name = name;
        this.job = job;
        this.Num_Of_Shifts_requested = num_of_shifts_requested;
        this.Shifts = shifts;
        this.Num_Of_Shifts = 0;
        this.shift_cant_work = shift_cant_work;

	}

}
