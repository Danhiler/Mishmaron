﻿<%@ Page Title="פרסום סידור עבודה" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Publish_Shifts.aspx.cs" Inherits="Publish_Shifts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script type="text/javascript" language="javascript">
    function check() {
    var sms_allowd= <%=num_of_sms %>;
    var count=0;var sms_used=0;
        while(document.getElementById('Checkboxs'+count)!=null)
        {
        if(document.getElementById('Checkboxs'+count).checked)
         sms_used=sms_used+parseInt(document.getElementById('Checkboxs'+count).value);
          count++;
    }
    if(sms_allowd>=sms_used){
    return true;
    }
    else
    {
    alert("אין לך מספיק אס-אמ-אסים, חסרות לך "+(sms_used-sms_allowd)+" הודעות");
    return false;
    }
   
    }

</script>
<form id="send_request" name="publish_shifts" method="post" action="Send_Shifts.aspx" onsubmit="return check()" >
<input type="hidden" name="week" value="<%=week %>" />
<table>
<tr><td align="center">
<h2>פרסום סידור עבודה</h2>
</td></tr>
<tr><td>
אנא סמן עבור כל עובד כיצד ברצונך לשלוח לו את סידור העבודה 
</td></tr>
<tr><td>
במקרה של שליחת SMS לעובד בעל מספר רב של משמרות האתר יבצע פיצול הודעות וישלח מספר הודעות לעובד(לפי מידת הצורך).
</td></tr>
</table>
<br />
<table align="center">
<tr><td>
מספר
 SMS 
ההעומדים לרשותך:
<%=num_of_sms %> 
<a href="purchase_SMS.aspx" >הוסף</a>
</td></tr>
<tr><td>
   <%Print_Table(); %>
   </td></tr>
  <tr><td align="center">
   <input type="submit" name="submit_sms" value="שלח" />
   </td></tr>
   </table>
   </form>
</asp:Content>

