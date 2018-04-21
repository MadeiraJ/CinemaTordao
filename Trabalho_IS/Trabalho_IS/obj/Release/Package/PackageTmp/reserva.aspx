<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="reserva.aspx.cs" Inherits="Trabalho_IS.reserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <section id="w3-content" style="max-width: 980px; margin: auto;">
        <div class="w3-panel">
            <asp:Image ID="logo" runat="server" src="../images/logo.png" />
        </div>
        <!--<div class="w3-row-padding" id="mais_vistos">-->
        <div class="w3-row-padding">
            <div class="w3-center w3-padding-64">
                <span class="w3-xlarge w3-bottombar w3-border-dark-grey w3-padding-16">Reserva</span>
            </div>

            <div class="w3-cell-row">
                <div class="w3-container w3-light-red w3-cell" style="/*width: 40%; height: 400px*/">
                    <div class="w3-container w3-cell">
                        <div class="w3-container">
                            <h3>Escolha do filme e horário</h3>
                            <p class="w3-opacity">Qual o Filme que quer ver?</p>
                            <asp:DropDownList ID="filmesSelecao" runat="server" OnSelectedIndexChanged="atualizarHoras" AutoPostBack="True">
                            </asp:DropDownList>
                            <br />
                            <p class="w3-opacity">Em que dia?</p>
                            <asp:DropDownList ID="selecaoDia" runat="server" OnSelectedIndexChanged="atualizarHoras" AutoPostBack="True">
                            </asp:DropDownList>

                            <br />
                            <p class="w3-opacity">Qual sessão?</p>
                            <asp:DropDownList ID="SelecaoSessao" OnSelectedIndexChanged="desenharCadeiras" AutoPostBack="True" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="w3-container w3-light-green w3-cell" style="width: 40%; height: 100px">
                    <asp:Panel runat="server" class="w3-container w3-cell" ID="imagens" Style="padding-top: 30px;">
                    </asp:Panel>
                </div>
            </div>
        </div>

        <div class="w3-cell-row ">
            <div class="w3-container w3-card-4 w3-light-grey">
                <br />
                <h3>Pagamento</h3>
                <asp:Label runat="server" class="w3-text">Nome: </asp:Label>
                <asp:TextBox ID="Nome" runat="server" class="w3-input w3-border w3-round" type="text"></asp:TextBox>

                <asp:Label runat="server" class="w3-number">Número de telefone: </asp:Label>
                <asp:TextBox ID="nTelefone" runat="server" class="w3-input w3-border w3-round" type="number"></asp:TextBox>

                <asp:Label runat="server" class="w3-text">E-mail: </asp:Label>
                <asp:TextBox ID="Mail" runat="server" class="w3-input w3-border w3-round" type="email"></asp:TextBox>
                <br />
                <asp:Button runat="server" class="w3-btn w3-blue-grey" Text="Gerar referência multibanco" OnClick="MandarMail_Click" />
                <br />
                <br />
                <asp:Literal ID="PopupBox" runat="server"></asp:Literal>
            </div>
        </div>
    </section>
</asp:Content>
