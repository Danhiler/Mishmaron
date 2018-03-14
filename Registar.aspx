<%@ Page Title="הרשמה" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registar.aspx.cs" Inherits="Registar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script type="text/javascript" language="javascript" id="fn">
        function Check() {
            // טענת כניסה: הפונקציה מקבלת טופס
            // טענת יציאה: אם הטופס תקין - מחזירה אמת, אחרת מציגה הודעה ומחזירה שקר
            var F, i;
            if (document.Registar_Request.USER_ID.style.backgroundColor == "") {
                alert("אנא בצע בדיקת זמינות שם משתמש");
                return false;
            }

            if (document.Registar_Request.USER_ID.style.backgroundColor == "#ff7777") {
                document.Registar_Request.USER_ID.focus();
                alert("שם משתמש תפוס או לא תקין");
                return false;
            }
            if (document.Registar_Request.Full_Name.style.backgroundColor == "") {
                document.Registar_Request.Full_Name.focus();
                alert("אנא מלא שם מלא");
                return false;
            }
            if (document.Registar_Request.Full_Name.style.backgroundColor == "#ff7777") {
                document.Registar_Request.Full_Name.focus();
                alert("שם מלא לא תקין");
                return false;
            }

            if (document.Registar_Request.Password.style.backgroundColor == "") {
                document.Registar_Request.Password.focus();
                alert("אנא מלא ססמא");
                return false;
            }
            if (document.Registar_Request.Password.style.backgroundColor == "#ff7777") {
                document.Registar_Request.Password.focus();
                alert("ססמא לא תקינה");
                return false;
            }

            if (document.Registar_Request.Confirm_Password.style.backgroundColor == "") {
                document.Registar_Request.Confirm_Password.focus();
                alert("אנא הזן את אימות הססמא");
                return false;
            }
            if (document.Registar_Request.Confirm_Password.style.backgroundColor == "#ff7777") {
                document.Registar_Request.Confirm_Password.focus();
                alert("הססמאות אינן זהות");
                return false;
            }
            if (document.Registar_Request.Company_Name.style.backgroundColor == "") {
                document.Registar_Request.Company_Name.focus();
                alert("אנא הזן שם חברה או עסק");
                return false;
            }
            if (document.Registar_Request.Company_Name.style.backgroundColor == "#ff7777") {
                document.Registar_Request.Company_Name.focus();
                alert("שם חברה או עסק לא תקין");
                return false;
            }
            if (document.Registar_Request.Phone.style.backgroundColor == "") {
                document.Registar_Request.Phone.focus();
                alert("אנא מלא מספר פלאפון");
                return false;
            }
            if (document.Registar_Request.Phone.style.backgroundColor == "#ff7777") {
                document.Registar_Request.Phone.focus();
                alert("מספר פלאפון לא תקין");
                return false;
            }
            if (document.Registar_Request.E_Mail.style.backgroundColor == "") {
                document.Registar_Request.E_Mail.focus();
                alert("אנא מלא מספר אימייל");
                return false;
            }
            if (document.Registar_Request.E_Mail.style.backgroundColor == "#ff7777") {
                document.Registar_Request.E_Mail.focus();
                alert("האימייל שהזנת לא תקין");
                return false;
            } 
            if (document.Registar_Request.phone_start.selectedIndex == 0) {
                alert("חובה לסמן את הקידומת בפלאפון");
                return false;
            }
            if ((document.Registar_Request.Year.selectedIndex == 0) || (document.Registar_Request.Month.selectedIndex == 0) || (document.Registar_Request.Day.selectedIndex == 0)) {
                alert('אנא הכנס תאריך לידה');
                return false;
            }
            if (!isDate(document.Registar_Request.Day.value, document.Registar_Request.Month.value, document.Registar_Request.Year.value)) {
                return false;
            }
            if (!document.Registar_Request.Accept_Terms.checked) {
                alert('אנא אשר את תנאי השימוש');
                return false;
            }

            alert("תודה רבה! נרשמת לאתר בהצלחה, הינך מועבר לדף ההתחברות");
            return true; // אפשר לשלוח את הטופס
        }
        function check_fname() {
            var flag = true;
            if (CheckNameForLettersh(document.Registar_Request.Full_Name.value) == false) {
                //document.Registar_Request.Full_Name.focus();
                //alert("נא השתמש באותיות בעברית בלבד בשם מלא");
                document.Registar_Request.fname_ans1.style.color = 'red';
                document.Registar_Request.Full_Name.style.backgroundColor = '#FF7777';
                flag= false;
            }
            else
                document.Registar_Request.fname_ans1.style.color = '';
                
            if (document.Registar_Request.Full_Name.value.length < 4 || document.Registar_Request.Full_Name.value.length > 20) {
                //document.Registar_Request.Full_Name.focus();
                //alert("שם מלא חייב להיות בין 4 ל 20 תווים");
                document.Registar_Request.fname_ans2.style.color = 'red';
                document.Registar_Request.Full_Name.style.backgroundColor = '#FF7777';
                flag = false;
            }
            else
                document.Registar_Request.fname_ans2.style.color = '';

            if ((document.Registar_Request.Full_Name.value.lastIndexOf(' ') != document.Registar_Request.Full_Name.value.indexOf(' ')) || (document.Registar_Request.Full_Name.value.indexOf(' ') == -1)) {
                //document.Registar_Request.Full_Name.focus();
                //alert("שם מלא חייב להכיל שתי מילים בלבד -רווח אחד");
                document.Registar_Request.fname_ans3.style.color = 'red';
                document.Registar_Request.Full_Name.style.backgroundColor = '#FF7777';
                flag = false;
            }
            else
                document.Registar_Request.fname_ans3.style.color = '';               
            if(flag)document.Registar_Request.Full_Name.style.backgroundColor = '#99FF99';
        }

function check_pass() {
    var flag = true;
        F = document.Registar_Request.Password.value;
        
        if (CheckNameForLetterse(F) == false) {
            //document.Registar_Request.Password.focus();
            //alert("נא השתמש באותיות באנגלית ומספרים בלבד בססמא");
            document.Registar_Request.pass_ans1.style.color = 'red';
            document.Registar_Request.Password.style.backgroundColor = '#FF7777';
            flag= false;
        }
        else
            document.Registar_Request.pass_ans1.style.color = '';
            
        if (F.length < 4 || F.length > 15) {
            //document.Registar_Request.Password.focus();
            //alert("אורך הססמה צריך להיות בין 4 ל15 תווים");
            document.Registar_Request.pass_ans2.style.color = 'red';
            document.Registar_Request.Password.style.backgroundColor = '#FF7777';
            flag = false;
        }
        else
            document.Registar_Request.pass_ans2.style.color = '';
            
       if(flag) document.Registar_Request.Password.style.backgroundColor = '#99FF99';
    }


    function check_confirm_pass() {
        var flag = true;
            F = document.Registar_Request.Password.value;
            if (F != document.Registar_Request.Confirm_Password.value) {
                //document.Registar_Request.Confirm_Password.focus();
                //alert("על הססמאות להיות זהות");confirm_pass_ans
                document.Registar_Request.confirm_pass_ans.style.color = 'red';
                document.Registar_Request.confirm_pass_ans.value = "על הססמאות להיות זהות";
                document.Registar_Request.Confirm_Password.style.backgroundColor = '#FF7777';
                flag = false;
            }
            else 
            {
                document.Registar_Request.confirm_pass_ans.style.color = '';
                document.Registar_Request.confirm_pass_ans.value = "";
            }

            if (flag) document.Registar_Request.Confirm_Password.style.backgroundColor = '#99FF99';
        }
function check_company() {
    var flag = true;
        if (document.Registar_Request.Company_Name.value.length == 0) {
            //document.Registar_Request.Company_Name.focus();
           // alert("חובה למלא שם חברה או עסק");
            document.Registar_Request.Company_Name.style.backgroundColor = '#FF7777';
            flag= false;
        }
        
        if (document.Registar_Request.Company_Name.value.length > 30) {
           // document.Registar_Request.Company_Name.focus();
            //alert("אורך שם חברה או עסק צריך להיות עד 30 תווים");
            document.Registar_Request.company_ans.style.color = 'red';
            document.Registar_Request.Company_Name.style.backgroundColor = '#FF7777';
            flag = false;
        }
        else
            document.Registar_Request.company_ans.style.color = '';
        
        if(flag)document.Registar_Request.Company_Name.style.backgroundColor = '#99FF99';
}
function check_phone() {
    var flag = true;
               if (CheckIsNumber(document.Registar_Request.Phone.value) == false) {
                //document.Registar_Request.Phone.focus();
                   // alert("נא השתמש במספרים בלבד במספר פלאפון");
                   document.Registar_Request.phone_ans1.style.color = 'red';
                   document.Registar_Request.Phone.style.backgroundColor = '#FF7777';
               flag= false;
           }
           else
               document.Registar_Request.phone_ans1.style.color = '';
               
            if (document.Registar_Request.Phone.value.length != 7) {
              //  document.Registar_Request.Phone.focus();
                //  alert("מספר פלאפון חייב להיות 7 ספרות");
                document.Registar_Request.phone_ans2.style.color = 'red';
                document.Registar_Request.Phone.style.backgroundColor = '#FF7777';
                flag = false;
            }
            else
                document.Registar_Request.phone_ans2.style.color = '';
            if(flag)document.Registar_Request.Phone.style.backgroundColor = '#99FF99';
}

function check_email()
{
        F = document.Registar_Request.E_Mail.value;
        i = F.indexOf('@');
        if (i == -1) {
           // document.Registar_Request.E_Mail.focus();
            // alert("כתובת דוא\"ל חייבת להכיל @");
            document.Registar_Request.email_ans.style.color = 'red';
            document.Registar_Request.email_ans.value = 'חייב להכיל שטרודל';
            document.Registar_Request.E_Mail.style.backgroundColor = '#FF7777';
            return false;
        }

        if (i == 0) {
            //document.Registar_Request.E_Mail.focus();
            //alert("כתובת דוא\"ל אינה יכולה להתחיל בכרוכית");
            document.Registar_Request.email_ans.style.color = 'red';
            document.Registar_Request.email_ans.value = 'אסור להתחיל בשטרודל';
            document.Registar_Request.E_Mail.style.backgroundColor = '#FF7777';
            return false;
        }

        if (F.lastIndexOf('@') == F.length - 1) {
            //document.Registar_Request.E_Mail.focus();
            //alert("כתובת דוא\"ל אינה יכולה להסתיים ב-@");
            document.Registar_Request.email_ans.style.color = 'red';
            document.Registar_Request.email_ans.value = 'אסור להסתיים בשטרודל';
            document.Registar_Request.E_Mail.style.backgroundColor = '#FF7777';
            return false;
        }
       

        if (F.lastIndexOf('@') > i) {
            //document.Registar_Request.E_Mail.focus();
            //alert("כתובת דוא\"ל אינה יכולה להכיל שתי @");
            document.Registar_Request.email_ans.style.color = 'red';
            document.Registar_Request.email_ans.value = 'חייב רק שטרודל אחד';
            document.Registar_Request.E_Mail.style.backgroundColor = '#FF7777';
            return false;
        }

        if (F.lastIndexOf('.') < i) {
            //document.Registar_Request.E_Mail.focus();
            //alert("חייבת להופיע נקודה אחרי @");
            document.Registar_Request.email_ans.style.color = 'red';
            document.Registar_Request.email_ans.value = 'חייב להכיל נקודה';
            document.Registar_Request.E_Mail.style.backgroundColor = '#FF7777';
            return false;
        }

        if (F.charAt(F.length - 1) == '.') {
           // document.Registar_Request.E_Mail.focus();
            //alert("כתובת דוא\"ל אינה יכולה להסתיים בנקודה");
            document.Registar_Request.email_ans.style.color = 'red';
            document.Registar_Request.email_ans.value = 'אסור להסתיים בנקודה';
            document.Registar_Request.E_Mail.style.backgroundColor = '#FF7777';
            return false;
        }

        if (F.indexOf("@.") > -1 || F.indexOf(".@") > -1) {
            //document.Registar_Request.E_Mail.focus();
            //alert("הנקודה אינה יכולה להיות צמודה ל@ ");
            document.Registar_Request.email_ans.style.color = 'red';
            document.Registar_Request.email_ans.value = 'אסור נקודה ושטרודל צמודים';
            document.Registar_Request.E_Mail.style.backgroundColor = '#FF7777';
            return false;
        }

        i = FindIn(F, "()[]{}<>\\|/,?!\"'`;:~!#$%^&*+=");
        if (i > -1) {
           // document.Registar_Request.E_Mail.focus();
            // alert("כתובת הדוא\"ל מכילה תו לא חוקי\n" + F.charAt(i));
            document.Registar_Request.email_ans.style.color = 'red';
            document.Registar_Request.email_ans.value = 'מכיר תו לא חוקי: ' + F.charAt(i) + '';
            document.Registar_Request.E_Mail.style.backgroundColor = '#FF7777';
            return false;
        }
        document.Registar_Request.email_ans.style.color = 'green';
        document.Registar_Request.email_ans.value = 'כתובת חוקית!';
        document.Registar_Request.E_Mail.style.backgroundColor = '#99FF99';
        }
       
  

function stripCharsInBag(s, bag){
	var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++){   
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary (year){
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}
function DaysArray(n) {
	for (var i = 1; i <= n; i++) {
		this[i] = 31
		if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
		if (i==2) {this[i] = 29}
   } 
   return this
}

function isDate(day,month,year){
	var daysInMonth = DaysArray(12);
	strYr=year;
	month=parseInt(month);
	day=parseInt(day);
	year=parseInt(year);

	if (month.length<1 || month<1 || month>12){
		alert("תאריך לידה אינו חוקי");
		return false;
	}
	if (day.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month]){
		alert("תאריך לידה אינו חוקי");
		return false;
	}
	if (year/1000 == 0 || year==0 ){
		alert("תאריך לידה אינו חוקי");
		return false
	}
return true
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

    function check_un() {
            window.open("Check_Username.aspx?USER_ID="+document.Registar_Request.USER_ID.value+"", "checking", "width=10 height=10")
    }
    function enable_button() {
        document.Registar_Request.USER_ID.style.backgroundColor == "";
        document.Registar_Request.check_username.disabled = false;
    }
    
    </script>

    <form name ="Registar_Request" id="rr" method="post" action="Insert.aspx" onsubmit="return Check();">
    <input type="hidden" name="Check_Username_page" value="Registar" />
<table style="width: 470px" align="center">
<tr>
<td colspan="4">
    <h2 align="center">טופס הרשמה לאתר</h2></td>
</tr>

<tr>
<td colspan="4">
    מנהל יקר, אנא מלא את פרטי הטופס הבא על מנת להירשם לאתר</td>
</tr>

<tr>
<td style="width: 120px">
<b>
שם משתמש:</b></td>
<td>
<input type="text" name="USER_ID" id="un" style="width: 150px;" onchange="enable_button()" />
</td>
<td style="width: 20px">
    &nbsp;</td>
<td style="width: 200px">
    
 <input id="Text12" type="text" readonly="readonly" name="user_ans1" value="אנגלית בלבד" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
     
 <input id="Text13" type="text" readonly="readonly" name="user_ans2" value="בין 3-15 תווים" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
 </td>
</tr>

<tr>
<td style="width: 120px">
    &nbsp;</td>
<td colspan="3">
    <input id="Button1" disabled="disabled" name="check_username" type="button" onclick="check_un()" value="בדוק זמינות" />
    &nbsp;&nbsp;&nbsp;
    <input id="Text3" type="text" readonly="readonly" name="user_ans" style="background-color: #bbc6d1; border-style: none; font-size: medium;" /></td>
</tr>

<tr>
<td style="width: 120px">
    &nbsp;</td>
<td>
    &nbsp;</td>
<td style="width: 20px">
    &nbsp;</td>
<td style="width: 200px">

    &nbsp;</td>
</tr>

<tr>
<td>
<b>
ססמא:
</b></td>
<td>
<input type="password" name="Password" style="width: 150px;" id="pb" onchange="check_pass()" />
</td>
<td>
    &nbsp;</td>
<td rowspan="2">
    
 <input id="Text1" type="text" readonly="readonly" name="pass_ans1" value="אנגלית ומספרים בלבד" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
<input id="Text2" type="text" readonly="readonly" name="pass_ans2" value="בין 4-15 תווים" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
    
</td>
</tr>

<tr>
<td>
<b>
    אימות ססמא:
    </b></td>
<td>
<input type="password" name="Confirm_Password" style="width: 150px;" id="pb2" onchange="check_confirm_pass()" />
</td>
<td>
    &nbsp;</td>
</tr>

<tr>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td>
<input id="Text4" type="text" readonly="readonly" name="confirm_pass_ans"       
        style="background-color: #bbc6d1; border-style: none; font-size: medium;" /></td>
</tr>
<tr>
<td>
<b>
שם מלא:
</b>
</td>
<td>
<input type="text" name="Full_Name" style="width: 150px;" onchange="check_fname()" /></td>
<td>
    &nbsp;</td>
<td>
<input id="Text5" type="text" readonly="readonly" name="fname_ans1" value="עברית בלבד" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
<input id="Text6" type="text" readonly="readonly" name="fname_ans2" value="בין 4-20 תווים" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
<input id="Text7" type="text" readonly="readonly" name="fname_ans3" value="שתי מילים" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />

    </td>
    </tr>
<tr>
<td>
<b>
שם עסק/חברה:
</b>
</td>
<td>
<input type="text" name="Company_Name" style="width: 150px;" id="cn" onchange="check_company()" /></td>
<td>
    &nbsp;</td>
<td>
<input id="Text8" type="text" readonly="readonly" name="company_ans" value="עד 30 תווים" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
    </td>
</tr>
<tr>
<td>
<b>
אימייל:
        </b></td>
<td>
<input type="text" name="E_Mail" style="width: 150px;" id="eb" onchange="check_email()" /></td>
<td>
    &nbsp;</td>
<td>
<input id="Text9" type="text" readonly="readonly" name="email_ans" value="אנא הכנס כתובת חוקית" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
    </td>
</tr>


    <tr>
<td>
    <b>
    פלאפון:
    </b>
    </td>
<td>
<input type="text" name="Phone" style="width: 80px;" id="eb0" onchange="check_phone()" />
-
<select id ="select3" name="phone_start" style="width: 50px;">
<option>בחר</option>
<%Area_Codes(); %>
</select>
</td>
<td>
    &nbsp;</td>
<td>
<input id="Text10" type="text" readonly="readonly" name="phone_ans1" value="מספרים בלבד" style="background-color: #bbc6d1; border-style: none; font-size: medium;" />
<input id="Text11" type="text" readonly="readonly" name="phone_ans2" value="10 ספרות" style="background-color: #bbc6d1; border-style: none; font-size: medium;" /></td>
</tr>


<tr>
<td>
<b>
תאריך לידה:
</b>
</td>
<td>
<table>
<tr>
<td>
<select id="Select4" name="Year">
<option>בחר</option>
<%years(); %>
        
    </select>
</td>
<td>
<select id="Select5" name="Month">
      
    <option>בחר</option>
    <%months(); %>
    </select>
</td>
<td>
<select id="Select6" name="Day">
  <option>בחר</option>
  <%days(); %>
    </select>
    </td>
    </tr>
    </table>
</td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td></tr>




<tr>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td></tr>

<tr>
    <td colspan="2">
        <input id="Accept_Terms" type="checkbox" />אני מסכים ל<a 
            href="Term_Of_Use.aspx" target="_blank" >תנאי השימוש</a></td>

    <td>
        &nbsp;</td>

    <td>
        &nbsp;</td>

</tr>

<tr>
    <td>
        &nbsp;</td>
    <td>
        <input id="submit" style="width: 109px" type="submit" value="הירשם" /></td>


    <td>
        &nbsp;</td>


    <td>
        &nbsp;</td>

</tr>

</table>
</form>
</asp:Content>

