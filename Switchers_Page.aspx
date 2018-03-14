<%@ Page Title="טבלת מחליפים" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Switchers_Page.aspx.cs" Inherits="Swichers_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script type="text/javascript">
    function Trans_To_english(str)
    {
for(i=0;i<str.length;i++)
{
    str = str.replace('א', 't');
    str = str.replace('ב', 'c');
    str = str.replace('ג', 'd');
    str = str.replace('ד', 's');
    str = str.replace('ה', 'v');
    str = str.replace('ו', 'u');
    str = str.replace('ז', 'z');
    str = str.replace('ח', 'j');
    str = str.replace('ט', 'y');
    str = str.replace('י', 'h');
    str = str.replace('כ', 'f');
    str = str.replace('ל', 'k');
    str = str.replace('מ', 'n');
    str = str.replace('נ', 'b');
    str = str.replace('ס', 'x');
    str = str.replace('ע', 'g');
    str = str.replace('פ', 'p');
    str = str.replace('צ', 'm');
    str = str.replace('ק', 'e');
    str = str.replace('ר', 'r');
    str = str.replace('ש', 'a');
    str = str.replace('ת', ',');
    
    str = str.replace(' ', '_');
    str = str.replace('ם', 'w');
    str = str.replace('ן', 'q');
    str = str.replace('ף', '[');
    str = str.replace('ך', ']');
    str = str.replace('ץ', '(');
   }
    return str;
    }
     function nextday(a)
     {
      var dim;
     switch(a[1])
     {
     case 0:
     case 2:
     case 4:
     case 6:
     case 7:
     case 9:
     case 11:
     dim=31;
     break;
     
     case 1:
     if(a[2]%4==0){dim=29;}
     else{ dim=28;}
     break;
     
     case 3:
     case 5:
     case 8:
     case 10:
     dim=30;
     break;
     }
     if(a[0] !=dim)
     {
   a[0]++;
     }
     else 
     if(a[1] != 11)
     {a[1]++;a[0]=1;}
     else
     {a[2]++;a[1]=0;a[0]=1;
     }
     a[3]++;
     if(a[3] ==7)
     a[3]=0;
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
    <div>
    <%if (week == "1")
      { %>
   <table style="width: 100%;">
    <tr><td style="width: 30px;">
      <a href="Switchers_Page.aspx?week=0"><img src="Pictures\right_arrow.png" width="30" border="0" alt="שבוע קודם" /></a>
      </td><td style="text-align: center">
     <h2>רשימת מחליפים</h2>
      </td>
          <td style="width: 30px;">
      <img src="Pictures\left_arrow_dis.png" width="30" border="0" alt="שבוע הבא" />  
      </td>
                                                                           </tr>
      </table> 
      <%}
      else
      { %>  
      
      <table style="width: 100%;">
    <tr><td style="width: 30px;">
      <img src="Pictures\right_arrow_dis.png" width="30" border="0" alt="שבוע קודם" />
      </td><td style="text-align: center">
          <h2>רשימת מחליפים</h2>
      </td>
          <td style="width: 30px;">
    <a href="Switchers_Page.aspx?week=1"><img src="Pictures\left_arrow.png" width="30" border="0" alt="שבוע הבא" /></a>
      </td>
                                                                           </tr>
      </table>  
      <%} %>

    <input type="hidden" name="Week" value="1"/>
        <table style="width: 80%;" id="Shifts_Table"  class="sample">
            <tr>
                <td>
                    &nbsp;</td>
                <td dir="rtl" style="text-align: center">
                    ראשון
                    <br />
                    <script type="text/jscript" language="javascript">
                        var thedate = new Date();
                        thedate.setMilliseconds(thedate.getDay());
                        var a = new Array(thedate.getDate(), thedate.getMonth(), thedate.getYear(), thedate.getDay());
                         if (<%=week %> == 1) {

                             a = nextday(a);
                             while (a[3] != 0)
                             a = nextday(a);
                         }
                         else {
                             while (a[3] != 0)
                                 a = prevday(a);
                         }
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
                    <textarea dir="rtl" id="TextArea2" cols="<%=Width_Of_Boxes %>"  name="Monday_Morning"  rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=MM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea3" cols="<%=Width_Of_Boxes %>"  name="Tuesday_Morning"  rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=TUM %></textarea>
                    </td>
                <td >
                   <textarea dir="rtl" id="TextArea4" cols="<%=Width_Of_Boxes %>" lang="he" name="Wednesday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=WM %></textarea>
                   </td>
                <td >
                    <textarea dir="rtl" id="TextArea5" cols="<%=Width_Of_Boxes %>"  name="Thursday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=THM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea6" cols="<%=Width_Of_Boxes %>"  name="Friday_Morning" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=FM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea7" cols="<%=Width_Of_Boxes %>"  
                        name="Saturday_Morning"  onclick="TakeShift(this)"
                        rows="<%=Length_Of_Boxes %>" 
                        readonly="readonly"   
                       ><%=SAM %></textarea>
                    </td>
            </tr>
                        <%if (intermediate_Shifts)
                          {%>
                         <tr>
                <td>
                    ביניים</td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Sunday_intermediate"  readonly="readonly" ><%=SUI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Monday_intermediate" 
                       readonly="readonly" ><%=MI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Tuesday_intermediate" 
                         readonly="readonly" ><%=TUI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Wednesday_intermediate"
                         readonly="readonly" ><%=WI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Thursday_intermediate" 
                        readonly="readonly" ><%=THI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Friday_intermediate"
                        readonly="readonly" ><%=FI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Saturday_intermediate" 
                        readonly="readonly" ><%=SAI%></textarea></td>
            </tr>
            <%} %>
            <tr>
                <td>
                    ערב<br />
                    <%=SE %>-<%=EE %></td>
                <td>
                    <textarea dir="rtl" id="TextArea8" cols="<%=Width_Of_Boxes %>"  name="Sunday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=SUE %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea9" cols="<%=Width_Of_Boxes %>"  name="Monday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=ME %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea10" cols="<%=Width_Of_Boxes %>"  name="Tuesday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=TUE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea11" cols="<%=Width_Of_Boxes %>"  name="Wednesday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=WE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea12" cols="<%=Width_Of_Boxes %>"  name="Thursday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=THE %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea13" cols="<%=Width_Of_Boxes %>"  name="Friday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=FE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl"  id="TextArea14" cols="<%=Width_Of_Boxes %>"  name="Saturday_Evening" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=SAE %></textarea></td>
            </tr>
        </table>
    </div>
    
</asp:Content>

