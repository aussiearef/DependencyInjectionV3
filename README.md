# Dependency Injection with .NET, 3rd Edition
## Sample codes of ["Dependency Injection With .NET "](https://www.udemy.com/course/dependency-injection-in-net-core-2-and-aspnet-core-2/?referralCode=648F7F114AAC06731A07) course on Udemy

[![](https://img-b.udemycdn.com/course/750x422/1598064_46f0_8.jpg)](https://www.udemy.com/course/dependency-injection-in-net-core-2-and-aspnet-core-2/?referralCode=648F7F114AAC06731A07) 



 This repository includes several .NET projects to demonstrate various dependency injection features in . NET. Currently, the minimum version of .NET needed to run these projects is .NET 8.



## The Personal Blog

Personal Blog is an application that demonstrates how to do simple operations with DI in ASP.NET Core. The project implements a straightforward personal notes application.

This project can use both AWS DynamoDB and SQL Server as its storage. 

To use AWS and its DynamoDB service, register DynamoDbDataService with the DI container in program.cs .
To use SQL Server, use SqlServerDataService and register it with the DI container in program.cs .

If you wish to use SQL Server, make sure you run the Create_All_Objects.sql file, which is in the DatabaseScripts folder, first. It will create a database called "personalblog" along with all the required database objects. Then you must update the connection string in appSettings.json properly so that the application can connect to SQL Server.

## More Free Courses on YouTube!

[![YouTube](https://img.shields.io/badge/YouTube-Subscribe-red?style=flat&logo=youtube)](http://www.youtube.com/@FreeTechnologyLectures)

Subscribe to the Free Technology and Technology Management Courses channel for regular free lectures about Coding, DevOps, and Technology Management. [Click Here to View the YouTube Channel](http://www.youtube.com/@FreeTechnologyLectures).

## Buy me a coffee ☕

If you find my work helpful, consider treating me by buying me a coffee!

<a href="https://ko-fi.com/arefkarimi"><img src="https://storage.ko-fi.com/cdn/kofi2.png?v=3" alt="ko-fi" height="36"></a>
