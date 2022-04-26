using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Domain.Entities;
using Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using src.Domain.Entities;
using src.Domain.Interface;
using src.Infrastructure.Helpers;

namespace src.Infrastructure.Services
{
    public class HttpServices : IHttpServices
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;
        public HttpServices(IConfiguration config, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _config = config;
        }
        public async Task<List<TopAgentsModel>> GetAgentsRankedByMostProperties()
        {
            var type = _config["FundaApi:Type"];
            var zo = _config["FundaApi:Zo"];
            var listedProperties = await GetAllPropertyData(type, zo);
            var result = listedProperties.GroupBy(item => item.MakelaarId)
                                        .Select(group => new TopAgentsModel
                                        {
                                            MakelaarId = group.First().MakelaarId,
                                            MakelaarNaam = group.First().MakelaarNaam,
                                            NumberOfProperties = group.Count()
                                        }).OrderByDescending(c => c.NumberOfProperties).Take(10).ToList();
            return result;
        }
        public async Task<List<TopAgentsModel>> GetAgentsRankedByMostPropertiesAndGarden()
        {
            var type = _config["FundaApi:Type"];
            var zoWithGarden = _config["FundaApi:ZoWithGarden"];
            var listedProperties = await GetAllPropertyData(type, zoWithGarden);
            var result = listedProperties.GroupBy(item => item.MakelaarId)
                                        .Select(group => new TopAgentsModel
                                        {
                                            MakelaarId = group.First().MakelaarId,
                                            MakelaarNaam = group.First().MakelaarNaam,
                                            NumberOfProperties = group.Count()
                                        }).OrderByDescending(c => c.NumberOfProperties).Take(10).ToList();
            return result;
        }
        public async Task<List<PropertyDataModel>> GetAllPropertyData(string type, string zo)
        {
            var listedProperty = new List<PropertyDataModel>();
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
                else if(response.StatusCode == System.Net.HttpStatusCode.TooManyRequests){
                    throw new TooManyRequestException("Kindly try again");
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized){
                    throw new UnauthorizedException("Kindly confirm authorization");
                }else{
                    throw new AppException("An Error occured");
                }
            }
            return listedProperty;
        }
    }
}