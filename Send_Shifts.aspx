<%@ Page Title="שליחת משמרות לעובדים" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Send_Shifts.aspx.cs" Inherits="Send_Shifts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <form id="form1" runat="server">
<table>
<tr><td>
<h2>דו"ח פרסום סידור עבודה</h2>
</td></tr>
<tr><td align="center">
להלן מופיעות תוצאות הפרסום של סידור העבודה
    :</td></tr>
<tr><td>
<%Print_Resualt(); %>
    
</td></tr>
<tr><td>
מספר הודעות SMS שנותרו:<%=sms_left %>
</td></tr>
<tr>
<td>
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</td></tr>
<tr>
<td>
<b>מקרא:</b>
<li><b>אין הודעות</b> - בחשבונך אין מספיק הודעות SMS לשליחה(<a href="purchase_SMS.aspx">הוסף</a>)</li>
<li><b>שגיאה</b> - בעיה בשרת, אנה פנה אלינו דרך דף יצירת הקשר</li>
<li><b>לא חוקי</b> - אחד ממרכיבי ההודעה לא חוקי(פלאפון או הודעה)</li>

</td>
</tr>
</table>
    </form>
</asp:Content>

