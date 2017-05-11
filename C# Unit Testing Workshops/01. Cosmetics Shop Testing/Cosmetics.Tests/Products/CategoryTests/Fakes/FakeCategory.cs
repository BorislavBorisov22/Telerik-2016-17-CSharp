namespace Cosmetics.Tests.Products.CategoryTests.Fakes
{
    using Contracts;
    using Cosmetics.Products;
    using System.Collections.Generic;

    internal class FakeCategory : Category
    {
        public FakeCategory(string name) 
            : base(name)
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
