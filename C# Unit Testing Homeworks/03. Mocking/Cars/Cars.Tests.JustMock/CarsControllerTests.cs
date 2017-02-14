namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;
    
    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
             // : this(new JustMockCarsRepository())
             : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortedShouldThrowArgumenExceptionWhenParameterIsInvalid()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("invalid parameter"));
        }

        [TestMethod]
        public void SearchingByMakeShouldReturnCorrectMakeCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search("BMW"));

            foreach (var car in model)
            {
                Assert.AreEqual("BMW", car.Make);
            }
        }

        [TestMethod]
        public void SortingWithParameterMakeShouldReturnTheSameCarsNumberAsIndex()
        {
            var sortedByMake = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));
            var allCars = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(allCars.Count, sortedByMake.Count);
        }

        [TestMethod]
        public void SortingWithParameterYearShouldReturnTheSameCarsNumberAsIndex()
        {
            var sortedByYear = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));
            var allCars = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(allCars.Count, sortedByYear.Count);
        }

        [TestMethod]
        public void SortWithParameterMakeShouldReturnAllCarsSortedByMake()
        {
            // arrange
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));
            var allCars = (IList<Car>)this.GetModel(() => this.controller.Index());
            var allCarsSorted = allCars.OrderBy(c => c.Make).ToList();
            bool isSorted = true;

            // act
            for (int i=0; i < model.Count; i++)
            {
                var modelCar = model[i];
                var allCar = allCarsSorted[i];

                if (modelCar.Make.CompareTo(allCar.Make) != 0)
                {
                    isSorted = false;
                    break;
                }
            }

            // assert
            Assert.IsTrue(isSorted);
        }

        [TestMethod]
        public void SortWithParameterYearShouldReturnAllCarsSortedCorrectly()
        {
            var sorted = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));
            var allCars = (IList<Car>)this.GetModel(() => this.controller.Index());
            allCars = allCars.OrderBy(c => c.Year).ToList();

            bool isSorted = true;

            for (int i=0; i < allCars.Count; i++)
            {
                var sortedCar = sorted[i];
                var allCar = allCars[i];

                if (sortedCar.Year != allCar.Year)
                {
                    isSorted = false;
                    break;
                }
            }

            Assert.IsTrue(isSorted);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
