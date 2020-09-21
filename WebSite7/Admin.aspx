
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolder1" Runat="Server">
<center><form runat="server">
    <div id="admin" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Search user with ID number: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Search user with Mail address: "></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" /><br />
        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="White" GridLines="None" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit">
            <RowStyle BackColor="Black" />
            <Columns>
                <asp:BoundField DataField="CustomerID" DataFormatString="{0}" HeaderText="ID" ReadOnly="True"  />
                <asp:BoundField DataField="fname" DataFormatString="{0}" HeaderText="First Name" ReadOnly="True" />
                <asp:BoundField DataField="lname" DataFormatString="{0}" HeaderText="Last Name" ReadOnly="True" />
                <asp:TemplateField HeaderText="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("address") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("address", "{0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mail Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("mail") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("mail", "{0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone Number">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("phone") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("phone", "{0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Profile Picture">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture", "images/{0}") %>' Height="100px" Width="100px" />
                    </ItemTemplate>
                    <ControlStyle Height="50px" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Select"
                            Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="60px" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FF3300" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#FF3300" />
            <AlternatingRowStyle BackColor="Black" />
        </asp:GridView>
    </div>
    <div id="orders" runat="Server">
        <asp:GridView ID="GridView2" Width="100%" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#FFFFFF" GridLines="None" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnRowDeleting="GridView2_RowDeleting1" OnPageIndexChanging="GridView2_PageIndexChanging" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowCancelingEdit="GridView2_RowCancelingEdit">
            <RowStyle BackColor="Black" />
            <Columns>
                <asp:BoundField DataField="ticketID" DataFormatString="{0}" HeaderText="Ticket ID" ReadOnly="True" />
                <asp:BoundField DataField="cinemaID" DataFormatString="{0}" HeaderText="Cinema ID" ReadOnly="True" />
                <asp:BoundField DataField="movieID" DataFormatString="{0}" HeaderText="Movie ID" ReadOnly="True" />
                <asp:BoundField DataField="seat" DataFormatString="{0}" HeaderText="Seat" />
                <asp:BoundField DataField="Row" DataFormatString="{0}" HeaderText="Row" />
                <asp:BoundField DataField="status" DataFormatString="{0}" HeaderText="Status" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton9" runat="server" CausesValidation="False" CommandName="Select"
                            Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton10" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="60px" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FF3300" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#FF3300" />
            <AlternatingRowStyle BackColor="Black" />
        </asp:GridView>
        <asp:GridView ID="GridView3" width="100%" runat="server" CellPadding="4" ForeColor="White" GridLines="None"
            Visible="False" AutoGenerateColumns="False" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowEditing="GridView3_RowEditing" OnRowUpdated="GridView3_RowUpdated" OnRowUpdating="GridView3_RowUpdating">
            <RowStyle BackColor="Black" />
            <FooterStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FF3300" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#FF3300" />
            <AlternatingRowStyle BackColor="Black" />
            <Columns>
                <asp:BoundField DataField="movieID" DataFormatString="{0}" HeaderText="Movie ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" DataFormatString="{0}" HeaderText="Movie Name" ReadOnly="True" />
                <asp:BoundField DataField="HourS" DataFormatString="{0}" HeaderText="Start Hour" ReadOnly="True" />
                <asp:BoundField DataField="MinutesS" DataFormatString="{0}" HeaderText="Start Minute" ReadOnly="True" />
                <asp:TemplateField HeaderText="Movie Length (in minutes)">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Length") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Length", "{0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cinema ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cinemaID") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("cinemaID", "{0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Price") %>' Width="30px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Price", "{0}₪") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Picture">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" AlternateText='<%# Eval("picture", "picture") %>'
                            Height="100px" ImageUrl='<%# Eval("picture", "{0}") %>' Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </div>
   </form>
       </center>
</asp:Content>