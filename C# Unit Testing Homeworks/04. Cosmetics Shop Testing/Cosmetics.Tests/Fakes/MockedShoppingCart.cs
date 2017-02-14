namespace Cosmetics.Tests.Fakes
{
    using Contracts;
    using Cosmetics.Products;
    using System.Collections;
    using System.Collections.Generic;

    internal class MockedShoppingCart : ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}
