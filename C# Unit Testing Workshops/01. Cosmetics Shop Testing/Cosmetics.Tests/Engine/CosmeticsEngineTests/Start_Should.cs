namespace Cosmetics.Tests.Engine.CosmeticsEngineTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;
    using System.Collections.Generic;
    using Fakes;
    using System.Linq;
    using Cosmetics.Common;
    using Products;

    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void ShouldProcessAndAddCategoryToCategoriesCollection_WhenProcessingValidCreateCategoryCommand()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartStub = new Mock<IShoppingCart>();
            var commandParserStub = new Mock<ICommandParser>();

            // setting up command
            var commandStub = new Mock<ICommand>();
            string commandName = "CreateCategory";
            string categoryName = "SomeCategory";
            var commandParameters = new List<string>() { categoryName };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            // setting up category
            var categoryToAddStub = new Mock<ICategory>();

            factoryStub.Setup(x => x.CreateCategory(It.IsAny<string>()))
                .Returns(categoryToAddStub.Object);

            // setting up commandParser
            var commandsToReturn = new List<ICommand>() { commandStub.Object };
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(commandsToReturn);

            var engine = new FakeCosmeticsEngine(
                factoryStub.Object,
                cartStub.Object,
                commandParserStub.Object
                );

            // act
            engine.Start();

            // assert
            Assert.AreSame(categoryToAddStub.Object, engine.Categories.First().Value);
            Assert.AreEqual(categoryName, engine.Categories.First().Key);
        }

        [Test]
        public void AddSelectedProductToTargetCategory_WhenProcessingValidAddToCategoryCommand()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartStub = new Mock<IShoppingCart>();
            var commandParserStub = new Mock<ICommandParser>();

            // setting up command
            var commandStub = new Mock<ICommand>();
            string commandName = "AddToCategory";
            string categoryToAddToName = "Chocolates";
            string productToAddName = "Milka";
            var commandParameters = new List<string>()
            {
                categoryToAddToName,
                productToAddName
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            // setting up category
            var categoryMock = new Mock<ICategory>();
            categoryMock.Setup(x => x.AddProduct(It.IsAny<IProduct>()));

            // setting up commandParser
            var commandsToReturn = new List<ICommand>() { commandStub.Object };
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(commandsToReturn);

            var engine = new FakeCosmeticsEngine(
                factoryStub.Object,
                cartStub.Object,
                commandParserStub.Object
                );

            // setting up collections
            engine.Products.Add(productToAddName, null);
            engine.Categories.Add(categoryToAddToName, categoryMock.Object);
            // act
            engine.Start();

            // assert
            categoryMock.Verify(
                x => x.AddProduct(It.IsAny<IProduct>()), Times.Once);
        }

        [Test]
        public void InvokeCategoriesRemoveMethod_WhenProcessingValidRemoveFromCategoryCommand()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartStub = new Mock<IShoppingCart>();
            var commandParserStub = new Mock<ICommandParser>();

            // setting up command
            var commandStub = new Mock<ICommand>();
            string commandName = "RemoveFromCategory";
            string categoryToRemoveFromName = "Chocolates";
            string productToRemoveName = "Milka";
            var commandParameters = new List<string>()
            {
                categoryToRemoveFromName,
                productToRemoveName
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            // setting up category
            var categoryMock = new Mock<ICategory>();
            categoryMock.Setup(x => x.RemoveProduct(It.IsAny<IProduct>()));

            // setting up commandParser
            var commandsToReturn = new List<ICommand>() { commandStub.Object };
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(commandsToReturn);

            var engine = new FakeCosmeticsEngine(
                factoryStub.Object,
                cartStub.Object,
                commandParserStub.Object
                );

            // setting up collections
            engine.Products.Add(productToRemoveName, null);
            engine.Categories.Add(categoryToRemoveFromName, categoryMock.Object);
            // act
            engine.Start();

            // assert
            categoryMock.Verify(
                x => x.RemoveProduct(It.IsAny<IProduct>()), Times.Once);
        }

        [Test]
        public void CallTargetCategoryPrintMethod_WhenProcessingValidShowCategoryCommand()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartStub = new Mock<IShoppingCart>();
            var commandParserStub = new Mock<ICommandParser>();

            // setting up command
            var commandStub = new Mock<ICommand>();
            string commandName = "ShowCategory";
            string categoryToShowName = "Chocolates";
            var commandParameters = new List<string>()
            {
                categoryToShowName,              
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            // setting up category
            var categoryMock = new Mock<ICategory>();
            categoryMock.Setup(x => x.Print());

            // setting up commandParser
            var commandsToReturn = new List<ICommand>() { commandStub.Object };
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(commandsToReturn);

            var engine = new FakeCosmeticsEngine(
                factoryStub.Object,
                cartStub.Object,
                commandParserStub.Object
                );

            // setting up collections
            engine.Categories.Add(categoryToShowName, categoryMock.Object);

            // act
            engine.Start();

            // assert
            categoryMock.Verify(
                x => x.Print(), Times.Once);
        }

        [Test]
        public void AddNewlyCreatedShampoo_WhenProcessingValidCreateShampooCommnad()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartStub = new Mock<IShoppingCart>();
            var commandParserStub = new Mock<ICommandParser>();

            // setting up command
            var commandStub = new Mock<ICommand>();
            string commandName = "CreateShampoo";
            var shampooName = "Nivea";
            var shampooBrand = "Maaan";
            var shampooPrice = "15";
            var shampooGender = "men";
            var shampooMilliliters = "100";
            var shampooUsage = "everyday";

            var commandParameters = new List<string>()
            {
                shampooName,
                shampooBrand,
                shampooPrice,
                shampooGender,
                shampooMilliliters,
                shampooUsage
            };
            
            // setting up command to process
            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            // setting up commandParser
            var commandsToReturn = new List<ICommand>() { commandStub.Object };
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(commandsToReturn);

            // setting up factory
            var shampooStub = new Mock<IShampoo>();

            factoryStub.Setup(
                x => x.CreateShampoo(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<decimal>(),
                    It.IsAny<GenderType>(),
                    It.IsAny<uint>(),
                    It.IsAny<UsageType>()
                    )).Returns(shampooStub.Object);

            var engine = new FakeCosmeticsEngine(
                factoryStub.Object,
                cartStub.Object,
                commandParserStub.Object
                );

            // act
            engine.Start();

            // assert
            Assert.AreSame(engine.Products.First().Value, shampooStub.Object);
        }

        [Test]
        public void AddNewlyCreatedToothpasteToProducts_WhenProcessingValidCreateToothpasteCommand()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartStub = new Mock<IShoppingCart>();
            var commandParserStub = new Mock<ICommandParser>();

            // setting up command
            var commandStub = new Mock<ICommand>();
            string commandName = "CreateToothpaste";
            var toothpasteName = "Nivea";
            var tootahpasteBrand = "Maaan";
            var toothpastePrice = "15";
            var toothpasteGender = "men";
            var toothpasteIngredients = "Some, Some, SomeMore";

            var commandParameters = new List<string>()
            {
                toothpasteName,
                tootahpasteBrand,
                toothpastePrice,
                toothpasteGender,
                toothpasteIngredients
            };

            // setting up command to process
            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            // setting up commandParser
            var commandsToReturn = new List<ICommand>() { commandStub.Object };
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(commandsToReturn);

            // setting up factory
            var toothpasteStub = new Mock<IToothpaste>();

            factoryStub.Setup(
                x => x.CreateToothpaste(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<decimal>(),
                    It.IsAny<GenderType>(),
                    It.IsAny<IList<string>>()
                    )).Returns(toothpasteStub.Object);

            var engine = new FakeCosmeticsEngine(
                factoryStub.Object,
                cartStub.Object,
                commandParserStub.Object
                );

            // act
            engine.Start();

            // assert
            Assert.AreSame(engine.Products.First().Value, toothpasteStub.Object);
        }

        [Test]
        public void AddProductToTheShoppingCart_WhenProcessingValidAddToShoppingCartCommand()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartMock = new Mock<IShoppingCart>();
            var commandParserStub = new Mock<ICommandParser>();

            // setting up command
            var commandStub = new Mock<ICommand>();
            string commandName = "AddToShoppingCart";
            string productName = "SomeName";

            var commandParameters = new List<string>()
            {
                productName
            };

            // setting up command to process
            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            // setting up commandParser
            var commandsToReturn = new List<ICommand>() { commandStub.Object };
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(commandsToReturn);

            // setting up shopping cart
            cartMock.Setup(x => x.AddProduct(It.IsAny<IProduct>()));

            var engine = new FakeCosmeticsEngine(
                factoryStub.Object,
                cartMock.Object,
                commandParserStub.Object
                );

            engine.Products.Add(productName, null);


            // act
            engine.Start();

            // assert
            cartMock.Verify(x => x.AddProduct(It.IsAny<IProduct>()), Times.Once);
        }

        [Test]
        public void RemoveProductFromTheShoppingCart_WhenProcessingValidRemoveFromShoppingCartCommand()
        {
            // arrange
            var factoryStub = new Mock<ICosmeticsFactory>();
            var cartMock = new Mock<IShoppingCart>();
            var commandParserStub = new Mock<ICommandParser>();

            // setting up command
            var commandStub = new Mock<ICommand>();
            string commandName = "RemoveFromShoppingCart";
            string productName = "SomeName";

            var commandParameters = new List<string>()
            {
                productName
            };

            // setting up command to process
            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            // setting up commandParser
            var commandsToReturn = new List<ICommand>() { commandStub.Object };
            commandParserStub.Setup(x => x.ReadCommands())
                .Returns(commandsToReturn);

            // setting up shopping cart
            cartMock.Setup(x => x.RemoveProduct(It.IsAny<IProduct>()));
            cartMock.Setup(x => x.ContainsProduct(It.IsAny<IProduct>()))
                .Returns(true);

            var engine = new FakeCosmeticsEngine(
                factoryStub.Object,
                cartMock.Object,
                commandParserStub.Object
                );

            engine.Products.Add(productName, null);

            // act
            engine.Start();

            // assert
            cartMock.Verify(x => x.RemoveProduct(It.IsAny<IProduct>()), Times.Once);
        }
    }
}
