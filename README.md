## Init backend server
```sh
$ dotnet run
```

## Init frontend server
```sh
$ ng serve --open
```

## Init backend server swagger
```sh
$ dotnet watch run
```

## build backend server
```sh
$ dotnet build
```

## Run migrations
```sh
$ dotnet ef migrations add <name>
$ dotnet ef database update
```

## Run SQL Server 
```sh
sqlcmd -S localhost -U SA -P '<password>'
```

## Add new package
```sh
dotnet add package <name>
```