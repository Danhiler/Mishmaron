<%@ Page Title="עדכון פרטי תפקיד" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Update_Job.aspx.cs" Inherits="Update_Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div dir="rtl">
    <script type="text/javascript">
        function Check() {
            // טענת כניסה: הפונקציה מקבלת טופס
            // טענת יציאה: אם הטופס תקין - מחזירה אמת, אחרת מציגה הודעה ומחזירה שקר
            var F, i;

            if (document.Insert_Job.short_job.value.length == 0) {
                document.Insert_Job.short_job.focus();
                alert("חובה למלא קיצור תפקיד");
                return false;
            }

            if (document.Insert_Job.short_job.value.length != 4) {
                document.Insert_Job.short_job.focus();
                alert("קיצור תפקיד חייב להיות 4 תווים");
                return false;
            }
            if (CheckNameForLettersh(document.Insert_Job.short_job.value) == false) {
                document.Insert_Job.short_job.focus();
                alert("נא השתמש באותיות בעברית בלבד בקיצור תפקיד");
                return false;
            }

            if (document.Insert_Job.job.value.length == 0) {
                document.Insert_Job.job.focus();
                alert("חובה למלא את התפקיד");
                return false;
            }

            if (CheckNameForLettersh(document.Insert_Job.job.value) == false) {
                document.Insert_Job.job.focus();
                alert("נא השתמש באותיות בעברית בלבד בתפקיד");
                return false;
            }
            if (document.Insert_Job.job.value.length < 3 || document.Insert_Job.job.value.length > 11) {
                document.Insert_Job.job.focus();
                alert("תפקיד חייב להיות בין 3 ל 11 תווים");
                return false;
            }
           
            }

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
    <form id="form1" name ="Insert_Job"  method="post" action="Updated_Job.aspx" dir="rtl" onsubmit="return Check();">
    <input type="hidden" name="Old_SJ" value="<%=short_job %>" />
        <table dir="rtl" style="width: 480px">
            <tr>
               
                <td style="width: 100px" >
                    <b>קיצור תפקיד: </b></td>
                <td >
                    <input id="Text5" type="text" name="short_job" style="width: 150px;" 
                        maxlength="4" value="<%=short_job %>" /></td>
                    
                <td style="width: 30px" >
                    &nbsp;</td>
                    
                 <td style="width: 200px" >
                    עברית בלבד<br />
                    4 תווים
                    </td>
                    
            </tr>
            <tr>
               
                <td style="width: 100px" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
                    
                <td style="width: 30px" >
                    &nbsp;</td>
                    
                <td style="width: 200px" >
                    &nbsp;</td>
                    
            </tr>
            <tr>
               
                <td >
                <b>
                    תפקיד:                     </b> </td>
                <td>
                    <input id="Text3" type="text" name="job" style="width: 150px;" value="<%=job %>" /></td>
                <td>
                    &nbsp;</td>
                <td>
                    עברית בלבד<br />
                    בין 3-11 תווים</td>
            </tr>
 
            <tr>
               
                <td >
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
 
           
 
            <tr>
                <td colspan="3">
    
    <center>
                    <input id="Submit1" type="submit" value="עדכן" /></center></td>
                    
                   
                <td>
    
                    &nbsp;</td>
                    
                   
              </tr>
        </table>
   
    </form>
         </div>
</asp:Content>

