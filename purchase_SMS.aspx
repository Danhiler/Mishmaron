<%@ Page Title="רכישת חבילות SMS" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="purchase_SMS.aspx.cs" Inherits="purchase_SMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<table class="sample">
<tr><td>
<h2 align="center">רכישת חבילת SMS</h2>
</td></tr>
<tr>
<td ><b>רכישה באמצעות כרטיס אשראי</b></td>
</tr>
<tr><td>
<b>שים לב! </b>
בדף החיוב הקפד להכניס את שמך המלא 
<b><span class="style1">בדיוק</span> </b>
באותה צורה שהכנסת אותו לאתר הזה,
<br />
אחרת זיכוי חשבונך עבור ההודעות שתרכוש יתבצע באופן ידני ולא אוטומטי
</td></tr>
<tr><td>
בחר את חבילת הSMS הרצויה:
</td></tr>
<tr>
<td>
 <table border="0">
 <tr>
 <td>
<a target="_blank" href='https://secure.paycard.co.il/webi/merpages/purchaselink.aspx?I=mtpurchase&mer=PayCard&MerchantID=1504044&Amount=29&Currency=ILS&UserDesc=%u05e8%u05db%u05d9%u05e9%u05ea%2040%20%u05d4%u05d5%u05d3%u05e2%u05d5%u05ea%20SMS' ><img src="Pictures/sms_small.png" alt="40 הודעות SMS ב29 שח" border="0" /></a>
</td>
</tr>
 <tr>
 <td>
 <a target="_blank" href='https://secure.paycard.co.il/webi/merpages/purchaselink.aspx?I=mtpurchase&mer=PayCard&MerchantID=1504044&Amount=49&Currency=ILS&UserDesc=%u05e8%u05db%u05d9%u05e9%u05ea%2090%20%u05d4%u05d5%u05d3%u05e2%u05d5%u05ea%20SMS' ><img src="Pictures/sms_medium.png" alt="90 הודעות SMS ב49 שח" border="0" /></a>
 </td>
 </tr>
  <tr>
 <td>
  <a target="_blank" href='https://secure.paycard.co.il/webi/merpages/purchaselink.aspx?I=mtpurchase&mer=PayCard&MerchantID=1504044&Amount=69&Currency=ILS&UserDesc=%u05e8%u05db%u05d9%u05e9%u05ea%20150%20%u05d4%u05d5%u05d3%u05e2%u05d5%u05ea%20SMS' ><img src="Pictures/sms_large.png" alt="150 הודעות SMS ב69 שח" border="0" /></a>
 </td>
 </tr>
 </table>
</td>
</tr>
<tr><td align="center">
<a href="receiving_email.aspx"><h2>לאחר ביצוע הרכישה המתן כחצי דקה ולחץ כאן</h2></a>
</td></tr>

</table>
</asp:Content>

