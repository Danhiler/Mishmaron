<%@ Page Title="דוח סידור עבודה אוטומטי" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Update_shifts.aspx.cs" Inherits="Update_shifts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            text-decoration: underline;
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td colspan="2">
                <p class="style1">
                    דוח סידור עבודה אוטומטי</p>
            </td>
        </tr>
       
      
    
        <tr>
            <td align="right">
                <b dir="rtl">חלוקת משמרות:</b></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <%print_workers_table(); %></td>
        </tr>
    </table>
</asp:Content>

