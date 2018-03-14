<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Owner_Page.aspx.cs" Inherits="Owner_Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>דף הצגת נתונים</title>
</head>
<body dir ="rtl" >
    <form id="form1" runat="server">
    <table align="center" bgcolor="#FFFFCC" border="1" dir="rtl" style="width: 80%">
    <tr>
    <td>
    גולשים באתר
     :
     <%=Application["Mone_Mevakrim"].ToString()%>
     </td>
     <td>
     שבוע התחלף: 
     <%=Application["Week_Changed"].ToString() %>
     <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
         style="text-align: left" Text="החלף שבוע" />
     </td>
     
     <td>
     הודעות: 
     <%=Application["Use_Down_Msg"].ToString()%>
     <asp:Button ID="Button7" runat="server" onclick="change_mes_Click" 
         style="text-align: left" Text="שנה" />
     </td>
     
     <td>
     <asp:TextBox ID="TextBox1" runat="server" Width="274px"></asp:TextBox>
     <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
         Text="hash md5" />
         </td>
         <td>
         הודעות SMS:
         <%=Num_Of_SMS %>
         <a href="Owner_SendSMS.aspx">שלח הודעה</a>
         </td>
         <td>
            <a href="Logoff.aspx">התנתקות</a>
         </td>
         </tr>
        <tr><td colspan="6">
        <h1>
             משתמשים
     -
     <%=GridView1.Rows.Count%>


     </h1>
    <%Print_Users(); %>
    <asp:Button ID="Button8" runat="server" Text="הצג" onclick="Button8_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataSourceID="AccessDataSource1" ForeColor="Black" 
        GridLines="Vertical" AllowPaging="True" PageSize="30" Visible="False">
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                SortExpression="ID" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />
            <asp:BoundField DataField="Passw" HeaderText="Passw" SortExpression="Passw" />
            <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="CName" HeaderText="CName" SortExpression="CName" />
            <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date_Of_Birth" 
                SortExpression="Date_Of_Birth" />
            <asp:BoundField DataField="Reg_Date" HeaderText="Reg_Date" 
                SortExpression="Reg_Date" />
            <asp:BoundField DataField="Days_Left" HeaderText="Days_Left" 
                SortExpression="Days_Left" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/MyDB.mdb" SelectCommand="SELECT * FROM [Users]" >
    </asp:AccessDataSource>
    </td></tr>
    <tr><td colspan="6">
    <h1>
    עובדים - 
     <%=GridView2.Rows.Count %>
    </h1>
        <asp:Button ID="Button9" runat="server" Text="הצג" onclick="Button9_Click" />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="AccessDataSource2" ForeColor="Black" 
            GridLines="Vertical" AllowPaging="True" PageSize="30" Visible="False">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="NameW" HeaderText="NameW" SortExpression="NameW" />
                <asp:BoundField DataField="UserID" HeaderText="UserID" 
                    SortExpression="UserID" />
                <asp:BoundField DataField="PassW" HeaderText="PassW" SortExpression="PassW" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="E_Mail" HeaderText="E_Mail" 
                    SortExpression="E_Mail" />
                <asp:BoundField DataField="Last_Wach" HeaderText="Last_Wach" 
                    SortExpression="Last_Wach" />
                     <asp:HyperLinkField DataNavigateUrlFields="UserID" 
                    DataNavigateUrlFormatString="Owner_Login.aspx?id={0}" 
                    HeaderImageUrl="~/Pictures/edit.gif" Text="login" />
                    
                                              <asp:HyperLinkField DataNavigateUrlFields="UserID"  
                DataNavigateUrlFormatString="owner_delete.aspx?ID={0}" HeaderText="delete" 
                Text="delete"  HeaderImageUrl="~/Pictures/del.gif" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
            DataFile="~/App_Data/MyDB.mdb" 
            SelectCommand="SELECT * FROM [Workers] ORDER BY [ID], [PassW]">
        </asp:AccessDataSource>

    </td></tr>
    <tr>
    <td colspan="6">
    <h1>
        דוחות קנייה - 
        <%=GridView6.Rows.Count %>
        <asp:Button ID="Button6" runat="server" 
                onclick="Change_Visible_payments" Text="הצג" />
    </h1>
        
        
        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="AccessDataSource6" ForeColor="Black" 
            GridLines="Vertical" Visible="False" AllowPaging="True" PageSize="30">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Full_name" HeaderText="Full_name" 
                    SortExpression="Full_name" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" 
                    SortExpression="Amount" />
                <asp:BoundField DataField="buying_date" 
                    HeaderText="buying_date" SortExpression="buying_date" />
                <asp:BoundField DataField="Payment_ID" HeaderText="Payment_ID" 
                    SortExpression="Payment_ID" />
                    <asp:HyperLinkField DataNavigateUrlFields="Payment_ID"  
                DataNavigateUrlFormatString="owner_delete_payment.aspx?ID={0}" HeaderText="delete" 
                Text="delete"  HeaderImageUrl="~/Pictures/del.gif" />
                
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource6" runat="server" 
            DataFile="~/App_Data/MyDB.mdb" 
        SelectCommand="SELECT * FROM [Payments] ORDER BY [buying_date]">
        </asp:AccessDataSource>
        </td></tr>
    <tr><td colspan="6">
    <h1>
        אפשרויות
        <asp:Button ID="Button2" runat="server" 
                onclick="Change_Visible_Options" Text="הצג" />
    </h1>
        
        
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="AccessDataSource3" ForeColor="Black" 
            GridLines="Vertical" Visible="False" AllowPaging="True" PageSize="30">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Length_Of_Boxes" HeaderText="LB" 
                    SortExpression="Length_Of_Boxes" />
                <asp:BoundField DataField="Length_Of_Temp_Boxes" 
                    HeaderText="LTB" SortExpression="Length_Of_Temp_Boxes" />
                <asp:CheckBoxField DataField="Use_Jobs" 
                    HeaderText="Use_Jobs" SortExpression="Use_Jobs" />
                    
                <asp:CheckBoxField DataField="intermediate_Shifts" 
                    HeaderText="IS" SortExpression="intermediate_Shifts" />
                    
                <asp:BoundField DataField="Max_Workers" HeaderText="Max_Workers" 
                    SortExpression="Max_Workers" />
                    
                <asp:BoundField DataField="Max_Jobs" HeaderText="Max_Jobs" 
                    SortExpression="Max_Jobs" />
                    
                <asp:BoundField DataField="Num_Of_SMS" HeaderText="Num_Of_SMS" 
                    SortExpression="Num_Of_SMS" />
                <asp:BoundField DataField="Last_Updated" HeaderText="Last_Updated" 
                    SortExpression="Last_Updated" />
                    
                    <asp:HyperLinkField DataNavigateUrlFields="ID" 
                    DataNavigateUrlFormatString="owner_update_mw.aspx?id={0}" 
                    HeaderImageUrl="~/Pictures/edit.gif" Text="change mw" />
                           <asp:HyperLinkField DataNavigateUrlFields="ID" 
                    DataNavigateUrlFormatString="Owner_Add_SMS.aspx?id={0}" 
                    HeaderImageUrl="~/Pictures/edit.gif" Text="Add sms" />
                    
                    <asp:HyperLinkField DataNavigateUrlFields="ID" 
                    DataNavigateUrlFormatString="Owner_Add_MG.aspx?id={0}" 
                    HeaderImageUrl="~/Pictures/edit.gif" Text="Add jobs" />
                
            </Columns>
           
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">
    </asp:ObjectDataSource>
        <asp:AccessDataSource ID="AccessDataSource3" runat="server" 
            DataFile="~/App_Data/MyDB.mdb" 
        
            SelectCommand="SELECT [ID], [Length_Of_Boxes], [Length_Of_Temp_Boxes], [Use_Jobs], [intermediate_Shifts], [Max_Workers], [Max_Jobs], [Num_Of_SMS], [Last_Updated] FROM [Options] ORDER BY [ID]">
        </asp:AccessDataSource>
        </td></tr>
        <tr>
        <td colspan="6">
    <h1>
        תפקידים
        <asp:Button ID="Button5" runat="server" 
                onclick="Change_Visible_Jobs" Text="הצג" />
    </h1>
        
        
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="AccessDataSource5" ForeColor="Black" 
            GridLines="Vertical" Visible="False" AllowPaging="True" PageSize="30">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Short_Job" HeaderText="Short_Job" 
                    SortExpression="Short_Job" />
                <asp:BoundField DataField="Job" 
                    HeaderText="Job" SortExpression="Job" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
                
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource5" runat="server" 
            DataFile="~/App_Data/MyDB.mdb" 
        SelectCommand="SELECT * FROM [Jobs] ORDER BY [ID], [Short_Job]">
        </asp:AccessDataSource>
        </td></tr>
        <tr><td colspan="6">
        <h1>
            טבלאות עבודה <asp:Button ID="Button1" runat="server" 
                onclick="Change_Visible_tables" Text="הצג" />
    </h1>
        
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="AccessDataSource4" ForeColor="Black" 
            GridLines="Vertical" Visible="False" AllowPaging="True" PageSize="30">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:CheckBoxField DataField="Allow_Changes" HeaderText="Allow_Changes" 
                    SortExpression="Allow_Changes" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Week" HeaderText="Week" SortExpression="Week" />
                <asp:BoundField DataField="sunday_morning" HeaderText="sunday_morning" 
                    SortExpression="sunday_morning" />
                <asp:BoundField DataField="monday_morning" HeaderText="monday_morning" 
                    SortExpression="monday_morning" />
                <asp:BoundField DataField="tuesday_morning" HeaderText="tuesday_morning" 
                    SortExpression="tuesday_morning" />
                <asp:BoundField DataField="wednesday_morning" HeaderText="wednesday_morning" 
                    SortExpression="wednesday_morning" />
                <asp:BoundField DataField="thursday_morning" HeaderText="thursday_morning" 
                    SortExpression="thursday_morning" />
                <asp:BoundField DataField="friday_morning" HeaderText="friday_morning" 
                    SortExpression="friday_morning" />
                <asp:BoundField DataField="saturday_morning" HeaderText="saturday_morning" 
                    SortExpression="saturday_morning" />
                <asp:BoundField DataField="sunday_intermediate" 
                    HeaderText="sunday_intermediate" SortExpression="sunday_intermediate" />
                <asp:BoundField DataField="monday_intermediate" 
                    HeaderText="monday_intermediate" SortExpression="monday_intermediate" />
                <asp:BoundField DataField="tuesday_intermediate" 
                    HeaderText="tuesday_intermediate" SortExpression="tuesday_intermediate" />
                <asp:BoundField DataField="wednesday_intermediate" 
                    HeaderText="wednesday_intermediate" SortExpression="wednesday_intermediate" />
                <asp:BoundField DataField="thursday_intermediate" 
                    HeaderText="thursday_intermediate" SortExpression="thursday_intermediate" />
                <asp:BoundField DataField="friday_intermediate" 
                    HeaderText="friday_intermediate" SortExpression="friday_intermediate" />
                <asp:BoundField DataField="saturday_intermediate" 
                    HeaderText="saturday_intermediate" SortExpression="saturday_intermediate" />
                <asp:BoundField DataField="sunday_evening" HeaderText="sunday_evening" 
                    SortExpression="sunday_evening" />
                <asp:BoundField DataField="monday_evening" HeaderText="monday_evening" 
                    SortExpression="monday_evening" />
                <asp:BoundField DataField="tuesday_evening" HeaderText="tuesday_evening" 
                    SortExpression="tuesday_evening" />
                <asp:BoundField DataField="wednesday_evening" HeaderText="wednesday_evening" 
                    SortExpression="wednesday_evening" />
                <asp:BoundField DataField="thursday_evening" HeaderText="thursday_evening" 
                    SortExpression="thursday_evening" />
                <asp:BoundField DataField="friday_evening" HeaderText="friday_evening" 
                    SortExpression="friday_evening" />
                <asp:BoundField DataField="saturday_evening" HeaderText="saturday_evening" 
                    SortExpression="saturday_evening" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource4" runat="server" 
            DataFile="~/App_Data/MyDB.mdb" 
        SelectCommand="SELECT * FROM [Work_Table] ORDER BY [ID]">
        </asp:AccessDataSource>
        </td></tr>
        <tr><td colspan="6">
        <h1>
            הודעות בתחתית האתר <asp:Button ID="Button10" runat="server" 
                onclick="Change_Visible_Mes" Text="הצג" />
                
    </h1>
        <a href="Owner_Add_Down_Mes.aspx">הוסף הודעה חדשה</a>
        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataSourceID="AccessDataSource7" ForeColor="Black" 
            GridLines="Vertical" Visible="False" AllowPaging="True" PageSize="30">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" 
                    InsertVisible="False" />
                <asp:CheckBoxField DataField="A_Admin" HeaderText="A_Admin" 
                    SortExpression="A_Admin" />
                <asp:CheckBoxField DataField="A_Worker" HeaderText="A_Worker" 
                    SortExpression="A_Worker" />
                <asp:BoundField DataField="Msg" HeaderText="Msg" 
                    SortExpression="Msg" />
                <asp:BoundField DataField="Link" HeaderText="Link" SortExpression="Link" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" 
                    DataNavigateUrlFormatString="Owner_Delete_Mes.aspx?id={0}" 
                    HeaderImageUrl="~/Pictures/del.gif" Text="DEL" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource7" runat="server" 
            DataFile="~/App_Data/MyDB.mdb" 
        SelectCommand="SELECT * FROM [Messages]">
        </asp:AccessDataSource>
        </td></tr>
        </table>
    </form>
        
</body>
</html>
