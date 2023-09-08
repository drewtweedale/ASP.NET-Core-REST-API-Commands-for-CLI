# ASP.NET Core REST API: Commands for CLI

_Since my memory is terrible, this API helps keep track of CLI commands. The API stores the command, what it does, and what platform it's from._

_Apologies for the excessive comments, but they are when reviewing the code_

_Credits: Les Jackson: https://www.youtube.com/watch?v=fmvcAzHpsk8&t=128s_

## Through this project, I learned and practiced concepts such as:
> * _MVC Architecture_
> * _.NET Core_
> * _C#_

## Namely, the tools/concepts I got familiar with were:
> * _Designing repositories_
> * _SQL Server Express_
> * _Dependency Injection_
> * _Entity Framework Core_
> * _RESTful API best practices_
> * _HTTP Requests( GET, POST, PUT, PATCH, DELETE)_
> * _Data Transfer Objects / AutoMapper_
> * _Postman_

## Application Architecture
![image](https://user-images.githubusercontent.com/49925421/90770546-3bb67e00-e2f2-11ea-8932-17345061ae3c.png)

## Below are a couple examples of HTTP requests and their outputs on Postman

### General GET Request: Returns all command line snippets stored in the database and returns '200 OK' Status Code
![image](https://private-user-images.githubusercontent.com/137343812/266471029-2c10d781-aba0-4ba4-8a5c-e6ad2bd70b76.PNG?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTEiLCJleHAiOjE2OTQxMzQwMTEsIm5iZiI6MTY5NDEzMzcxMSwicGF0aCI6Ii8xMzczNDM4MTIvMjY2NDcxMDI5LTJjMTBkNzgxLWFiYTAtNGJhNC04YTVjLWU2YWQyYmQ3MGI3Ni5QTkc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBSVdOSllBWDRDU1ZFSDUzQSUyRjIwMjMwOTA4JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDIzMDkwOFQwMDQxNTFaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT04MzBlOGU1OTBhNmMwNWFkNjVjY2NjY2NkZDFlMjAzYzMwY2MwZTkzNjU1NmY5YTFlOGFkNGNhZDRjOTMyYWJmJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.YNc_4xFuqdM4OcqA7dgEL21FT_xWMbcO70PjSv6VZew)

### POST Request: Adds a new command to the database with a location header, and yields a '201 Created' status code
![image](https://private-user-images.githubusercontent.com/137343812/266471854-c5a4ada4-2e2c-4277-b273-3f27ebb11aba.PNG?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTEiLCJleHAiOjE2OTQxMzQ0NTYsIm5iZiI6MTY5NDEzNDE1NiwicGF0aCI6Ii8xMzczNDM4MTIvMjY2NDcxODU0LWM1YTRhZGE0LTJlMmMtNDI3Ny1iMjczLTNmMjdlYmIxMWFiYS5QTkc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBSVdOSllBWDRDU1ZFSDUzQSUyRjIwMjMwOTA4JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDIzMDkwOFQwMDQ5MTZaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT05MDRmNWFmZTE1NGIyYWI0YTdkMGZmYzRlNzUwNWJlMTNiNjc0OGIxNjE2NzdmMGMyODI2OGE1NzU3NjQ5ZTRlJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.Nd1ap27LNnwFN4A8GI-09qQRCufa4AA27OYuNOh-bpo)