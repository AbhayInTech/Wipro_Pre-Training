//IUnitofWork is used here to group related operations into a single transaction

//ex: saving changes to multiple entities in a single database transaction

//ex: committing all changes or rolling back in case of an error

// So, UnitOfWork is responsible for coordinating the work of multiple repositories by providing a single

// interface for saving changes.
using RepoDemo.Api.Models;//this will help us in accessing product model
using RepoDemo.Api.Repository.Interfaces;//this will help us in accessing IGenericRepository interface

public interface IUnitOfWork : IDisposable //this interface is used to amnage the lifetime of the object
{
    IGenericRepository<Product> Products { get; }
    // this method will help in saving changes to the database
    // here product is a repository for Product entities and we can define other repository in a similar manner
    Task<int> SaveAsync();// this method will help in saving changes to the database asynchronously
}
