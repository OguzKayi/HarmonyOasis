<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HarmonyOasis.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="secenek">
        <a href="Kategoriler.aspx">Kategoriler</a>
        <a href="Muzisyenler.aspx">Müzisyenler</a>
    </div>
    <asp:Repeater ID="rp_parca" runat="server">
        <ItemTemplate>
            <div class="parca">
                <div class="isim">
                    <a href="Parcaicerik.aspx?parcaID=<%# Eval("ID") %>">
                        <h4><%# Eval("Isim") %></h4>
                    </a>
                </div>
                <div class="tarih">
                    <label><%# Eval("TarihStr") %></label>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
