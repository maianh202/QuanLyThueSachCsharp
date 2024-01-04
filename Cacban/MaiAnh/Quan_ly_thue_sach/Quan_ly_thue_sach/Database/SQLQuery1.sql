
CREATE TABLE [dbo].[tblLinhvuc]
(
	[Malinhvuc] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Tenlinhvuc] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[tblTacgia]
(
	[Matacgia] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Tentacgia] NVARCHAR(50) NOT NULL, 
    [Ngaysinh] DATETIME NOT NULL, 
    [Gioitinh] NVARCHAR(10) NOT NULL, 
    [Diachi] NVARCHAR(300) NOT NULL
)

CREATE TABLE [dbo].[tblNXB]
(
	[MaNXB] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [TenNXB] NVARCHAR(50) NOT NULL, 
    [Diachi] NVARCHAR(300) NOT NULL, 
    [Dienthoai] NVARCHAR(20) NOT NULL 
)

CREATE TABLE [dbo].[tblNgonngu]
(
	[Mangonngu] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Tenngonngu] NVARCHAR(50) NOT NULL 
)

CREATE TABLE [dbo].[tblLoaisach]
(
	[Maloai] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Tenloai] NVARCHAR(50) NOT NULL 
)

CREATE TABLE [dbo].[tblSach]
(
	[Masach] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Tensach] NVARCHAR(50) NOT NULL, 
    [Maloai] NVARCHAR(50) NOT NULL, 
    [Malinhvuc] NVARCHAR(50) NOT NULL, 
    [Matacgia] NVARCHAR(50) NOT NULL, 
    [MaNXB] NVARCHAR(50) NOT NULL, 
    [Mangonngu] NVARCHAR(50) NOT NULL, 
    [Sotrang] FLOAT NOT NULL, 
    [Giasach] FLOAT NOT NULL, 
    [Dongiathue] FLOAT NOT NULL, 
    [Soluong] FLOAT NOT NULL, 
    [Anh] NVARCHAR(300) NOT NULL, 
    [Ghichu] NVARCHAR(300) NOT NULL,
	Foreign key (Maloai) references tblLoaisach (Maloai),
	Foreign key (Malinhvuc) references tblLinhvuc (Malinhvuc),
	Foreign key (Matacgia) references tblTacgia (Matacgia),
	Foreign key (MaNXB) references tblNXB (MaNXB),
	Foreign key (Mangonngu) references tblNgonngu (Mangonngu)
)

CREATE TABLE [dbo].[tblKhach]
(
	[Makhach] NVARCHAR(50) NOT NULL PRIMARY KEY, 
	[Tenkhach] NVARCHAR(50) NOT NULL, 
    [Ngaysinh] DATETIME NOT NULL, 
    [Gioitinh] NCHAR(10) NOT NULL, 
    [Diachi] NVARCHAR(300) NOT NULL,
)
--
CREATE TABLE [dbo].[tblCalam]
(
	[Maca] NVARCHAR(50) NOT NULL PRIMARY KEY, 
	[Tenca] NVARCHAR(50) NOT NULL, 
)

CREATE TABLE [dbo].[tblNV]
(
	[MaNV] NVARCHAR(50) NOT NULL PRIMARY KEY, 
	[TenNV] NVARCHAR(50) NOT NULL, 
    [Maca] NVARCHAR(50) NOT NULL, 
    [Namsinh] DATETIME NOT NULL, 
    [Gioitinh] NVARCHAR(10) NOT NULL, 
    [Diachi] NVARCHAR(300) NOT NULL, 
    [Dienthoai] NVARCHAR(20) NOT NULL, 
    [Luong] FLOAT NOT NULL,
	Foreign Key (Maca) references tblCalam(Maca)
)

CREATE TABLE [dbo].[tblTinhtrang]
(
	[MaTT] NVARCHAR(50) NOT NULL PRIMARY KEY, 
	[TenTT] NVARCHAR(50) NOT NULL, 
)

CREATE TABLE [dbo].[tblVipham]
(
	[MaVP] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [TenVP] NVARCHAR(50) NOT NULL, 
    [Tienphat] FLOAT NOT NULL 
)

CREATE TABLE [dbo].[tblHDThue]
(
	[Mathue] NVARCHAR(50) NOT NULL PRIMARY KEY, 
	[Makhach] NVARCHAR(50) NOT NULL, 
    [MaNV] NVARCHAR(50) NOT NULL, 
    [Ngaythue] DATETIME NOT NULL, 
    [Tiendatcoc] FLOAT NOT NULL, 
    Foreign key (Makhach) references tblKhach(Makhach),
	Foreign key (MaNV) references tblNV(MaNV),
)

CREATE TABLE [dbo].[tblHDTra]
(
	[Matra] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Mathue] NVARCHAR(50) NOT NULL, 
    [MaNV] NVARCHAR(50) NOT NULL, 
    [Ngaytra] DATETIME NOT NULL, 
    [Tongtien] FLOAT NOT NULL,
	Foreign key (Mathue) references tblHDThue(Mathue),
	Foreign key (MaNV) references tblNV(MaNV),
)

CREATE TABLE [dbo].[tblCTHDThue]
(
	[Mathue] NVARCHAR(50) NOT NULL , 
    [Masach] NVARCHAR(50) NOT NULL, 
    [MaTT] NVARCHAR(50) NOT NULL, 
    [Datra] NVARCHAR(10) NOT NULL, 
    PRIMARY KEY ([Mathue], [Masach]),
	foreign key (Mathue) references tblHDThue(Mathue),
	foreign key (Masach) references tblSach(Masach),
	foreign key ([MaTT]) references tblTinhtrang(MaTT),
)

CREATE TABLE [dbo].[tblCTHDTra]
(
	[Matra] NVARCHAR(50) NOT NULL , 
    [Masach] NVARCHAR(50) NOT NULL, 
    [MaVP] NVARCHAR(50) NOT NULL, 
    [Thanhtien] FLOAT NOT NULL, 
    PRIMARY KEY ([Matra], [Masach]),
	foreign key ([Matra]) references tblHDTra(Matra),
	foreign key (Masach) references tblSach(Masach),
	foreign key ([MaVP]) references tblVipham(MaVP),
)
