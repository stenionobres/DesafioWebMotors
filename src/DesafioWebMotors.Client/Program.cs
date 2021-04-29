using DesafioWebMotors.ApiServices.Services;
using DesafioWebMotors.Persistence.DataTransferObjects;
using DesafioWebMotors.Persistence.Mappers;
using System;

namespace DesafioWebMotors.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //var mapper = new AnuncioWebMotorsMapper();
            //var anuncio = new AnuncioWebMotors()
            //{
            //    Marca = "marca 2",
            //    Modelo = "modelo 2",
            //    Versao = "versao 2",
            //    Ano = 2019,
            //    Quilometragem = 3455,
            //    Observacao = ""
            //};

            //var anuncio2 = mapper.Get(2);


            //mapper.Delete(anuncio2);


            var api = new OnlineChallengeApiService();

            var marcas = api.GetVersoes(idDoModelo: 1);
        }
    }
}
