using AMS.Application.Mapper.Interfaces;
using AMS.Application.Mapper.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Mapper.Configurations
{
    internal class MapConfiguration:Profile
    {
        public MapConfiguration() 
        { 
            var mappers = GetStandartMaps();
            foreach(var mapper in mappers)
            {
                CreateMap(mapper.Source, mapper.Destination).ReverseMap();
            }
        }

        private static IEnumerable<MapModel> GetStandartMaps()
        {
           var types = Assembly.GetExecutingAssembly().GetTypes();

            return types.Where(x => x.GetInterfaces()
            .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMapTo<>)))
                .Select(x => new MapModel
                {
                    Source = x,
                    Destination = x.GetInterfaces().First().GenericTypeArguments[0]
                }) ;

        }
    }
}
