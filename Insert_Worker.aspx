<%@ Page Title="רישום עובד" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Insert_Worker.aspx.cs" Inherits="Insert_Worker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div dir="rtl">
    <script type="text/javascript">
        function Check() {
            // טענת כניסה: הפונקציה מקבלת טופס
            // טענת יציאה: אם הטופס תקין - מחזירה אמת, אחרת מציגה הודעה ומחזירה שקר
            var F, i;

          

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

          
            if (document.Insert_Worker.worker_Phone.value != "") {
                if (document.Insert_Worker.phone_start.selectedIndex == 0) {
                    alert("חובה לסמן את הקידומת בפלאפון");
                    return false;
                }
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
              <%if (use_jobs)
          { %>
                         
                if (document.Insert_Worker.job.selectedIndex == 0) {
                    alert("חובה לסמן את תפקיד העובד");
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

        <asp:Label ID="Label1" runat="server" name="lable1" Font-Bold="True" 
        Font-Size="Medium" ForeColor="Red"></asp:Label>
    <form name ="Insert_Worker"  method="post" action="Insert_Worker.aspx" dir="rtl" onsubmit="return Check();">
         <table dir="rtl" style="width: 480px">
          <%if (use_jobs)
          { %>
         <tr>
               
                <td style="width: 100px" >
                <b>
                    תפקיד:
                    </b></td>
                <td >
                    <select id="Select1" name ="job" style="width: 80px">
                        <option>בחר</option>
                        <%Add_Jobs(); %>
                    </select>
                   </td>
                    
                <td style="width: 30px" >
                    &nbsp;</td>
                    
                <td style="width: 200px" >
                    </td>
                    
            </tr>
                     <tr><td style="width: 100px" >&nbsp;</td><td >&nbsp;</td>
                    
                <td style="width: 30px" >
                    &nbsp;</td>
                    
                <td style="width: 200px" >
                    </td>
                    
            </tr>
            <%} %>
            <tr>
               
                <td style="width: 100px" >
                <b>
                    שם עובד:
                    </b></td>
                <td >
                    <input id="Text5" type="text" name="worker_name" style="width: 150px;" /></td>
                    
                <td style="width: 30px" >
                    &nbsp;</td>
                    
                <td style="width: 200px" >

                    עברית בלבד<br />
                    בין 2-7 תווים</td>
                    
            </tr>
                       <tr>
               
                <td >
                <b>
                    פלאפון:
                    </b></td>
                <td  >
                   <input type="text" name="worker_Phone" style="width: 80px;" id="eb0" />
-
<select id ="select3" name="phone_start" style="width: 50px;">
<option>בחר</option>
<%Area_Codes(); %>
</select>
</td>                <td >
                    &nbsp;</td>
                <td  >
                    לא חובה<br />
                    מספרים בלבד<br />
                    עד 12 תווים</td>
            </tr>
            <tr>
                <td colspan="3">
    
    <center>
                    <input id="Submit1" type="submit" value="הוסף" /></center></td>
                    
                   
                <td>
    
                    &nbsp;</td>
                    
                   
              </tr>
        </table>
    </form>
         </div>
</asp:Content>

