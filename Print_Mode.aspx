<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_Mode.aspx.cs" Inherits="Print_Mode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>סידור עבודה</title>
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


</style>
<link rel="shortcut icon" type="image/x-icon" href="/Pictures/favicon.ico" />
</head>
<body dir="rtl">
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

    <div style="width: 297mm; height: 210mm; text-align: center">   
        <form id="form1" runat="server" name="shifts" >
    <input type="hidden" name="Week" value="<%=week %>"/>
        
        
        
        <h1>
        <%=company_name %>
        </h1>

          
                
                <h2>
                    סידור עבודה לשבוע&nbsp;&nbsp;&nbsp;
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
            style="font-family: Arial; font-size: medium; height: 130mm;">
            <tr>
                <td>
                    &nbsp;</td>
                <td dir="rtl" style="text-align: center">
                    ראשון
                    <br />
                    <script type="text/jscript" language="javascript">
                    document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    
                    
                    </script>
                    </td>
                <td dir="rtl" style="text-align: center">
                    שני
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </td>
                <td dir="rtl" style="text-align: center">
                    שלישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </td>
                <td dir="rtl" style="text-align: center">
                    רבעי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </td>
                <td dir="rtl" style="text-align: center">
                    חמישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </td>
                <td dir="rtl" style="text-align: center">
                    שישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </td>
                <td dir="rtl" style="text-align: center">
                    שבת
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    </td>
            </tr>
            <tr>
                <td>
                    בוקר<br />
                     <%=SM %>-<%=EM %></td>
                <td>
                    <textarea dir="rtl" id="TextArea1" cols="<%=Width_Of_Boxes %>"  name="Sunday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=SUM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea2" cols="<%=Width_Of_Boxes %>"  name="Monday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=MM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea3" cols="<%=Width_Of_Boxes %>"  name="Tuesday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=TUM %></textarea>
                    </td>
                <td >
                   <textarea dir="rtl" id="TextArea4" cols="<%=Width_Of_Boxes %>"  name="Wednesday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=WM %></textarea>
                   </td>
                <td >
                    <textarea dir="rtl" id="TextArea5" cols="<%=Width_Of_Boxes %>"  name="Thursday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=THM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea6" cols="<%=Width_Of_Boxes %>"  name="Friday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=FM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea7" cols="<%=Width_Of_Boxes %>"  name="Saturday_Morning" readonly="readonly" rows="<%=Length_Of_Boxes %>" dir="rtl"><%=SAM %></textarea>
                    </td>
            </tr>
                        <%if (intermediate_Shifts == "True")
                          {%>
                         <tr>
                <td>
                    ביניים</td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Sunday_intermediate" readonly="readonly" /> <%=SUI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Monday_intermediate" readonly="readonly"
                        ><%=MI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Tuesday_intermediate" readonly="readonly"
                       ><%=TUI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Wednesday_intermediate" readonly="readonly"
                        ><%=WI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Thursday_intermediate" readonly="readonly"
                        ><%=THI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Friday_intermediate" readonly="readonly"
                        ><%=FI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Saturday_intermediate" readonly="readonly"
                       ><%=SAI%></textarea></td>
            </tr>
            <%} %>
            <tr>
                <td>
                    ערב<br />
                    <%=SE %>-<%=EE %></td>
                <td>
                    <textarea dir="rtl" id="TextArea8" cols="<%=Width_Of_Boxes %>"  name="Sunday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=SUE %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea9" cols="<%=Width_Of_Boxes %>"  name="Monday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=ME %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea10" cols="<%=Width_Of_Boxes %>"  name="Tuesday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=TUE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea11" cols="<%=Width_Of_Boxes %>"  name="Wednesday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=WE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea12" cols="<%=Width_Of_Boxes %>"  name="Thursday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=THE %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea13" cols="<%=Width_Of_Boxes %>"  name="Friday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=FE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea14" cols="<%=Width_Of_Boxes %>"  name="Saturday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly"><%=SAE %></textarea></td>
            </tr>
        </table>
<a href="javascript:window.print()">הדפס</a>
        </form>
    </div>
</body>
</html>
