using AutoMapper;
using ForumSystem.Services.Contracts;
using System;

namespace ForumSystem.Services
{
    public class MappingService : IMappingService
    {
        public TMapTo Map<TMapTo>(object from)
        {
            if (from == null)
            {
                throw new ArgumentNullException("Mapping from object cannot be null!");
            }

            return Mapper.Map<TMapTo>(from);
        }
    }
}
