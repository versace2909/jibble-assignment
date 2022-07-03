# Jibble Assigment

## Project description
    
The project contains:
- Backend API: 
  - .Net core 3.1
  - Entity Framework Core
  - PostgreSQL
  - Swagger
- SPA (Web App)
    - VueJS 3 (vue-cli)
    - Ant Design (Ant Table and Ant Upload)

## Structure
We have following projects
- Domain Project: Contain entities for business 
- Application: Define interface for business logic
- Infrastructure: Implement the interface was defined in the application layer
- WebAPI: Web API for the application, using swagger
- Tests: Unit test project

## Installation

1. Install Docker on your local machine
2. Pull PosgreSQL docker image
```
docker pull postgres
```
3. Run the docker image
```
docker run --name postgreslocal -e POSTGRES_PASSWORD=sa123456 -d postgres
```
4. Create new database name **jibble**
5. Run the migration (refer to the migration part)


## Migration
To add new migration, run the following command
```
dotnet ef migrations add InitialDatabase --project Infrastructure --startup-project WebAPI
```

To apply migration, run the following command
```
dotnet ef database update --project Infrastructure --startup-project WebAPI      
```
