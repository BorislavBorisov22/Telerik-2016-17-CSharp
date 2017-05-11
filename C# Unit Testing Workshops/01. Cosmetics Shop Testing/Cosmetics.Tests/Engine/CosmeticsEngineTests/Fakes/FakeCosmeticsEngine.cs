namespace Cosmetics.Tests.Engine.CosmeticsEngineTests.Fakes
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Cosmetics.Engine;

    internal class FakeCosmeticsEngine : CosmeticsEngine
    {
        public FakeCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser) 
            : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
