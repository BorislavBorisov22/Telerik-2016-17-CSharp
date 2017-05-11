namespace Cosmetics.Tests.Products.ShoppingCartTests.Fakes
{
    using System.Collections.Generic;

    using Cosmetics.Products;
    using Contracts;

    internal class FakeShoppingCart : ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
