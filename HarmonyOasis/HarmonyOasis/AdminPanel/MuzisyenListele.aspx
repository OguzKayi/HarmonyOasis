<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MuzisyenListele.aspx.cs" Inherits="HarmonyOasis.AdminPanel.MuzisyenListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Müzisyen Liste</h3>
        </div>
        <div class="addbutton">
            <a href="MuzisyenEkle.aspx">
                <h3>Müzisyen Ekle</h3>
            </a>
        </div>
        <asp:Panel ID="failed_pnl" CssClass="pnl_fail" runat="server" Visible="false">
            <asp:Label ID="lbl_fail" runat="server"></asp:Label>
        </asp:Panel>
        <div class="formContent">
            <asp:ListView ID="lv_Muzisyenler" OnItemCommand="lv_Muzisyenler_ItemCommand" runat="server">
                <LayoutTemplate>
                    <table cellspacing="0" cellpadding="0" class="tablo">
                        <tr>
                            <th>ID</th>
                            <th>İsim</th>
                            <th>Özet</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("Ozet") %></td>
                        <td><%# Eval("Durum") %></td>
                        <td>
                            <a class="TableButtonDuzenle" href='MuzisyenDuzenle.aspx?muzisyenID=<%# Eval("ID") %>'>Düzenle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="TableButtonSil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_durum" runat="server" CssClass="TableButtonDurum" CommandArgument='<%# Eval("ID") %>' CommandName="durum">Durum</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
