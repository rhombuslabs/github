# Matt Nicholson - XYZ Corp for Guidant

Files to look at:
* Controllers\UsersController.cs
* Models\User.cs
* XyzCorpDbContext.cs

Notes:
* You'll need to restore all the Nuget packages included in the project.
* I used Entity Framework Core because it has an in-memory data store for simplicity, 
ordinarily I would use the full EF and the model designer.
* EF Core In-Memory has some limitations such as not being relational, not supporting unique indexes. 
I wouldn't do the uniqueness code as it is, I would let EF take care of that and properly handle the constraint exception.
* I used Unity as my dependency injector and a third party library that hooks it up to WebApi.
* I used Postman to test.