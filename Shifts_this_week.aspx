<%@ Page Title="סידור עבודה - שבוע נוכחי" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Shifts_this_week.aspx.cs" Inherits="Shifts_this_week" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script type="text/jscript" language="javascript">

function allow_save()
{
document.Shifts.Save_Changes.disabled=false;
}
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
    
function TakeIntermediateShift(txtArea,str) 
{
    <%if(Allow_Changes &&(!bool.Parse(Session["Admin"].ToString())))
    {
     %>
I=window.open("Add_Intermediate_Shift.aspx?Day="+txtArea+"&IS="+Trans_To_english(str.value)+"&name="+Trans_To_english("<%if(use_jobs){Response.Write(""+short_job+"|"+Session["Wname"].ToString()+"");}else{Response.Write(""+Session["Wname"].ToString()+"");} %>"),""+txtArea+"","menubar=no,resizable=yes,status=no,scrollbars=no,directories=no,toolbar=no, height=170, width=330, alwaysRaised=yes, left=400");
I.focus();
document.Shifts.Save_Changes.disabled=false;
 <% } %>
 
     <%if(bool.Parse(Session["Admin"].ToString()))
    {
     %>
     if((my!=null)&&(!my.closed))
     {
  my.focus();
I=window.open("Add_Intermediate_Shift.aspx?Day="+txtArea+"&IS="+Trans_To_english(str.value)+"&name="+Trans_To_english(my.document.getElementById('ListBox1').value),""+txtArea+"","menubar=no,resizable=yes,status=no,scrollbars=no,directories=no,toolbar=no, height=170, width=330, alwaysRaised=yes, left=400");
I.focus();
document.Shifts.Save_Changes.disabled=false;
}
 <% } %>
}
function pausecomp(millis) 
{
var date = new Date();
var curDate = null;

do { curDate = new Date(); } 
while(curDate-date < millis);
} 
    function removeSubstring(myStr, ind, len) {
      first= myStr.substr(0, ind);
      last = myStr.substr(ind+len, myStr.length-(ind+len));
      return first+last;
    }
    
    var my;

function open_show_workers()
{
 my=window.open("Show_Workers.aspx", "Workers","menubar=no,resizable=yes,status=no,scrollbars=no,directories=no,toolbar=no, height=200, width=100, alwaysRaised=yes");
 my.focus();
}

    function TakeShift(txtArea) {
    <%if(use_jobs){Response.Write("var st='"+short_job+"|"+Session["Wname"].ToString()+"'");}else{Response.Write("var st='"+Session["Wname"].ToString()+"'");} %>
    if((my!=null)&&(!my.closed)){
    st = my.document.getElementById('ListBox1').value;my.focus();
           }     
           var ad;       
           <%if(Allow_Changes &&(!bool.Parse(Session["Admin"].ToString()))){Response.Write("ad=true");}%>;
           var io=((my!=null)&&(!my.closed));
    if(ad || io){
    

       document.Shifts.Save_Changes.disabled=false;
        
        for(i = 13-st.length;i>0;i--){
        st +=" ";
        }
        var val = txtArea.value;
        var ind = val.indexOf(st);
        if( ind < 0)
        {
           txtArea.value += st;
        }
        else
        {
           txtArea.value = removeSubstring(txtArea.value,ind,st.length);
        }
        }       
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


     function prevday(a)
     {
      var dim;
     switch(a[1]-1)
     {
     case -1:
     case 0:
     case 2:
     case 4:
     case 6:
     case 7:
     case 9:
     dim=31;
     break;
     
     case 1:
     dim=28;
     break;
     
     case 3:
     case 5:
     case 8:
     case 10:
     dim=30;
     break;
     }
     if(a[0]!=1)
     a[0]--;
     else if(a[1]==0)
     {
     a[2]--;
     a[1]=11;
     a[0]=31;
     }
     else
     {a[1]--;
     a[0]=dim;}
     
      a[3]--;
     if(a[3] ==-1)
     a[3]=6;
return a;
                      
     
     }
     function r_u_sure()
{
return confirm("האם אתה בטוח שברצונך לבצע פעולה זאת");

}
     function change_location_p()
     {
     window.location="http://www.mishmaron.com/Publish_Shifts.aspx?week=0";
     }
     function change_location_s()
     {
     window.location="http://www.mishmaron.com/Switchers_Page.aspx?week=0";
     }
     
</script>
    <div>
    <form name="Shifts" method="post" action="Update_Shifts.aspx" onsubmit="return r_u_sure();" >
        <input type="hidden" name="Week" value="0"/>
    <table style="width: 80%;">
    <tr><td style="width: 30px;">
      <img src="Pictures\right_arrow_dis.png" width="30" border="0" alt="שבוע נוכחי" />
      </td><td style="text-align: center">
           <%    if (Session["Admin"] != null && (bool)Session["Admin"])
                 {
                     Response.Write("<a href='Print_Mode.aspx?id=" + un + "&name=" + trance_name + "&week=0' target='_blank' >גרסת הדפסה</a>");
                     Response.Write("&nbsp;&nbsp;&nbsp;<a href='Requests_Page.aspx?week=0' target='_blank' >טבלת בקשות</a>");
                 }

        %>
      </td>
          <td style="width: 30px;">
    <a href="Shifts_next_week.aspx"><img src="Pictures\left_arrow.png" width="30" border="0" alt="שבוע הבא" /></a>
      </td>
                                                                           </tr>
      </table>   
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
                        while(a[3]!=0)
                        a= prevday(a);
                    document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    
                    </script>
                     <br />
                     <font color = "blue"><%=events[0] %></font>
                    </td>
                <td dir="rtl" style="text-align: center">
                    שני
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    <br />
                     <font color = "blue"><%=events[1] %></font>
                    </td>
                <td dir="rtl" style="text-align: center">
                    שלישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    <br />
                     <font color = "blue"><%=events[2] %></font>
                    </td>
                <td dir="rtl" style="text-align: center">
                    רבעי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    <br />
                     <font color = "blue"><%=events[3] %></font>
                    </td>
                <td dir="rtl" style="text-align: center">
                    חמישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    <br />
                     <font color = "blue"><%=events[4] %></font>
                    </td>
                <td dir="rtl" style="text-align: center">
                    שישי
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    <br />
                     <font color = "blue"><%=events[5] %></font>
                    </td>
                <td dir="rtl" style="text-align: center">
                    שבת
                    <br />
                    <script type="text/jscript" language="javascript">
                        a = nextday(a);
                        document.write(a[0] + "." + (a[1] + 1) + "." + a[2]);
                    </script>
                    <br />
                     <font color = "blue"><%=events[6] %></font>
                    </td>
            </tr>
              <%if ((!bool.Parse(Session["Admin"].ToString())) && (!shifts_ready))
                    Print_Table_for_workers();
                else
                {%>
            <tr>
                <td>
                    בוקר<br />
                    <%=SM %>-<%=EM %></td>
                <td>
                    <textarea dir="rtl" id="TextArea1"  cols="<%=Width_Of_Boxes %>"  name="Sunday_Morning" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=SUM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea2" cols="<%=Width_Of_Boxes %>"  name="Monday_Morning" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=MM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea3"  cols="<%=Width_Of_Boxes %>"  name="Tuesday_Morning" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=TUM %></textarea>
                    </td>
                <td >
                   <textarea dir="rtl" id="TextArea4"  cols="<%=Width_Of_Boxes %>"  name="Wednesday_Morning" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=WM %></textarea>
                   </td>
                <td >
                    <textarea dir="rtl" id="TextArea5"  cols="<%=Width_Of_Boxes %>"  name="Thursday_Morning" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=THM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea6"  cols="<%=Width_Of_Boxes %>"  name="Friday_Morning" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=FM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea7"  cols="<%=Width_Of_Boxes %>"  name="Saturday_Morning" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=SAM %></textarea>
                    </td>
            </tr>
                                   <%if (intermediate_Shifts){%>
                         <tr>
                <td>
                    ביניים</td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Sunday_intermediate" onclick='TakeIntermediateShift(1,this);' readonly="readonly" ><%=SUI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Monday_intermediate"  
                        onclick='TakeIntermediateShift(2,this);' readonly="readonly" ><%=MI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Tuesday_intermediate" 
                        onclick='TakeIntermediateShift(3,this);' readonly="readonly" ><%=TUI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Wednesday_intermediate"
                        onclick='TakeIntermediateShift(4,this);' readonly="readonly" ><%=WI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Thursday_intermediate"
                        onclick='TakeIntermediateShift(5,this);' readonly="readonly" ><%=THI%></textarea></td>
                <td>
                    <textarea dir="rtl"cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Friday_intermediate"
                        onclick='TakeIntermediateShift(6,this);' readonly="readonly" ><%=FI%></textarea></td>
                <td >
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Saturday_intermediate"
                        onclick='TakeIntermediateShift(7,this);' readonly="readonly" ><%=SAI%></textarea></td>
            </tr>
            <%} %>
            <tr>
                <td>
                    ערב<br />
                    <%=SE %>-<%=EE %></td>
                <td>
                    <textarea dir="rtl" id="TextArea8" cols="<%=Width_Of_Boxes %>"  name="Sunday_Evening" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=SUE %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea9" cols="<%=Width_Of_Boxes %>"  name="Monday_Evening" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=ME %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea10" cols="<%=Width_Of_Boxes %>"  name="Tuesday_Evening" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=TUE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea11" cols="<%=Width_Of_Boxes %>"  name="Wednesday_Evening" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=WE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea12" cols="<%=Width_Of_Boxes %>"  name="Thursday_Evening" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=THE %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea13" cols="<%=Width_Of_Boxes %>"  name="Friday_Evening" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=FE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea14" cols="<%=Width_Of_Boxes %>"  name="Saturday_Evening" onclick="TakeShift(this)" rows="<%=Length_Of_Boxes %>" readonly="readonly" ><%=SAE %></textarea></td>
            </tr>
            <%} %>
        </table>
         <table width="80%">
        <tr>
        <td style="width: 25px"> <input type="submit" id="m_button" name="Save_Changes" value="שמור שינויים" <%if(!(bool)Session["Admin"]) Response.Write("disabled='disabled'");%> /></td>
<% 
           if((ADO.GetFullTable("Work_Table","week=2 And ID="+Session["ID"]).Rows[0]["Allow_Changes"].ToString() =="True") && (Session["Admin"] != null) && ((bool)Session["Admin"]))
       {
           Response.Write("<td style='width: 25px'><input type='submit' id='m_button' name='set_const' value='אפס למשמרות הקבועות' /></td>");
           }
    if (Session["Admin"] != null && (bool)Session["Admin"])
   {
        %>
        <td style="width: 25px"><input type="submit" id="m_button" name="Erase_All" value="מחק הכל" /></td>
       <%if (shifts_ready)
         {
             Response.Write("<td style='width: 25px'><input type='button' id='m_button' name='Send_Emails' value='פרסם סידור' onclick='change_location_p()' /></td>");
         }%>
             
              
        <td style="width: 300px">&nbsp;&nbsp;<input type="checkbox" id='Checkbox1' name="AC"  value="off" <%if (shifts_ready)Response.Write("checked='checked'");%>/>&nbsp;סידור עבודה מוכן</td>
        
      <%if (!shifts_ready) Response.Write("<td style='width: 300px' ><input style='height:30px' id='m_button' type='submit' name='AI_shift' value='סדר משמרות' /></td>"); %>
        
        <td style="text-align: left"><input id="m_button" type="button" value="הראה עובדים" onclick="open_show_workers()" name="show_workers" /></td>

       <%}%>

           
                                    <%if (!bool.Parse(Session["Admin"].ToString()))
                                      {
                                          if (!Allow_Changes) if (shifts_ready) { Response.Write("<td ><font color='blue'>סידור העבודה מוכן!</font></td><td style='width: 25px'><input type='button' name='Send_Emails' value='טבלת מחליפים' onclick='change_location_s()' /></td>"); } else { Response.Write("<td><font color='red'>הטבלה נעולה!</font></td>"); }
                                          else Response.Write("<td> <font color='blue'>אנא הזן את יכולת העבודה השבועית שלך</font></td>");
                                      }
                %>            
        </tr>
        </table>
        </form>
    </div>
    
</asp:Content>

