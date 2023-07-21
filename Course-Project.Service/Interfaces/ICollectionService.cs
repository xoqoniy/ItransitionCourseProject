using Course_Project.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Service.Interfaces
{
    public interface ICollectionService
    {
        Task<Collection> CreateCollection(Collection collection);
        IQueryable<Collection> GetAllCollections();
        IQueryable<Collection> GetCollectionsByCondition(Expression<Func<Collection, bool>> expression);
        Task<Collection> GetCollection(Expression<Func<Collection, bool>> expression);
        Task<Collection> UpdateCollection(Collection collection);
        Task<bool> DeleteCollection(Expression<Func<Collection, bool>> expression);
        Task<bool> DeleteCollections(Expression<Func<Collection, bool>> expression);
        Task<bool> UploadImage(int collectionId, IFormFile imageFile);
    }
}
