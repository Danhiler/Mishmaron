<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Requests_Page.aspx.cs" Inherits="Requests_Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>דף בקשות</title>
      <style type="text/css">
table.sample {
	border-width: 2px;
	border-style: solid;
	border-color: gray;
	border-collapse: collapse;
}
table.sample th {
	border-width: 1px;
	padding: 1px;
	border-style: dotted;
	border-color: gray;
}
table.sample td {
	border-width: 1px;
	padding: 1px;
	border-style: dotted;
	border-color: gray;
}

table.reg {
	border-style:  none;
}
table.reg th {
	border-style: none;
}
table.reg td {
	border-style: none;
}


</style>
<link rel="shortcut icon" type="image/x-icon" href="/Pictures/favicon.ico" />
</head>
<body dir="rtl">
<center>
  <script type="text/javascript">
function nextday(a) {
    var dim;
    switch (a[1]) {
        case 0:
        case 2:
        case 4:
        case 6:
        case 7:
        case 9:
        case 11:
            dim = 31;
            break;

        case 1:
            dim = 28;
            break;

        case 3:
        case 5:
        case 8:
        case 10:
            dim = 30;
            break;
    }
    if (a[0] != dim) {
        a[0]++;
    }
    else
        if (a[1] != 11)
    { a[1]++; a[0] = 1; }
    else {
        a[2]++; a[1] = 0; a[0] = 1;
    }
    a[3]++;
    if (a[3] == 7)
        a[3] = 0;
    return a;

}


function prevday(a) {
    var dim;
    switch (a[1] - 1) {
        case -1:
        case 0:
        case 2:
        case 4:
        case 6:
        case 7:
        case 9:
            dim = 31;
            break;

        case 1:
            dim = 28;
            break;

        case 3:
        case 5:
        case 8:
        case 10:
            dim = 30;
            break;
    }
    if (a[0] != 1)
        a[0]--;
    else if (a[1] == 0) {
        a[2]--;
        a[1] = 11;
        a[0] = 31;
    }
    else {
        a[1]--;
        a[0] = dim;
    }

    a[3]--;
    if (a[3] == -1)
        a[3] = 6;
    return a;


}
</script>

    <div style="width: 297mm; height: 210mm; text-align: center" align="center">   
        <form id="form1" runat="server" name="shifts" >
    <input type="hidden" name="Week" value="<%=week %>"/>
        
        
        
        <h1>
        <%=company_name %>
        </h1>

          
                
                <h2>
                    דף בקשות לשבוע&nbsp;&nbsp;&nbsp;
                     <script type="text/jscript" language="javascript">
                             var thedate = new Date();
                             thedate.setMilliseconds(thedate.getDay());
                             var a = new Array(thedate.getDate(), thedate.getMonth(), thedate.getYear(), thedate.getDay());
                             
                         if (<%=week %> == 1) {

                             a = nextday(a);
                             while (a[3] != 0)
                             a = nextday(a);
                             document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                         }
                         else {
                             while (a[3] != 0)
                                 a = prevday(a);
                             document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                         }
                                                 document.write(" - ");
                             while (a[3] != 6)
                                 a = nextday(a);
                                 document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                                   while (a[3] != 0)
                                 a = prevday(a);
                    
                    </script>
                    
                    </h2>
                    <table id="Table1" border="1" dir="rtl" class="sample" 
            align="center" 
            style="width: 250mm; height: 150mm; font-family: Arial; font-size: large; font-style: normal">
            <tr>
                <td>
                    &nbsp;</td>
                <th dir="rtl" style="text-align: center">
                    ראשון
                    <br />
                    <script type="text/jscript" language="javascript">
                    document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    
                    
                    </script>
                    </th>
                <th dir="rtl" style="text-align: center">
                    שני
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </th>
                <th dir="rtl" style="text-align: center">
                    שלישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </th>
                <th dir="rtl" style="text-align: center">
                    רבעי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </th>
                <th dir="rtl" style="text-align: center">
                    חמישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </th>
                <th dir="rtl" style="text-align: center">
                    שישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </th>
                <th dir="rtl" style="text-align: center">
                    שבת
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </th>
            </tr>
           <%Print_Table(); %>
        </table>
<a href="javascript:window.print()">הדפס</a>
        </form>
    </div>
    </center>
</body>
</html>
