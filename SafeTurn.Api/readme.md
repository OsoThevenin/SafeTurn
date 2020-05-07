# SafeTurn.Api!

## Requisites

- Net Core 3.1 ([https://dotnet.microsoft.com/download/dotnet-core](https://dotnet.microsoft.com/download/dotnet-core))
- Sql Server

## Migration

Go to SafeTurn.Persistence

> `cd SafeTurn.Persistente`

Execute this command:

> `dotnet ef --startup-project ..\SafeTurn.Presentation\ migrations add Initial -o DataAccess/Migrations`
