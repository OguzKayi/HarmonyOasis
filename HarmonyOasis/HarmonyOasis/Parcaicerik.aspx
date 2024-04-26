<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Parcaicerik.aspx.cs" Inherits="HarmonyOasis.Parcaicerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="parcaicerik">
        <div class="parcaBaslik">
            <h3>
                <asp:Literal runat="server" ID="ltrl_baslik"></asp:Literal></h3>
        </div>
        <div class="bilgi">
            <label>
                <asp:Literal runat="server" ID="ltrl_muzisyen"></asp:Literal></label>
            <br />
            <label>
                <asp:Literal runat="server" ID="ltrl_kategori"></asp:Literal></label>
        </div>
        <div class="nota">
            <asp:Literal ID="ltrl_content" runat="server"></asp:Literal>
        </div>
    </div>
    <asp:Panel CssClass="yorumPaneli" ID="yorumVarpanel" runat="server">
        <div class="yorum">
            <div class="yorumtitle">
                <h4>Yorum Paneli</h4>
            </div>
            <div class="yorumBilgi">
                <small>Üye:
                    <asp:Literal runat="server" ID="ltrl_UyeIsim"></asp:Literal>
                    |</small>
                <small>Müzisyen:
                    <asp:Literal runat="server" ID="ltrl_MuzIsim"></asp:Literal>
                    |</small>
                <small>Kategori:
                    <asp:Literal runat="server" ID="ltrl_KatIsim"></asp:Literal>
                    |</small>
                <small>Parça:
                    <asp:Literal runat="server" ID="ltrl_ParIsim"></asp:Literal></small>
            </div>
            <asp:Panel Visible="false" ID="failed_pnl" CssClass="pnl_fail" runat="server">
                <asp:Label ID="lbl_fail" runat="server"></asp:Label>
            </asp:Panel>
            <div class="yorumIcerik">
                <asp:TextBox TextMode="MultiLine" PlaceHolder="Yorum(500)..." runat="server" ID="tb_yorum" CssClass="yorum_tb"></asp:TextBox>
            </div>
            <div class="yorumEkle">
                <asp:Button ID="btn_yorum" OnClick="btn_yorum_Click" runat="server" CssClass="yorum_btn" Text="Yorum Yap" />
            </div>
        </div>
        <asp:Repeater ID="rp_Parcayorum" runat="server">
            <ItemTemplate>
                <div class="yorumListe">
                    <div class="yorumlisteBilgi">
                        <label>ID: <%# Eval("ID") %> |</label>
                        <label>Üye: <%# Eval("Uye") %> |</label>
                        <label>Müzisyen: <%# Eval("Muzisyen") %> |</label>
                        <label>Kategori: <%# Eval("Kategori") %> |</label>
                        <label>Parça: <%# Eval("Parca") %> |</label>
                        <label>Tarih: <%# Eval("Tarih") %></label>
                    </div>
                    <div class="yorumlisteIcerik">
                        <label><%# Eval("Icerik") %></label>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    <asp:Panel CssClass="yorumPaneli" ID="yorumYokpanel" runat="server">
        <div class="yorumtitle">
            <h4>Yorum Paneli</h4>
        </div>
        <label>
            Yorum Panelini Görebilmek İçin Lütfen <a href="KullaniciGiris.aspx">Giriş Yapın.</a>
        </label>
    </asp:Panel>
</asp:Content>
