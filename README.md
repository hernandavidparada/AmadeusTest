# AmadeusTest

This is a test project for the manage of diferent products for diferent stores. It can insert, delete, update and get the products that enter in a store.

## Technologies

Angular 15.2,   

.NET Core 6.0,  

Sql server 15.0

## Get started

1. Create a database in Sql server and give it any name, in this case "prueba"
2. Execute the DataBase/CreateTableProducts.sql file to create the principal table
3. Clone the .NET core project (Back/ProductsManager)
4. Modify the connectionString in the file ProductsManager.Repository/Repositories/ProductsRepository.cs with the name of the datasourse and database
5. Clone the Angular project (Front/products-manager-angular)
6. Install and run the Angular project (npm install, ng serve)


