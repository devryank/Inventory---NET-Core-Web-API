﻿using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IUserRepository _user;
        private ISupplierRepository _supplier;
        private IUnitRepository _unit;
        private IItemCategoryRepository _itemCategory;
        private IItemRepository _item;
        private IInboundRepository _inbound;
        private IOutboundRepository _outbound;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new SupplierRepository(_repoContext);
                }
                return _supplier;
            }
        }
        public IUnitRepository Unit
        {
            get
            {
                if (_unit == null)
                {
                    _unit = new UnitRepository(_repoContext);
                }
                return _unit;
            }
        }
        public IItemCategoryRepository ItemCategory
        {
            get
            {
                if (_itemCategory == null)
                {
                    _itemCategory = new ItemCategoryRepository(_repoContext);
                }
                return _itemCategory;
            }
        }
        public IItemRepository Item
        {
            get
            {
                if (_item == null)
                {
                    _item = new ItemRepository(_repoContext);
                }
                return _item;
            }
        }

        public IInboundRepository Inbound
        {
            get
            {
                if (_inbound == null)
                {
                    _inbound = new InboundRepository(_repoContext);
                }
                return _inbound;
            }
        }

        public IOutboundRepository Outbound
        {
            get
            {
                if (_outbound == null)
                {
                    _outbound = new OutboundRepository(_repoContext);
                }
                return _outbound;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
