﻿using Academy.Commands.Contracts;
using Academy.Data.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    public class ListUsersInSeasonCommand : ICommand
    {
        private readonly IAcademyData academyData;

        public ListUsersInSeasonCommand(IAcademyData academyData)
        {
            this.academyData = academyData ?? throw new ArgumentNullException("AcademyData cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.academyData.Seasons[int.Parse(seasonId)];

            return season.ListUsers();
        }
    }
}
