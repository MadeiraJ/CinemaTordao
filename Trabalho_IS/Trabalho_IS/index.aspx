<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="index.aspx.cs" Inherits="Trabalho_IS.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <section id="w3-content" style="max-width: 980px; margin: auto;">
        <div class="w3-panel">
            <asp:Image ID="logo" runat="server" src="../images/logo.png" />
        </div>
        <div class="w3-container">
            <div class="w3-display-container mySlides" style="display: block;">
                <asp:Image ID="destaque1" runat="server" Style="width: 100%" />
                <div class="w3-display-topleft w3-container w3-padding-32">
                    <asp:Label ID="nDestaque1" class="w3-white w3-padding-large w3-animate-bottom" runat="server"></asp:Label>                    
                </div>
            </div>
            <div class="w3-display-container mySlides" style="display: none;">
                <asp:Image ID="destaque2" runat="server" Style="width: 100%" />
                <div class="w3-display-topleft w3-container w3-padding-32">
                    <asp:Label ID="nDestaque2" class="w3-white w3-padding-large w3-animate-bottom" runat="server"></asp:Label>   
                </div>
            </div>
            <div class="w3-display-container mySlides" style="display: none;">
                <asp:Image ID="destaque3" runat="server" Style="width: 100%" />
                <div class="w3-display-topleft w3-container w3-padding-32">
                    <asp:Label ID="nDestaque3" class="w3-white w3-padding-large w3-animate-bottom" runat="server"></asp:Label>                      
                </div>
            </div>

            <div class="w3-display-container mySlides" style="display: none;">
                <asp:Image ID="destaque4" runat="server" Style="width: 100%" />
                <div class="w3-display-topleft w3-container w3-padding-32">
                    <asp:Label ID="nDestaque4" class="w3-white w3-padding-large w3-animate-bottom" runat="server"></asp:Label>
                </div>
            </div>

            <div class="w3-display-container mySlides" style="display: none;">
                <asp:Image ID="destaque5" runat="server" Style="width: 100%" />
                <div class="w3-display-topleft w3-container w3-padding-32">
                    <asp:Label ID="nDestaque5" class="w3-white w3-padding-large w3-animate-bottom" runat="server"></asp:Label>
                </div>
            </div>
            <div class="w3-container w3-dark-grey w3-padding w3-xlarge">
                <div class="w3-left" onclick="plusDivs(-1)"><i class="fa fa-arrow-circle-left w3-hover-text-teal"></i></div>
                <div class="w3-right" onclick="plusDivs(1)"><i class="fa fa-arrow-circle-right w3-hover-text-teal"></i></div>
                <div class="w3-center">
                    <span class="w3-tag demodots w3-border w3-transparent w3-hover-white w3-white" onclick="currentDiv(1)"></span>
                    <span class="w3-tag demodots w3-border w3-transparent w3-hover-white" onclick="currentDiv(2)"></span>
                    <span class="w3-tag demodots w3-border w3-transparent w3-hover-white" onclick="currentDiv(3)"></span>
                    <span class="w3-tag demodots w3-border w3-transparent w3-hover-white" onclick="currentDiv(4)"></span>
                    <span class="w3-tag demodots w3-border w3-transparent w3-hover-white" onclick="currentDiv(5)"></span>
                </div>
            </div>
        </div>

        <!-- Grid -->
        <div class="w3-row-padding" id="mais_vistos">
            <div class="w3-center w3-padding-64">
                <span class="w3-xlarge w3-bottombar w3-border-dark-grey w3-padding-16">Filmes Mais Vistos</span>
            </div>
            <div class="w3-third w3-margin-bottom" style="height:800px;">
                <div class="w3-card-4" style="height:800px;">
                    <asp:Image ID="maisVisto1" runat="server" class="images" Style="width: 100%" />
                    <div class="w3-container" style="height:800px;">                      
                        <h3><asp:Literal ID="nVisto1" runat="server" /></h3>
                        <p class="w3-opacity"><asp:Literal ID="genero1" runat="server" /></p>
                        <p><asp:Literal ID="descricao1" runat="server" /></p>
                        <p><asp:Button class="w3-button w3-light-grey w3-block" Text="Reservar" runat="server" OnClick="Unnamed_Click" /></p>
                    </div>
                </div>
            </div>
            <div class="w3-third w3-margin-bottom" style="height:800px;">
                <div class="w3-card-4" style="height:800px;">
                    <asp:Image ID="maisVisto2" runat="server" class="images" Style="width: 100%" />
                    <div class="w3-container" style="height:800px;">
                        <h3> <asp:Literal ID="nVisto2" runat="server" /></h3>
                        <p class="w3-opacity"><asp:Literal ID="genero2" runat="server" /></p>
                        <p><asp:Literal ID="descricao2" runat="server" /></p>
                        <p><asp:Button class="w3-button w3-light-grey w3-block" Text="Reservar" runat="server" OnClick="Unnamed_Click" /></p>
                    </div>
                </div>
            </div>

            <div class="w3-third w3-margin-bottom" style="height:800px;">
                <div class="w3-card-4" style="height:800px;">
                    <asp:Image ID="maisVisto3" runat="server" class="images" Style="width: 100%" />
                    <div class="w3-container">
                        <h3> <asp:Literal ID="nVisto3" runat="server" /></h3>
                        <p class="w3-opacity"><asp:Literal ID="genero3" runat="server" /></p>
                        <p><asp:Literal ID="descricao3" runat="server" /></p>
                        <p><asp:Button class="w3-button w3-light-grey w3-block" Text="Reservar" runat="server" OnClick="Unnamed_Click"/></p>
                    </div>
                </div>
            </div>
            <div class="w3-third w3-margin-bottom" style="height:800px;">
                <div class="w3-card-4" style="height:800px;">
                    <asp:Image ID="maisVisto4" runat="server" class="images" Style="width: 100%" />
                    <div class="w3-container" style="height:800px;">
                        <h3> <asp:Literal ID="nVisto4" runat="server" /></h3>
                        <p class="w3-opacity"><asp:Literal ID="genero4" runat="server" /></p>
                        <p><asp:Literal ID="descricao4" runat="server" /></p>
                        <p><asp:Button class="w3-button w3-light-grey w3-block" Text="Reservar" runat="server" OnClick="Unnamed_Click" /></p>
                    </div>
                </div>
            </div>

            <div class="w3-third w3-margin-bottom" style="height:800px;">
                <div class="w3-card-4" style="height:800px;">
                    <asp:Image ID="maisVisto5" runat="server" class="images" Style="width: 100%" />
                    <div class="w3-container">
                        <h3> <asp:Literal ID="nVisto5" runat="server" /></h3>
                        <p class="w3-opacity"><asp:Literal ID="genero5" runat="server" /></p>
                        <p><asp:Literal ID="descricao5" runat="server" /></p>
                        <p><asp:Button class="w3-button w3-light-grey w3-block" Text="Reservar" runat="server" OnClick="Unnamed_Click" /></p>
                    </div>
                </div>
            </div>

            <div class="w3-third w3-margin-bottom" style="height:800px;">
                <div class="w3-card-4" style="height:800px;">
                    <asp:Image ID="maisVisto6" runat="server" class="images" Style="width: 100%" />
                    <div class="w3-container" style="height:800px;">
                        <h3> <asp:Literal ID="nVisto6" runat="server" /></h3>
                        <p class="w3-opacity"><asp:Literal ID="genero6" runat="server" /></p>
                        <p><asp:Literal ID="descricao6" runat="server" /></p>
                        <p><asp:Button class="w3-button w3-light-grey w3-block" Text="Reservar" runat="server" OnClick="Unnamed_Click" /></p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>