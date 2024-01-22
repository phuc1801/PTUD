Cre: Đai Học Hàng Hải Việt Nam
#ĐỀ 1:
  Câu 1(0.5 điểm) : Tạo CSDL BaiKiemTraSo3
  Gồm các bảng sau:
  PhimDienAnh(MaPhimDienAnh,TenPhimDienAnh)
  - MaPhimDienAnh là số nguyên, tự tăng, khóa chính
  - Tên phim điện ảnh tối đa 30 ký tự có dấu, không để trống và là duy nhất
  DienVien(MaDienVien,HoTen,NgaySinh)
  - MaDienVien là số nguyên, tự tăng, khóa chính
  - Họ tên tối đa 30 ký tự có dấu, không để trống
  - Ngày sinh kiểu ngày tháng, yêu cầu tuổi >= 18
  PhimDienAnhDienVien(MaDienVien,MaPhimDienAnh,ThuLao,GhiChu)
  - MaDienVien,MaPhimDienAnh tham chiếu sang bảng diễn viên và bảng phim điện ảnh và là khóa chính
  - Thù lao là 1 số nguyên không âm
  - GhiChu tối đa 100 ký tự có dấu
  Câu 2 (0.5 điểm): Tạo view vChiTietPhimDienAnhDienVien gồm các thông tin sau: Mã diễn viên, họ tên, tên phim điện ảnh, thù lao, ghi chú
  Câu 3 (0.75 điểm): Tạo thủ tục spThemPhimDienAnhDienVien nhận 3 tham số mã diễn viên, tên phim điện ảnh, thù lao và ghi chú
  - Kiểm tra xem mã diễn viên tồn tại không
  - Kiểm tra xem tên phim điện ảnh tồn tại không
  - Kiểm tra xem thù lao có âm không
  - Kiểm tra xem diễn viên này và phim điện ảnh này đã được lưu trữ chưa
  - Nếu tất cả đều ổn thì thêm vào bảng PhimDienAnhDienVien
  Câu 4(0.75 điểm): Tạo hàm TimKiemPhimDienAnh nhận tham số đầu vào là mã phim điện ảnh và tên phim điện ảnh.
  - nếu ko muốn tìm theo mã phim điện ảnh thì đưa mã phim điện ảnh là NULL vào
  - nếu ko muốn tìm theo tên phim điện ảnh thì đưa tên phim điện ảnh là NULL vào (có thể tìm kiếm gần đúng)
  - Trả về danh sách phim điện ảnh thỏa mãn điều kiện
  Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
  Tạo form QuanLyDienVien cho phép:
  - Hiển thị danh sách diễn viên lên datagridview (0.5 điểm)
  - Hiển thị thông tin diễn viên khi click chọn từng dòng (0.5 điểm)
  - Thêm diễn viên (1 điểm)
  - Sửa diễn viên (1 điểm)
  - Xóa diễn viên (1 điểm)
  - Bắt lỗi khi thêm, sửa, xóa diễn viên (1 điểm)
  - Khi xóa diễn viên sẽ xóa đi các thông tin liên quan bên bảng PhimDienAnhDienVien (1 điểm)
  - Tìm kiếm diễn viên theo mã diễn viên (0.75 điểm)
  - Tìm kiếm diễn viên theo họ tên (0.75 điểm)
  ***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 2
  Câu 1(0.5 điểm) : Tạo CSDL BaiKiemTraSo3
  Gồm các bảng sau:
  NgoaiNgu(MaNgoaiNgu,TenNgoaiNgu)
  - MaNgoaiNgu là số nguyên, tự tăng, khóa chính
  - Tên ngoại ngữ tối đa 30 ký tự có dấu, không để trống và là duy nhất
  NhanVien(MaNhanVien,HoTen,NgaySinh)
  - MaNhanVien là số nguyên, tự tăng, khóa chính
  - Họ tên tối đa 30 ký tự có dấu, không để trống
  - Ngày sinh kiểu ngày tháng, yêu cầu tuổi >= 18
  NgoaiNguNhanVien(MaNhanVien,MaNgoaiNgu,GhiChu)
  - MaNhanVien,MaNgoaiNgu tham chiếu sang bảng nhân viên và bảng ngoại ngữ và là khóa chính
  - GhiChu tối đa 100 ký tự có dấu
  Câu 2 (0.5 điểm): Tạo view vChiTietNgoaiNguNhanVien gồm các thông tin sau: Mã nhân viên, họ tên, tên ngoại ngữ, ghi chú
  Câu 3 (0.75 điểm): Tạo thủ tục spThemNgoaiNguNhanVien nhận 3 tham số mã nhân viên, tên ngoại ngữ và ghi chú
  - Kiểm tra xem mã nhân viên tồn tại không
  - Kiểm tra xem tên ngoại ngữ tồn tại không
  - Kiểm tra xem nhân viên này và ngoại ngữ này đã được lưu trữ chưa
  - Nếu tất cả đều ổn thì thêm vào bảng NgoaiNguNhanVien
  Câu 4(0.75 điểm): Tạo hàm TimKiemNgoaiNgu nhận tham số đầu vào là mã ngoại ngữ và tên ngoại ngữ.
  - nếu ko muốn tìm theo mã ngoại ngữ thì đưa mã ngoại ngữ là NULL vào
  - nếu ko muốn tìm theo tên ngoại ngữ thì đưa tên ngoại ngữ là NULL vào (có thể tìm kiếm gần đúng)
  - Trả về danh sách ngoại ngữ thỏa mãn điều kiện
  Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
  Tạo form QuanLyNhanVien cho phép:
  - Hiển thị danh sách nhân viên lên datagridview (0.5 điểm)
  - Hiển thị thông tin nhân viên khi click chọn từng dòng (0.5 điểm)
  - Thêm nhân viên (1 điểm)
  - Sửa nhân viên (1 điểm)
  - Xóa nhân viên (1 điểm)
  - Bắt lỗi khi thêm, sửa, xóa nhân viên (1 điểm)
  - Khi xóa nhân viên sẽ xóa đi các thông tin liên quan bên bảng NgoaiNguNhanVien (1 điểm)
  - Tìm kiếm nhân viên theo mã nhân viên (0.75 điểm)
  - Tìm kiếm nhân viên theo họ tên (0.75 điểm)
  ***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 3
Câu 1(0.75 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
BangCap(MaBangCap,TenBangCap)
- MaBangCap là số nguyên, tự tăng, khóa chính
- Tên bằng cấp tối đa 30 ký tự có dấu, không để trống và là duy nhất
NgoaiNgu(MaNgoaiNgu,TenNgoaiNgu)
- MaNgoaiNgu là số nguyên, tự tăng, khóa chính
- Tên ngoại ngữ tối đa 30 ký tự có dấu, không để trống và là duy nhất
SinhVien(MaSinhVien,HoTen,DienThoai)
- MaSinhVien là số nguyên, tự tăng, khóa chính
- Họ tên tối đa 30 ký tự có dấu, không để trống
- Điện thoại tối đa 10 ký tự không dấu, không để trống
NgoaiNguSinhVien(MaSinhVien,MaNgoaiNgu,MaBangCap)
- MaSinhVien,MaNgoaiNgu,MaBangCap tham chiếu sang bảng sinh viên, bảng ngoại ngữ, bảng bằng cấp và là khóa chính
Câu 2 (0.5 điểm): Tạo view vChiTietNgoaiNguSinhVien gồm các thông tin sau: Mã sinh viên, họ tên, tên ngoại ngữ, tên bằng cấp
Câu 3 (0.75 điểm): Tạo thủ tục spThemNgoaiNguSinhVien nhận 3 tham số mã sinh viên, mã ngoại ngữ và mã bằng cấp
- Kiểm tra xem mã sinh viên tồn tại không
- Kiểm tra xem mã ngoại ngữ tồn tại không
- Kiểm tra xem mã bằng cấp có tồn tại không
- Kiểm tra xem sinh viên này và ngoại ngữ này đã được lưu trữ chưa
- Nếu tất cả đều ổn thì thêm vào bảng NgoaiNguSinhVien
Câu 4(0.75 điểm): Tạo hàm TimKiemSinhVien nhận tham số đầu vào là mã sinh viên, họ tên, điện thoại.
- nếu ko muốn tìm theo mã sinh viên thì đưa mã sinh viên là NULL vào
- nếu ko muốn tìm theo họ tên thì đưa họ tên là NULL vào (có thể tìm kiếm gần đúng)
- nếu ko muốn tìm theo điện thoại thì đưa điện thoại là NULL vào (có thể tìm kiếm gần đúng)
- Trả về danh sách sinh viên thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyNgoaiNgu cho phép:
- Hiển thị danh sách ngoại ngữ lên datagridview (0.5 điểm)
- Hiển thị thông tin ngoại ngữ khi click chọn từng dòng (0.25 điểm)
- Thêm ngoại ngữ (1 điểm)
- Sửa ngoại ngữ (1 điểm)
- Xóa ngoại ngữ (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa ngoại ngữ (2 điểm)
- Tìm kiếm ngoại ngữ theo mã ngoại ngữ (0.75 điểm)
- Tìm kiếm ngoại ngữ theo tên ngoại ngữ (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 4
Câu 1(0.5 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
LoaiHang(MaLoaiHang,TenMaLoaiHang)
- MaLoaiHang là số nguyên, tự tăng, khóa chính
- Tên loại hàng tối đa 30 ký tự có dấu, không để trống và là duy nhất
HangHoa(MaHangHoa,TenHangHoa,MaLoaiHang)
- MaHangHoa là số nguyên, tự tăng, khóa chính
- Tên hàng hóa tối đa 30 ký tự có dấu, không để trống và là duy nhất
- MaLoaiHang tham chiếu sang bảng loại hàng
NhaCungCap(MaNhaCungCap,HoTen,DiaChi)
- MaNhaCungCap là số nguyên, tự tăng, khóa chính
- Họ tên tối đa 30 ký tự có dấu, không để trống
- Địa chỉ chiều dài tối đa 100 ký tự có dấu, không để trống
HangHoaNhaCungCap(MaNhaCungCap,MaHangHoa,GhiChu)
- MaNhaCungCap,MaHangHoa tham chiếu sang bảng nhà cung cấp và bảng hàng hóa và là khóa chính
- GhiChu tối đa 100 ký tự có dấu
Câu 2 (0.5 điểm): Tạo view vChiTietHangHoaNhaCungCap gồm các thông tin sau: Mã nhà cung cấp, họ tên, tên hàng hóa, tên loại hàng
Câu 3 (0.75 điểm): Tạo thủ tục spThemHangHoaNhaCungCap nhận 3 tham số mã nhà cung cấp, mã hàng hóa và ghi chú
- Kiểm tra xem mã nhà cung cấp tồn tại không
- Kiểm tra xem mã hàng hóa tồn tại không
- Kiểm tra xem nhà cung cấp này và hàng hóa này đã được lưu trữ chưa
- Nếu tất cả đều ổn thì thêm vào bảng HangHoaNhaCungCap
Câu 4(0.75 điểm): Tạo hàm TimKiemHangHoa nhận tham số đầu vào là mã hàng hóa, tên hàng hóa, tên loại hàng.
- nếu ko muốn tìm theo mã hàng hóa thì đưa mã hàng hóa là NULL vào
- nếu ko muốn tìm theo tên hàng hóa thì đưa tên hàng hóa là NULL vào (có thể tìm kiếm gần đúng)
- nếu ko muốn tìm theo tên hàng hóa thì đưa tên hàng hóa là NULL vào (có thể tìm kiếm gần đúng)
- Trả về danh sách hàng hóa thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyNhaCungCap cho phép:
- Hiển thị danh sách nhà cung cấp lên datagridview (0.5 điểm)
- Hiển thị thông tin nhà cung cấp khi click chọn từng dòng (0.5 điểm)
- Thêm nhà cung cấp (1 điểm)
- Sửa nhà cung cấp (1 điểm)
- Xóa nhà cung cấp (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa nhà cung cấp (1 điểm)
- Khi xóa nhà cung cấp sẽ xóa đi các thông tin liên quan bên bảng HangHoaNhaCungCap (1 điểm)
- Tìm kiếm nhà cung cấp theo mã nhà cung cấp (0.75 điểm)
- Tìm kiếm nhà cung cấp theo tên nhà cung cấp (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 5
Câu 1(0.75 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
Kho(MaKho,TenKho)
- MaKho là số nguyên, tự tăng, khóa chính
- Tên kho tối đa 30 ký tự có dấu, không để trống và là duy nhất
DonViTinh(MaDonViTinh,TenDonViTinh)
- MaDonViTinh là số nguyên, tự tăng, khóa chính
- Tên đơn vị tính tối đa 30 ký tự có dấu, không để trống và là duy nhất
HangHoa(MaHangHoa,TenHangHoa,MaDonViTinh,GhiChu)
- MaHangHoa là số nguyên, tự tăng, khóa chính
- Tên hàng hóa tối đa 30 ký tự có dấu, không để trống và là duy nhất
- Ghi chú tối đa 100 ký tự có dấu, không để trống
- MaDonViTinh tham chiếu sang bảng đơn vị tính
LuuKho(MaHangHoa,MaKho,SoLuong)
- MaHangHoa,MaKho tham chiếu sang bảng hàng hóa, bảng kho và là khóa chính
- SoLuong là 1 số thực không âm
Câu 2 (0.5 điểm): Tạo view vChiTietLuuKho gồm các thông tin sau: Mã hàng hóa, tên hàng hóa, tên đơn vị tính, tên kho, số lượng
Câu 3 (0.75 điểm): Tạo thủ tục spThemHangHoa nhận 3 tham số tên hàng hóa, tên đơn vị tính, ghi chú
- Kiểm tra xem tên hàng hóa bị trùn không
- Kiểm tra xem tên đơn vị tính có tồn tại không
- Nếu tất cả đều ổn thì thêm vào bảng HangHoa
Câu 4(0.75 điểm): Tạo hàm TimKiemLuuKho nhận tham số đầu vào là tên hàng hóa, tên kho, số lượng.
- nếu ko muốn tìm theo tên hàng hóa thì đưa tên hàng hóa là NULL vào
- nếu ko muốn tìm theo tên kho thì đưa tên kho là NULL vào (có thể tìm kiếm gần đúng)
- nếu ko muốn tìm theo số lượng thì đưa số lượng là NULL vào
- Trả về danh sách lưu kho thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyHangHoa cho phép:
- Hiển thị danh sách hàng hóa lên datagridview (0.5 điểm)
- Hiển thị thông tin hàng hóa khi click chọn từng dòng (0.25 điểm)
- Thêm hàng hóa (1 điểm)
- Sửa hàng hóa (1 điểm)
- Xóa hàng hóa (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa hàng hóa (2 điểm)
- Tìm kiếm hàng hóa theo mã hàng hóa (0.75 điểm)
- Tìm kiếm hàng hóa theo tên hàng hóa (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 6
Câu 1(0.75 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
ChungChi(MaChungChi,TenChungChi,ThoiHan)
- MaChungChi là số nguyên, tự tăng, khóa chính
- Tên chứng chỉ tối đa 30 ký tự có dấu, không để trống và là duy nhất
- ThoiHan là 1 số nguyên không âm (chỉ số tháng), nếu chứng chỉ vô thời hạn thì thời hạn là NULL
NgoaiNgu(MaNgoaiNgu,TenNgoaiNgu)
- MaNgoaiNgu là số nguyên, tự tăng, khóa chính
- Tên ngoại ngữ tối đa 30 ký tự có dấu, không để trống và là duy nhất
NhanVien(MaNhanVien,HoTen,DienThoai)
- MaNhanVien là số nguyên, tự tăng, khóa chính
- Họ tên tối đa 30 ký tự có dấu, không để trống
- Điện thoại tối đa 10 ký tự không dấu, không để trống
NgoaiNguNhanVien(MaNhanVien,MaNgoaiNgu,MaChungChi,NgayCap)
- MaNhanVien,MaNgoaiNgu,MaChungChi tham chiếu sang bảng nhân viên, bảng ngoại ngữ, bảng chứng chỉ và là khóa chính
- NgayCap là 1 giá trị kiểu ngày tháng ko để trống
Câu 2 (0.75 điểm): Tạo view vChiTietNgoaiNguNhanVien gồm các thông tin sau: Mã nhân viên, họ tên, tên ngoại ngữ, tên chứng chỉ, ngày cấp
Câu 3 (0.5 điểm): Tạo thủ tục spThemChungChi nhận 2 tham số tên chứng chỉ và thời hạn
- Kiểm tra xem tên chứng chỉ bị trùng không
- Nếu tất cả đều ổn thì thêm vào bảng ChungChi
Câu 4(0.75 điểm): Tạo hàm TimKiemNhanVien nhận tham số đầu vào là mã nhân viên, họ tên, điện thoại.
- nếu ko muốn tìm theo mã nhân viên thì đưa mã nhân viên là NULL vào
- nếu ko muốn tìm theo họ tên thì đưa họ tên là NULL vào (có thể tìm kiếm gần đúng)
- nếu ko muốn tìm theo điện thoại thì đưa điện thoại là NULL vào (có thể tìm kiếm gần đúng)
- Trả về danh sách nhân viên thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyChungChi cho phép:
- Hiển thị danh sách chứng chỉ lên datagridview (0.5 điểm)
- Hiển thị thông tin chứng chỉ  khi click chọn từng dòng (0.25 điểm)
- Thêm chứng chỉ (1 điểm)
- Sửa chứng chỉ (1 điểm)
- Xóa chứng chỉ (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa chứng chỉ (2 điểm)
- Tìm kiếm chứng chỉ theo mã chứng chỉ (0.75 điểm)
- Tìm kiếm chứng chỉ theo tên chứng chỉ (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 7
Câu 1(0.5 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
LoaiPhim(MaLoaiPhim,TenMaLoaiPhim)
- MaLoaiPhim là số nguyên, tự tăng, khóa chính
- Tên loại phim tối đa 30 ký tự có dấu, không để trống và là duy nhất
PhimDienAnh(MaPhimDienAnh,TenPhimDienAnh,MaLoaiPhim)
- MaPhimDienAnh là số nguyên, tự tăng, khóa chính
- Tên phim điện ảnh tối đa 30 ký tự có dấu, không để trống và là duy nhất
- MaLoaiPhim tham chiếu sang bảng loại phim
DienVien(MaDienVien,HoTen)
- MaDienVien là số nguyên, tự tăng, khóa chính
- Họ tên tối đa 30 ký tự có dấu, không để trống
PhimDienAnhDienVien(MaDienVien,MaPhimDienAnh,GhiChu)
- MaDienVien,MaPhimDienAnh tham chiếu sang bảng diễn viên và bảng phim điện ảnh và là khóa chính
- GhiChu tối đa 100 ký tự có dấu
Câu 2 (0.5 điểm): Tạo view vChiTietPhimDienAnhDienVien gồm các thông tin sau: Mã diễn viên, họ tên, tên phim điện ảnh, tên loại phim
Câu 3 (0.75 điểm): Tạo thủ tục spThemPhimDienAnhDienVien nhận 3 tham số mã diễn viên, mã phim điện ảnh và ghi chú
- Kiểm tra xem mã diễn viên tồn tại không
- Kiểm tra xem mã phim điện ảnh tồn tại không
- Kiểm tra xem diễn viên này và phim điện ảnh này đã được lưu trữ chưa
- Nếu tất cả đều ổn thì thêm vào bảng PhimDienAnhDienVien
Câu 4(0.75 điểm): Tạo hàm TimKiemLoaiPhim nhận tham số đầu vào là mã loại phim và tên loại phim.
- nếu ko muốn tìm theo mã loại phim thì đưa mã loại phim là NULL vào
- nếu ko muốn tìm theo tên loại phim thì đưa tên loại phim là NULL vào (có thể tìm kiếm gần đúng)
- Trả về danh sách loại phim điện ảnh thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyPhimDienAnh cho phép:
- Hiển thị danh sách phim điện ảnh lên datagridview (0.5 điểm)
- Hiển thị thông tin phim điện ảnh khi click chọn từng dòng (0.5 điểm)
- Thêm phim điện ảnh (1 điểm)
- Sửa phim điện ảnh (1 điểm)
- Xóa phim điện ảnh (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa phim điện ảnh (1 điểm)
- Khi xóa phim điện ảnh sẽ xóa đi các thông tin liên quan bên bảng PhimDienAnhDienVien (1 điểm)
- Tìm kiếm diễn viên theo mã phim điện ảnh (0.75 điểm)
- Tìm kiếm diễn viên theo tên phim điện ảnh (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 8
Câu 1(0.75 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
Kho(MaKho,TenKho)
- MaKho là số nguyên, tự tăng, khóa chính
- Tên kho tối đa 30 ký tự có dấu, không để trống và là duy nhất
DonViTinh(MaDonViTinh,TenDonViTinh)
- MaDonViTinh là số nguyên, tự tăng, khóa chính
- Tên đơn vị tính tối đa 30 ký tự có dấu, không để trống và là duy nhất
HangHoa(MaHangHoa,TenHangHoa,GhiChu)
- MaHangHoa là số nguyên, tự tăng, khóa chính
- Tên hàng hóa tối đa 30 ký tự có dấu, không để trống, không trùng lặp
- Ghi chú tối đa 100 ký tự có dấu, không để trống
LuuKho(MaHangHoa,MaDonViTinh,MaKho,SoLuong)
- MaHangHoa,MaDonViTinh,MaKho tham chiếu sang bảng hàng hóa, bảng đơn vị tính, bảng kho và là khóa chính
- SoLuong là 1 số thực không âm
Câu 2 (0.5 điểm): Tạo view vChiTietLuuKho gồm các thông tin sau: Mã hàng hóa, tên hàng hóa, tên đơn vị tính, tên kho, số lượng
Câu 3 (0.75 điểm): Tạo thủ tục spThemLuuKho nhận 4 tham số tên hàng hóa, tên đơn vị tính,tên kho,số lượng
- Kiểm tra xem tên hàng hóa tồn tại không
- Kiểm tra xem tên đơn vị tính tồn tại không
- Kiểm tra xem tên kho có tồn tại không
- Kiểm tra xem số lượng có âm không
- Kiểm tra xem hàng hóa này, đơn vị tính này và kho này đã được lưu trữ chưa
- Nếu tất cả đều ổn thì thêm vào bảng LuuKho
Câu 4(0.75 điểm): Tạo hàm TimKiemHangHoa nhận tham số đầu vào là mã hàng hóa, tên hàng hóa, ghi chú.
- nếu ko muốn tìm theo mã hàng hóa thì đưa mã hàng hóa là NULL vào
- nếu ko muốn tìm theo tên hàng hóa thì đưa tên hàng hóa là NULL vào (có thể tìm kiếm gần đúng)
- nếu ko muốn tìm theo ghi chú thì đưa ghi chú là NULL vào (có thể tìm kiếm gần đúng)
- Trả về danh sách hàng hóa thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyKho cho phép:
- Hiển thị danh kho lên datagridview (0.5 điểm)
- Hiển thị thông tin kho khi click chọn từng dòng (0.25 điểm)
- Thêm kho (1 điểm)
- Sửa kho (1 điểm)
- Xóa kho (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa kho (2 điểm)
- Tìm kiếm kho theo mã kho (0.75 điểm)
- Tìm kiếm kho theo tên kho (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 9
Câu 1(0.75 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
ChungChi(MaChungChi,TenChungChi,ThoiHan)
- MaChungChi là số nguyên, tự tăng, khóa chính
- Tên chứng chỉ tối đa 30 ký tự có dấu, không để trống và là duy nhất
- ThoiHan là 1 số nguyên không âm (chỉ số tháng), nếu chứng chỉ vô thời hạn thì thời hạn là NULL
NghiepVu(MaNghiepVu,TenNghiepVu)
- MaNghiepVu là số nguyên, tự tăng, khóa chính
- Tên nghiệp vụ tối đa 30 ký tự có dấu, không để trống và là duy nhất
NhanVien(MaNhanVien,HoTen,DienThoai)
- MaNhanVien là số nguyên, tự tăng, khóa chính
- Họ tên tối đa 30 ký tự có dấu, không để trống
- Điện thoại tối đa 10 ký tự không dấu, không để trống
NghiepVuNhanVien(MaNhanVien,MaNghiepVu,MaChungChi,NgayCap)
- MaNhanVien,MaNghiepVu,MaChungChi tham chiếu sang bảng nhân viên, bảng nghiệp vụ, bảng chứng chỉ và là khóa chính
- NgayCap là 1 giá trị kiểu ngày tháng ko để trống
Câu 2 (0.75 điểm): Tạo view vChiTietNghiepVuNhanVien gồm các thông tin sau: Mã nhân viên, họ tên, tên nghiệp vụ, tên chứng chỉ, ngày cấp
Câu 3 (0.75 điểm): Tạo thủ tục spThemNghiepVuNhanVien nhận 3 tham số mã nhân viên, tên nghiệp vụ, tên chứng chỉ và ngày cấp
- Kiểm tra xem mã nhân viên tồn tại không
- Kiểm tra xem tên nghiệp vụ tồn tại không
- Kiểm tra xem tên chứng chỉ tồn tại không
- Kiểm tra xem nhân viên này, nghiệp vụ này và chứng chỉ này đã được lưu trữ chưa
- Nếu tất cả đều ổn thì thêm vào bảng NghiepVuNhanVien
Câu 4(0.5 điểm): Tạo hàm TimKiemNghiepVu nhận tham số đầu vào là mã nghiệp vụ và tên nghiệp vụ.
- nếu ko muốn tìm theo mã nghiệp vụ thì đưa mã nghiệp vụ là NULL vào
- nếu ko muốn tìm theo tên nghiệp vụ thì đưa tên nghiệp vụ là NULL vào (có thể tìm kiếm gần đúng)
- Trả về danh sách nghiệp vụ thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyNhanVien cho phép:
- Hiển thị danh sách nhân viên lên datagridview (0.25 điểm)
- Hiển thị thông tin nhân viên khi click chọn từng dòng (0.5 điểm)
- Thêm nhân viên (1 điểm)
- Sửa nhân viên (1 điểm)
- Xóa nhân viên (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa nhân viên (1 điểm)
- Khi xóa nhân viên sẽ xóa đi các thông tin liên quan bên bảng NghiepVuNhanVien (1 điểm)
- Tìm kiếm nhân viên theo mã nhân viên (0.75 điểm)
- Tìm kiếm nhân viên theo họ tên (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 10
Câu 1(0.75 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
BangCap(MaBangCap,TenBangCap)
- MaBangCap là số nguyên, tự tăng, khóa chính
- Tên bằng cấp tối đa 30 ký tự có dấu, không để trống và là duy nhất
ChuyenMon(MaChuyenMon,TenChuyenMon)
- MaChuyenMon là số nguyên, tự tăng, khóa chính
- Tên chuyên môn tối đa 30 ký tự có dấu, không để trống và là duy nhất
NhanVien(MaNhanVien,HoTen,DiaChi)
- MaNhanVien là số nguyên, tự tăng, khóa chính
- Họ tên tối đa 30 ký tự có dấu, không để trống
- Địa chỉ tối đa 100 ký tự có dấu, không để trống
ChuyenMonNhanVien(MaNhanVien,MaChuyenMon,MaBangCap)
- MaNhanVien,MaChuyenMon tham chiếu sang bảng nhân viên và bảng chuyên môn và là khóa chính
- MaBangCap tham chiếu sang bảng bằng cấp
Câu 2 (0.5 điểm): Tạo view vChiTietChuyenMonNhanVien gồm các thông tin sau: Mã nhân viên, họ tên, tên chuyên môn, tên bằng cấp
Câu 3 (0.75 điểm): Tạo thủ tục spThemChuyenMonNhanVien nhận 3 tham số mã nhân viên, tên chuyên môn và tên bằng cấp
- Kiểm tra xem mã nhân viên tồn tại không
- Kiểm tra xem tên chuyên môn tồn tại không
- Kiểm tra xem tên bằng cấp có tồn tại không
- Kiểm tra xem nhân viên này và chuyên môn này đã được lưu trữ chưa
- Nếu tất cả đều ổn thì thêm vào bảng ChuyenMonNhanVien
Câu 4(0.75 điểm): Tạo hàm TimKiemNhanVien nhận tham số đầu vào là mã nhân viên, họ tên, địa chỉ.
- nếu ko muốn tìm theo mã nhân viên thì đưa mã nhân viên là NULL vào
- nếu ko muốn tìm theo họ tên thì đưa họ tên là NULL vào (có thể tìm kiếm gần đúng)
- nếu ko muốn tìm theo địa chỉ thì đưa địa chỉ là NULL vào (có thể tìm kiếm gần đúng)
- Trả về danh sách nhân viên thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyBangCap cho phép:
- Hiển thị danh bằng cấp lên datagridview (0.5 điểm)
- Hiển thị thông tin bằng cấp  khi click chọn từng dòng (0.25 điểm)
- Thêm bằng cấp (1 điểm)
- Sửa bằng cấp (1 điểm)
- Xóa bằng cấp (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa bằng cấp (2 điểm)
- Tìm kiếm bằng cấp theo mã bằng cấp (0.75 điểm)
- Tìm kiếm bằng cấp theo tên bằng cấp (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
#ĐỀ 11
Câu 1(0.75 điểm) : Tạo CSDL BaiKiemTraSo3
Gồm các bảng sau:
ChungChi(MaChungChi,TenChungChi,ThoiHan)
- MaChungChi là số nguyên, tự tăng, khóa chính
- Tên chứng chỉ tối đa 30 ký tự có dấu, không để trống và là duy nhất
- ThoiHan là 1 số nguyên không âm (chỉ số tháng), nếu chứng chỉ vô thời hạn thì thời hạn là NULL
ChuyenMon(MaChuyenMon,TenChuyenMon)
- MaChuyenMon là số nguyên, tự tăng, khóa chính
- Tên chuyên môn tối đa 30 ký tự có dấu, không để trống và là duy nhất
NhanVien(MaNhanVien,HoTen,DiaChi)
- MaNhanVien là số nguyên, tự tăng, khóa chính
- Họ tên tối đa 30 ký tự có dấu, không để trống
- Địa chỉ tối đa 100 ký tự có dấu, không để trống
ChuyenMonNhanVien(MaNhanVien,MaChuyenMon,MaChungChi,NgayCap)
- MaNhanVien,MaChuyenMon,MaChungChi tham chiếu sang bảng nhân viên, bảng chuyên môn, bảng chứng chỉ và là khóa chính
- NgayCap là 1 giá trị kiểu ngày tháng ko để trống
Câu 2 (0.75 điểm): Tạo view vChiTietChuyenMonNhanVien gồm các thông tin sau: Mã nhân viên, họ tên, tên chuyên môn, tên chứng chỉ, ngày cấp
Câu 3 (0.5 điểm): Tạo thủ tục spThemChungChi nhận 2 tham số tên chứng chỉ và thời hạn
- Kiểm tra xem tên chứng chỉ bị trùng không
- Nếu tất cả đều ổn thì thêm vào bảng ChungChi
Câu 4(0.75 điểm): Tạo hàm TimKiemNhanVien nhận tham số đầu vào là mã nhân viên, họ tên, địa chỉ.
- nếu ko muốn tìm theo mã nhân viên thì đưa mã nhân viên là NULL vào
- nếu ko muốn tìm theo họ tên thì đưa họ tên là NULL vào (có thể tìm kiếm gần đúng)
- nếu ko muốn tìm theo địa chỉ thì đưa địa chỉ là NULL vào (có thể tìm kiếm gần đúng)
- Trả về danh sách nhân viên thỏa mãn điều kiện
Câu 5: Tạo project theo tên sinh viên và mã sinh viên ví dụ: LeQuyetTien_26670 (KO THEO YÊU CẦU TRỪ 0.5 ĐIỂM)
Tạo form QuanLyChungChi cho phép:
- Hiển thị danh sách chứng chỉ lên datagridview (0.5 điểm)
- Hiển thị thông tin chứng chỉ khi click chọn từng dòng (0.25 điểm)
- Thêm chứng chỉ (1 điểm)
- Sửa chứng chỉ (1 điểm)
- Xóa chứng chỉ (1 điểm)
- Bắt lỗi khi thêm, sửa, xóa chứng chỉ (2 điểm)
- Tìm kiếm chứng chỉ theo mã chứng chỉ (0.75 điểm)
- Tìm kiếm chứng chỉ theo tên chứng chỉ (0.75 điểm)
***NÉN TẤT CẢ BÀI LÀM THÀNH 1 FILE ĐẶT TÊN THEO TÊN VÀ MÃ SINH VIÊN VÍ DỤ: LeQuyetTien_26670.zip, LƯU Ý XÓA THƯ MỤC BIN TRONG PROJECT ĐỂ TRÁNH VIRUS KHI NỘP (KO THEO YÊU CẦU TRỪ 1 ĐIỂM)
