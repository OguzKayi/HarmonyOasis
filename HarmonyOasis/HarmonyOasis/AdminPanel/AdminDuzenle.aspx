<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDuzenle.aspx.cs" Inherits="HarmonyOasis.AdminPanel.AdminDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
    <div class="formTitle">
        <h3>Admin Ekle
        </h3>
    </div>
    <div class="formContent">
        <asp:Panel ID="failed_pnl" CssClass="pnl_fail" runat="server" Visible="false">
            <asp:Label ID="lbl_fail" runat="server"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="successful_pnl" CssClass="pnl_success" runat="server" Visible="false">
            <asp:Label ID="lbl_success" runat="server">Admin Düzenleme Başarılı</asp:Label>
        </asp:Panel>
        <div class="left">
            <div class="row">
                <label class="formtag">Kullanıcı Adı</label>
                <asp:TextBox ID="tb_kullanici" CssClass="form_tb" runat="server" PlaceHolder="Kullanıcı Adı..."></asp:TextBox>
            </div>
            <div class="row">
                <label class="formtag">İsim</label>
                <asp:TextBox ID="tb_isim" CssClass="form_tb" runat="server" PlaceHolder="Admin Adı..."></asp:TextBox>
            </div>
            <div class="row">
                <label class="formtag">Soy İsim</label>
                <asp:TextBox ID="tb_soyisim" CssClass="form_tb" runat="server" PlaceHolder="Admin Soy Adı..."></asp:TextBox>
            </div>
            <div class="row">
                <label class="formtag">Aktiflik Durumu</label>
                <asp:CheckBox ID="cb_yayin" Style="color: white" Text="Aktifleştir" runat="server" />
                <small style="color: #b2b0b0">(Eğer İşaretliyse Aktif)</small>
            </div>
            <div class="row">
                <asp:Button ID="btn_adminDuzenle" class="formbutton" Text="Admin Düzenle" OnClick="btn_adminDuzenle_Click" runat="server" />
            </div>
        </div>
        <div class="right">
            <div class="row">
                <label class="formtag">Email</label>
                <asp:TextBox ID="tb_email" CssClass="form_tb" runat="server" PlaceHolder="Email..."></asp:TextBox>
            </div>
            <div class="row">
                <label class="formtag">İsim</label>
                <asp:TextBox ID="tb_sifre" CssClass="form_tb" runat="server" PlaceHolder="Şifre..."></asp:TextBox>
            </div>
            <div class="row">
                <label class="formtag">Admin Türü</label>
                <asp:DropDownList ID="ddl_tur" runat="server" CssClass="form_ddl" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
            </div>
        </div>
        <div style="clear: both"></div>
    </div>
</div>
</asp:Content>
