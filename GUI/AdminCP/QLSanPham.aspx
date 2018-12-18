<%@ Page Title="" Language="C#" MasterPageFile="~/AdminCP/AdminCP.Master" AutoEventWireup="true" CodeBehind="QLSanPham.aspx.cs" Inherits="GUI.AdminCP.QLSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>AdminCP - Quản lí hãng sản xuất</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Quản lí sản phẩm</h2>
    <hr />
    <div class="form-group">
        <label for="txtMaSP">Mã sản phẩm:</label>
        <asp:TextBox ID="txtMaSP" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMaSP" runat="server" ControlToValidate="txtMaSP" ErrorMessage="Vui lòng nhập mã sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtTenSP">Tên sản phẩm:</label>
        <asp:TextBox ID="txtTenSP" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTenSP" runat="server" ControlToValidate="txtTenSP" ErrorMessage="Vui lòng nhập tên sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtThongTin">Thông tin:</label>
        <asp:TextBox ID="txtThongTin" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvThongTin" runat="server" ControlToValidate="txtThongTin" ErrorMessage="Vui lòng nhập thông tin sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtGiaTien">Giá bán:</label>
        <asp:TextBox ID="txtGiaTien" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvGiaTien" runat="server" ControlToValidate="txtGiaTien" ErrorMessage="Vui lòng nhập giá bán sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revGiaTien" runat="server" ControlToValidate="txtGiaTien" ValidationExpression="\d+" ErrorMessage="Dữ liệu không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <label for="txtSoLuongTonKho">Số lượng tồn kho:</label>
        <asp:TextBox ID="txtSoLuongTonKho" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSoLuongTonKho" runat="server" ControlToValidate="txtSoLuongTonKho" ErrorMessage="Vui lòng nhập số lượng tồn kho sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revSoLuongTonKho" runat="server" ControlToValidate="txtSoLuongTonKho" ValidationExpression="\d+" ErrorMessage="Dữ liệu không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <label for="txtMaLoaiSP">Hãng sản xuất:</label>
        <asp:DropDownList ID="ddlMaLoaiSP" runat="server" CssClass="dropdown-item"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="filAnhMinhHoa">Ảnh minh hoạ:</label><br />
        <asp:Image ID="imgAnhMinhHoa" runat="server" ImageUrl="~/img/AnhDaiDien/profile.png" Width="150px" Height="150px" />
        <asp:Button ID="btnXoaAnhMinhHoa" runat="server" Text="Xoá" CssClass="btn align-bottom" OnClick="btnXoaAnhMinhHoa_Click" CausesValidation="False" /><br />
        <br />
        <asp:FileUpload ID="filAnhMinhHoa" runat="server" CssClass="form-row" />
        <script type="text/javascript">
            function readURL(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#cphBody_imgAnhMinhHoa').attr('src', e.target.result);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }
            $("#cphBody_filAnhMinhHoa").change(function () {
                readURL(this);
            });
        </script>
        <asp:Label ID="lblAnhMinhHoaLoiDungLuong" runat="server" Text="Dung lượng file tối đa 1 MB" Visible="false" CssClass="text-danger"></asp:Label>
        <asp:Label ID="lblAnhMinhHoaLoiFile" runat="server" Text="Chỉ được tải lên ảnh .jpg hoặc .png" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
    <div class="form-group">
        <label for="chkTrangThai">Kinh doanh</label>
        <asp:CheckBox ID="chkTrangThai" CssClass="form-check-inline" runat="server" />
    </div>
    <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnThem_Click" />
    <asp:Button ID="btnSua" runat="server" Text="Sửa" CssClass="btn btn-secondary" OnClick="btnSua_Click" />
    <asp:Button ID="btnHuy" runat="server" Text="Huỷ" CausesValidation="false" CssClass="btn btn-danger" OnClick="btnHuy_Click" />
    <asp:Label ID="lblThemThanhCong" runat="server" Text="Thêm sản phẩm thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblThemThatBaiMaSP" runat="server" Text="Mã sản phẩm đã tồn tại" CssClass="text-danger" Visible="false"></asp:Label>
    <asp:Label ID="lblThemThatBaiMaLoaiSP" runat="server" Text="Vui lòng chọn loại sản phẩm" CssClass="text-danger" Visible="false"></asp:Label>
    <asp:Label ID="lblXoaThanhCong" runat="server" Text="Xoá sản phẩm thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblSuaThanhCong" runat="server" Text="Sửa sản phẩm thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblSuaThatBai" runat="server" Text="Vui lòng chọn loại sản phẩm" CssClass="text-danger" Visible="false"></asp:Label>

    <hr />
    <div class="float-right">
        <label for="ddlPhanLoaiSP">Hãng sản xuất</label>
        <asp:DropDownList ID="ddlPhanLoaiSP" runat="server" CssClass="dropdown-toggle-split" AutoPostBack="True" OnTextChanged="ddlPhanLoaiSP_TextChanged"></asp:DropDownList>
    </div>
    <asp:GridView ID="grvSanPham" runat="server" AutoGenerateColumns="False" OnRowCommand="grvSanPham_RowCommand" Width="1065px" CssClass="table-bordered table-hover" CellPadding="5" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grvSanPham_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="MaSP" HeaderText="Mã sản phẩm">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TenSP" HeaderText="Tên sản phẩm">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="ThongTin" HeaderText="Thông tin">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="GiaTien" HeaderText="Giá tiền" DataFormatString="{0:C0}">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="SoLuongTonKho" HeaderText="Số lượng tồn kho">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="MaLoaiSP" HeaderText="Mã hãng sản xuất">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Ảnh minh hoạ">
                <ItemTemplate>
                    <asp:Image ID="imgAnhMinhHoa" runat="server" ImageUrl='<%# "~/img/AnhMinhHoa/" + Eval("AnhMinhHoa") %>' />
                </ItemTemplate>
                <ControlStyle Width="100px" />
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:TemplateField>
            <asp:CheckBoxField DataField="TrangThai" HeaderText="Kinh doanh">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnChon" runat="server" CausesValidation="False" CssClass="btn btn-secondary" Width="100%" CommandName="Chon" CommandArgument='<%# Eval("MaSP") %>' Text="Chọn" />
                    <asp:Button ID="btnXoa" runat="server" CausesValidation="False" CssClass="btn btn-danger" Width="100%" CommandName="Xoa" CommandArgument='<%# Eval("MaSP") %>' Text="Xoá" OnClientClick="return confirm('Bạn có muốn xoá sản phẩm này không?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
