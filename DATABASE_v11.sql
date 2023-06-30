﻿
CREATE DATABASE QUAN_LY_SHOP_DA_QUY
GO
USE QUAN_LY_SHOP_DA_QUY

--NGUOIDUNG 1XXXX
--SANPHAM   2XXXX
--HOADON    3XXXX
--GIOHANG   4XXXX
--GIAOHANG  5XXXX



CREATE TABLE [dbo].[SANPHAM] (
    [MaSP]        INT IDENTITY(20000, 1)	NOT NULL,
    [TenSP]       NVARCHAR (30)				NOT NULL,
    [DVT]         NVARCHAR (10)				NOT NULL,
    [Gia]         INT						NOT NULL,
    [NuocSX]      NVARCHAR (50)				NOT NULL,
    [TenThuongHieu]        NVARCHAR (20)	NOT NULL,
    [TonKho]	  INT 						NOT	NULL,
	[HinhMinhHoa] VARCHAR(MAX),
    PRIMARY KEY CLUSTERED ([MaSP] ASC),
);

CREATE TABLE [dbo].[NGUOIDUNG] (
    [MaKH]     INT   IDENTITY(10000, 1)		NOT NULL,
    [DoanhSo]  INT          DEFAULT ((0))	NOT NULL,
    [DiaChi]   NVARCHAR (50)				NOT NULL,
    [SDT]      NCHAR (10)					NOT NULL,
	[UserName]   VARCHAR (20)				NOT NULL,
    [Password]   VARCHAR (20)				NOT NULL,
    [Permission] INT          DEFAULT ((0)) NOT NULL,
	[HoTen] NVARCHAR (20)					NOT NULL,
    PRIMARY KEY CLUSTERED ([MaKH] ASC),
);

CREATE TABLE [dbo].[GIAOHANG] (
    [MaGH]   INT   IDENTITY(50000, 1)		NOT NULL,
    [MaKH]   INT							NOT NULL,
    [SDT]    NCHAR (10)						NOT NULL,
    [DiaChi] NVARCHAR (50)					NOT NULL,
	[GhiChu] NVARCHAR (50),
    PRIMARY KEY CLUSTERED ([MaGH] ASC),
    CONSTRAINT [FK_GIAOHANG_NGUOIDUNG] FOREIGN KEY ([MaKH]) REFERENCES [dbo].[NGUOIDUNG] ([MaKH])
);


CREATE TABLE [dbo].[HOADON] (

    [MaHD]     INT   IDENTITY(30000, 1)		NOT NULL,
    [NgayHD]   DATETIME,
    [MaKH]     INT							NOT NULL,
    [TriGiaHD] INT,
    [MaGH] INT								NOT NULL, 
    PRIMARY KEY CLUSTERED ([MaHD] ASC),
    CONSTRAINT [FK_HOADON_NGUOIDUNG] FOREIGN KEY ([MaKH]) REFERENCES [dbo].[NGUOIDUNG] ([MaKH]), 
    CONSTRAINT [FK_HOADON_GIAOHANG] FOREIGN KEY ([MaGH]) REFERENCES [dbo].[GIAOHANG]([MaGH])
);


CREATE TABLE [dbo].[CTHD] (
    [MaHD]   INT							NOT NULL,
    [MaSP]   INT							NOT NULL,
    [SL]     INT							NOT NULL,
    PRIMARY KEY CLUSTERED ([MaHD] ASC, [MaSP] ASC),
    CONSTRAINT [FK_CTHD_SANPHAM] FOREIGN KEY ([MaSP]) REFERENCES [dbo].[SANPHAM] ([MaSP]), 
    CONSTRAINT [FK_CTHD_HOADON] FOREIGN KEY ([MaHD]) REFERENCES [dbo].[HOADON]([MaHD])
);

CREATE TABLE [dbo].[GIOHANG] (
    [MaKH]          INT						NOT NULL,
    [TriGiaGioHang] INT,
    PRIMARY KEY CLUSTERED (MaKH ASC),
    CONSTRAINT [FK_GIOHANG_NGUOIDUNG] FOREIGN KEY ([MaKH]) REFERENCES [dbo].[NGUOIDUNG] ([MaKH])
);

CREATE TABLE [dbo].[CTGH] (
	[MaKH]   INT							NOT NULL,
    [MaSP]   INT							NOT NULL,
    [SL]     INT							NOT NULL,
    PRIMARY KEY CLUSTERED ([MaKH] ASC, [MaSP] ASC),
    CONSTRAINT [FK_CTGH_SANPHAM] FOREIGN KEY ([MaSP]) REFERENCES [dbo].[SANPHAM] ([MaSP]),
    CONSTRAINT [FK_CTGH_GIOHANG] FOREIGN KEY ([MaKH]) REFERENCES [dbo].[GIOHANG] ([MaKH])
);
select *from NHACUNGCAP
CREATE TABLE NHACUNGCAP
(
  MaCC   INT IDENTITY(1000,1) NOT NULL,
  TenCC  NVARCHAR(50)         NOT NULL,
  DiaChi NVARCHAR(100)        NOT NULL,
  SoDT   NVARCHAR(15)         NOT NULL,
  CONSTRAINT PK_NHACUNGCAP PRIMARY KEY (MaCC)
)
insert into CTHD (MaHD, MaSP, SL) values (30020, 20004, 1)

CREATE TABLE PHIEUDV
(
  TenDV NVARCHAR(40)         NOT NULL,
  MaDV		INT,
  UserName	Varchar(20),
  TraTrc    INT DEFAULT ((0))     NOT NULL,
  NgGiao      DATETIME           ,
  TinhTrang Varchar(20),
  NgLap     DATETIME,
  TongTien  INT DEFAULT ((0))     NOT NULL,
  SL     INT	,
  SoDT   NVARCHAR(15)          ,
  DonGiaDV INT,
  DonGiaDT INT,
  SoPhieu  INT IDENTITY(20000, 1),
   PRIMARY KEY CLUSTERED (SoPhieu ASC),
)
GO
Drop table LOAIDICHVU


GO
--Delete data

--INSERT NHACUNGCAP
--INSERT NCC
select DIACHI, SoDT from NHACUNGCAP where tencc = N'Công ty Cổ phần Đại Phát Minh'
SELECT *FROM SANPHAM
INSERT INTO NHACUNGCAP (TenCC, DiaChi, SoDT) VALUES (N'Công ty TNHH Tâm Anh', N'Quận 1, Hồ Chí Minh', N'0823456789')
INSERT INTO NHACUNGCAP (TenCC, DiaChi, SoDT) VALUES (N'Công ty Cổ phần Đại Phát Minh', N'Tòa nhà Han River, Đà Nẵng', N'0865432109')
INSERT INTO NHACUNGCAP (TenCC, DiaChi, SoDT) VALUES (N'Công ty TNHH Thiên Hương', N'Quận Hoàn Kiếm, Hà Nội', N'0845678901')
INSERT INTO NHACUNGCAP (TenCC, DiaChi, SoDT) VALUES (N'Công ty Cổ phần Hải Đăng', N'Quận 3, Hồ Chí Minh', N'0832109876')
INSERT INTO NHACUNGCAP (TenCC, DiaChi, SoDT) VALUES (N'Công ty TNHH Sơn Hà', N'Hai Bà Trưng, Hà Nội', N'0854321098')
--INSERT NGUOIDUNG

select *from PHIEUDV
INSERT INTO NGUOIDUNG( DoanhSo, DiaChi, SDT, UserName, Password, Permission, HoTen ) VALUES ( 0, 'TPHCM', '0909090', 'NAM', '123123',  0, N'Nguyễn Hữu Nam')
INSERT INTO NGUOIDUNG( DoanhSo, DiaChi, SDT, UserName, Password, Permission, HoTen ) VALUES ( 0, 'TPHCM', '0909090', 'QUAN', '123123', 2, N'Đặng Hồ Anh Quân')
INSERT INTO NGUOIDUNG( DoanhSo, DiaChi, SDT, UserName, Password, Permission, HoTen ) VALUES ( 0, 'TPHCM', '0909090', 'MINH', '123123', 2, N'Văn Nhật Minh')
-- INSERT LOAIDICHVU
SELECT* from LOAIDICHVU
INSERT INTO LOAIDICHVU (LoaiDV, DonGia) VALUES (N'Cân thử',	100000)
INSERT INTO LOAIDICHVU (LoaiDV, DonGia) VALUES (N'Đánh bóng',	150000)
INSERT INTO LOAIDICHVU (LoaiDV, DonGia) VALUES (N'Gia công trang sức',	500000)
INSERT INTO LOAIDICHVU (LoaiDV, DonGia) VALUES (N'Chế tác trang sức',	1000000)
INSERT INTO LOAIDICHVU (LoaiDV, DonGia) VALUES (N'Định giá',	200000)
GO
SELECT TenDV, UserName, TraTrc, NgGiao, TinhTrang, NgLap,TongTien,SL,SoDT,DonGiaDV,DonGiaDT,SoPhieu 
FROM PHIEUDV

---INSERT SANPHAM
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Dây chuyền bạc', N'Cái', 3990000, N'Việt Nam', N'DOJI', 1000, 'Ag.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Dây chuyền vàng', N'Cái', 230000, N'Việt Nam', N'Đại Việt', 1000, 'Au.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Dây chuyền kim cương', N'Cái', 140000, N'Việt Nam', N'Đại Việt', 1000, 'kc.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Nhẫn bạc', N'Cặp', 130000, N'Việt Nam', N'DOJI', 1000, 'nag.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Nhẫn vàng', N'Cặp', 1150000, N'Việt Nam', N'DOJI', 1000, 'nau.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Nhẫn kim cương', N'Cặp', 520000, N'Việt Nam', N'DOJI', 1000, 'nkc.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Bông tay vàng', N'Cặp', 165000, N'Việt Nam', N'DOJI', 1000, 'btvang.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Vòng tay thạch anh', N'Cái', 12000, N'Việt Nam', N'DOJI', 1000, 'vttanh.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Lắc tay ruby', N'Cái', 145000, N'Việt Nam', N'Đại Việt', 1000, 'ruby.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Nhẫn rubyblue', N'Cái', 25000, N'Việt Nam', N'Đại Việt', 1000, 'rubyblue.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Bông Tai Ngọc Bích', N'Cặp', 240000, N'Việt Nam', N'Đại Việt', 1000, 'ngocbich.jpg')
INSERT INTO SANPHAM (TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) VALUES (N'Khuyên tai Peridot', N'Cặp', 2990000, N'Việt Nam', N'Đại Việt', 1000, 'peridot.jpg')

---INSERT PHIEUDV
INSERT INTO PHIEUDV(TenDV,MaDV, UserName, TraTrc, NgGiao, TinhTrang, NgLap, TongTien, SL,SoDT, DonGiaDV,DonGiaDT) VALUES (N'Sửa',10001, N'Minh', 100000, N'1-2-2022', N'ChuaGiao', N'1-1-2022', 1000000, N'2', N'1234567', 600000,70000)

Select *from HOADON

INSERT INTO CTGH (MaKH, MaSP, SL) VALUES (10000, 20001, 3)
INSERT INTO CTGH (MaKH, MaSP, SL) VALUES (10001, 20001, 2)

INSERT INTO PHIEUDV(TenDV, UserName, TraTrc, NgGiao, TinhTrang, NgLap,TongTien,SL,SoDT,DonGiaDV,DonGiaDT) VALUES(N'LamBong',N'Bao','50000',N'23-6-2022',N'ChuaGiao','20-6-2022',200000,1,'096321',20000,20000)
 
INSERT INTO GIAOHANG(MaKH, SDT, DiaChi, GhiChu) VALUES (10000, '003003', 'TPHCM', 'GC')
INSERT INTO GIAOHANG(MaKH, SDT, DiaChi, GhiChu) VALUES (10001, '004004', 'TPHCM', '')
INSERT INTO GIAOHANG(MaKH, SDT, DiaChi, GhiChu) VALUES (10001, '003004', 'TPHCM', '')

--INSERT HOADON


INSERT INTO HOADON  (NgayHD, MaKH, TriGiaHD, MaGH) VALUES ('2023-6-12', 10000, 0, 50000)
INSERT INTO HOADON  (NgayHD, MaKH, TriGiaHD, MaGH) VALUES ('2023-6-10', 10001, 0, 50001)
INSERT INTO HOADON  (NgayHD, MaKH, TriGiaHD, MaGH) VALUES ('2023-6-30', 10000, 0, 50001)


INSERT INTO CTHD (MaHD, MaSP, SL) VALUES (30000, 20001, 3)
INSERT INTO CTHD (MaHD, MaSP, SL) VALUES (30001, 20001, 2)

--

INSERT INTO PHIEUDV(TenDV, UserName, TraTrc, NgGiao, TinhTrang, NgLap,TongTien,SL,SoDT,DonGiaDV,DonGiaDT,SoPhieu) VALUES(N'hàn',N'quan','2000',N'10-1-2022','DaGiao','9-1-2022',10000,N'1',N'12122',2000030000,1)


/*			THEM		XOA			SUA
GIOHANG		 +(1)		 -			+(TriGiaGioHang)
CTGH		 +			 +			+(MaKH, MASP, SL)
SANPHAM		 -			 -			+(GIA)
(1) KIEM TRA TriGiaGioHang = 0
*/
-- INSERT GIOHANG: TRIGIAGIOHANG = 0
CREATE OR ALTER TRIGGER GH_CTGH_SP_TriGiaGioHang_INSERT
ON GIOHANG
FOR INSERT
AS
	--KHAI BAO BIEN
	DECLARE @MaKH INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaKH = MaKH FROM INSERTED
	--XU LY
	UPDATE GIOHANG SET TriGiaGioHang = 0 WHERE MaKH = @MaKH
	PRINT('Da update TriGiaGioHang = 0')

GO

--UPDATE GIOHANG
CREATE OR ALTER TRIGGER GioHang_CTGH_SP_TriGiaGioHang_UPDATE
ON GIOHANG
FOR UPDATE
AS 
	--KHAI BAO BIEN
	DECLARE @MaKH INT
	DECLARE @TriGiaGioHang INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaKH = MaKH FROM INSERTED
	
	SELECT @TriGiaGioHang = SUM(SL * GIA) 
	FROM SANPHAM, CTGH 
	WHERE SANPHAM.MASP = CTGH.MASP 
	AND MaKH = @MaKH 
	--XU LY
	SELECT @TriGiaGioHang = ISNULL(@TriGiaGioHang, 0)
	UPDATE GIOHANG SET TriGiaGioHang = @TriGiaGioHang WHERE MaKH = @MaKH
	PRINT('Da update TriGiaGioHang dung cho gio hang')

GO
--INSERT CTGH
CREATE OR ALTER TRIGGER CTGH_GioHang_SP_INSERT
ON CTGH
FOR INSERT
AS
	--KHAI BAO BIEN
	DECLARE @MaKH INT
	DECLARE @TriGiaGioHang INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaKH = MaKH FROM INSERTED
	
	SELECT @TriGiaGioHang = SUM(CTGH.SL * GIA)
	FROM SANPHAM, CTGH 
	WHERE SANPHAM.MASP = CTGH.MASP 
	AND MaKH = @MaKH 
	--XU LY
	UPDATE GIOHANG SET TriGiaGioHang = ISNULL(@TriGiaGioHang, 0) WHERE MaKH = @MaKH
	PRINT('Da update TriGiaGioHang moi cho gio hang')

GO
--DELETE CTGH
CREATE OR ALTER TRIGGER CTGH_GH_SP_DELETE
ON CTGH
FOR DELETE
AS 
	--KHAI BAO BIEN
	DECLARE @MaKH INT, @TriGiaGioHang INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaKH = MaKH FROM DELETED

	SELECT @TriGiaGioHang = SUM(CTGH.SL * GIA)
	FROM SANPHAM, CTGH 
	WHERE SANPHAM.MASP = CTGH.MASP 
	AND MaKH = @MaKH 
	--XU LY
UPDATE GIOHANG SET TriGiaGioHang = ISNULL(@TriGiaGioHang, 0) WHERE MaKH = @MaKH
	PRINT('Da update TriGiaGioHang moi cho gio hang')

GO
--UPDATE CTGH
CREATE OR ALTER TRIGGER CTGH_GH_SP_UPDATE
ON CTGH
FOR UPDATE
AS 
	--KHAI BAO BIEN
	DECLARE @MaKHCU INT, @TriGiaGioHangCU INT
	DECLARE @MaKHMOI INT, @TriGiaGioHangMOI INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaKHCU = MaKH FROM DELETED
	SELECT @MaKHMOI = MaKH FROM INSERTED

	SELECT @TriGiaGioHangCU = SUM(CTGH.SL * GIA) FROM SANPHAM, CTGH 
	WHERE SANPHAM.MASP = CTGH.MASP AND MaKH = @MaKHCU
	SELECT @TriGiaGioHangMOI = SUM(CTGH.SL * GIA) FROM SANPHAM, CTGH 
	WHERE SANPHAM.MASP = CTGH.MASP AND MaKH = @MaKHMOI 
	--XU LY
	UPDATE GIOHANG SET TriGiaGioHang = @TriGiaGioHangCU WHERE MaKH = @MaKHCU
	UPDATE GIOHANG SET TriGiaGioHang = @TriGiaGioHangMOI WHERE MaKH = @MaKHMOI
	PRINT('Da update TriGiaGioHang moi cho gio hang')

GO
--UPDATE SANPHAM
CREATE OR ALTER TRIGGER SP_CTGH_GH_UPDATE
ON SANPHAM
FOR UPDATE
AS 
	DECLARE @MASP INT
	SELECT @MASP = MASP FROM INSERTED

	SELECT * INTO TEMP FROM CTGH WHERE MASP = @MASP -- BANG TEMP CHUA CAC CTGH DA MUA @MASP

	WHILE (EXISTS (SELECT * FROM TEMP))
	BEGIN
		DECLARE @MaKH INT, @TriGiaGioHang INT
		SELECT TOP 1 @MaKH = MaKH FROM TEMP
		SELECT @TriGiaGioHang = SUM(CTGH.SL * GIA) FROM SANPHAM, CTGH 
		WHERE SANPHAM.MASP = CTGH.MASP AND MaKH = @MaKH 
		UPDATE GIOHANG SET TriGiaGioHang = @TriGiaGioHang WHERE MaKH = @MaKH
		DELETE FROM TEMP WHERE MaKH = @MaKH
	END
	DROP TABLE TEMP
	PRINT ('Da update TriGiaGioHang cua cac gio hang')

GO
--Update Service
--UPDATE Dich Vu


DROP TRIGGER CTHD_SP_UPDATE
--Trigger on CTHD, update SANPHAM.TonKho
--INSERT CTHD
CREATE OR ALTER TRIGGER CTHD_SP_INSERT
ON CTHD
FOR INSERT
AS
	--KHAI BAO BIEN
	DECLARE @MaSP INT, @SL INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaSP = MaSP, @SL = SL FROM INSERTED
	--XU LY
	UPDATE SANPHAM SET TonKho = TonKho - @SL WHERE MASP = @MaSP
	PRINT('Da update SL moi cho san pham')

GO
--DELETE CTHD
CREATE OR ALTER TRIGGER CTHD_SP_DELETE
ON CTHD
FOR DELETE
AS 
	--KHAI BAO BIEN
	DECLARE @MaSP INT, @SL INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaSP = MaSP, @SL = SL FROM DELETED
	--XU LY
	UPDATE SANPHAM SET TonKho = TonKho + @SL WHERE MASP = @MaSP
	PRINT('Da update SL moi cho san pham')

GO
--UPDATE CTHD
CREATE OR ALTER TRIGGER CTHD_SP_UPDATE
ON CTHD
FOR UPDATE
AS 
	--KHAI BAO BIEN
	DECLARE @MaSPCU INT, @SLCU INT
	DECLARE @MaSPMOI INT, @SLMOI INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaSPCU = MaSP, @SLCU = SL FROM DELETED
	SELECT @MaSPMOI = MaSP, @SLMOI = SL FROM INSERTED
	--XU LY
	UPDATE SANPHAM SET TonKho = TonKho + @SLCU - @SLMOI WHERE MASP = @MaSPCU
	PRINT('Da update SL moi cho san pham')
GO
select *from SANPHAM

/*			THEM		XOA			SUA
HOADON		 +(1)		 -			+(TriGiaHD)
CTHD		 +			 +			+(MaHD, MASP, SL)
SANPHAM		 -			 -			+(GIA)
(1) KIEM TRA TriGiaHD = 0
*/


-- INSERT HOADON: TriGiaHD = 0
CREATE OR ALTER TRIGGER HD_CTHD_SP_TriGiaHD_INSERT
ON HOADON
FOR INSERT
AS
	--KHAI BAO BIEN
	DECLARE @MaHD INT
	DECLARE @NgayHD DATETIME
	--GAN GIA TRI CHO BIEN
	SELECT @MaHD = MaHD FROM INSERTED
	SELECT @NgayHD = NgayHD FROM INSERTED
	--XU LY
	SELECT @NgayHD = ISNULL(@NgayHD, GETDATE())
	UPDATE HOADON SET TriGiaHD = 0, NgayHD = @NgayHD WHERE MaHD = @MaHD
	PRINT('Da update TriGiaHD = 0')

GO

--UPDATE HOADON
CREATE OR ALTER TRIGGER HD_CTHD_SP_TriGiaHD_UPDATE
ON HOADON
FOR UPDATE
AS 
	--KHAI BAO BIEN
	DECLARE @MaHD INT
	DECLARE @TriGiaHD INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaHD = MaHD FROM INSERTED
	
	SELECT @TriGiaHD = SUM(SL * GIA) 
	FROM SANPHAM, CTHD 
	WHERE SANPHAM.MASP = CTHD.MASP 
	AND MaHD = @MaHD 
	--XU LY
	SELECT @TriGiaHD = ISNULL(@TriGiaHD, 0)
	UPDATE HOADON SET TriGiaHD = @TriGiaHD WHERE MaHD = @MaHD
	PRINT('Da update TriGiaHD dung cho hoa don')

GO
--INSERT CTHD
CREATE OR ALTER TRIGGER CTHD_HD_SP_INSERT
ON CTHD
FOR INSERT
AS
	--KHAI BAO BIEN
	DECLARE @MaHD INT
	DECLARE @TriGiaHD INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaHD = MaHD FROM INSERTED
	
	SELECT @TriGiaHD = SUM(CTHD.SL * GIA)
	FROM SANPHAM, CTHD 
	WHERE SANPHAM.MASP = CTHD.MASP 
	AND MaHD = @MaHD 
	--XU LY
	UPDATE HOADON SET TriGiaHD = @TriGiaHD WHERE MaHD = @MaHD
	PRINT('Da update TriGiaHD moi cho hoa don')

GO
--DELETE CTHD
CREATE OR ALTER TRIGGER CTHD_HD_SP_DELETE
ON CTHD
FOR DELETE
AS 
	--KHAI BAO BIEN
	DECLARE @MaHD INT, @TriGiaHD INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaHD = MaHD FROM DELETED

	SELECT @TriGiaHD = SUM(CTHD.SL * GIA)
	FROM SANPHAM, CTHD 
	WHERE SANPHAM.MASP = CTHD.MASP 
	AND MaHD = @MaHD 
	--XU LY
	UPDATE HOADON SET TriGiaHD = ISNULL(@TriGiaHD, 0) WHERE MaHD = @MaHD
	PRINT('Da update TriGiaHD moi cho hoa don')

GO
--UPDATE CTHD
CREATE OR ALTER TRIGGER CTHD_HD_SP_UPDATE
ON CTHD
FOR UPDATE
AS 
	--KHAI BAO BIEN
	DECLARE @MaHDCU INT, @TriGiaHDCU INT
	DECLARE @MaHDMOI INT, @TriGiaHDMOI INT
	--GAN GIA TRI CHO BIEN
	SELECT @MaHDCU = MaHD FROM DELETED
	SELECT @MaHDMOI = MaHD FROM INSERTED

	SELECT @TriGiaHDCU = SUM(CTHD.SL * GIA) FROM SANPHAM, CTHD 
	WHERE SANPHAM.MASP = CTHD.MASP AND MaHD = @MaHDCU
	SELECT @TriGiaHDMOI = SUM(CTHD.SL * GIA) FROM SANPHAM, CTHD 
	WHERE SANPHAM.MASP = CTHD.MASP AND MaHD = @MaHDMOI 
	--XU LY
	UPDATE HOADON SET TriGiaHD = @TriGiaHDCU WHERE MaHD = @MaHDCU
	UPDATE HOADON SET TriGiaHD = @TriGiaHDMOI WHERE MaHD = @MaHDMOI
	PRINT('Da update TriGiaHD moi cho hoa don')

GO
--UPDATE SANPHAM
CREATE OR ALTER TRIGGER SP_CTHD_HD_UPDATE
ON SANPHAM
FOR UPDATE
AS 
	DECLARE @MASP INT
	SELECT @MASP = MASP FROM INSERTED

	SELECT * INTO TEMP FROM CTHD WHERE MASP = @MASP -- BANG TEMP CHUA CAC CTHD DA MUA @MASP

	WHILE (EXISTS (SELECT * FROM TEMP))
	BEGIN
		DECLARE @MaHD INT, @TriGiaHD INT
		SELECT TOP 1 @MaHD = MaHD FROM TEMP
		SELECT @TriGiaHD = SUM(CTHD.SL * GIA) FROM SANPHAM, CTHD 
		WHERE SANPHAM.MASP = CTHD.MASP AND MaHD = @MaHD 
		UPDATE HOADON SET TriGiaHD = @TriGiaHD WHERE MaHD = @MaHD
		DELETE FROM TEMP WHERE MaHD = @MaHD
	END
	DROP TABLE TEMP
	PRINT ('Da update TriGiaHD cua cac hoa don')

GO

--15 DOANHSO = SUM(HOADON.TriGiaHD) 
/*			THEM		XOA			SUA
HOADON		 +			 +			+(MAKH, TriGiaHD)
NGUOIDUNG	 +(1)		 -			+(DOANHSO)
*/
--(1) KIEM TRA DOANHTHU = 0
--INSERT NGUOIDUNG
CREATE OR ALTER TRIGGER KH_HD_INSERT
ON NGUOIDUNG
FOR INSERT
AS
	--KHAI BAO BIEN
	DECLARE @MAKH INT
	--GAN GIA TRI CHO BIEN
	SELECT @MAKH = MAKH FROM INSERTED
	--XU LY
	UPDATE NGUOIDUNG SET DOANHSO = 0 WHERE MAKH = @MAKH
	PRINT('Da update DOANHSO = 0')

	INSERT INTO GIOHANG(MaKH) VALUES (@MAKH)

GO

--UPDATE NGUOIDUNG
CREATE OR ALTER TRIGGER KH_HD_UPDATE
ON NGUOIDUNG
FOR UPDATE
AS
	--KHAI BAO BIEN
	DECLARE @DOANHSO MONEY
	DECLARE @MAKH INT
	--GAN GIA TRI CHO BIEN
	SELECT @MAKH = MAKH FROM INSERTED

	SELECT @DOANHSO = SUM(TriGiaHD) FROM HOADON, INSERTED
	WHERE HOADON.MAKH = @MAKH
	--XU LY
	SELECT @DOANHSO = ISNULL(@DOANHSO, 0)
	UPDATE NGUOIDUNG SET DOANHSO = @DOANHSO WHERE MAKH = @MAKH
	PRINT ('Da update DOANHSO cua khach hang')

GO
--INSERT, UPDATE HOADON
CREATE OR ALTER TRIGGER HD_KH_INSERT_UPDATE
ON HOADON
FOR INSERT, UPDATE
AS
	--KHAI BAO BIEN	
	DECLARE @DOANHSO MONEY
	DECLARE @MAKH INT
	--GAN GIA TRI CHO BIEN
	SELECT @MAKH = MAKH FROM INSERTED

	SELECT @DOANHSO = SUM(HOADON.TriGiaHD) FROM HOADON, INSERTED
	WHERE HOADON.MAKH = @MAKH
	--XU LY
SELECT @DOANHSO = ISNULL(@DOANHSO, 0)
	UPDATE NGUOIDUNG SET DOANHSO = @DOANHSO WHERE MAKH = @MAKH
	PRINT ('Da update DOANHSO cua khach hang')

GO
--DELETE HOADON
CREATE OR ALTER TRIGGER HD_KH_DELETE
ON HOADON
FOR DELETE
AS
	--KHAI BAO BIEN	
	DECLARE @DOANHSO MONEY
	DECLARE @MAKH INT
	--GAN GIA TRI CHO BIEN
	SELECT @MAKH = MAKH FROM DELETED

	SELECT @DOANHSO = SUM(HOADON.TriGiaHD) FROM HOADON, DELETED
	WHERE HOADON.MAKH = @MAKH
	--XU LY
	SELECT @DOANHSO = ISNULL(@DOANHSO, 0)
	UPDATE NGUOIDUNG SET DOANHSO = @DOANHSO WHERE MAKH = @MAKH
	PRINT ('Da update DOANHSO cua khach hang')
GO

-- PhieuDV of MaPDV = 30000
DECLARE @MaPDV INT = 30001

SELECT SoPhieu = MaPDV, NgayLap = NgLap, KhachHang = TenHK, SDT = SDT, TongTien, TraTrc, ConLai = TongTien - TraTrc, TinhTrang
FROM PHIEUDV
WHERE MaPDV = @MaPDV

SELECT LoaiDichVu = LoaiDV, DonGiaDichVu = DonGia, DonGiaDuocTinh = DonGia + PhuPhi, SoLuong = CTPDV.SL, ThanhTien = CTPDV.SL * (DonGia + PhuPhi), TraTrc = CTPDV.TraTrc, ConLai = CTPDV.SL * (DonGia + PhuPhi) - CTPDV.TraTrc, NgayGiao = NgGiao, CTPDV.TinhTrang
FROM CTPDV, LOAIDICHVU
WHERE CTPDV.MaDV = LOAIDICHVU.MaDV
AND CTPDV.MaPDV = @MaPDV
GO



Select *from SANPHAM

Delete from SANPHAM
where MaSP='20012'