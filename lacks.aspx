<%@ Page Title="חוסרים" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="lacks.aspx.cs" Inherits="lacks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script type="text/javascript">
    function change_loc() {
        window.location = "http://www.mishmaron.com/publish_emergency.aspx";
    }
</script> 

<table>
<tr><td align="center" colspan="2">
<h2><b>חיסרון עובדים במשמרות</b></h2>
</td></tr>
<tr><td colspan="2">
<%Print_Lacks(); %>
</td></tr>
<%if (bool.Parse(Session["Admin"].ToString()))
  { %>
  <tr><td><input id="Button1" type="button" value="פרסום התרעת חוסרים" onclick="change_loc()" /></td>
  <td align="right">
<form  id="form1" action="fill_lacks.aspx">
    <input id="Button2" type="submit" value="מילוי חוסרים באופן אקראי" name="submit" />
         </form></td></tr>
<%} %>
</table>
</asp:Content>

