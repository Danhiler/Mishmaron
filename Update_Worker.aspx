<%@ Page Title="עדכון עובד" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Update_Worker.aspx.cs" Inherits="AddWorker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script type="text/javascript">
    function Check() {
        // טענת כניסה: הפונקציה מקבלת טופס
        // טענת יציאה: אם הטופס תקין - מחזירה אמת, אחרת מציגה הודעה ומחזירה שקר
        var F, i;

        if (document.Insert_Worker.worker_ID.value.length == 0) {
            document.Insert_Worker.worker_ID.focus();
            alert("חובה למלא שם משתש");
            return false;
        }

        if (document.Insert_Worker.worker_ID.value.length < 3 || document.Insert_Worker.worker_ID.value.length > 15) {
            document.Insert_Worker.worker_ID.focus();
            alert("שם משתמש חייב להיות בין 3 ל 15 תווים");
            return false;
        }
        if (CheckNameForLetterse(document.Insert_Worker.worker_ID.value) == false) {
            document.Insert_Worker.worker_ID.focus();
            alert("נא השתמש באותיות באנגלית בלבד בשם משתמש");
            return false;
        }

        if (document.Insert_Worker.worker_name.value.length == 0) {
            document.Insert_Worker.worker_name.focus();
            alert("חובה למלא שם עובד");
            return false;
        }

        if (CheckNameForLettersh(document.Insert_Worker.worker_name.value) == false) {
            document.Insert_Worker.worker_name.focus();
            alert("נא השתמש באותיות בעברית בלבד בשם עובד");
            return false;
        }
        if (document.Insert_Worker.worker_name.value.length < 2 || document.Insert_Worker.worker_name.value.length > 7) {
            document.Insert_Worker.worker_name.focus();
            alert("שם עובד חייב להיות בין 2 ל 7 תווים");
            return false;
        }



        F = document.Insert_Worker.worker_PassW.value;
            if (CheckNameForLetterse(F) == false) {
                document.Insert_Worker.worker_PassW.focus();
                alert("נא השתמש באותיות באנגלית ומספרים בלבד בססמא");
                return false;
            }
            if (F.length < 4 || F.length > 15) {
                document.Insert_Worker.worker_PassW.focus();
                alert("אורך הססמה צריך להיות בין 4 ל15 תווים");
                return false;
            }
            if (document.Insert_Worker.worker_Phone.value != "") {
                if (CheckIsNumber(document.Insert_Worker.worker_Phone.value) == false) {
                    document.Insert_Worker.worker_Phone.focus();
                    alert("נא השתמש במספרים בלבד במספר פלאפון");
                    return false;
                }
                if (document.Insert_Worker.worker_Phone.value.length > 10) {
                    document.Insert_Worker.worker_Phone.focus();
                    alert("מספר פלאפון חייב להיות עד 10 ספרות");
                    return false;
                }
                if (document.Insert_Worker.worker_Phone.value.length < 5) {
                    document.Insert_Worker.worker_Phone.focus();
                    alert("מספר פלאפון חייב להיות לפחות 5 ספרות");
                    return false;
                }
            }

                   //alert(document.Insert_Worker.worker_name.value + " עודכן בהצלחה");
        return true; // אפשר לשלוח את הטופס
    }

    function CheckNameForLettersh(Text) {
        var Let = "אבגדהוזחטיכךלמםנןסעפףצץקרשת1234567890'-\" ";
        var tav, i;
        for (i = 0; i < Text.length; i++) {
            tav = Text.charAt(i);
            if (Let.indexOf(tav) == -1)
                return false;
        }
        return true;
    }
    function CheckNameForLetterse(Text) {
        var Let = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var tav, i;
        for (i = 0; i < Text.length; i++) {
            tav = Text.charAt(i);
            if (Let.indexOf(tav) == -1)
                return false;
        }
        return true;
    }

    function CheckIsNumber(Text) {
        var Let = "1234567890";
        var tav, i;
        for (i = 0; i < Text.length; i++) {
            tav = Text.charAt(i);
            if (Let.indexOf(tav) == -1)
                return false;
        }
        return true;
    }

    function FindIn(Text, Chars) {
        // טענת כניסה: הפונקציה מקבלת שתי מחרוזות
        // טענת יציאה: מחזירה את המופע הראשון של תו מתוך המחרוזת השנייה במחרוזת הראשונה
        // או -1 אם אין תווים משותפים
        var c, i;
        for (i = 0; i < Text.length; i++) {
            c = Text.charAt(i);
            if (Chars.indexOf(c) > -1)
                return i;
        }
        return -1;
    }
        </script>

    <form name="Insert_Worker"  method="post" action="Updated_Worker.aspx" onsubmit="return Check();" dir="rtl">
    <input type="hidden" name="Old_ID" value ="<%=Request.QueryString["ID"].ToString()%>"/>
        <table style="width:260px;" dir="rtl">
        <%if (use_jobs)
          { %>
           <tr>       
                <th >
                    תפקיד</th>
                <td >
                    <select id="Select1" name="job" <%if (!(bool)Session["Admin"]) Response.Write("readonly='readonly'"); %>>
                        <option><%=job%></option>
                        <%Add_Jobs();%>
                    </select>
            </tr>
            <tr>
               
                <th >
                    &nbsp;</th>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
               <%} %>
                <th >
                    שם עובד</th>
                <td >
                    <input id="worker_name" type="text" name="worker_name" value="<%=name %>" <%if (!(bool)Session["Admin"]) Response.Write("readonly='readonly'"); %> /></td>
            </tr>
            <tr>
               
                <th >
                    &nbsp;</th>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
               
                <th>
                    שם משתמש</th>
                <td >
                    <input id="Text3" type="text" name="worker_ID" value="<%=IDw %>"/></td>
            </tr>
            <tr>
               
                <th>
                    &nbsp;</th>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
               
                <th >
                    ססמא</th>
                <td >
                    <input id="Text4" type="password" name="worker_PassW" value="<%=pass %>" /></td>
            </tr>
            <tr>
               
                <th >
                    &nbsp;</th>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
               
                <th >
                    פלאפון</th>
                <td >
                 <input type="text" name="worker_Phone" style="width: 80px;" id="eb0" value="<%= phone.Split('-')[1]%>" />
-
<select id ="select3" name="phone_start" style="width: 50px;">
<option><%=phone.Split('-')[0] %></option>
<%Area_Codes(); %>
</select>
                    </td>
            </tr>
            
            <tr>
                <td colspan="2">
    
    <center>
                    <input id="Submit1" type="submit" value="עדכן" /></center></td>
              </tr>
        </table>
    
    </form>

</asp:Content>

