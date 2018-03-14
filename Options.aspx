<%@ Page Title="הגדרות" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Options.aspx.cs" Inherits="Options" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #Text
        {
            width: 20px;
        }
                
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script type="text/javascript" language="javascript">
    function Check() {
        if (document.options.SM1.value.length != 2) {
            document.options.SM1.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
        if (CheckNumbers(document.options.SM1.value) == false) {
            document.options.SM1.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.SM1.value > 59) {
            document.options.SM1.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }

        if (document.options.SM2.value.length != 2) {
            document.options.SM2.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
        if (CheckNumbers(document.options.SM2.value) == false) {
            document.options.SM2.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.SM2.value > 24) {
            document.options.SM2.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (document.options.EM1.value.length != 2) {
            document.options.EM1.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
        
        if (CheckNumbers(document.options.EM1.value) == false) {
            document.options.EM1.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.EM1.value > 59) {
            document.options.EM1.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (document.options.EM2.value.length != 2) {
            document.options.EM2.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
        if (CheckNumbers(document.options.EM2.value) == false) {
            document.options.EM2.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.EM2.value > 24) {
            document.options.EM2.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (document.options.SE1.value.length != 2) {
            document.options.SE1.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
        if (CheckNumbers(document.options.SE1.value) == false) {
            document.options.SE1.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.SE1.value > 59) {
            document.options.SE1.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (document.options.SE2.value.length != 2) {
            document.options.SE2.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
        if (CheckNumbers(document.options.SE2.value) == false) {
            document.options.SE2.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.SE2.value > 24) {
            document.options.SE2.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (document.options.EE1.value.length != 2) {
            document.options.EE1.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
        if (CheckNumbers(document.options.EE1.value) == false) {
            document.options.EE1.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.EE1.value > 59) {
            document.options.EE1.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (document.options.EE2.value.length != 2) {
            document.options.EE2.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
        if (CheckNumbers(document.options.EE2.value) == false) {
            document.options.EE2.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.EE2.value > 24) {
            document.options.EE2.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (CheckNumbers(document.options.LOB.value) == false) {
            document.options.LOB.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (CheckNumbers(document.options.LOTB.value) == false) {
            document.options.LOTB.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.options.LOB.value > 30 || document.options.LOB.value <1) {
            document.options.LOB.focus();
            alert("גודל תיבה חייב להיות מ 1 עד 30");
            return false;
        }

        if (document.options.LOTB.value > 30 || document.options.LOTB.value < 1) {
            document.options.LOTB.focus();
            alert("גודל תיבת ביניים חייב להיות מ 1 עד 30");
            return false;
        }
         return true;
    }
            function CheckNumbers(Text) {
        var Let = "1234567890";
        var tav, i;
        for (i = 0; i < Text.length; i++) {
            tav = Text.charAt(i);
            if (Let.indexOf(tav) == -1)
                return false;
        }
        return true;
    }

    </script>
<form id ="form1" name="options" method="post" action="update_Options.aspx" onsubmit="return Check();">

<h1 align="center">הגדרות</h1>
<ul >
       <li>  <a href="Update_AI.aspx" target="_blank">הגדרת הצורך השבועי בעובדים</a></li>
                  <br />
          
             <li>
            בעסק שלך יש עובדים בעלי משמרות קבועות?
            <input id="Checkbox4" type="checkbox" name="const_Shifts" <%if (const_Shifts)Response.Write("checked='checked'");%> />
           <br />
      <a href="Const_Shifts.aspx" target="_blank">הגדר משמרות קבועות </a>
      </li>

               
                 <br />

               
        <table align="center" cellpadding="20" border="1" style='border-style:dotted;' ><tr><td>
    <table cellspacing="3" align="center">
        <tr>
            <th colspan="2" style="text-align: center">
                משמרות בוקר</th>
        </tr>
        <tr>
            <td>
                התחלה:</td>
            <td>
                <input id="Text1" name="SM1" style="width: 20px;" type="text" value="<%=sm.Substring(3, 2) %>" 
                     maxlength="2"/>
                :
                <input id="Text5" name="SM2" style="width: 20px;" type="text" value="<%=sm.Substring(0, 2) %>" 
                     maxlength="2"/>
                
                </td>
        </tr>
        <tr>
            <td>
                סיום:</td>
                        <td>
                <input id="Text2" name="EM1" style="width: 20px;" type="text" value="<%=em.Substring(3, 2) %>" 
                     maxlength="2"/>
                :
                <input id="Text6" name="EM2" style="width: 20px;" type="text" value="<%=em.Substring(0, 2) %>" 
                     maxlength="2"/>
                
                </td>
        </tr>
    </table>
    </td><td >
        <table cellspacing="3">
        
        <tr>
            <th colspan="2" style="text-align: center" align="center">
                משמרות ערב</th>
        </tr>
        <tr>
            <td>
                התחלה:</td>
                        <td>
                <input id="Text3" name="SE1" style="width: 20px;" type="text" value="<%=se.Substring(3, 2) %>" 
                     maxlength="2"/>
                :
                <input id="Text7" name="SE2" style="width: 20px;" type="text" value="<%=se.Substring(0, 2) %>" 
                     maxlength="2"/>
                
                </td>
        </tr>
        <tr>
            <td>
                סיום:</td>
                        <td>
                <input id="Text4" name="EE1" style="width: 20px;" type="text" value="<%=ee.Substring(3, 2) %>" 
                     maxlength="2"/>
                :
                <input id="Text8" name="EE2" style="width: 20px;" type="text" value="<%=ee.Substring(0, 2) %>" 
                     maxlength="2"/>
                
                </td>
        </tr>
        </table>
        </td></tr></table>
        <br />

            <li>   מספר עובדים מכסימלי במשמרת בוקר/ערב:
       
            
     
 <input id="Text9" name="LOB" style="width: 20px;" type="text" value="<%=Length_Of_Boxes %>"/></li>
 <br />
          <li>  בעסקך קיימות משמרות ביניים?
            <input id="Checkbox1" type="checkbox" name="intermediate_Shifts" <%if (intermediate_Shifts)Response.Write("checked='checked'");%> />
       </li>
      <br />
      <li>
       מספר עובדים מכסימלי במשמרת ביניים:
      
 <input id="Text10" name="LOTB" style="width: 20px;" type="text" value="<%=Length_Of_T_Boxes %>"/>
     </li>
        <br />
        <li>
                            בעסקך קיימים מגוון תפקידים?(לדוגמה: מלצרים, טבחים, אחמ"שים)
                            <input id="Checkbox3" 
                                <%if (use_jobs)Response.Write("checked='checked'");%>="" 
                                name="use_job" type="checkbox" />
                   </li>
                   <br />
    <li>
    עד איזה יום ניתן להגיש משמרות לשבוע של לאחר מכן?
<select id="Select5" name="deadline">
     
    <%deadlines(); %>
    </select>
       </li>
       <br />
       </ul>
<input id="Submit1" type="submit" value="שמור שינויים" />
    </form>

</asp:Content>

