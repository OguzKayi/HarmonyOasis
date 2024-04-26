<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="HarmonyOasis.AdminPanel.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Harmony Oasis Admin Panel Giriş,</title>
    <link href="assets/css/Giris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="title">
                <h3>Admin Panel</h3>
            </div>
            <div class="sus"></div>
            <asp:Panel ID="failed_pnl" runat="server" CssClass="pnl_fail" Visible="false">
                <asp:Label ID="lbl_fail" runat="server"></asp:Label>
            </asp:Panel>
            <div class="content">
                <div class="row">
                    <label class="tag">Kullanıcı Adı</label>
                    <asp:TextBox ID="tb_kullaniciadi" placeholder="Kullanıcı Adı..." runat="server" Text="O.K." CssClass="textbox"></asp:TextBox>
                </div>
                <div class="row">
                    <label class="tag">Email</label>
                    <asp:TextBox ID="tb_email" placeholder="Email..." runat="server" Text="o.k.@gmail.com" CssClass="textbox"></asp:TextBox>
                </div>
                <div class="row">
                    <label class="tag">Şifre</label>
                    <asp:TextBox ID="tb_sifre" type="password" placeholder="Şifre..." runat="server" CssClass="textbox"></asp:TextBox>
                </div>
                <div class="sus"></div>
                <div class="row">
                    <asp:Button ID="btn_sign" Text="Giriş Yap" OnClick="btn_sign_Click" CssClass="signButton" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
