<%@ Page Title="הודעות" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Add_Comment.aspx.cs" Inherits="Add_Comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<form id="form1" method="post" name="Comment" action="Save_Comment.aspx">
<table align="center" style="width: 300px">
<tr><td style="text-align: center">
כאן יפורסמו הודעות ע"י המנהל:
    <textarea dir="rtl" id="TextArea1" name="Comment" cols="50" rows="15" <%if (!(bool)Session["Admin"])Response.Write("readonly='readonly'"); %>><%=com %></textarea>
         </td></tr>
 <%  if ((bool)Session["Admin"])
     {

     Response.Write("<tr><td align='right'>");
     
     Response.Write("<input id='Checkbox1' type='checkbox' name='show_comment' ");
     if (show_Comment == "True")
     Response.Write("checked='checked' ");
     Response.Write("/>");
     Response.Write("הראה הודעה כאשר עובד מתחבר");
     Response.Write("</td></tr>");
     Response.Write("<tr><td style='text-align: center'>");
     Response.Write("<input id='Submit1' name='submit' type='submit' value='שמור' />");
    Response.Write("</td></tr>");
} %>
</table>

</form>


</asp:Content>

