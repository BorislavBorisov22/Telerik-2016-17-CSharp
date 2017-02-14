namespace Cosmetics.Tests.Fakes
{
    using Contracts;
    using Cosmetics.Products;
    using System.Collections.Generic;

    internal class MockedCategory : Category
    {
        public MockedCategory(string name) 
            : base(name)
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}
