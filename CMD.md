## Commands

- https://raw.githubusercontent.com/dalers/mywind/master/northwind-erd.png

```
docker rm wk-mysql
docker run --name wk-mysql -e MYSQL_ROOT_PASSWORD=1234 -p 3306:3306 -d mysql
docker ps

create database DotNetDapper


mysql -u root -p -e "create database DotNetDapper"
mysql -u root -p DotNetDapper < resource/Northwind.MySql.Create.sql
mysql -u root -p DotNetDapper < resource/Northwind.MySql.Data.sql
1234
```