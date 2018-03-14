using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Shift
/// </summary>
public class Shift
{
    public string job;
    public int num_of_workers;
    public string hours;
	public Shift( int num_of_workers, string job, string hours)
	{

        this.num_of_workers = num_of_workers;
        this.job = job;
        this.hours = hours;
	}
    public Shift()
    {
        this.num_of_workers = 0;
        this.job = "בחר";
        this.hours = "";
    }
}
