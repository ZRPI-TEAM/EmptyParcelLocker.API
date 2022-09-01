# EmptyParcelLocker.API

# Requiremenets

- NET 6.0
- Database: SQL (or another but you have to implement database repository)

# Before launch

- add connection string to appsettings.json
- if you had to implement database repository - you have to apply dependency injection in Program.cs
- add migration via terminal
  `dotnet ef migrations add "message"`
- update database
  `dotnet ef database update`
