<%@ Page Title="תפקידים" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="jobs.aspx.cs" Inherits="jobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<center>
<h1>
תפקידים
</h1>
</center>
<%if (bool.Parse(Session["Admin"].ToString()))
  { %>
<a href ="Add_Job.aspx">הוספת תפקידים</a>
<%} 
PrintList(); %>
</asp:Content>

