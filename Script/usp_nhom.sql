/*----------------------------------------------------------
MASV:
HO TEN CAC THANH VIEN NHOM:
LAB: 03 - NHOM
NGAY:
----------------------------------------------------------*/
-- CAU LENH TAO STORED PROCEDURE
--USE MASTER
USE QLSVNhom
GO

-- procedure lab ca nhan
CREATE OR ALTER PROCEDURE SP_INS_SINHVIEN(
    @MASV NVARCHAR(20),
    @HOTEN NVARCHAR(100),
    @NGAYSINH DATETIME,
    @DIACHI NVARCHAR(200),
    @MALOP VARCHAR(20),
    @TENDN NVARCHAR(100),
    @MATKHAU VARCHAR = '123'
)
AS
    INSERT INTO SINHVIEN VALUES(@MASV, @HOTEN, @NGAYSINH, @DIACHI, @MALOP, @TENDN, HashBytes('MD5', @MATKHAU))
GO
--EXEC SP_INS_SINHVIEN N'SV01', 'NGUYEN THE ANH', '1/1/1990', '280 AN DUONG VUONG', 'CNTT-K35', 'VA', '123456'
GO
-- i)
--DROP PROCEDURE SP_INS_PUBLIC_NHANVIEN
CREATE OR ALTER PROCEDURE SP_INS_PUBLIC_NHANVIEN(
    @MANV VARCHAR(20),
    @HOTEN NVARCHAR(100),
    @EMAIL VARCHAR(20),
    @LUONGCB INT,
    @TENDN NVARCHAR(100),
    @MK NVARCHAR(20)
)
AS
    EXECUTE('CREATE ASYMMETRIC KEY ' + @MANV + ' WITH ALGORITHM = RSA_2048 ENCRYPTION BY PASSWORD = ''' + @MK + '''')
	DECLARE @LUONG VARBINARY(2048)
    SET @LUONG = ENCRYPTBYASYMKEY(ASYMKEY_ID(@MANV), CONVERT(VARCHAR(20), @LUONGCB))
	-- Table NhanVien (MANV, HOTEN, EMAIL, LUONG, TENDN, MATKHAU, PUBKEY)
    INSERT INTO NHANVIEN VALUES(@MANV, @HOTEN, @EMAIL,@LUONG, @TENDN, HashBytes('SHA1', @MK), CONVERT(VARBINARY(64), @MANV))
GO

--EXEC SP_INS_PUBLIC_NHANVIEN 'NV01', 'NGUYEN THE ANH', 'NTA@', 3000000, 'NTA', N'abcd12'
SELECT * FROM NHANVIEN
--DELETE FROM NHANVIEN WHERE MANV = 'NV01'
GO


-- ii)
CREATE OR ALTER PROCEDURE SP_SEL_PUBLIC_NHANVIEN(
    @TENDN NVARCHAR(100),
    @MK VARCHAR(20)
)
AS
    SELECT MANV, 
		HOTEN,
		EMAIL, 
		CONVERT(VARCHAR(64), DECRYPTBYASYMKEY(ASYMKEY_ID(@TENDN), 
			NV.LUONG, 
			CONVERT(NVARCHAR(20), @MK))) 
			AS LUONGCB
	FROM NHANVIEN NV;
GO

--EXEC SP_SEL_PUBLIC_NHANVIEN 'NV01', N'123456'
GO

--DROP ASYMMETRIC KEY NV01

-- d)
-- Tao user NVA, NVB
--EXEC SP_INS_PUBLIC_NHANVIEN 'NV01', 'NGUYEN VAN A', 'nva@yahoo.com', 3000000, 'NVA', N'123456'
--EXEC SP_INS_PUBLIC_NHANVIEN 'NV02', 'NGUYEN VAN B', 'nvb@yahoo.com', 2000000, 'NVB', N'1234567'
GO
-- SELECT * FROM NHANVIEN

-- procedure list class
create or alter procedure class_list
as
	DECLARE cur CURSOR 
	FOR	SELECT * FROM LOP
	OPEN cur
	FETCH NEXT FROM cur
	CLOSE cur
	DEALLOCATE cur
GO

--INSERT INTO LOP VALUES('l1', 'lop 1', 'NV01')
--DELETE FROM LOP WHERE Malop = 'l1' 
EXEC class_list
GO

create or alter procedure class_list_nhanvien(
	@MANV VARCHAR(20)
)
as
	DECLARE cur CURSOR 
	FOR	SELECT sv.masv as 'Mã sinh viên', sv.hoten as 'Họ tên', sv.ngaysinh as 'Ngày sinh', sv.diachi as 'Địa chỉ', sv.malop as 'Mã lớp', sv.tendn as 'Tên đăng nhập' 
		FROM SINHVIEN sv join LOP l ON sv.MALOP = l.MALOP
		                 join NHANVIEN nv on nv.MANV = l.MANV
		WHERE nv.MANV = @MANV;
	OPEN cur
	FETCH NEXT FROM cur
	CLOSE cur
	DEALLOCATE cur
GO
EXEC class_list_nhanvien 'NV01';

GO

-- procedure list student
CREATE or ALTER PROCEDURE student_list(
	@MALOP VARCHAR(20)
)
AS
	DECLARE cur CURSOR 
	FOR	SELECT masv as 'Mã sinh viên', hoten as 'Họ tên', ngaysinh as 'Ngày sinh', diachi as 'Địa chỉ', malop as 'Mã lớp', tendn as 'Tên đăng nhập' FROM SINHVIEN WHERE MALOP=@MALOP
	OPEN cur
	FETCH NEXT FROM cur
	CLOSE cur
	DEALLOCATE cur
GO

EXEC student_list 'CNTT-K35'
GO

-- procedure update student
CREATE or ALTER PROCEDURE student_update(
	@MaNV varchar(20),
	@MaSV NVARCHAR(20),
    @HOTEN as NVARCHAR(100) = NULL,
    @NGAYSINH as DATETIME = NULL,
    @DIACHI as NVARCHAR(200) = NULL,
    @MALOP as VARCHAR(20) = NULL,
    @TENDN as NVARCHAR(100) = NULL,
    @MAHP as VARCHAR(20) = NULL,
    @DIEM as INT = NULL
)
AS
    BEGIN
        DECLARE cur CURSOR
        FOR SELECT NV.MANV, SV.MASV, SV.HOTEN, SV.NGAYSINH, SV.DIACHI, SV.MALOP, SV.TENDN, D.MAHP, D.DIEMTHI
            FROM SINHVIEN SV JOIN BANGDIEM D ON SV.MASV = D.MASV
                JOIN LOP ON SV.MALOP = LOP.MALOP
                JOIN NHANVIEN NV ON NV.MANV = LOP.MANV
            WHERE SV.MASV = @MaSV AND NV.MANV = @MaNV
    END

    -- update if not null
    BEGIN
        -- UPDATE INFO
        OPEN cur
        FETCH NEXT FROM cur
		IF @@FETCH_STATUS != -1
        BEGIN        
			IF @HOTEN IS NOT NULL
				UPDATE SINHVIEN SET HOTEN = @HOTEN WHERE MASV = @MaSV
			IF @NGAYSINH IS NOT NULL
				UPDATE SINHVIEN SET NGAYSINH = @NGAYSINH WHERE MASV = @MaSV
			IF @DIACHI IS NOT NULL
				UPDATE SINHVIEN SET DIACHI = @DIACHI WHERE MASV = @MaSV
			IF @TENDN IS NOT NULL
				UPDATE SINHVIEN SET TENDN = @TENDN WHERE MASV = @MaSV
			-- UPDATE SCORE
			IF @DIEM IS NOT NULL AND @MAHP IS NOT NULL
			BEGIN
				DECLARE @encryptedScore VARBINARY(2048)
				SET @encryptedScore = ENCRYPTBYASYMKEY(ASYMKEY_ID(@MANV), CONVERT(VARCHAR(20), @DIEM))
				UPDATE BANGDIEM SET DIEMTHI = @encryptedScore WHERE MASV = @MaSV AND MAHP = @MAHP
			END
		END
        CLOSE cur
        DEALLOCATE cur   
    END
GO

EXEC student_update 'NV01', 'SV01', NULL, NULL, 'cp525ck', NULL, NULL, 'HP2', 10 

GO

CREATE OR ALTER PROCEDURE STUDENT_DELETE(
	@MASV VARCHAR(20)
)
AS
BEGIN

	DELETE FROM BangDiem WHERE MASV = @MASV;
	DELETE FROM SINHVIEN WHERE MASV = @MASV;

END;
GO

EXEC STUDENT_DELETE 'SV05';


		
-- View deciphered score below

------------------------
-- Insert and show data
------------------------
SELECT * FROM SINHVIEN
--EXEC SP_INS_SINHVIEN N'SV02', 'NGUYEN THE ANH', '1/1/2000', '280 AN DUONG VUONG', 'SH-K35', 'VA', '123456'
--EXEC SP_INS_SINHVIEN 'SV03','ABC','1/1/2012','100','CNTT-K35','VB'
SELECT * FROM NHANVIEN
--EXEC SP_INS_PUBLIC_NHANVIEN 'NV01', 'NGUYEN VAN A', 'nva@yahoo.com', 3000000, 'NVA', N'123456'

SELECT * FROM LOP
--INSERT INTO LOP VALUES('CNTT-K35', 'CNTT', 'NV01')
--INSERT INTO LOP VALUES('SH-K35', 'SH', 'NV02')

SELECT * FROM HocPhan
--INSERT INTO HocPhan VALUES('HP1', 'TOAN', 2)
--INSERT INTO HocPhan VALUES('HP2', 'LY', 2)

SELECT * FROM BANGDIEM
--INSERT INTO BANGDIEM VALUES('SV01', 'HP1', 5)
--INSERT INTO BANGDIEM VALUES('SV01', 'HP2', 10)

--------------------------
-- Test encrypt DIEMTHI
--------------------------
--SELECT SV1.MASV, BD.MAHP, CONVERT(VARCHAR(64), DECRYPTBYASYMKEY(ASYMKEY_ID('NV01'), 
--				BD.DiemThi, 
--				N'123456')) 
--FROM NHANVIEN NV1 JOIN LOP ON LOP.MANV = NV1.MANV JOIN SINHVIEN SV1 ON SV1.MALOP = LOP.MALOP JOIN BangDiem BD ON BD.MaSV = SV1.MASV
