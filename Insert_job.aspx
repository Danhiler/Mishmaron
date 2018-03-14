<%@ Page Title="רישום עבודה" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Insert_job.aspx.cs" Inherits="Insert_job" %>

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
            if (document.Insert_Job.job_desc.value.length != 0) {
                if (CheckNameForLettersh(document.Insert_Job.job_desc.value) == false) {
                    document.Insert_Job.job_desc.focus();
                    alert("נא השתמש באותיות בעברית בלבד בפירוט התפקיד");
                    return false;
                }
                if (document.Insert_Job.job_desc.value.length < 4 || document.Insert_Job.job_desc.value.length > 25) {
                    document.Insert_Job.job_desc.focus();
                    alert("פירוט התפקיד חייב להיות בין 4 ל 25 תווים");
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
        <asp:Label ID="Label1" runat="server" name="lable1" Font-Bold="True" 
        Font-Size="Medium" ForeColor="Red"></asp:Label>
    <form name ="Insert_Job"  method="post" action="Insert_Job.aspx" dir="rtl" onsubmit="return Check();">
        <table dir="rtl" style="width: 480px">
            <tr>
               
                <td style="width: 100px" >
                    <b>קיצור תפקיד: </b></td>
                <td >
                    <input id="Text5" type="text" name="short_job" style="width: 150px;" 
                        maxlength="4" /></td>
                    
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
                    <input id="Text3" type="text" name="job" style="width: 150px;" /></td>
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
               
                <td >
                <b>
                    פירוט תפקיד:
                    </b></td>
                <td  >
                    <input id="Text4" type="text" name="job_desc" style="width: 150px;" /></td>
                <td  >
                    &nbsp;</td>
                <td >
                לא חובה
                <br />
                    עברית בלבד<br />
                    בין 4-25 תווים</td>
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

