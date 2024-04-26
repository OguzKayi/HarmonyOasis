<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="HarmonyOasis.Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profilbilgi">
        <asp:Panel Visible="false" runat="server" ID="failed_pnl" CssClass="pnl_fail">
            <asp:Label ID="lbl_fail" runat="server"></asp:Label>
        </asp:Panel>
        <asp:Panel Visible="false" runat="server" ID="successed_pnl" CssClass="pnl_success">
            <asp:Label ID="lbl_success" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <label class="formtag">Kullanıcı Adı</label><br />
            <asp:TextBox ID="tb_kullanici" CssClass="tb" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <label class="formtag">Email</label><br />
            <asp:TextBox ID="tb_email" CssClass="tb" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <label class="formtag">Şifre</label><br />
            <asp:TextBox ID="tb_sifre" CssClass="tb" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <label class="formtag">Kayıt Tarihi</label><br />
            <asp:Label ID="kyt_tarih" Style="color: white;" runat="server"></asp:Label>
        </div>
        <div class="row">
            <asp:Button runat="server" OnClick="btn_uye_Click" ID="btn_uye" CssClass="uye_btn" Text="Düzenle" />
        </div>
    </div>
    <div class="profilyorum">
        <asp:Panel Visible="false" runat="server" ID="failedYorum_pnl" CssClass="pnl_fail">
            <asp:Label ID="lblYorum_fail" runat="server"></asp:Label>
        </asp:Panel>
        <asp:Repeater ID="rp_profilYorum" OnItemCommand="profilYorum_ItemCommand" runat="server">
            <ItemTemplate>
                <div />
                <div class="profilYorumBilgi">
                    <label>ID: <%# Eval("ID") %> |</label>
                    <label>Üye: <%# Eval("Uye") %> |</label>
                    <label>Müzisyen: <%# Eval("Muzisyen") %> |</label>
                    <label>Kategori: <%# Eval("Kategori") %> |</label>
                    <label>Parça: <%# Eval("Parca") %> |</label>
                    <label>Tarih: <%# Eval("Tarih") %></label>
                </div>
                <div class="profilYorumIcerik">
                    <label><%# Eval("Icerik") %></label>
                </div>
                <div class="yorumSecenek">
                    <asp:LinkButton ID="lbtn_sil" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                </div>
                <div style="clear: both"></div>
                </div/>
            </ItemTemplate>
        </asp:Repeater>
        <div style="clear: both"></div>
    </div>
</asp:Content>
