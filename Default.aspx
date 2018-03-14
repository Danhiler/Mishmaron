<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="משמרון - סידור עבודה" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <meta name="description" content="סידור עבודה אוטומטי המתבצע באופן פשוט ויעיל לעסקים המעסיקים עובדים במשמרות, שבועיים ניסיון חינם וללא כל התחייבות" />
        <meta name="robots" content="index,follow" />
        <meta name="keywords" content="סידור עבודה, שיבוץ במשמרות, ניהול משמרות" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server">
    <div align="right" dir="rtl" style="font-style: normal; font-family: Arial">
                יותר ויותר עסקים בארץ ובעולם עוברים לשיטה של הגשת משמרות דרך האינטרנט
                <br />
                משמרון מאפשרת סידור עבודה לעובדים בעסק שלך, האתר פשוט להפעלה וידידותי למשתמש.
                <br />
                באתרנו העובדים יכולים להגיש את יכולת העבודה שלהם 24/7 ובאופן פשוט ונוח
                המנהל יכול לקבוע סידור עבודה ולפרסם אותו לעובדים בקלות וביעילות
                כמו כן האתר מספק מספר רב של אפשרויות למנהלים ולעובדים:
                <br />
                <b>אז מה יש באתר? </b>
                <br />
                 <ul>
        
               <li>מערכת אוטומטית פשוטה וקלה לקביעת סידור עבודה</li>
               <li>רשימת קשר של העובדים</li>
               <li>אפשרות להשאיר הודעות לעובדים</li>
               <li>אפשרות מעקב אחר צפיית העובדים בסידור העבודה</li>
               <li>שליחת סידורי עבודה לעובדים באמצעות אימיילים ו SMS</li>
               <li>אפשרות להדפיס סידור עבודה מסודר ורשימת קשר</li>
               <li>מדריכים לעובדים ולמנהלים לשימוש נוח ויעיל יותר במערכת האתר</li>
               </ul>
               
               <br />
              כל מה שעליכם לעשות זה להירשם בדף ההרשמה(לא יותר מ5 דקות
              <asp:Label ID="Label1" runat="server" Text=")"></asp:Label>
              ולהתחיל לקבוע סידור עבודה בעסק שלהם בקלות וביעילות
              <br />
              האתר עובד בצורה הטובה ביותר בדפדפן של Internet Explorer גרסא 6 ומעלה.
              <br />
              <%Response.Write(hashmd5.getMd5Hash("1234")); %>
              </div>
              
    </form>
</asp:Content>

