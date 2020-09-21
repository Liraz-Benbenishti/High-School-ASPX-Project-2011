<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CapiteryTable.aspx.cs" Inherits="CapiteryTable" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph2" Runat="Server">  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" Runat="Server">
<form id="Form1" runat="server">
<asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="productID" DataFormatString="{0}" HeaderText="Product ID"
            ReadOnly="True" />
        <asp:BoundField DataField="Name" DataFormatString="{0}" HeaderText="Product Name" />
        <asp:ImageField DataAlternateTextField="picture" DataImageUrlFormatString="{0}" HeaderText="Picture"
            ReadOnly="True">
        </asp:ImageField>
        <asp:BoundField DataField="Price" DataFormatString="{0} שקל" HeaderText="Price" />
        <asp:BoundField DataField="amount" DataFormatString="{0}" HeaderText="Amount" />
        <asp:CommandField ShowEditButton="True" />
        <asp:CommandField ShowDeleteButton="True" />
    </Columns>
    </asp:GridView>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

