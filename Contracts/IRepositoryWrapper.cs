﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }
        IUnitRepository Unit { get; }
        void Save();
    }
}