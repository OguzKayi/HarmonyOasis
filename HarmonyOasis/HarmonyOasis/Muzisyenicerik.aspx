<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Muzisyenicerik.aspx.cs" Inherits="HarmonyOasis.Muzisyenicerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_container">
        <asp:Repeater ID="rp_muzisyen" runat="server">
            <ItemTemplate>
                <div class="muzisyen">
                    <div class="resim">
                        <img src="/Resimler/MuzisyenResimleri/<%# Eval("Resim") %>" />
                    </div>
                    <div class="baslik">
                        <label><%# Eval("Isim") %></label>
                    </div>
                    <div class="ozet">
                        <label><%# Eval("Ozet") %></label>
                    </div>
                    <div class="devami">
                        <%--Bu QueryString'i Almanın Eval'den Başka Yolu Yok Mu Ya--%>
                        <a href='MuzisyenBiyografi.aspx?muzisyenID=<%# Eval("ID") %>'>Devamı Burada!</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rp_parcalar" runat="server">
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
    </div>
</asp:Content>
