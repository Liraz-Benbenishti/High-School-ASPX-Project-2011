<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCapitery.aspx.cs" Inherits="AddCapitery" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder1" Runat="Server">
<form runat="server">
<script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="slide.js"></script>
<script type="text/javascript" src="jquery.js"></script>
<script>
function closeAll()
{
  $("#T1").hide();
  $("#T2").hide();
  $("#T3").hide();
  $("#T4").hide();
}
$(document).ready(function(){
closeAll();
  $("#link1").click(function(){
closeAll();
  $("#T1").show();
  });
    $("#A1").click(function(){
closeAll();
  $("#T2").show();
  });
    $("#A2").click(function(){
closeAll();
  $("#T3").show();
  });
    $("#A3").click(function(){
closeAll();
  $("#T4").show();
  });
});
</script>
    <a id="link1">Add Cappitery Item</a> * 
     <a id="A1">Add Catgory for the capitary</a> * 
      <a id="A2">Add hall to the cinema</a> * 
       <a id="A3">Add Movie</a>
<div id="T1" style="display: none;">

<table>
<caption>
Add item to the capitary
</caption>
<tr>
<td>
Name:
</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
</tr><tr>
<td>
Picture:
</td>
<td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
</td>
</tr><tr>
<td>
Price:
</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</td>
</tr><tr>
<td>
Amount:
</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</td>
</tr><tr>
<td>
Catgory:
</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td colspan="2" style="text-align: center;">
    <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" /></td>
</tr>
</table>

</div>
<div id="T2">

<table>
<caption>Add Catgory for the capitary</caption>
<tr>
<td>
Catgory Name:
</td><td>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2" style="text-align: center;">
    <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" /></td>
</tr>
</table>

</div>
<div id="T3">

<table>
<caption>Add hall to the cinema</caption>
<tr>
<td>
Name:
</td><td>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
</td>
</tr><tr>
<td>
Rows:
</td><td>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
</td>
</tr><tr>
<td>
Seat Per Row:
</td><td>
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2" style="text-align: center;">
    <asp:Button ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
</td>
</tr>
</table>

</div>
<div id="T4" style="display: none;">
<table>
<caption>Add Movie</caption>
<tr>
<td>Name:
</td>
<td>
</td>
</tr><tr>
<td>Hour:
</td>
<td>
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>:<asp:TextBox ID="TextBox9"
        runat="server"></asp:TextBox>
</td>
</tr><tr>
<td>Length:
</td>
<td>
    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
</td>
</tr><tr>
<td>
Hall:
</td>
<td>
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
</td>
</tr><tr>
<td>
Price:
</td>
<td>
    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
</td>
</tr><tr>
<td>
Picture:
</td>
<td>
    <asp:FileUpload ID="FileUpload2" runat="server" />
</td>
</tr><tr>
<td colspan="2" style="text-align: center;">
</td>
</tr>
</table>
</div>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

