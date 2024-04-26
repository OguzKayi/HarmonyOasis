<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="HarmonyOasis.AdminPanel.UyeListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Üye Liste</h3>
        </div>
        <asp:Panel ID="failed_pnl" CssClass="pnl_fail" runat="server" Visible="false">
            <asp:Label ID="lbl_fail" runat="server"></asp:Label>
        </asp:Panel>
        <div class="formContent">
            <asp:ListView ID="lv_uyeler" OnItemCommand="lv_uyeler_ItemCommand" runat="server">
                <LayoutTemplate>
                    <table cellspacing="0" cellpadding="0" class="tablo">
                        <tr>
                            <th>ID</th>
                            <th>İsim</th>
                            <th>Kayıt</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Kullaniciadi") %></td>
                        <td><%# Eval("Kayit") %></td>
                        <td><%# Eval("Durum") %></td>
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
