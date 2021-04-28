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

        public IEnumerable<Modelo> GetModelos(int idDaMarca)
        {
            var modelos = new List<Modelo>();
            var request = new RestRequest("Model", Method.GET);
            request.AddParameter("MakeID", idDaMarca.ToString());
            var response = _restClient.Execute<List<Modelo>>(request);

            if (response.IsSuccessful)
            {
                modelos = response.Data;
            }

            return modelos;
        }

        public IEnumerable<Versao> GetVersoes(int idDoModelo)
        {
            var versoes = new List<Versao>();
            var request = new RestRequest("Version", Method.GET);
            request.AddParameter("ModelID", idDoModelo);
            var response = _restClient.Execute<List<Versao>>(request);

            if (response.IsSuccessful)
            {
                versoes = response.Data;
            }

            return versoes;
        }
    }
}
