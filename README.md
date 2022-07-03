# jibble-assignment

To add new migration, run the following command
```
dotnet ef migrations add InitialDatabase --project Infrastructure --startup-project WebAPI
```

To apply migration, run the following command
```
dotnet ef database update --project Infrastructure --startup-project WebAPI      
```
