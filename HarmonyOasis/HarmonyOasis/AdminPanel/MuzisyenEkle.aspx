<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MuzisyenEkle.aspx.cs" Inherits="HarmonyOasis.AdminPanel.MuzisyenEkle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Müzisyen Ekle
            </h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="failed_pnl" CssClass="pnl_fail" runat="server" Visible="false">
                <asp:Label ID="lbl_fail" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="successful_pnl" CssClass="pnl_success" runat="server" Visible="false">
                <asp:Label ID="lbl_success" runat="server">Müzisyen Ekleme Başarılı</asp:Label>
            </asp:Panel>
            <div class="left">
                <div class="row">
                    <label class="formtag">Müzisyen Ismi</label>
                    <asp:TextBox ID="tb_isim" CssClass="form_tb" runat="server" PlaceHolder="Müzisyen Adı..."></asp:TextBox>
                </div>
                <div class="row">
                    <label class="formtag">Özet</label>
                    <asp:TextBox ID="tb_ozet" CssClass="form_tb" runat="server" TextMode="MultiLine" PlaceHolder="Özet..."></asp:TextBox>
                </div>
                <div class="row">
                    <label class="formtag">Müzisyen Resim</label>
                    <asp:FileUpload ID="fu_resim" runat="server" CssClass="form_tb" />
                </div>
                <div class="row">
                    <label class="formtag">Yayın Durumu</label>
                    <asp:CheckBox ID="cb_yayin" Style="color: white" Text=" Yayınla" runat="server" />
                    <small style="color: #b2b0b0">(Eğer İşaretliyse Yayınlanır)</small>
                </div>
                <div class="row">
                    <asp:Button ID="btn_muzisyenEkle" class="formbutton" Text="Müzisyen Ekle" OnClick="btn_muzisyenEkle_Click" runat="server" />
                </div>
            </div>
            <div class="right">
                <div class="row">
                    <label class="formtag">Biyografi</label>
                    <asp:TextBox ID="tb_content" CssClass="form_tb" runat="server" TextMode="MultiLine" PlaceHolder="Biyografi..."></asp:TextBox>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
