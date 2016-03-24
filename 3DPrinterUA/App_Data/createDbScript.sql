create database if not exists 3dprinterua;
use 3dprinterua;
create table orderprint(
	id int not null auto_increment primary key,
    image1 longblob,
    image2 longblob,
    image3 longblob,
    image4 longblob,
    image5 longblob,
    isVerified boolean
);

