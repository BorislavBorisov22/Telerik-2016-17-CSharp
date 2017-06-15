using Ninject.Modules;
using Dealership.Engine.Providers;
using Dealership.Contracts;
using Dealership.Models;
using Dealership.Factories;
using Dealership.Factories.Contracts;
using Ninject.Extensions.Factory;
using Dealership.Engine;
using Dealership.CommandHandlers.Contracts;
using Dealership.CommandHandlers;
using Ninject;
using Dealership.Engine.Providers.Contracts;

namespace Dealership.Container
{
    public class DealershipModule : NinjectModule
    {
        private const string UserName = "User";
        private const string CommentName = "Comment";
        private const string CarName = "Car";
        private const string MotorcycleName = "Motorcycle";
        private const string TruckName = "Truck";

        public override void Load()
        {
            this.Bind<IEngine>().To<DealershipEngine>().InSingletonScope();

            this.Bind<ICommand>().To<Command>();
            this.Bind<IUser>().To<User>().Named(UserName);
            this.Bind<IComment>().To<Comment>().Named(CommentName);
            this.Bind<IVehicle>().To<Car>().Named(CarName);
            this.Bind<IVehicle>().To<Motorcycle>().Named(MotorcycleName);
            this.Bind<IVehicle>().To<Truck>().Named(TruckName);

            this.Bind<IUserProvider>().To<UserProvider>().InSingletonScope();
            this.Bind<IDealershipFactory>().ToFactory().InSingletonScope();
            this.Bind<IInputOutputProvider>().To<InputOutputProvider>().InSingletonScope();
            this.Bind<IReportsProvider>().To<ReportsProvider>().InSingletonScope();

            this.Bind<ICommandHandler>()
                .ToMethod(context =>
                {
                    var userNotLoggedHandler = context.Kernel.Get<UserNotLoggedHandler>();
                    var registerHandler = context.Kernel.Get<RegisterUserHandler>();
                    var loginHandler = context.Kernel.Get<LoginUserHandler>();
                    var logoutUserHandler = context.Kernel.Get<LogoutUserHandler>();
                    var addVehicleHandler = context.Kernel.Get<AddVehicleHandler>();
                    var removeVehicleHandler = context.Kernel.Get<RemoveVehicleHandler>();
                    var addCommentHandler = context.Kernel.Get<AddCommentHandler>();
                    var removeCommentHandler = context.Kernel.Get<RemoveCommentHandler>();
                    var showUsersHandler = context.Kernel.Get<ShowUsersHandler>();
                    var showVehiclesHandler = context.Kernel.Get<ShowVehiclesHandler>();

                    userNotLoggedHandler.SetSuccessor(registerHandler);
                    registerHandler.SetSuccessor(loginHandler);
                    loginHandler.SetSuccessor(logoutUserHandler);
                    logoutUserHandler.SetSuccessor(addVehicleHandler);
                    addVehicleHandler.SetSuccessor(removeVehicleHandler);
                    removeVehicleHandler.SetSuccessor(addCommentHandler);
                    addCommentHandler.SetSuccessor(removeCommentHandler);
                    removeCommentHandler.SetSuccessor(showUsersHandler);
                    showUsersHandler.SetSuccessor(showVehiclesHandler);

                    return userNotLoggedHandler;
                })
                .WhenInjectedInto<IEngine>().InSingletonScope();

            this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
        }
    }
}
