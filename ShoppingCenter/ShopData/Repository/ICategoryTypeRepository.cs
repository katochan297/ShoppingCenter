﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData.Model;

namespace ShopData.Repository
{
    public interface ICategoryTypeRepository : IGenericRepository<CategoryType>
    {
        CategoryType FindByName(string name);
    }
}
