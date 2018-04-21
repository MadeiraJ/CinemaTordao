<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="pesquisa.aspx.cs" Inherits="Trabalho_IS.pesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <section id="content" style="max-width: 980px; margin: auto;" runat="server">
        <div class="w3-panel">
            <asp:Image ID="logo" runat="server" src="../images/logo.png" />
        </div>
        <div class="w3-container">
        </div>
        <div class="w3-row-padding" id="todosfilmes" runat="server">
            <div class="w3-center w3-padding-64">
                <span class="w3-xlarge w3-bottombar w3-border-dark-grey w3-padding-16">Todos os Filmes</span>
            </div>
        </div>
    </section>
</asp:Content>