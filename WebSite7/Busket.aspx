<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Busket.aspx.cs" Inherits="Busket" %>

<%-- Add content controls here --%>
<asp:Content ID="Content3" ContentPlaceHolderID="ph2" runat="server">
        <li><a style="color: Black;" href="MyData.aspx?Edit=yes">Edit Profile</a></li>
        <li><a style="color: Black;" href="MyData.aspx">View Profile</a></li>
        <li><a style="color: Black;" href="Busket.aspx">Busket</a></li>
        <li><a style="color: Black;" href="MoviesList.aspx">Movies List</a></li>
        <li><a style="color: Black;" href="ShowTickets.aspx">Show Tickets</a></li>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolder1" Runat="Server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <link rel="stylesheet" type="text/css" href="StyleSheet.css" /> 
    <title>MovieStar</title>
</head>
<body><center>
    <form id="form1" runat="server">
    <div>

    <div id="busket" runat="server"></div>
   
    </div>
    </form>
</center></body>
</html>
</asp:Content>