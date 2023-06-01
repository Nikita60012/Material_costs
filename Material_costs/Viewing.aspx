<%@ Page Title="Viewing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Viewing.aspx.cs" Inherits="Material_costs.Viewing" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="font-family: 'Times New Roman', Times, serif; font-size: 48px;">Просмотр перечня записей&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="BackButton" runat="server" Font-Names="Times New Roman" Font-Size="24pt" ForeColor="Black" PostBackUrl="~/MainMenu.aspx">Назад</asp:LinkButton>
    </h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" Width="248px" AutoGenerateColumns="False" CellPadding="1" EditIndex="0">
            <Columns>
                <asp:BoundField ReadOnly="True" DataField="1" HeaderText="ID" />
                <asp:BoundField ReadOnly="True" DataField="12.04.2322" HeaderText="Дата" />
                <asp:BoundField DataField="25" HeaderText="Количество изделий" />
                <asp:CheckBoxField ReadOnly="True" DataField="true" HeaderText="Стандарт" />
            </Columns>
        </asp:GridView>
    </p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    </asp:Content>
