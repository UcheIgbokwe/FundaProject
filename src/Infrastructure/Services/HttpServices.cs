using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using src.Domain.Entities;
using src.Domain.Interface;

namespace src.Infrastructure.Services
{
    public class HttpServices : IHttpServices
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<HttpServices> _logger;
        public HttpServices(IConfiguration config, IHttpClientFactory clientFactory,  ILogger<HttpServices> logger)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _config = config;
        }
        public async Task<List<ListedPropertyByAgentModel>> GetAgentsRankedByMostProperties()
        {
            try
            {
                var type = _config["FundaApi:Type"];
                var zo = _config["FundaApi:Zo"];
                var listedProperties = await GetAllPropertyData(type, zo);
                var result = listedProperties.GroupBy(item => item.MakelaarId)
                                            .Select(group => new ListedPropertyByAgentModel
                                            {
                                                MakelaarId = group.First().MakelaarId,
                                                MakelaarNaam = group.First().MakelaarNaam,
                                                Objects = group.ToList()
                                            }).OrderByDescending(c => c.Objects?.Count).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured.");
                return new List<ListedPropertyByAgentModel>();
            }
        }
        public async Task<List<ListedPropertyByAgentModel>> GetAgentsRankedByMostPropertiesAndGarden()
        {
            try
            {
                var type = _config["FundaApi:Type"];
                var zoWithGarden = _config["FundaApi:ZoWithGarden"];
                var listedProperties = await GetAllPropertyData(type, zoWithGarden);
                var result = listedProperties.GroupBy(item => item.MakelaarId)
                                            .Select(group => new ListedPropertyByAgentModel
                                            {
                                                MakelaarId = group.First().MakelaarId,
                                                MakelaarNaam = group.First().MakelaarNaam,
                                                Objects = group.ToList()
                                            }).OrderByDescending(c => c.Objects?.Count).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured.");
                return new List<ListedPropertyByAgentModel>();
            }
        }
        public async Task<List<PropertyDataModel>> GetAllPropertyData(string type, string zo)
        {
            var listedProperty = new List<PropertyDataModel>();
            try
            {
                bool pageAvailable = true;
                int page = 1;
                var client = _clientFactory.CreateClient("fundaPartner");
                client.DefaultRequestHeaders.Accept.Clear();

                var builder = new UriBuilder(_config["FundaApi:BaseUrl"]);
                while (pageAvailable)
                {
                    var query = HttpUtility.ParseQueryString(builder.Query);
                    query["type"] = type;
                    query["zo"] = zo;
                    query["page"] = page.ToString();
                    query["pagesize"] = "25";
                    builder.Query = query.ToString();

                    var url = builder.ToString();

                    using var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = JsonConvert.DeserializeObject<ListedPropertyModel>(response.Content.ReadAsStringAsync().Result);
                        listedProperty.AddRange(resp?.Objects!);
                        //Check if number of pages have been exceeded and return false to stop loop.
                        if(page > resp?.Paging?.AantalPaginas)
                        {
                            pageAvailable = false;
                        }else{
                            page ++;
                        }
                    }
                }
                return listedProperty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured.");
                return listedProperty;
            }
        }
    }
}