<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="List_Of_Workers.aspx.cs" Inherits="List_Of_Workers" Title="רשימת עובדים" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
  <div>
<h1 style="text-align: center">רשימת עובדים</h1>
      
   <br />
    <% PrintAdmin();  %>
    <br />
    <%PrintList(); %>

   
 </div> 
  
</asp:Content>

