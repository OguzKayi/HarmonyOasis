<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="YorumListeKontrolYapildi.aspx.cs" Inherits="HarmonyOasis.AdminPanel.YorumListeKontrolYapildi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Yorum Liste Kontrol Yapıldı</h3>
        </div>
        <div class="kontrol">
            <div class="kontrol1">
                <a href="YorumListeKontrolYapildi.aspx">
                    <h3>Kontrol Yapıldı</h3>
                </a>
            </div>
            <div class="kontrol2">
                <a href="YorumListeKontrolYapilmadi.aspx">
                    <h3>Kontrol Yapılmadı</h3>
                </a>
            </div>
        </div>
        <div style="clear: both"></div>
        <asp:Panel ID="failed_pnl" CssClass="pnl_fail" runat="server" Visible="false">
            <asp:Label ID="lbl_fail" runat="server"></asp:Label>
        </asp:Panel>
        <div class="formContent">
            <asp:ListView ID="lv_kontrolyapildiYorumlar" OnItemCommand="lv_kontrolyapildiYorumlar_ItemCommand" runat="server">
                <LayoutTemplate>
                    <table cellspacing="0" cellpadding="0" class="tablo">
                        <tr>
                            <th>ID</th>
                            <th>Üye</th>
                            <th>Parça</th>
                            <th>Tarih</th>
                            <th>Durum</th>
                            <th>Kontrol</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Uye") %></td>
                        <td><%# Eval("Parca") %></td>
                        <td><%# Eval("Tarih") %></td>
                        <td><%# Eval("Durum") %></td>
                        <td><%# Eval("Kontrol") %></td>
                        <td>
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
