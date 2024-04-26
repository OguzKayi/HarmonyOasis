<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MuzisyenBiyografi.aspx.cs" Inherits="HarmonyOasis.MuzisyenBiyografi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="muzisyen">
        <div class="resim">
            <asp:Image runat="server" ID="resim" />
        </div>
        <div class="baslik">
            <label>
                <asp:Literal runat="server" ID="ltrl_isim"></asp:Literal>
            </label>
        </div>
        <div class="ozet">
            <asp:Literal runat="server" ID="ltrl_ozet"></asp:Literal>
        </div>
        <div class="biyografi">
            <asp:Literal runat="server" ID="ltrl_biyografi"></asp:Literal>
        </div>
    </div>
</asp:Content>
