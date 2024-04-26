<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ParcaEkle.aspx.cs" Inherits="HarmonyOasis.AdminPanel.ParcaEkle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Parça Ekle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="failed_pnl" CssClass="pnl_fail" runat="server" Visible="false">
                <asp:Label ID="lbl_fail" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="successful_pnl" CssClass="pnl_success" runat="server" Visible="false">
                <asp:Label ID="lbl_success" runat="server">Parça Ekleme Başarılı</asp:Label>
            </asp:Panel>
            <div class="left">
                <div class="row">
                    <label class="formtag">Parça İsmi</label>
                    <asp:TextBox ID="tb_isim" CssClass="form_tb" runat="server" PlaceHolder="Parça Adı..."></asp:TextBox>
                </div>
                <div class="row">
                    <label class="formtag"></label>
                    <asp:DropDownList ID="ddl_kategori" CssClass="form_ddl" runat="server" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label class="formtag"></label>
                    <asp:DropDownList ID="ddl_muzisyen" CssClass="form_ddl" runat="server" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label class="formtag">Parça Tarihi</label>
                    <asp:TextBox ID="tb_tarih" CssClass="form_tb" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="row">
                    <label class="formtag">Yayın Durumu</label>
                    <asp:CheckBox ID="cb_yayin" Style="color: white" Text=" Yayınla" runat="server" />
                    <small style="color: #b2b0b0">(Eğer İşaretliyse Yayınlanır)</small>
                </div>
                <div class="row">
                    <asp:Button ID="btn_ParcaEkle" class="formbutton" Text="Parça Ekle" OnClick="btn_ParcaEkle_Click" runat="server" />
                </div>
            </div>
            <div class="right">
                <div class="row">
                    <label class="formtag">Nota</label>
                    <asp:TextBox ID="tb_content" CssClass="form_tb" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
