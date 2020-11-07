using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuthApi.Model
{
public class ProductRepository
{
     private readonly AppDbContext _db;
     public  ProductRepository(AppDbContext db)
    { 
        _db=db;
    }
     /// <summary>
     /// (Категория) тип продукта начальная старанича сайта
     /// </summary>
     /// <returns></returns>
    public IQueryable<ProductType> GetProductTypes(){
         Console.WriteLine("Create -----------      GetProductTypes() ---------- Start->");
        return _db.ProductTypes ;
    }
}

}