﻿using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsService : IProductsService
    {
        IProductsRepository _productRepository;
        public ProductsService(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts(int position, int skip, string? name, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _productRepository.Get(position,skip,name,minPrice,maxPrice,categoryIds);
        }
    }
}
