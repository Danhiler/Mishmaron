<%@ Page Title="משמרות קבועות" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="Const_Shifts.aspx.cs" Inherits="Const_Shifts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<script type="text/javascript">
    function Trans_To_english(str) {
    
        for (i = 0; i < str.length; i++) {
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
            str = str.replace('ם', 'w');
            str = str.replace('ן', 'q');
            str = str.replace('ף', '[');
            str = str.replace('ך', ']');
            str = str.replace('ץ', '(');
            str = str.replace(' ', '_');
        }
    return str;
    }

    function TakeIntermediateShift(txtArea, str) {
    var Is;
      if((my!=null)&&(!my.closed))
     {
  my.focus();
Is=window.open("Add_Intermediate_Shift.aspx?Day="+txtArea+"&IS="+Trans_To_english(str.value)+"&name="+Trans_To_english(my.document.getElementById('ListBox1').value),""+txtArea+"","menubar=no,resizable=yes,status=no,scrollbars=no,directories=no,toolbar=no, height=170, width=330, alwaysRaised=yes, left=400");
document.Shifts.Save_Changes.disabled=false;
Is.focus();
}    
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
function TakeShift(txtArea) 
    {
if((my!=null)&&(!my.closed)){
    st = my.document.getElementById('ListBox1').value;my.focus();
        
        for(i = 13-st.length;i>0;i--)
        {
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
     function open_show_workers()
{
 my=window.open("Show_Workers.aspx", "Workers", "menubar=no,resizable=yes,status=no,scrollbars=no,directories=no,toolbar=no, height=200, width=100, alwaysRaised=yes");
 my.focus();
}
</script>

    <form name="Shifts" method="post"  action="Save_Const_Shifts.aspx" >
        <div>
    <input type="hidden" name="Week" value="1"/>
        <table style="width: 80%;" id="Shifts_Table" border="1" class="sample">
        <tr><td align ="center" colspan ="8">
        <h2>משמרות שבועיות קבועות</h2>
        </td></tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td dir="rtl" style="text-align: center">
                    ראשון             
                    </td>
                <td dir="rtl" style="text-align: center">
                    שני
                    </td>
                <td dir="rtl" style="text-align: center">
                    שלישי
                    </td>
                <td dir="rtl" style="text-align: center">
                    רבעי
                    </td>
                <td dir="rtl" style="text-align: center">
                    חמישי
                    </td>
                <td dir="rtl" style="text-align: center">
                    שישי
                    </td>
                <td dir="rtl" style="text-align: center">
                    שבת
                    </td>
            </tr>
            <tr>
                <td>
                    בוקר<br />
                     <%=SM %>-<%=EM %></td>
                <td>
                    <textarea dir="rtl" id="TextArea1" cols="<%=Width_Of_Boxes %>"  name="Sunday_Morning" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=SUM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea2" cols="<%=Width_Of_Boxes %>"  name="Monday_Morning" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=MM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea3" cols="<%=Width_Of_Boxes %>"  name="Tuesday_Morning" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=TUM %></textarea>
                    </td>
                <td >
                   <textarea dir="rtl" id="TextArea4" cols="<%=Width_Of_Boxes %>"  name="Wednesday_Morning" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=WM %></textarea>
                   </td>
                <td >
                    <textarea dir="rtl" id="TextArea5" cols="<%=Width_Of_Boxes %>"  name="Thursday_Morning" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=THM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea6" cols="<%=Width_Of_Boxes %>"  name="Friday_Morning" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=FM %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea7" cols="<%=Width_Of_Boxes %>"  name="Saturday_Morning" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=SAM %></textarea>
                    </td>
            </tr>
                        <%if (intermediate_Shifts == "True")
                          {%>
                         <tr>
                <td>
                    ביניים</td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Sunday_intermediate" onclick='TakeIntermediateShift(1,this);' readonly="readonly" ><%=SUI%></textarea></td>
                <td>
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>  " name="Monday_intermediate" 
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
                    <textarea dir="rtl" cols="<%=Width_Of_Boxes %>" rows="<%=Length_Of_T_Boxes %>" name="Friday_intermediate" 
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
                    <textarea dir="rtl" id="TextArea8" cols="<%=Width_Of_Boxes %>"  name="Sunday_Evening" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=SUE %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea9" cols="<%=Width_Of_Boxes %>"  name="Monday_Evening" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=ME %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea10" cols="<%=Width_Of_Boxes %>"  name="Tuesday_Evening" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=TUE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea11" cols="<%=Width_Of_Boxes %>"  name="Wednesday_Evening" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=WE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea12" cols="<%=Width_Of_Boxes %>"  name="Thursday_Evening" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=THE %></textarea>
                    </td>
                <td>
                    <textarea dir="rtl" id="TextArea13" cols="<%=Width_Of_Boxes %>"  name="Friday_Evening" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=FE %></textarea>
                    </td>
                <td >
                    <textarea dir="rtl" id="TextArea14" cols="<%=Width_Of_Boxes %>"  name="Saturday_Evening" rows="<%=Length_Of_Boxes %>" onclick="TakeShift(this)" readonly="readonly" ><%=SAE %></textarea></td>
            </tr>
        </table>
       <table style="width: 100%;">
        <tr>
         <td style="width: 100px;"> 
         <input type="submit" name="Save_Changes" value="שמור שינויים" />
         </td>
        <td style="width: 100px;">
        <input  type="submit" name="Erase_All" value="מחק הכל" />
        </td>
        <td align="left">
        <input id="Button" type="button" value="הראה עובדים" onclick="open_show_workers()" name="show_workers" />
        </td>
        </tr>
        </table>
    </div>
    
    </form>
</asp:Content>

