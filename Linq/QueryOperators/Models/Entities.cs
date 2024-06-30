using System;
using System.Collections.Generic;
using System.Text;

namespace StandardQueryOperators
{
    class SimpleEntity
    {
        public int P1 { get; set; }
        public string P2 { get; set; }

        public bool P { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }

    class NestedEntity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public List<NestedEntity> C { get; set; }
    }

    class Product
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
