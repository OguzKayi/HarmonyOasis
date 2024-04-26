<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciGiris.aspx.cs" Inherits="HarmonyOasis.KullaniciGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Harmony Oasis Üye Girişi</title>
    <link href="assets/css/KullaniciGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="title">
                <h2>Harmony Oasis</h2>
                <h3>Üye Paneli</h3>
            </div>
            <asp:Panel Visible="false" ID="failed_pnl" runat="server" CssClass="pnl_fail">
                <asp:Label ID="lbl_fail" CssClass="fail" runat="server"></asp:Label>
            </asp:Panel>
            <div class="buclassaisimbulamadım">
                <a class="a1" style="border-color: yellow" href="KullaniciGiris.aspx">Giriş Yap</a>
                <a class="a2" href="KullaniciKayit.aspx">Kayıt Ol</a>
            </div>
            <div style="clear: both"></div>
            <div class="content">
                <div class="row">
                    <label>Kullanıcı Adı</label>
                    <asp:TextBox ID="tb_kullanici" runat="server" CssClass="tb" PlaceHolder="Kullanıcı Adı..."></asp:TextBox>
                </div>
                <div class="row">
                    <label>Email</label>
                    <asp:TextBox ID="tb_email" runat="server" CssClass="tb" PlaceHolder="Email..."></asp:TextBox>
                </div>
                <div class="row">
                    <label>Şifre</label>
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="tb" PlaceHolder="Şifre..."></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Button ID="btn_kayit" runat="server" OnClick="btn_kayit_Click" Text="Giriş Yap" CssClass="btn" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
