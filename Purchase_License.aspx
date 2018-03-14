<%@ Page Title="רכישת ימי שירות" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Purchase_License.aspx.cs" Inherits="Purchase_License" %>

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
<h2 align="center">הוספת ימי שירות</h2>
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
בחר את החבילת הרצויה:
</td></tr>
<tr>
<td>
 <table border="0">
 <tr>
 <td>
<a target="_blank" href='https://secure.paycard.co.il/webi/merpages/purchaselink.aspx?I=mtpurchase&mer=PayCard&MerchantID=1504044&Amount=147&Currency=ILS&UserDesc=%u05e8%u05db%u05d9%u05e9%u05ea%203%20%u05d7%u05d5%u05d3%u05e9%u05d9%u05dd%20-%2090%20%u05d9%u05de%u05d9%u05dd' ><img src="Pictures/license_small.png" alt="90 יום ב59 שח" border="0" /></a>
</td>
</tr>
 <tr>
 <td>
 <a target="_blank" href='https://secure.paycard.co.il/webi/merpages/purchaselink.aspx?I=mtpurchase&mer=PayCard&MerchantID=1504044&Amount=264&Currency=ILS&UserDesc=%u05e8%u05db%u05d9%u05e9%u05ea%206%20%u05d7%u05d5%u05d3%u05e9%u05d9%u05dd%20-%20180%20%u05d9%u05de%u05d9%u05dd' ><img src="Pictures/license_medium.png" alt="180 יום ב99 שח" border="0" /></a>
 </td>
 </tr>
  <tr>
 <td>
  <a target="_blank" href='https://secure.paycard.co.il/webi/merpages/purchaselink.aspx?I=mtpurchase&mer=PayCard&MerchantID=1504044&Amount=399&Currency=ILS&UserDesc=%u05e8%u05db%u05d9%u05e9%u05ea%2012%20%u05d7%u05d5%u05d3%u05e9%u05d9%u05dd%20-%20360%20%u05d9%u05de%u05d9%u05dd' ><img src="Pictures/license_large.png" alt="360 יום ב169 שח" border="0" /></a>
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

