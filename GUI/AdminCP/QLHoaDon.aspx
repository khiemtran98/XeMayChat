<%@ Page Title="" Language="C#" MasterPageFile="~/AdminCP/AdminCP.Master" AutoEventWireup="true" CodeBehind="QLHoaDon.aspx.cs" Inherits="GUI.AdminCP.QLHoaDon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>AdminCP - Quản lí hoá đơn</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Quản lí hoá đơn</h2>
    <hr />
    <div class="form-group">
        <label for="txtMaHD">Mã hoá đơn:</label>
        <asp:TextBox ID="txtMaHD" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMaHD" runat="server" ControlToValidate="txtMaHD" ErrorMessage="Vui lòng nhập mã hoá đơn" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtTenTaiKhoan">Tên tài khoản:</label>
        <asp:TextBox ID="txtTenTaiKhoan" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTenTaiKhoan" runat="server" ControlToValidate="txtTenTaiKhoan" ErrorMessage="Vui lòng nhập tên tài khoản" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtNgayMua">Ngày mua:</label>
        <asp:TextBox ID="txtNgayMua" runat="server" TextMode="DateTime" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNgayMua" runat="server" ControlToValidate="txtNgayMua" ErrorMessage="Vui lòng nhập ngày mua" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revNgayMua" runat="server" ControlToValidate="txtNgayMua" ValidationExpression="^(0?[1-9]|1[0-2])/(0?[1-9]|1[0-9]|2[0-9]|3[01])/\d{4}$" ErrorMessage="Ngày mua không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>

    </div>
    <div class="form-group">
        <label for="txtDiaChiGiaoHang">Địa chi giao hàng:</label>
        <asp:TextBox ID="txtDiaChiGiaoHang" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="revDiaChi" runat="server" ControlToValidate="txtDiaChiGiaoHang" ErrorMessage="Vui lòng nhập địa chỉ giao hàng" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtSDTGiaoHang">SĐT giao hàng:</label>
        <asp:TextBox ID="txtSDTGiaoHang" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSDT" runat="server" ControlToValidate="txtSDTGiaoHang" ErrorMessage="Vui lòng nhập SĐT giao hàng" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revSDT" runat="server" ControlToValidate="txtSDTGiaoHang" ValidationExpression="0+[19]\d{8,9}" ErrorMessage="SĐT không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>

    <hr />
    <div class="form-group">
        <h5>Chi tiết hoá đơn</h5>
        <asp:DataList ID="dtlCTSP" runat="server" DataKeyField="MaHD" RepeatDirection="Horizontal" OnItemCommand="dtlCTSP_ItemCommand">
            <ItemTemplate>
                <label for="txtMaSP">Mã sản phẩm:</label>
                <asp:TextBox ID="txtDTLCTHDMaSP" runat="server" Enabled="false" Text='<%# Eval("MaSP") %>' MaxLength="10" CssClass="form-control"></asp:TextBox>
                <label for="txtSoLuong">Số lượng:</label>
                <asp:TextBox ID="txtDTLCTHDSoLuong" runat="server" TextMode="Number" Enabled="false" Text='<%# Eval("SoLuong") %>' MaxLength="10" CssClass="form-control"></asp:TextBox>
                <label for="txtDonGia">Đơn giá:</label>
                <asp:TextBox ID="txtDTLCTHDDonGia" runat="server" TextMode="Number" Enabled="false" Text='<%# Eval("DonGia") %>' MaxLength="10" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnChonCTHD" runat="server" Text="Chọn" CausesValidation="False" CommandName="ChonCTHD" CommandArgument='<%# Eval("MaSP") %>' CssClass="btn btn-secondary" Width="100%" />
                <asp:Button ID="btnXoaCTHD" runat="server" Text="Xoá" CausesValidation="False" CommandName="XoaCTHD" CommandArgument='<%# Eval("MaSP") %>' CssClass="btn btn-danger" Width="100%" OnClientClick="return confirm('Bạn có muốn xoá chi tiết hoá đơn này không?');" />
            </ItemTemplate>
        </asp:DataList>
    </div>

    <div class="form-control" id="frmCTHD" runat="server">
        <div class="form-group">
            <label for="txtCTHDMaSP">Mã sản phẩm:</label>
            <asp:TextBox ID="txtCTHDMaSP" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMaSP" runat="server" ControlToValidate="txtCTHDMaSP" ErrorMessage="Vui lòng nhập mã sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="txtCTHDSoLuong">Số lượng:</label>
            <asp:TextBox ID="txtCTHDSoLuong" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSoLuong" runat="server" ControlToValidate="txtCTHDSoLuong" ErrorMessage="Vui lòng nhập số lượng sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="txtCTHDDonGia">Đơn giá:</label>
            <asp:TextBox ID="txtCTHDDonGia" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDonGia" runat="server" ControlToValidate="txtCTHDDonGia" ErrorMessage="Vui lòng nhập đơn giá" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnCTHDThem" runat="server" CssClass="btn btn-primary" Text="Thêm" OnClick="btnCTHDThem_Click" />
        <asp:Button ID="btnCTHDSua" runat="server" CssClass="btn btn-secondary" Text="Sửa" OnClick="btnCTHDSua_Click" />
        <asp:Button ID="btnCTHDHuy" runat="server" CausesValidation="False" CssClass="btn btn-danger" Text="Huỷ" OnClick="btnCTHDHuy_Click" />
        <asp:Label ID="lblThemCTHDThanhCong" runat="server" Text="Thêm chi tiết hoá đơn thành công" CssClass="text-primary" Visible="false"></asp:Label>
        <asp:Label ID="lblThemSuaCTHDThatBai" runat="server" Text="Mã sản phẩm không tồn tại hoặc bị trùng" CssClass="text-danger" Visible="false"></asp:Label>
        <asp:Label ID="lblSuaCTHDThanhCong" runat="server" Text="Sửa chi tiết hoá đơn thành công" CssClass="text-primary" Visible="false"></asp:Label>
        <asp:Label ID="lblXoaCTHDThanhCong" runat="server" Text="Xoá chi tiết hoá đơn thành công" CssClass="text-primary" Visible="false"></asp:Label>
    </div>

    <div class="form-group">
        <label for="txtTongTien">Tổng tiền:</label>
        <asp:TextBox ID="txtTongTien" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTongTien" runat="server" ControlToValidate="txtTongTien" ErrorMessage="Vui lòng nhập tổng tiền" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>

    <asp:Button ID="btnHDThem" runat="server" CssClass="btn btn-primary" Text="Thêm" OnClick="btnHDThem_Click" />
    <asp:Button ID="btnHDSua" runat="server" CssClass="btn btn-secondary" Text="Sửa" OnClick="btnHDSua_Click" />
    <asp:Button ID="btnHDHuy" runat="server" CausesValidation="False" CssClass="btn btn-danger" Text="Huỷ" OnClick="btnHDHuy_Click" />

    <asp:Label ID="lblThemHDThanhCong" runat="server" Text="Thêm hoá đơn thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblThemSuaHDThatBai" runat="server" Text="Mã hoá đơn đã tồn tại hoặc tên tài khoản không tồn tại" CssClass="text-danger" Visible="false"></asp:Label>
    <asp:Label ID="lblSuaHDThanhCong" runat="server" Text="Sửa hoá đơn thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblXoaHDThanhCong" runat="server" Text="Huỷ hoá đơn thành công" CssClass="text-primary" Visible="false"></asp:Label>

    <hr />
    <asp:GridView ID="grvHoaDon" runat="server" AutoGenerateColumns="False" OnRowCommand="grvHoaDon_RowCommand" Width="1065px" CssClass="table-bordered table-hover" CellPadding="5" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grvHoaDon_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="MaHD" HeaderText="Mã hoá đơn">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TenTaiKhoan" HeaderText="Tên tài khoản">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayMua" HeaderText="Ngày mua">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DiaChiGiaoHang" HeaderText="Địa chỉ giao hàng">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="SDTGiaoHang" HeaderText="SĐT giao hàng">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="TongTien" HeaderText="Tổng tiền" DataFormatString="{0:C0}">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="TrangThai" HeaderText="Xác nhận">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnChon" runat="server" CausesValidation="False" CssClass="btn btn-secondary" CommandName="ChonHD" CommandArgument='<%# Eval("MaHD") %>' Text="Chọn" />
                    <asp:Button ID="btnXoa" runat="server" CausesValidation="False" CssClass="btn btn-danger" CommandName="XoaHD" CommandArgument='<%# Eval("MaHD") %>' Text="Huỷ" OnClientClick="return confirm('Bạn có muốn huỷ hoá đơn này không?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
