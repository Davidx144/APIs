# APIs

# 🔧Breakthrough Broker 2.0 - .NET BackEnd

## 🤖 Github Repository

https://github.com/Davidx144/APIs

## 🛠️ Installation
 Requirements:

- .NET 7.0
- Visual Studio 2022 Profesional or Superior
- SQL Server Express 2022 o Development Edition 2022.
- SQL Server Management Studio (SSMS) 

## ⚙ Setup (Run Locally)

- Install SQL Server and configure for Windows Authentication
- Install SQL Server Management Studio
- Download source code from Repository.
- Connect to Sql Server using SQL Server Management Studio.
- Open appsettings.json and modify ConnectionStrings by the credentials of your own SQLServer.
- In the terminal use the "command dotnet ef migrations add NameInitialCreation" to create the initial data migration.

- Then use the command "dotnet ef database update" to migrate that data to the DB.



## 🔗 Links URLs

- Base URL: http://localhost:5240
- EndPonts:
    - Categotys:
        - /api/Category [GET]
        - /api/Category/{categoryId} [GET]
        - /api/Category/ [POST]
        - /api/Category/{categoryId} [PUT]
        - /api/Category/{categoryId} [DELETE]

    - Products:
        - /api/Products [GET]
        - /api/Products/{productsId} [GET]
        - /api/Products/category/{productsId} [GET]
        - /api/Products/ [POST]
        - /api/Products/{productsId} [PUT]
        - /api/Products/{productsId} [DELETE]
    
    - Design:
        - /api/Design [GET]
        - /api/Design/{designId} [GET]
        - /api/Design/product/{designId} [GET]
        - /api/Design/ [POST]
        - /api/Design/{designId} [PUT]
        - /api/Design/{designId} [DELETE]

    - Flyes:
        - /api/Flyes [GET]
        - /api/Flyes/{flyesId} [GET]
        - /api/Flyes/design/{flyesId} [GET]
        - /api/Flyes/ [POST]
        - /api/Flyes/{flyesId} [PUT]
        - /api/Flyes/{flyesId} [DELETE]


## 👓 Authors

- [@Davidx144](https://github.com/Davidx144)



