using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Data.Contracts
{
    public interface IAcademyData
    {
        IList<ISeason> Seasons { get; }

        IList<IStudent> Students { get; }

        IList<ITrainer> Trainers { get; }

    }
}
