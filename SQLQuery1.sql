create database ShopBIu;
go
use ShopBIu;
create table Tb_Staff(
	Staff_Id nvarchar(7) primary key,
	Staff_Name nvarchar(55),
	Username nvarchar (55),
	Passwordx nvarchar(55)
);

create table Tb_Categories(
Category_Id int primary key,
Category_Name nvarchar(50),
Pictrue nvarchar(255),
);

create table Tb_Products(
 Product_Id int primary key,
    Product_Name nvarchar(100),
    Category_Id int,
    Price decimal(10,2),
    Descriptions nvarchar(255),
    foreign key (Category_Id) references Tb_Categories(Category_Id)
);

create table Tb_Customers (
    Customer_Id int primary key,
    Customer_Name nvarchar(100),
    Email NVARCHAR(100),
    Addresz nvarchar(255),
    Phone nvarchar(20)
);

create table Tb_Carts (
    Cart_Id int primary key,
    Customer_Id int,
    CreatedDate DATETIME,
    foreign key (Customer_Id) references Tb_Customers(Customer_Id)
);

create table Tb_Cart_Detail (
    CartDetail_Id int primary key,
    Cart_Id int,
    Product_Id int,
    Quantity int,
    foreign key (Cart_Id) references Tb_Carts(Cart_Id),
    foreign key (Product_Id) references Tb_Products(Product_Id)
);


--Dữ liệu
insert into Tb_Categories (Category_Id, Category_Name, Pictrue) values
(01,'LAPTOP',N'Laptop'),
(02,'SMART PHONE',N'Smart'),
(03,'PC',N'Pc');


-- Thêm dữ liệu vào bảng Products
insert into Tb_Products (Product_Id, Product_Name, Category_Id, Price, Descriptions) values
(001, 'Laptop Asus B1402CVA', 01, 13000000,N'laptop1.jpg'),
(002, 'Laptop Asus TUF Gaming A15', 01, 23000000,N'laptop2.jpg'),
(003, 'Laptop ASUS Vivobook 15 ', 01, 17000000,N'laptop3.jpg'),
(004, 'Laptop Asus Zenbook 14 OLED', 01, 19000000,N'laptop4.jpg'),
(005, 'Laptop Asus ROG Zephyrus G14', 01, 25000000,N'laptop5.jpg'),
(006, 'Laptop Asus ExpertBook B1500CEAE', 01, 21000000,N'laptop6.jpg'),
(007, 'Laptop Asus ROG Zephyrus G16', 01, 23000000,N'laptop7.jpg'),
(008, 'Laptop Asus ROG Zephyrus M16 ', 01, 33000000,N'laptop8.jpg');

-- Thêm dữ liệu vào bảng Customers
insert into Tb_Customers (Customer_ID, Customer_Name, Email, Addresz, Phone) values
(2705, N'Lê Quốc Anh', 'qanh@gmail.com', N'03 Mai Thúc Loan, Gia Lai', '0335543069'),
(0309, N'Trần Bảo Hân', 'han@gmail.com', N'09 Điện Biên Phủ, Đà Nẵng', '0958371345'),
(2810, N'Lê Tiến Đạt', 'dat@gmail.com', N'14 Lê Lợi, Hà Nội', '091243544');