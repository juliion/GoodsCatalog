﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsCatalog.Models;

namespace GoodsCatalog.Repos.Interfaces
{
    public interface IBrandsRepo
    {
        List<Brand> GetAllBrands();
    }
}
