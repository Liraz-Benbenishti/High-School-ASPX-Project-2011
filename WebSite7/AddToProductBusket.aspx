<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddToProductBusket.aspx.cs" Inherits="AddToProductBusket" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolder1" Runat="Server"><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <link rel="stylesheet" type="text/css" href="StyleSheet.css" /> 
    <title>MovieStar</title>
    <script language="javascript">
    function CreateDiv(row, chair)
    {


var X = event.clientX;
var Y = event.clientY;
document.getElementById("ddd").style.top= document.body.scrollTop + Y;
document.getElementById("ddd").style.left= document.body.scrollLeft + X;
    document.getElementById("ddd").innerHTML = "row: " + row + " chair: " + chair;
    }
    </script>
</head>
<body><center>
    <form id="form1" runat="server">
    <div>
       <asp:Label ID="Label1" runat="server" Style="position: static"></asp:Label><br /><br />
<div id="ddd" style='position: absolute; background-color: Bisque; border: solid 1px gray;'></div>
    <div id="content" runat="server">
        </div>

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1"
            runat="server" Text="Order" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Style="z-index: 100; right: 0px; position: static;
            top: 0px" Text="Cancel Chair Keep" OnClick="Button2_Click" />
    </div>
    </form>
</center></body>
</html>
</asp:Content>