using Academy.Data.Contracts;
using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Data
{
    public class AcademyData : IAcademyData
    {
        public AcademyData()
        {
            this.Seasons = new List<ISeason>();
            this.Students = new List<IStudent>();
            this.Trainers = new List<ITrainer>();
        }

        public IList<ISeason> Seasons { get; private set; }

        public IList<IStudent> Students { get; private set; }

        public IList<ITrainer> Trainers { get; private set; }
    }
}
