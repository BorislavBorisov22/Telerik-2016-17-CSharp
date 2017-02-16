namespace Dealership.Tests.Engine.DealershipEngineTests.Fakes
{
    using Contracts;
    using Dealership.Engine;
    using Dealership.Factories;
    using System.Collections;
    using System.Collections.Generic;

    internal class FakeDealershipEngine : DealershipEngine
    {
        public FakeDealershipEngine(IDealershipFactory factory, ICommandParser commandParser)
            : base(factory, commandParser)
        {
        }

        public IDealershipFactory Factory
        {
            get
            {
                return base.factory;
            }
        }

        public ICommandParser CommandParser
        {
            get
            {
                return base.commandParser;
            }
        }

        public IUser LoggedUser
        {
            get
            {
                return base.loggedUser;
            }
            set
            {
                base.loggedUser = value;
            }
        }

        public ICollection<IUser> Users
        {
            get
            {
                return base.users;
            }
        }

        public ILogger Logger
        {
            get
            {
                return this.logger;
            }

            set
            {
                this.logger = value;
            }
        }
    }
}
