using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AuthApi.Model;
using Microsoft.AspNetCore.Authorization;
namespace AuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository ;
                public ProductController(ProductRepository repository){
         _repository=repository;

        }
         [HttpGet]
         [Route("Type")]
        public IEnumerable<ProductType> ProductTypes(){
            return _repository.GetProductTypes().ToList();
         //  throw new Exception("NOt Implimetn Exception");
        }

    }





}