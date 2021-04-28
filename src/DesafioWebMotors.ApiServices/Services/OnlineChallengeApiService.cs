using RestSharp;
using System.Collections.Generic;
using DesafioWebMotors.ApiServices.DataTransferObjects;

namespace DesafioWebMotors.ApiServices.Services
{
    public class OnlineChallengeApiService
    {
        private string _baseUrl => "https://desafioonline.webmotors.com.br/api/OnlineChallenge/";

        private RestClient _restClient;

        public OnlineChallengeApiService()
        {
            _restClient = new RestClient(_baseUrl);
        }

        public IEnumerable<Marca> GetMarcas()
        {
            var marcas = new List<Marca>();
            var request = new RestRequest("Make", Method.GET);
            var response = _restClient.Execute<List<Marca>>(request);

            if (response.IsSuccessful)
            {
                marcas = response.Data;
            }

            return marcas;
        }
    }
}
