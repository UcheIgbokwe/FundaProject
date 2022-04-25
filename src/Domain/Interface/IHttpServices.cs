using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Domain.Entities;

namespace src.Domain.Interface
{
    public interface IHttpServices
    {
        Task<List<PropertyDataModel>> GetAllPropertyData(string type, string zo);
        Task<List<ListedPropertyByAgentModel>> GetAgentsRankedByMostProperties();
        Task<List<ListedPropertyByAgentModel>> GetAgentsRankedByMostPropertiesAndGarden();
    }
}