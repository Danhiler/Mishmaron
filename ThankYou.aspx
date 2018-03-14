<%@ Page Title="אישור קנייה" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ThankYou.aspx.cs" Inherits="ThankYou_SMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<center>
    <asp:Label ID="Label1" runat="server" 
        Text="אימות הרכישה נכשלה!<br> אנא פנה אלינו דרך דף יצירת הקשר על מנת לברר מדוע הרכישה נכשלה" Font-Size="Large" 
        ForeColor="Red"></asp:Label>
        </center>
</asp:Content>

