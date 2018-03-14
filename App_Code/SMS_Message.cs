using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using il.co.simplesms.ws2;

/// <summary>
/// Summary description for SMS_Message
/// </summary>
public class SMS_Message
{
    public string To;
    public string from;
    public string msg;

	public SMS_Message(string to, string from, string msg)
	{
        this.To = to;
        this.from = from;
        this.msg = msg;
	}
    public bool Check_Message()
    {
        if (this.msg.Length == 0) return false;
        if (this.msg.Length > 70) return false;

        if (this.from.Length != 10) return false;
        if (this.from[0]!='0') return false;
        if (this.from[1] != '5') return false;

        if (this.To.Length != 10) return false;
        if (this.To[0] != '0') return false;
        if (this.To[1] != '5') return false;
        return true ;
    }
    public bool Send()
    {
        // An object which interfaces with the web service
        SendService ss = new SendService();
        
        // The sending of the message (A synchronous event - We wait untill finished)
        return ss.SendMessage("danhiler@gmail.com", "d1a1n1", this.from, this.To , this.msg);
    }
}
