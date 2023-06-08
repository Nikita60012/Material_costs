<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Material_costs._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 style="font-family: 'Times New Roman'; font-size: 42px">Введите логин и пароль</h1>
       
        <p style="font-family: 'Times New Roman'; font-size: 28px">Логин: </p>
        <asp:TextBox ID="LoginTextBox" runat="server" Font-Names="Times New Roman" Height="25px" Width="196px"></asp:TextBox>
        <br />
       
        <p style="font-family: 'Times New Roman'; font-size: 28px">Пароль: </p>
        <asp:TextBox ID="PasswordTextBox" runat="server" Font-Names="Times New Roman" Height="25px" Width="196px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="LogInButton" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Larger" Height="35px" OnClick="Button1_Click" Text="Войти" Width="127px" />
        <br />
        <br />
        <asp:Label ID="incorrectLabel" runat="server" Font-Names="Times New Roman" Font-Size="18pt" Text="Логин или пароль неверны" Visible="False"></asp:Label>
    </div>

    </asp:Content>
