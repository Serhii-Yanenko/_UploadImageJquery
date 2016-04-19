create database if not exists 3dprinterua;
use 3dprinterua;
create table orderprint(
	id int not null auto_increment primary key,
    image1 nvarchar(250),
    image2 nvarchar(250),
    image3 nvarchar(250),
    image4 nvarchar(250),
    image5 nvarchar(250),
    isVerified boolean
);
