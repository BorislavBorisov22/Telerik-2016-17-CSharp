namespace Cosmetics.Tests.Engine
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;
    using System.Collections.Generic;
    using Products;
    using Cosmetics.Engine;
    using Fakes;
    using Cosmetics.Products;
    using System.Linq;
    using Cosmetics.Common;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenInputStringIsInCreateCAtegoryFormat_ShouldAddCategoryToList()
        {
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartStub = new Mock<IShoppingCart>();
            var commandStub = new Mock<ICommand>();
            var categoryStub = new Mock<ICategory>();
            categoryStub.SetupGet(c => c.Name).Returns("TestCategory");
            commandStub.SetupGet(c => c.Name).Returns("CreateCategory");
            commandStub.SetupGet(c => c.Parameters).Returns(new List<string>() { "TestCategory" });

            factoryStub.Setup(f => f.CreateCategory(It.IsAny<string>())).Returns(categoryStub.Object);

            var commandParsersStub = new Mock<ICommandParser>();
            commandParsersStub.Setup(
                cp => cp.ReadCommands())
                .Returns(new List<ICommand>() { commandStub.Object });

            var engine = new MockedCosmeticsEngine(
                factoryStub.Object,
                cartStub.Object,
                commandParsersStub.Object
                );


            engine.Start();


            var resultCategory = engine.Categories["TestCategory"];
            // Assert.IsInstanceOf<Category>(engine.Categories["TestCategory"]);
            Assert.AreSame(resultCategory, categoryStub.Object);
            Assert.AreEqual(resultCategory.Name, categoryStub.Object.Name);
        }

        [Test]
        public void AddToCategory_WhenInputStringIsValidAddToCategoryFormat_ShouldAddProductInREsepectiveCategory()
        {
            string commandName = "AddToCategory";
            string categoryName = "ForMale";
            string productName = "Shamponachetuu";

            var factoryStub = new Mock<ICosmeticsFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var shoppingCartStub = new Mock<IShoppingCart>();

            var commandStub = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var shampooStub = new Mock<IShampoo>();

            // setting fake product
            shampooStub.SetupGet(x => x.Name).Returns(productName);

            // setting fake category
            categoryMock.Setup(x => x.Name).Returns(categoryName);
            categoryMock.Setup(x => x.AddProduct(It.IsAny<IProduct>())).Verifiable();
            // setting fake command
            commandStub.SetupGet(x => x.Name).Returns(commandName);
            commandStub.SetupGet(x => x.Parameters)
                .Returns(new List<string>() { categoryName, productName });

            // setting fakse commandParser
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { commandStub.Object });

            var engine = new MockedCosmeticsEngine(
                factoryStub.Object,
                shoppingCartStub.Object,
                commandParserStub.Object
                );

            engine.Products.Add(productName, shampooStub.Object);
            engine.Categories.Add(categoryName, categoryMock.Object);

            engine.Start();

            categoryMock.Verify(x => x.AddProduct(It.IsAny<IProduct>()), Times.Once);
        }

        [Test]
        public void RemoveFromCategory_WhenInputStrignIsValidRemoveFromCategoryFormat_ShouldRemoveProductFromCategory()
        {
            string commandName = "RemoveFromCategory";
            string categoryName = "ForMale";
            string productName = "Shamponachetuu";

            var factoryStub = new Mock<ICosmeticsFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var shoppingCartStub = new Mock<IShoppingCart>();

            var commandStub = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var shampooStub = new Mock<IShampoo>();

            // setting fake product
            shampooStub.SetupGet(x => x.Name).Returns(productName);

            // setting fake category
            categoryMock.Setup(x => x.Name).Returns(categoryName);
            categoryMock.Setup(x => x.AddProduct(It.IsAny<IProduct>())).Verifiable();
            // setting fake command
            commandStub.SetupGet(x => x.Name).Returns(commandName);
            commandStub.SetupGet(x => x.Parameters)
                .Returns(new List<string>() { categoryName, productName });

            // setting fakse commandParser
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { commandStub.Object });

            var engine = new MockedCosmeticsEngine(
                factoryStub.Object,
                shoppingCartStub.Object,
                commandParserStub.Object
                );

            engine.Products.Add(productName, shampooStub.Object);
            engine.Categories.Add(categoryName, categoryMock.Object);
            // engine.Categories[categoryName].AddProduct(shampooStub.Object);

            engine.Start();

            categoryMock.Verify(x => x.RemoveProduct(It.IsAny<IProduct>()), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsInValidShowCategoryFormat_ShouldInvokeCategoryPrintMethod()
        {
            // arrange
            string commandName = "ShowCategory";
            string categoryName = "TestCategory";

            var factoryStub = new Mock<ICosmeticsFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var shoppingCartStub = new Mock<IShoppingCart>();

            var commandStub = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var shampooStub = new Mock<IShampoo>();

            commandStub.SetupGet(x => x.Name).Returns(commandName);
            commandStub.SetupGet(x => x.Parameters).Returns(new List<string> { categoryName });

            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { commandStub.Object});

            categoryMock.Setup(x => x.Print()).Verifiable();

            var engine = new MockedCosmeticsEngine(
                 factoryStub.Object,
                 shoppingCartStub.Object,
                 commandParserStub.Object
                );

            engine.Categories.Add(categoryName, categoryMock.Object);

            // act
            engine.Start();

            // assert
            categoryMock.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void CreateShampoo_WhenInputStringIsInCorrectCreateShampooFormat_ShouldAddShampooInProducts()
        {
            // arrange
            string commandName = "CreateShampoo";

            var factoryStub = new Mock<ICosmeticsFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var shoppingCartStub = new Mock<IShoppingCart>();

            var commandStub = new Mock<ICommand>();
            var shampooStub = new Mock<IShampoo>();

            shampooStub.SetupGet(x => x.Name).Returns("ShampoanchetoBrat");

            commandStub.SetupGet(x => x.Name).Returns(commandName);
            commandStub.SetupGet(x => x.Parameters)
                .Returns(new List<string> { "Cool", "Nivea", "0.50", "men", "500", "everyday" });

            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { commandStub.Object });

            factoryStub.Setup(x => x.CreateShampoo("Cool", "Nivea", 0.50M, GenderType.Men, 500, UsageType.EveryDay))
                .Returns(shampooStub.Object);

            var engine = new MockedCosmeticsEngine(
                 factoryStub.Object,
                 shoppingCartStub.Object,
                 commandParserStub.Object
                );

            // act
            engine.Start();

            // assert
            Assert.AreEqual(1, engine.Products.Count);
            Assert.AreSame(shampooStub.Object, engine.Products.First().Value);
        }

        [Test]
        public void Start_WhenInputStringIsInValidCreateToothPasteFormat_ShouldAddToothpasteToProducts()
        {
            // arrange
            string commandName = "CreateToothpaste";

            var factoryStub = new Mock<ICosmeticsFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var shoppingCartStub = new Mock<IShoppingCart>();

            var commandStub = new Mock<ICommand>();
            var toothpasteStub = new Mock<IToothpaste>();

            commandStub.SetupGet(x => x.Name).Returns(commandName);
            commandStub.SetupGet(x => x.Parameters)
                .Returns(new List<string>() { "White+", "Colgate", "15.50", "men", "fluor,bqla,golqma" });

            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { commandStub.Object });

            factoryStub.Setup(x => x.CreateToothpaste("White+", "Colgate", 15.50M, GenderType.Men, new List<string> { "fluor", "bqla", "golqma" }))
                .Returns(toothpasteStub.Object);

            var engine = new MockedCosmeticsEngine(
                factoryStub.Object,
                shoppingCartStub.Object,
                commandParserStub.Object
                );

            // act
            engine.Start();

            Assert.AreEqual(1, engine.Products.Count);
            Assert.AreSame(toothpasteStub.Object, engine.Products.First().Value);
        }

        [Test]
        public void Start_WhenInputStringIsValidCreateAddToShoppingCartFormat_ShouldResultInAddingProductToCart()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var commandStub = new Mock<ICommand>();
            var toothpasteStub = new Mock<IToothpaste>();

            commandStub.SetupGet(x => x.Name).Returns("AddToShoppingCart");
            commandStub.SetupGet(x => x.Parameters)
                .Returns(new List<string>() { "TestName" });

            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { commandStub.Object });

            var engine = new MockedCosmeticsEngine(
                 factoryStub.Object,
                 shoppingCartMock.Object,
                 commandParserStub.Object
                );

            engine.Products.Add("TestName", toothpasteStub.Object);

            // act
            engine.Start();

            // assert
            shoppingCartMock.Verify(x => x.AddProduct(toothpasteStub.Object),Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidRemoveFromCartFormat_ShouldInvokeCartRemoveProduct()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var commandStub = new Mock<ICommand>();
            var toothpasteStub = new Mock<IToothpaste>();

            commandStub.SetupGet(x => x.Name).Returns("RemoveFromShoppingCart");
            commandStub.SetupGet(x => x.Parameters)
                .Returns(new List<string>() { "TestName" });

            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { commandStub.Object });

            shoppingCartMock.Setup(x => x.ContainsProduct(It.IsAny<IProduct>()))
                .Returns(true);

            var engine = new MockedCosmeticsEngine(
                 factoryStub.Object,
                 shoppingCartMock.Object,
                 commandParserStub.Object
                );

            engine.Products.Add("TestName", toothpasteStub.Object);
            // act
            engine.Start();

            // assert
            shoppingCartMock.Verify(x => x.RemoveProduct(toothpasteStub.Object),Times.Once);
        }
    }
}
