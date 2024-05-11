-- 2023-10-20
alter table news_order_list add COLUMN userid int;
-- news_comment
create TABLE news_comment(
     Id int AUTO_INCREMENT ,
     nickname varchar(50) not null,
     content varchar(2000) not null ,
     createtime DateTime,
     updatetime DateTime,
     state int default 0,
     parentid int ,
     userid   int ,
     likecount int default 0,
     hatecount int default 0,
     newsid int default 0,
     title  varchar(50)
     PRIMARY KEY (Id)


) ENGINE=InnoDB DEFAULT CHARSET=utf8;


--2023-10-24--
alter table news add COLUMN is_comment int default 0;

alter table news add COLUMN charge_type int default 0;