using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters prp)
        {
            return _context.Products
                .FilteredByCategoryId(prp.CategoryId)
                .FilteredBySearchTerm(prp.SearchTerm)
                .FilteredByPrice(prp.MinPrice,prp.MaxPrice,prp.IsValidPrice)
                .ToPaginate(prp.PageNumber,prp.PageSize);
 
        }

        public IQueryable<Product> GetAllShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges).Where(p=>p.ShowCase.Equals(true));
        }

        public Product? GetOneProduct(int id,bool trackChanges)
        {
            return FindByCondition(p=>p.ProductId.Equals(id),trackChanges);
        }

        public void UpdateOneProduct(Product entity) =>Update(entity);
    }
}
