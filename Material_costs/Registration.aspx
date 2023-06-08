<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Material_costs.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
    <h2 style="font-family: 'Times New Roman', Times, serif; font-size: 48px;">Регистрация&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="BackButton" runat="server" Font-Names="Times New Roman" Font-Size="24pt" ForeColor="Black" PostBackUrl="~/MainMenu.aspx">Назад</asp:LinkButton>
    </h2>
       
        <p style="font-family: 'Times New Roman'; font-size: 28px">Логин: </p>
        <asp:TextBox ID="LoginTextBox" runat="server" Font-Names="Times New Roman" Height="25px" Width="196px"></asp:TextBox>
        <br />
       
        <p style="font-family: 'Times New Roman'; font-size: 28px">Пароль: </p>
        <asp:TextBox ID="PasswordTextBox" runat="server" Font-Names="Times New Roman" Height="25px" Width="196px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="RegButton" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Larger" Height="35px" OnClick="RegButton_Click" Text="Зарегестрировать" Width="220px" />
        </div>
        </asp:Content>
