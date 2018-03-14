<%@ Page Title="עדכון פרטי משתמש" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Updated_User.aspx.cs" Inherits="Updated_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <script language="javascript" id="fn" type="text/javascript">
      function Check() {
          // טענת כניסה: הפונקציה מקבלת טופס
          // טענת יציאה: אם הטופס תקין - מחזירה אמת, אחרת מציגה הודעה ומחזירה שקר
          var F, i;
          
<%if (c == "3")
  { %>
          if (document.Registar_Request.Full_Name.value.length == 0) {
              document.Registar_Request.Full_Name.focus();
              alert("חובה למלא שם מלא");
              return false;
          }

          if (CheckNameForLettersh(document.Registar_Request.Full_Name.value) == false) {
              document.Registar_Request.Full_Name.focus();
              alert("נא השתמש באותיות בעברית בלבד בשם מלא");
              return false;
          }
          if (document.Registar_Request.Full_Name.value.length < 3 || document.Registar_Request.Full_Name.value.length > 15) {
              document.Registar_Request.Full_Name.focus();
              alert("שם מלא חייב להיות בין 3 ל 15 תווים");
              return false;
          }
          <%} %>
          F = document.Registar_Request.Password2.value;
              if (CheckNameForLetterse(F) == false) {
                  document.Registar_Request.Password2.focus();
                  alert("נא השתמש באותיות באנגלית ומספרים בלבד בססמא");
                  return false;
              }
              if (F.length < 4 || F.length > 15) {
                  document.Registar_Request.Password2.focus();
                  alert("אורך הססמה צריך להיות בין 4 ל15 תווים");
                  return false;
          }
          <%if (c == "2")
  { %>

          F = document.Registar_Request.Password.value;
          if ((F != null) && (F != "")) {
              if (CheckNameForLetterse(F) == false) {
                  document.Registar_Request.Password.focus();
                  alert("נא השתמש באותיות באנגלית ומספרים בלבד בססמא");
                  return false;
              }
              if (F.length < 4 || F.length > 15) {
                  document.Registar_Request.Password.focus();
                  alert("אורך הססמה צריך להיות בין 4 ל15 תווים");
                  return false;
              }
          }
          if (F != document.Registar_Request.Confirm_Password.value) {
              document.Registar_Request.Confirm_Password.focus();
              alert("על הססמאות להיות זהות");
              return false;
          }
          <%} %>
          <%if (c == "4")
  { %>
          if (document.Registar_Request.Company_Name.value.length == 0) {
              document.Registar_Request.Company_Name.focus();
              alert("חובה למלא שם חברה או עסק");
              return false;
          }

<%} %>
 <%if (c == "7")
  { %>
           if (document.Registar_Request.Phone.value.length == 0) {
            document.Registar_Request.Phone.focus();
            alert("חובה למלא מספר פלאפון");
            return false;
        }
        
                    if (CheckIsNumber(document.Registar_Request.Phone.value) == false) {
                document.Registar_Request.Phone.focus();
                alert("נא השתמש במספרים בלבד במספר פלאפון");
                return false;
            }
            if (document.Registar_Request.Phone.value.length > 10) {
                document.Registar_Request.Phone.focus();
                alert("מספר פלאפון חייב להיות עד 10 ספרות");
                return false;
            }
                        if (document.Registar_Request.Phone.value.length < 5) {
                document.Registar_Request.Phone.focus();
                alert("מספר פלאפון חייב להיות לפחות 5 ספרות");
                return false;
            }

<%} %>
          <%if (c == "5")
  { %>

          F = document.Registar_Request.E_Mail.value;
          i = F.indexOf('@');
          if (i == -1) {
              document.Registar_Request.E_Mail.focus();
              alert("כתובת דוא\"ל חייבת להכיל @");
              return false;
          }

          if (i == 0) {
              document.Registar_Request.E_Mail.focus();
              alert("כתובת דוא\"ל אינה יכולה להתחיל בכרוכית");
              return false;
          }

          if (F.lastIndexOf('@') == F.length - 1) {
              document.Registar_Request.E_Mail.focus();
              alert("כתובת דוא\"ל אינה יכולה להסתיים ב-@");
              return false;
          }

          if (F.lastIndexOf('@') > i) {
              document.Registar_Request.E_Mail.focus();
              alert("כתובת דוא\"ל אינה יכולה להכיל שתי @");
              return false;
          }

          if (F.lastIndexOf('.') < i) {
              document.Registar_Request.E_Mail.focus();
              alert("חייבת להופיע נקודה אחרי @");
              return false;
          }

          if (F.charAt(F.length - 1) == '.') {
              document.Registar_Request.E_Mail.focus();
              alert("כתובת דוא\"ל אינה יכולה להסתיים בנקודה");
              return false;
          }

          if (F.indexOf("@.") > -1 || F.indexOf(".@") > -1) {
              document.Registar_Request.E_Mail.focus();
              alert("הנקודה אינה יכולה להיות צמודה ל@ ");
              return false;
          }

          i = FindIn(F, "()[]{}<>\\|/,?!\"'`;:~!#$%^&*+=");
          if (i > -1) {
              document.Registar_Request.E_Mail.focus();
              alert("כתובת הדוא\"ל מכילה תו לא חוקי\n" + F.charAt(i));
              return false;
          }
          <%} %>

          return true; // אפשר לשלוח את הטופס
      }

      function CheckNameForLettersh(Text) {
          var Let = "'-\"אבגדהוזחטיכךלמםנןסעפףצץקרשת1234567890 ";
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
    <asp:Label ID="Label1" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="Red"></asp:Label>
    <form name="Registar_Request" id="rr" method="post" action="Updated_User.aspx" onsubmit="return Check();">
    <input type="hidden" name="C" value="<%=c %>" />
<table>

<%if (c == "2")
  { %>
  <tr>
<td>
ססמא חדשה
    :</td>
<td>
<input type="password" name="Password" style="width: 150px;" id="Password1"/>
</td>
</tr>

<tr>
<td>
אימות ססמא חדשה
    :</td>
<td>
<input type="password" name="Confirm_Password" style="width: 150px;" id="Password2"/>
</td>
</tr>
<%} %>

<%if (c == "3")
  { %>
  <tr>
<td>
שם מלא:
</td>
<td>
<input type="text" name="Full_Name" style="width: 150px;" value="<%=full_name %>" /></td>
</tr>
<%} %>

<%if (c == "4")
  { %>
<tr>
<td>
שם עסק/חברה:
</td>
<td>
<input type="text" name="Company_Name" style="width: 150px;" id="cn" value="<%=company_name %>" /></td>
</tr>
<%} %>

<%if (c == "7")
  { %>
<tr>
<td>
פלאפון
    :</td>
<td>
<input type="text" name="Phone" style="width: 80px;" id="eb0" value="<%=phone.Split('-')[1] %>" />
-
<select id ="select3" name="phone_start" style="width: 50px;">
<option><%=phone.Split('-')[0] %></option>
<%Area_Codes(); %>
</select>
</td>
</tr>
<%} %>

<%if (c == "5")
  { %>
<tr>
<td>
אימייל
    :</td>
<td>
<input type="text" name="E_Mail" style="width: 150px;" id="eb"  value="<%=E_mail %>" /></td>
</tr>
<%} %>

<%if (c == "6")
  { %>
<tr>
<td>
תאריך לידה:
</td>
<td>
<table dir="rtl">
<tr>
<td>
<select id="Select4" name="Year">
<option><%=year%></option>
<%years(); %>
        
    </select>
</td>
<td>
<select id="Select5" name="Month">
      
    <option><%=month%></option>
    <%months(); %>
    </select>
</td>
<td>
<select id="Select6" name="Day">
  <option><%=day%></option>
  <%days(); %>
    </select>
    </td>
    </tr>
    </table>
    </td></tr>
    <%} %>
    



<tr>
    <td>&nbsp;</td></tr>
    <tr>
<td>
ססמא
    :</td>
<td>
<input type="password" name="Password2" style="width: 150px;" id="pb"/>
</td>
</tr>




<tr>
    <td>
        &nbsp;</td>
    <td>
        <input id="submit" style="width: 109px" type="submit" value="אשר" /></td>
        </tr>


</table>
</form>
</asp:Content>

