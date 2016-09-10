﻿using PetStore.Data.Repositories.Interfaces;
using System;

namespace PetStore.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IPetRepository Pets { get; }
        int Complete();
    }
}