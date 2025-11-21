/*
------------------------------------------ DATABASE					- Tạo/ xóa database

- Tao CSDL :
	CREATE DATABASE LienQuanDB;
	GO

- Xoa CSDL :
	DROP DATABASE LienQuanDB;

- Mo DB :
	USE LienQuanDB;
	GO

------------------------------------------ TABLE 					– Tạo, xóa bảng

- Vi du : 
	CREATE TABLE Vidu (
		matchID INT,
		modeID INT,
		vidu1 CHAR(10),
		FOREIGN KEY (matchID) REFERENCES Matchs(matchID),
		FOREIGN KEY (modeID) REFERENCES Mode(modeID),
		PRIMARY KEY(matchID, modeID) --Truong hop co 2 PK 
);

- Xóa bảng neu ton tai
	DROP TABLE IF EXISTS table_name;

- INTO table : Copy bang
	SELECT column1, column2, ...
		INTO NewTable
		FROM ExistingTable
		WHERE điều_kiện;

------------------------------------------ ALTER TABLE [Table]		– Thay đổi cấu trúc bảng

ALTER TABLE Vidu
	ADD vidu2 VARCHAR(100) NOT NULL;
		vidu3 INT DEFAULT 0;
		--Tao nhieu bang vidu4 ...

ALTER TABLE Vidu
	DROP COLUMN vidu2, vidu3; 


- Thay đổi thuộc tính của cột hiện có (kiểu dữ liệu, NULL/NOT NULL)
	ALTER TABLE Vidu
	ALTER COLUMN vidu1 VARCHAR(55) NOT NULL;


- Thêm ràng buộc (constraint) như PRIMARY KEY, FOREIGN KEY, UNIQUE, CHECK, DEFAULT
	ALTER TABLE Vidu
	ADD CONSTRAINT vidu2 DEFAULT 0 FOR vidu2;

- Xoa rang buoc
	ALTER TABLE Vidu
	DROP CONSTRAINT vidu2;


------------------------------------------ INSERT INTO [Table]		– them du lieu vao bảng

INSERT INTO Mode	(Nếu có khóa chính là IDENTITY(1, 1)
	VALUES  ('5v5', 'Dau thuong'),
			('Rank', 'Dau rank'),
			('3v3', 'Dau 3v3'),
			('Dau moc', 'Che do giai tri'),
			('Dua xe', 'Che do giai tri');

INSERT INTO Matchs(matchTime, matchStatus, modeID)
	VALUES ('2025-7-15', 0, 3),
		   ('2024-3-11', 1, 5);	

INSERT INTO Vidu
	VALUES	(1, 5,'vd1', 'vd2', 3);

------------------------------------------ SELECT					- Tao 1 bang tam thoi

SELECT * FROM table									-- *: lay tat ca cac cot, theo thu tu mac dinh
SELECT modename, modeID FROM table;					-- Lay tat ca cac cot duoc chi dinh
SELECT TOP n column1, column2,... FROM table;		-- Lay n so cac cot duoc chi dinh
SELECT DISTINCT * / column FROM table;				-- Loai bo cac du lieu trung lap
SELECT * FROM table ORDER BY column ASC/DESC;		-- ASC Tang dan , DESC Giam dan
SELECT * FROM table WHERE (column > 12 AND/OR column2 = N'abc');	

-Cac phep so sanh:
	1. >, <, >=, <= 
	2. <>, != khac
	3. = : Chi chon chuoi giong nhau	
		VD: → Chỉ chọn dòng có Name đúng chính xác là "An" (không phải "Anh", "Lan", "Tan", v.v.).
	4. LIKE :
		[%] : Đại diện cho bất kỳ chuỗi nào, kể cả chuỗi rỗng. Có thể là 0 hoặc nhiều ký tự.
		WHERE Name LIKE 'A%'    -- bắt đầu bằng A (A, An, Anh, Anny...)
		WHERE Name LIKE '%n'    -- kết thúc bằng n (Lan, An, Tuan...)
		WHERE Name LIKE '%an%'  -- chứa chuỗi "an" ở bất kỳ đâu (An, Lan, Tuan, Anh...)
		
		[_] : Đại diện cho chính xác 1 ký tự bất kỳ. 
		WHERE Name LIKE '_an'   -- có đúng 3 ký tự, kết thúc bằng "an" (Lan, Ban, Can...)
		WHERE Name LIKE 'A__'   -- bắt đầu bằng A, sau đó là 2 ký tự bất kỳ (Anh, Anh, Ana, etc.)
	5. BETWEEN 3 AND 5  <=>  <= 3 AND >= 5


------------------------------------------ DATETIME					- Thời gian				yyyy-mm-dd

SELECT								--→ Trả về năm, tháng, ngày hiện tại.
	YEAR(GETDATE()) AS Nam,
	MONTH(GETDATE()) AS Thang,
	DAY(GETDATE()) AS Ngay;	

SELECT GETDATE();					--→ Tra ve gio hien tai


SELECT DATEDIFF(datepart, start_date, end_date) AS ...;
				year	
				month	
				day	
				hour
				minute
				second
- Ví dụ : 
	DATEDIFF(year, '2005-07-19', '2025-07-19') AS sonam,
	DATEDIFF(month, '2005-07-19', '2025-07-19') AS sothanng,
	DATEDIFF(day, '2005-07-19', '2025-07-19') AS songay;

- AS: Dùng để đặt bí danh (alias) cho cột hoặc bảng trong truy vấn.


------------------------------------------ JOIN					

JOIN:	Chỉ lấy những dòng có kết quả khớp giữa hai bảng theo điều kiện ON.

LEFT JOIN:	Lấy tất cả dữ liệu bên trái (A).
			Nếu không có khớp với bảng bên phải (B), phần từ bảng B sẽ là NULL.

RIGHT JOIN:	Ngược lại với LEFT JOIN. 

FULL JOIN:	Lấy tất cả dòng từ cả hai bảng.
			Dòng nào không có kết quả khớp sẽ có NULL ở phía không có dữ liệu.

	
- GROUP BY :
	COUNT MIN MAX AVARAGE SUM
	Meo "O select co gi thi trong group by cung"

- IN :
	SELECT * FROM table				-- or
	WHERE row IN ('A', 'B', 'C');	-- kiem tra xem co dung 1 trong 3 khong

- Truy vấn lồng :
	Từ khóa		Ý nghĩa						Subquery trả về			Ví dụ
	--------------------------------------------------------------------------------------
	IN			Có trong danh sách			Danh sách nhiều dòng	IN (SELECT...)
	=			Bằng giá trị				1 dòng 1 cột			= (SELECT MAX(...))
	<, >		So sánh						1 dòng 1 cột			> (SELECT AVG(...))
	EXISTS		Kiểm tra có dòng nào		0 hoặc nhiều dòng		EXISTS (SELECT...)
	ANY			So sánh với ít nhất 1		Nhiều giá trị			> ANY (SELECT...)
	ALL			So sánh với tất cả			Nhiều giá trị			> ALL (SELECT...)


------------------------------------------ UPDATE/DELETE					- Cập nhât/ xóa dữ liệu trong bảng

 - UPDATE :
	UPDATE table_name
		SET column1 = value1,
		column2 = value2,
		...
		WHERE condition;

 - DELETE : 
	DELETE FROM ten_bang
	WHERE dieu_kien;
*/
