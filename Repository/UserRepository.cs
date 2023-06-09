﻿using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .ToList();
        }

        public User GetUserById(Guid userId)
        {
            return FindByCondition(user => user.Id.Equals(userId)).FirstOrDefault();
        }

        //public User GetUserWithDetails(Guid userId)
        //{
        //    return FindByCondition(user => user.Id.Equals(userId))
        //        .Include(u => u.Todos)
        //        .FirstOrDefault();
        //}

        public void CreateUser(User user) => Create(user);
        public void UpdateUser(User user) => Update(user);
        public void DeleteUser(User user) => Delete(user);
        public User GetUserByEmail(string email)
        {
            return FindByCondition(user => user.Email == email).FirstOrDefault();
        }
    }
}
