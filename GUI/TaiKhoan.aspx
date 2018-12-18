<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaiKhoan.aspx.cs" Inherits="GUI.TaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Thông tin tài khoản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Thông tin tài khoản</h2>
    <p>Nếu muốn sửa đổi thông tin tài khoản, nhập thông tin mới và nhấn nút Cập nhật</p>
    <p>Để thay đổi mật khẩu, vui lòng sử dụng trang <a href="DoiMatKhau.aspx">Đổi mật khẩu</a></p>
    <asp:Panel ID="panThongTinTaiKhoan" runat="server" DefaultButton="btnCapNhat">
        <div class="form-group">
            <label for="txtTenTaiKhoan">Tên tài khoản:</label>
            <asp:TextBox ID="txtTenTaiKhoan" runat="server" MaxLength="20" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
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
            <asp:Image ID="imgAnhDaiDien" runat="server" Width="150px" Height="150px" />
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
        <asp:Button ID="btnCapNhat" runat="server" CssClass="btn btn-primary" Text="Cập nhật" OnClick="btnCapNhat_Click" />
        <asp:Button ID="btnHuy" runat="server" CssClass="btn btn-danger" Text="Hủy bỏ" OnClick="btnHuy_Click" /><br />
        <asp:Label ID="lblCapNhatThanhCong" runat="server" Text="Cập nhật thông tin thành công" CssClass="font-weight-bold text-primary" Visible="false"></asp:Label>
        <asp:Label ID="lblCapNhatThatBai" runat="server" Text="Cập nhật thông tin thất bại" CssClass="font-weight-bold text-danger" Visible="false"></asp:Label>
    </asp:Panel>
</asp:Content>
