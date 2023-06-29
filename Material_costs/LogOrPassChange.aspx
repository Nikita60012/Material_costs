<%@ Page Title="LogOrPassChange" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogOrPassChange.aspx.cs" Inherits="Material_costs.LogOrPassChange" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2 style="font-family: 'Times New Roman', Times, serif; font-size: 48px;">Смена логина и пароля&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="BackButton" runat="server" Font-Names="Times New Roman" Font-Size="24pt" ForeColor="Black" PostBackUrl="~/MainMenu.aspx">Назад</asp:LinkButton>
    </h2>
    <p style="font-family: 'Times New Roman'; font-size: 28px">Новый логин: </p>
        <asp:TextBox ID="NewLoginTextBox" runat="server" Font-Names="Times New Roman" Height="25px" Width="196px"></asp:TextBox>
        <br />
        
        <p style="font-family: 'Times New Roman'; font-size: 28px">Новый пароль: </p>
        <asp:TextBox ID="NewPasswordTextBox" runat="server" Font-Names="Times New Roman" Height="25px" Width="196px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <p style="font-family: 'Times New Roman'; font-size: 28px">Старый пароль: </p>
        <asp:TextBox ID="OldPasswordTextBox" runat="server" Font-Names="Times New Roman" Height="25px" Width="196px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="incorrectLabel" runat="server" Font-Names="Times New Roman" Font-Size="18pt" Text="Введите текущий пароль" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ChangeButton" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Larger" Height="35px" OnClick="ChangeButton_Click" Text="Сменить" Width="220px" />
        
    </div>

    </asp:Content>