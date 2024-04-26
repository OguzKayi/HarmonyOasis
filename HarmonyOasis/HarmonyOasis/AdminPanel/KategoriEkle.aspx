<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="HarmonyOasis.AdminPanel.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Kategori Ekle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="failed_pnl" CssClass="pnl_fail" runat="server" Visible="false">
                <asp:Label ID="lbl_fail" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="successful_pnl" CssClass="pnl_success" runat="server" Visible="false">
                <asp:Label ID="lbl_success" runat="server">Kategori Ekleme Başarılı</asp:Label>
            </asp:Panel>
            <div class="row">
                <label class="formtag">Kategori İsmi</label>
                <asp:TextBox ID="tb_isim" CssClass="form_tb" runat="server" PlaceHolder="Kategori Adı..."></asp:TextBox>
            </div>
            <div class="row">
                <label class="formtag">Açıklama</label>
                <asp:TextBox ID="tb_aciklama" CssClass="form_tb" TextMode="Multiline" runat="server" PlaceHolder="Açıklama..."></asp:TextBox>
            </div>
            <div class="row">
                <label class="formtag">Yayın Durumu</label>
                <asp:CheckBox ID="cb_yayin" Style="color: white" Text=" Yayınla" runat="server" />
                <small style="color: #b2b0b0">(Eğer İşaretliyse Yayınlanır)</small>
            </div>
            <div class="row">
                <asp:Button ID="btnkategoriEkle" CssClass="formbutton" Text="Kategori Ekle" OnClick="btnkategoriEkle_Click" runat="server" />
            </div>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
