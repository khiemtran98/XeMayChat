<%@ Page Title="" Language="C#" MasterPageFile="~/AdminCP/AdminCP.Master" AutoEventWireup="true" CodeBehind="QLTaiKhoan.aspx.cs" Inherits="GUI.AdminCP.QLTaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>AdminCP - Quản lí tài khoản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Quản lí tài khoản</h2>
    <hr />
    <div class="form-group">
        <label for="txtTenTaiKhoan">Tên tài khoản:</label>
        <asp:TextBox ID="txtTenTaiKhoan" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTenTaiKhoan" runat="server" ControlToValidate="txtTenTaiKhoan" ErrorMessage="Vui lòng nhập tên tài khoản" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtMatKhau">Mật khẩu:</label>
        <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password" MaxLength="20" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMatKhau" runat="server" ControlToValidate="txtMatKhau" ErrorMessage="Vui lòng nhập mật khẩu" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Vui lòng nhập email" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <label for="txtSDT">SĐT:</label>
        <asp:TextBox ID="txtSDT" runat="server" TextMode="Phone" MaxLength="11" CssClass="form-control"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revSDT" runat="server" ControlToValidate="txtSDT" ValidationExpression="0+[19]\d{8,9}" ErrorMessage="SĐT không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <label for="txtDiaChi">Địa chỉ:</label>
        <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtHoTen">Họ tên:</label>
        <asp:TextBox ID="txtHoTen" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revHoTen" runat="server" ControlToValidate="txtHoTen" ValidationExpression="[\D]{0,100}" ErrorMessage="Họ tên không hợp lệ" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <label for="filAnhDaiDien">Ảnh đại diện:</label><br />
        <asp:Image ID="imgAnhDaiDien" runat="server" ImageUrl="~/img/AnhDaiDien/profile.png" Width="150px" Height="150px" />
        <asp:Button ID="btnXoaAnhDaiDien" runat="server" Text="Xoá" CssClass="btn align-bottom" OnClick="btnXoaAnhDaiDien_Click" CausesValidation="False" /><br />
        <br />
        <asp:FileUpload ID="filAnhDaiDien" runat="server" CssClass="form-row" />
        <script type="text/javascript">
            function readURL(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#cphBody_imgAnhDaiDien').attr('src', e.target.result);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }
            $("#cphBody_filAnhDaiDien").change(function () {
                readURL(this);
            });
        </script>
        <asp:Label ID="lblAnhDaiDienLoiDungLuong" runat="server" Text="Dung lượng file tối đa 1 MB" Visible="false" CssClass="text-danger"></asp:Label>
        <asp:Label ID="lblAnhDaiDienLoiFile" runat="server" Text="Chỉ được tải lên ảnh .jpg hoặc .png" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
    <div class="form-group">
        <label for="chkLaAdmin">Administrator:</label>
        <asp:CheckBox ID="chkLaAdmin" CssClass="form-check-inline" runat="server" />
    </div>
    <div class="form-group">
        <label for="chkTrangThai">Hoạt động:</label>
        <asp:CheckBox ID="chkTrangThai" CssClass="form-check-inline" runat="server" />
    </div>
    <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnThem_Click" />
    <asp:Button ID="btnSua" runat="server" Text="Sửa" CssClass="btn btn-secondary" OnClick="btnSua_Click" />
    <asp:Button ID="btnHuy" runat="server" Text="Huỷ" CausesValidation="false" CssClass="btn btn-danger" OnClick="btnHuy_Click" />
    <asp:Label ID="lblThemThanhCong" runat="server" Text="Thêm tài khoản thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblThemThatBai" runat="server" Text="Tên tài khoản đã tồn tại" CssClass="text-danger" Visible="false"></asp:Label>
    <asp:Label ID="lblXoaThanhCong" runat="server" Text="Xoá tài khoản thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <asp:Label ID="lblSuaThanhCong" runat="server" Text="Sửa tài khoản thành công" CssClass="text-primary" Visible="false"></asp:Label>
    <hr />
    <asp:GridView ID="grvTaiKhoan" runat="server" AutoGenerateColumns="False" OnRowCommand="grvTaiKhoan_RowCommand" Width="1065px" CssClass="table-bordered table-hover" CellPadding="5" AllowPaging="True" OnPageIndexChanging="grvTaiKhoan_PageIndexChanging" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="TenTaiKhoan" HeaderText="Tên tài khoản">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="SDT" HeaderText="SĐT">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="HoTen" HeaderText="Họ tên">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Ảnh đại diện">
                <ItemTemplate>
                    <asp:Image ID="imgAnhDaiDien" runat="server" ImageUrl='<%# "~/img/AnhDaiDien/" + Eval("AnhDaiDien") %>' />
                </ItemTemplate>
                <ControlStyle Width="50px" />
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
            </asp:TemplateField>
            <asp:CheckBoxField DataField="LaAdmin" HeaderText="Administrator">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="TrangThai" HeaderText="Hoạt động">
                <HeaderStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnChon" runat="server" CausesValidation="False" CssClass="btn btn-secondary" CommandName="Chon" CommandArgument='<%# Eval("TenTaiKhoan") %>' Text="Chọn" />
                    <asp:Button ID="btnXoa" runat="server" CausesValidation="False" CssClass="btn btn-danger" CommandName="Xoa" CommandArgument='<%# Eval("TenTaiKhoan") %>' Text="Xoá" OnClientClick="return confirm('Bạn có muốn xoá tài khoản này không?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle Font-Size="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
