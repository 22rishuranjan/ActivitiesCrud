# ActivitiesCrud

Backend folder contains, crudApi solution that gives 4 end points.
UI folder has a react application, that consumes the api provided by CrudApi sln in the backend/CrudApi directory.
.

prerequisite
a. .NET Core 3.1
b. Node js
c. Sql Server 

Make sure:
1.to change connection string inside appsetting.json in backend/crudApi directory.
2.that cors is enabled for your react app. I have enabled cors policy for localhost:3000, localhost:3001. But if your react application is running on any different port, then either change port in react app or add your port in the corspolicy defined in startup.cs in backend/CrudApi directory.
