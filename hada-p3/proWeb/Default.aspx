<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
        <h1>Products managment</h1>
    </div>
    <div>
        Code:
        <asp:TextBox ID="Code" runat="server"  Width="173px"></asp:TextBox>
        <br />
        <br />
        Name:
        <asp:TextBox ID="Name" runat="server" Width="173px"></asp:TextBox>        
        <br />
        <br />
        Amount:
        <asp:TextBox ID="Amount" runat="server" Width="173px"></asp:TextBox>
        <br />
        <br />
        Category:
        <asp:DropDownList ID="Category" runat="server" OnSelectedIndexChanged="Category_SelectedIndexChanged">
                <asp:ListItem Text="Computing" Value="0"></asp:ListItem>
                <asp:ListItem Text="Telephony" Value="1"></asp:ListItem>
                <asp:ListItem Text="Gaming" Value="2"></asp:ListItem>
                <asp:ListItem Text="Home appliances" Value="3"></asp:ListItem>
            </asp:DropDownList>
        <br />
        <br />
        Price:
        <asp:TextBox ID="Price" runat="server" Width="173px"></asp:TextBox>
        <br />
        <br />
        Creation Date:
        <asp:TextBox ID="Creation_date" runat="server" Width="173px"></asp:TextBox>
        <br />
        <asp:Button ID="Create" runat="server" Text="Create" OnClick="Create_Click"/>
        &nbsp;
        <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click"/>
        &nbsp;
        <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click"/>
        <br />
        <asp:Button ID="Read" runat="server" Text="Read" OnClick="Read_Click" />
        &nbsp;
        <asp:Button ID="Read_First" runat="server" Text="Read First" OnClick="Read_First_Click"/>
        &nbsp;
        <asp:Button ID="Read_Prev" runat="server" Text="Read Prev" OnClick="Read_Prev_Click"/>
        &nbsp;
        <asp:Button ID="Read_Next" runat="server" Text="Read Next" OnClick="Read_Next_Click"/>
        &nbsp;
        <asp:label ID="label1" runat="server" Text=" " />
    </div>
</asp:Content>