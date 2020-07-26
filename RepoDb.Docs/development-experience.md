﻿# The Development Experience

If you are to use RepoDb, the development experience is identical to both Entity Framework and Dapper. But, it gives you the most attributes of micro-ORM (i.e: Direct, Performant, Efficient and etc).

### Entity Framework

In Entity Framework, you tend to create a DbContext so you will inherit the entity-based operations.

```csharp
public class DatabaseContext : DbContext
{
	public DatabaseContext()
	{
		ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		ChangeTracker.AutoDetectChangesEnabled = false;
		ChangeTracker.LazyLoadingEnabled = true;
	}

	public DbSet<Person> People { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseSqlServer("Server=.;Database=TestDB;Integrated Security=SSPI;");
	}
}
```

And you call the operations like below.

```csharp
using (var context = new DbContext())
{
	context.Add(new Person
	{
		Name = "John Doe",
		DateInsertedUtc = DateTime.UtcNow
	});
	context.SaveChanges();
}
```

### Dapper

In Dapper, you tend to simply open a connection and then execute an operation.

```csharp
using (var connection = new SqlConnection("Server=.;Database=TestDB;Integrated Security=SSPI;"))
{
	var people = connection.Query<Person>("SELECT * FROM [dbo].[Person]");
}
```

### RepoDb

In RepoDb, you just simply open a connection like Dapper, and then, call the operations like Entity Framework.

```csharp
using (var connection = new SqlConnection("Server=.;Database=TestDB;Integrated Security=SSPI;"))
{
	connection.Insert(new Person
	{
		Name = "John Doe",
		DateInsertedUtc = DateTime.UtcNow
	});
}
```

Though you can as well force the complete Dapper-Like experience like below.

```csharp
using (var connection = new SqlConnection("Server=.;Database=TestDB;Integrated Security=SSPI;"))
{
	var people = connection.ExecuteQuery<Person>("SELECT * FROM [dbo].[Person]");
}
```

And force the EF-Like design with the use of repository.

```csharp
public class PeopleRepository : BaseRepository<Person, SqlConnection>
{
	public PeopleRepository() :
		base("Server=.;Database=TestDB;Integrated Security=SSPI;")
	{ }
}
```

And you call the operations like below.

```csharp
using (var repository = new PeopleRepository())
{
	repository.Insert(new Person
	{
		Name = "John Doe",
		DateInsertedUtc = DateTime.UtcNow
	});
}
```