using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Course_Project.Dal.IRepositories;
using Course_Project.Domain.Entities;
using Course_Project.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Course_Project.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IRepository<Collection> _collectionRepository;

        public CollectionService(IRepository<Collection> collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        // Create a new collection
        public async Task<Collection> CreateCollection(Collection collection)
        {
            var createdCollection = await _collectionRepository.InsertAsync(collection);
            await _collectionRepository.SaveAsync();
            return createdCollection;
        }

        // Read all collections
        public IQueryable<Collection> GetAllCollections()
        {
            return _collectionRepository.SelectAll();
        }

        // Read collections based on a condition
        public IQueryable<Collection> GetCollectionsByCondition(Expression<Func<Collection, bool>> expression)
        {
            return _collectionRepository.SelectAll(expression);
        }

        // Read a single collection based on a condition
        public async Task<Collection> GetCollection(Expression<Func<Collection, bool>> expression)
        {
            return await _collectionRepository.SelectAsync(expression);
        }

        // Update a collection
        public async Task<Collection> UpdateCollection(Collection collection)
        {
            var updatedCollection = _collectionRepository.Update(collection);
            await _collectionRepository.SaveAsync();
            return updatedCollection;
        }

        // Delete a collection
        public async Task<bool> DeleteCollection(Expression<Func<Collection, bool>> expression)
        {
            var deleted = await _collectionRepository.DeleteAsync(expression);
            if (deleted)
                await _collectionRepository.SaveAsync();

            return deleted;
        }

        // Delete multiple collections
        public async Task<bool> DeleteCollections(Expression<Func<Collection, bool>> expression)
        {
            var deleted = _collectionRepository.DeleteMany(expression);
            if (deleted)
                await _collectionRepository.SaveAsync();

            return deleted;
        }

        // Upload image for a collection
        public async Task<bool> UploadImage(int collectionId, IFormFile imageFile)
        {
            var collection = await _collectionRepository.SelectAsync(c => c.Id == collectionId);

            if (collection == null || imageFile == null || imageFile.Length <= 0)
                return false;

            // Convert image to byte array
            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }

            // Update the collection with the image data and filename
            collection.ImageData = imageData;
            collection.ImageFilename = imageFile.FileName;

            await _collectionRepository.SaveAsync();
            return true;
        }

    }
}
