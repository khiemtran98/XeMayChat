<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GUI.index" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Xe Máy Chất</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <asp:DataList ID="dtlDSSanPham" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="dtlDSSanPham_ItemCommand">
        <ItemTemplate>
            <div class="card" style="width: 200px">
                <asp:HyperLink ID="hplAnhMinhHoa" runat="server" NavigateUrl='<%# "ChiTietSP.aspx?MaSP=" + Eval("MaSP") %>'>
                    <asp:Image ID="imgAnhMinhHoa" runat="server" CssClass="card-img-top" ImageUrl='<%# "img/AnhMinhHoa/" + Eval("AnhMinhHoa") %>' />
                </asp:HyperLink>
                <div class="card-body">
                    <asp:HyperLink ID="hplTenSP" runat="server" NavigateUrl='<%# "ChiTietSP.aspx?MaSP=" + Eval("MaSP") %>'>
                        <asp:Label ID="lblTenSanPham" runat="server" CssClass="h4 card-title" Text='<%# Eval("TenSP") %>'></asp:Label>
                    </asp:HyperLink><br />
                    <asp:Label ID="lblGiaTien" runat="server" CssClass="card-text" Text='<%# Eval("GiaTien") + " VND" %>'></asp:Label>
                    <asp:Button ID="btnThemVaoGH" runat="server" CssClass="btn btn-primary" Text="Thêm vào giỏ hàng" CommandName="ThemGH" CommandArgument='<%# Eval("MaSP") %>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:Label ID="lblThongBao" runat="server" Text="Không tìm thấy sản phẩm nào." CssClass="text-body" Visible="false"></asp:Label>
    <center>
        <cc1:CollectionPager ID="cprDSTrang" runat="server" BackNextLocation="Split" BackText="" FirstText="Trang đầu" HideOnSinglePage="True" LastText="Trang cuối" MaxPages="10" NextText="" PageSize="12" QueryStringKey="Trang" ResultsFormat="Kết quả hiển thị {0}-{1} (trên {2})" ResultsLocation="Top" SectionPadding="50" ShowFirstLast="False" ShowLabel="False" UseSlider="True"></cc1:CollectionPager>
    </center>
</asp:Content>
