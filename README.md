# Mini-Data
Mini-Data is a simple lightweight micro ORM that has been designed with a focus on readability. It provides a basic interface to simple CRUD operations. 

All operations are asynchronous.

This is a work in progress with new features being added daily atm. If you have any interest in the project please fork.

My contact is jonathontek@gmail.com

I'd love to hear what you think.

Planned short term feature:
* Updates
* Deletes
* Top N
* Count
* Joins and foreign key constraints

```csharp
//Define a model class 
//implementing IDbTable marker interface
public class Person : IDbTable
{
	[PrimaryKey]
	public int Id { get; set; }
	
	[AutoIncrement]
	public int Count { get; set; }

	//Optional data attributes
	[Nullable]
	[DataType("varchar(50)")]
	public string Name { get; set; }
}
```

Once you have defined a model you are free to begin creating/ deleting tables

```csharp
using (var db = new DbConnection())
{
	await db.DropTableAsync<Person>();

	await db.CreateTableAsync<Person>();

	await db.DropCreateTableAsync<Person>();
}
```

Once you have created table you can begin adding data

```csharp
using (var db = new DbConnection())
{
	async db.InsertAsync(new Person {Name = "Rick Bobby"});
}
```

Once you have data you can begin querying

```csharp
using (var db = new DbConnection())
{
	var query = db.Select<Person>().Where(p => p.Id, Sql.Equals(1));

	var people = await query.SelectAsync();	
	var person = await query.SelectSingleAsync();	
}

//Need to use the generic DbConnection with expressions
using (var db = new DbConnection<Person>())
{
	//Select accepts strings or expressions to limit columns
	var query = db.Select(p => p.Name).Where(p => p.Name, Sql.Like("Rick%"));
	
	//Same as
	//var query = db.Select("Name").Where(p => p.Name, Sql.Like("Rick%"));
	
	//Or select multiple columns
	//var query = db.Select("Name Id").Where(p => p.Name, Sql.Like("Rick%"));

	var people = await query.SelectAsync();
}
```

Current interface includes
```csharp
public interface IDbConnection<T> where T : class, new()
{
	SelectQuery<T> Select<TProperty>(Expression<Func<T, TProperty>> expression);
}

public interface IDbConnection
{
	SelectQuery<T> Select<T>(params string[] columns) where T : class, new();

	SelectQuery<T> Select<T>(string columns) where T : class, new();

	Task CreateTableAsync<TTable>() where TTable : class, IDbTable, new();

	Task DropCreateTableAsync<TTable>() where TTable : class, IDbTable, new();

	Task DropTableAsync<TTable>() where TTable : class, IDbTable, new();

	Task InsertAsync<T>(T toInsert) where T : class, IDbTable, new();

	Task InsertCollectionAsync<T>(IEnumerable<T> toInsert) where T : class, IDbTable, new();
}
```