// Objective of creating this repo is to provide a centralized location for data access logic.making it easier to manage and maintain.

// Generic repository interface defining common data access methods for any entity type.

using System.Linq.Expressions;
using RepoDemo.Api.Models;
using RepoDemo.Api.Data;

namespace RepoDemo.Api.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
        //we are calling this interface as generic repository interface because it can work with any entity type
        // we can refer this class as metadata as it coantains only method signatures

    {
        Task<IEnumerable<T>> GetAllAsync();
        // this method will hell in fetching data based on primary key
        Task<T> GetByIdAsync(int id);
        // this method will help in fetching data based on any condition
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        // this method will help in adding new entity to the database
        Task AddAsync(T entity); //task type help us to perfform async operation
        // this method will help in adding multiple entities to the database
        void Update(T entity);
        // this method will help in updating existing entity in the database
        void Delete(T entity);
        // this method will help in deleting existing entity from the database
    }
}

//all the methods in this interface are asynchronous to improve performance and scalability of the application

//All the methods that are defined in this interface will help us in performing CRUD operations on the entities.//

//Here entities refer to the objects that are being managed by the application, such as products, orders, customers, etc.

//So, 