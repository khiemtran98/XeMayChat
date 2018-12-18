<%@ Page Title="" Language="C#" MasterPageFile="~/AdminCP/AdminCP.Master" AutoEventWireup="true" CodeBehind="QLLoaiSanPham.aspx.cs" Inherits="GUI.AdminCP.QLLoaiSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>AdminCP - Quản lí loại sản phẩm</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Quản lí hãng sản xuất</h2>
    <hr />
    <div class="form-group">
        <label for="txtMaLoaiSP">Mã hãng sản xuất:</label>
        <asp:TextBox ID="txtMaLoaiSP" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMaLoaiSP" runat="server" ControlToValidate="txtMaLoaiSP" ErrorMessage="Vui lòng nhập mã loại sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtTenLoaiSP">Tên hãng sản xuất:</label>
        <asp:TextBox ID="txtTenLoaiSP" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTenLoaiSP" runat="server" ControlToValidate="txtTenLoaiSP" ErrorMessage="Vui lòng nhập tên loại sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="chkTrangThai">Kích hoạt</label>
        <asp:CheckBox ID="chkTrangThai" CssClass="form-check-inline" runat="server" />
    </div>
    <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnThem_Click" />
    <asp:Button ID="btnSua" runat="server" Text="Sửa" CssClass="btn btn-secondary" OnClick="btnSua_Click" />
    <asp:Button ID="btnHuy" runat="server" Text="Huỷ" CausesValidation="false" CssClass="btn btn-danger" OnClick="btnHuy_Click" />
    <asp:Label ID="lblThemThanhCong" runat="server" Text="Thêm loại sản phẩm thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblThemThatBai" runat="server" Text="Mã loại sản phẩm đã tồn tại" CssClass="text-danger" Visible="false"></asp:Label>
    <asp:Label ID="lblXoaThanhCong" runat="server" Text="Xoá loại sản phẩm thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblSuaThanhCong" runat="server" Text="Sửa loại sản phẩm thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblSuaThatBai" runat="server" Text="Mã loại sản phẩm không tồn tại" CssClass="text-danger" Visible="false"></asp:Label>
    <hr />
    <asp:GridView ID="grvLoaiSanPham" runat="server" AutoGenerateColumns="False" OnRowCommand="grvLoaiSanPham_RowCommand" Width="1065px" CssClass="table-bordered table-hover" CellPadding="5" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grvLoaiSanPham_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="MaLoaiSP" HeaderText="Mã hãng sản xuất">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TenLoaiSP" HeaderText="Tên hãng sản xuất">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="TrangThai" HeaderText="Kích hoạt" ReadOnly="True">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <center>
                        <asp:Button ID="btnChon" runat="server" CausesValidation="False" CssClass="btn btn-secondary" CommandName="Chon" CommandArgument='<%# Eval("MaLoaiSP") %>' Text="Chọn" />
                        <asp:Button ID="btnXoa" runat="server" CausesValidation="False" CssClass="btn btn-danger" CommandName="Xoa" CommandArgument='<%# Eval("MaLoaiSP") %>' Text="Xoá" OnClientClick="return confirm('Bạn có muốn xoá loại sản phẩm này không?');" />
                    </center>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>

</asp:Content>
