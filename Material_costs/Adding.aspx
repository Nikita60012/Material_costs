<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Material_costs.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="font-family: 'Times New Roman', Times, serif; font-size: 48px;">Добавление записей о расходах&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="BackButton" runat="server" Font-Names="Times New Roman" Font-Size="24pt" ForeColor="Black" PostBackUrl="~/MainMenu.aspx">Назад</asp:LinkButton>
    </h2>
       
        <p style="font-family: 'Times New Roman'; font-size: 28px">Дата:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Алюминевые болванки ():</p>
    <asp:Calendar ID="Date" runat="server" Height="89px" Width="198px"></asp:Calendar>
        <br />
       
        <p style="font-family: 'Times New Roman'; font-size: 28px">Количество изделий:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Медная проволка 0.5мм (м.):</p>
        <asp:TextBox ID="ProductsTextBox" runat="server" Font-Names="Times New Roman" Height="25px" Width="196px"></asp:TextBox>
        <br />
        <br />
    <br />
&nbsp;&nbsp;&nbsp;
    <p style="font-family: 'Times New Roman', Times, serif; font-size: 28px">
        <asp:CheckBox ID="IsStandart" runat="server" Checked="True" Font-Names="timews new roman" Font-Size="18pt" Text="По стандартам" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Моторное масло (л.):</p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<br />
        <br />
        <br />
        <asp:Button ID="AddButton" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Larger" Height="35px" OnClick="Button1_Click" Text="Добавить запись" Width="220px" />
        </asp:Content>
