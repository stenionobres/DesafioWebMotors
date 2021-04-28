using System.Linq;
using System.Collections.Generic;
using DesafioWebMotors.Application.Models;
using DesafioWebMotors.Persistence.Mappers;

namespace DesafioWebMotors.Application.Services
{
    public class AnuncioService
    {
        private readonly AnuncioWebMotorsMapper _anuncioMapper;

        public AnuncioService(AnuncioWebMotorsMapper anuncioMapper)
        {
            _anuncioMapper = anuncioMapper;
        }

        public IEnumerable<AnuncioWebMotors> GetAnuncios()
        {
            var anuncios = _anuncioMapper.GetAll();

            return anuncios.Select(anuncioFromDatabase => new AnuncioWebMotors() 
            {
                Id = anuncioFromDatabase.Id,
                Marca = anuncioFromDatabase.Marca,
                Modelo = anuncioFromDatabase.Modelo,
                Versao = anuncioFromDatabase.Versao,
                Ano = anuncioFromDatabase.Ano,
                Quilometragem = anuncioFromDatabase.Quilometragem,
                Observacao = anuncioFromDatabase.Observacao
            });
        }

        public AnuncioWebMotors GetAnuncio(int id)
        {
            var anuncioFromDatabase = _anuncioMapper.Get(id);

            return new AnuncioWebMotors()
            {
                Id = anuncioFromDatabase.Id,
                Marca = anuncioFromDatabase.Marca,
                Modelo = anuncioFromDatabase.Modelo,
                Versao = anuncioFromDatabase.Versao,
                Ano = anuncioFromDatabase.Ano,
                Quilometragem = anuncioFromDatabase.Quilometragem,
                Observacao = anuncioFromDatabase.Observacao
            };
        }
    }
}
