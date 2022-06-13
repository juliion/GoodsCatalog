using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsCatalog.Models;
using GoodsCatalog.Repos.Interfaces;
using GoodsCatalog.Dapper;

namespace GoodsCatalog.Repos.Implements
{
    public class BrandsRepo : IBrandsRepo
    {
        public List<Brand> GetAllBrands()
        {
            return QueryManager.ExecuteSelect<Brand>("GetAllBrands").ToList();
        }
    }
}
