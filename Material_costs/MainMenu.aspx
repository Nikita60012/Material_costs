<%@ Page Title="MainMenu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Material_costs.MainMenu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <h2>
        <asp:HyperLink ID="AddHyperLink" runat="server" Font-Names="Times New Roman" Font-Size="18pt" ForeColor="Black" NavigateUrl="~/Adding.aspx">Добавить новую запись</asp:HyperLink>

    &nbsp;</h2>
    <p style="font-family: 'Times New Roman'; font-size: 18px">
        Страница для добавления новых записей солгасно стандартам или ручным вводом затрат</p>
<p>
        <asp:Button ID="AddPageButton" runat="server" Height="28px" Text="&gt;&gt;&gt;" Width="128px" Font-Size="12pt" Font-Bold="False" PostBackUrl="~/Adding.aspx" />
</p>
<p>
        &nbsp;</p>
    <h2>
        <asp:HyperLink ID="ViewHyperLink" runat="server" Font-Names="Times New Roman" Font-Size="18pt" ForeColor="Black" NavigateUrl="~/Viewing.aspx">Просмотреть перечень записей</asp:HyperLink>

    </h2>
<p style="font-family: 'Times New Roman', Times, serif; font-size: 18px;">
        Страница для просмотра перечня записей по датам</p>
<p style="font-family: 'Times New Roman', Times, serif; font-size: 18px;">
        <asp:Button ID="ViewPageButton" runat="server" Height="28px" Text="&gt;&gt;&gt;" Width="128px" Font-Size="12pt" Font-Bold="True" PostBackUrl="~/Viewing.aspx" />

    </p>
<p style="font-family: 'Times New Roman', Times, serif; font-size: 18px;">
        &nbsp;</p>
    <h3 Font-Names="Times New Roman" Font-Size="14pt" style="font-family: 'Times New Roman', Times, serif">Вывести данные в файл</h3>
<p style="font-size: 18px; font-family: 'Times New Roman', Times, serif">
        Вывод данных в отдельный .xlsx файл находящийся на рабочем столе в папке CostTables\</p>
<p style="font-size: 18px; font-family: 'Times New Roman', Times, serif">
        <asp:Button ID="DownloadDataButton" runat="server" Height="28px" Text="&gt;&gt;&gt;" Width="128px" Font-Size="12pt" Font-Bold="True" OnClick="DownloadDataButton_Click" />
    </p>
    <p style="font-size: 18px; font-family: 'Times New Roman', Times, serif">
        &nbsp;</p>
        </div>
    </asp:Content>
