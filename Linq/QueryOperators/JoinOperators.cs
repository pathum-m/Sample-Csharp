using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StandardQueryOperators
{
    public class JoinOperators
    {
        [Fact]
        public void Join()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Cola", CategoryId = 0 },
                new Product { Name = "Tea", CategoryId = 0 },
                new Product { Name = "Apple", CategoryId = 1 },
                new Product { Name = "Kiwi", CategoryId = 1 },
                new Product { Name = "Carrot", CategoryId = 2 },
            };

            List<Category> categories = new List<Category>
            {
                new Category { Id = 0, CategoryName = "Beverage" },
                new Category { Id = 1, CategoryName = "Fruit" },
                new Category { Id = 2, CategoryName = "Vegetable" }
            };

            var queryExpression = from category in categories
                                join product in products on category.Id equals product.CategoryId
                                select (category, product);

            var methodExpression = categories.Join(
                products,
                category => category.Id,
                product => product.CategoryId,
                (category, product) => (category, product));

            var first = methodExpression.First();
            Assert.Equal(first.product.CategoryId, first.category.Id);
            Assert.Equal("Beverage", first.category.CategoryName);
            Assert.Equal("Cola", first.product.Name);
        }

        [Fact]
        public void GroupJoin()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Cola", CategoryId = 0 },
                new Product { Name = "Tea", CategoryId = 0 },
                new Product { Name = "Apple", CategoryId = 1 },
                new Product { Name = "Kiwi", CategoryId = 1 },
                new Product { Name = "Carrot", CategoryId = 2 },
            };

            List<Category> categories = new List<Category>
            {
                new Category { Id = 0, CategoryName = "Beverage" },
                new Category { Id = 1, CategoryName = "Fruit" },
                new Category { Id = 2, CategoryName = "Vegetable" }
            };

            var queryExpression = from category in categories
                                  join product in products on category.Id equals product.CategoryId into productGroup
                                  select productGroup;

            var methodExpression = categories.GroupJoin(
                products,
                category => category.Id,
                product => product.CategoryId,
                (category, products) => products);

            Assert.Single(methodExpression.Last());
        }
    }
}
