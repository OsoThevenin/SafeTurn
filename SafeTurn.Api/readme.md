# SafeTurn.Api!

## Requisites

- Net Core 3.1 ([https://dotnet.microsoft.com/download/dotnet-core](https://dotnet.microsoft.com/download/dotnet-core))
- Sql Server

## Migration

Go to SafeTurn.Persistence

> `cd SafeTurn.Persistente`

Execute this command for IDENTITY:

> `dotnet ef --startup-project ../SafeTurn.Presentation migrations add Initial -o Identity/Migrations --context SafeTurn.Persistence.Identity.IdentityDbContext`

Execute this command for APP:

> `dotnet ef --startup-project ../SafeTurn.Presentation migrations add Initial -o DataAccess/Migrations --context SafeTurn.Persistence.DataAccess.ApplicationDbContext`

## Develop with Mac

- Need docker
> `docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Sample123$" -p 1433:1433 --name sqlserver2017withoutmount -d mcr.microsoft.com/mssql/server:2017-latest`
