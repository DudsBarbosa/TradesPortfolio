﻿using CreditSuisse.TradesPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.TradesPortfolio.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category GetById(int id);

        void Add(Category category);

        void Update(Category category);

        void Delete(int id);
    }
}
