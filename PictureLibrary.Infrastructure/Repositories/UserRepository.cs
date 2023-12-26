﻿using MongoDB.Bson;
using MongoDB.Driver;
using PictureLibrary.Domain.Configuration;
using PictureLibrary.Domain.Entities;
using PictureLibrary.Domain.Repositories;

namespace PictureLibrary.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(
            IAppSettings appSettings, 
            IMongoClient mongoClient) 
            : base(appSettings, mongoClient)
        {
        }

        protected override string CollectionName => "Users";

        public async Task<User?> GetById(ObjectId id)
        {
            return await Task.Run(() =>
            {
                return Query().FirstOrDefault(u => u.Id == id);
            });
        }
    }
}
