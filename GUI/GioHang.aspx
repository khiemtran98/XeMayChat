<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="GUI.GioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Giỏ hàng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <asp:GridView ID="grvGioHang" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" OnRowCommand="grvGioHang_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Ảnh sản phẩm">
                <ItemTemplate>
                    <asp:Image ID="imgAnhMinhHoa" runat="server" ImageUrl='<%# "img/AnhMinhHoa/" + Eval("AnhMinhHoa") %>' Width="75px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="MaSP" HeaderText="Mã SP" />
            <asp:BoundField DataField="TenSP" HeaderText="Tên SP" />
            <asp:TemplateField HeaderText="Giá tiền">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("GiaTien") + " VND" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnXoa" runat="server" CssClass="btn btn-danger" CausesValidation="False" CommandName="XoaSP" CommandArgument='<%# Eval("MaSP") %>' Text="Xóa" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa SP này?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <span class="font-weight-bold">Tổng cộng: </span>
    <asp:Label ID="lblTongTien" runat="server" CssClass="font-weight-normal"></asp:Label>
    <asp:Button ID="btnThanhToan" runat="server" CssClass="btn btn-primary" Text="Thanh toán" OnClick="btnThanhToan_Click" />
</asp:Content>
