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

        public void SaveAnuncio(AnuncioWebMotors anuncioWebMotors)
        {
            var anuncioForDatabase = new Persistence.DataTransferObjects.AnuncioWebMotors()
            {
                Marca = anuncioWebMotors.Marca.Split("#")[1],
                Modelo = anuncioWebMotors.Modelo.Split("#")[1],
                Versao = anuncioWebMotors.Versao.Split("#")[1],
                Ano = anuncioWebMotors.Ano,
                Quilometragem = anuncioWebMotors.Quilometragem,
                Observacao = anuncioWebMotors.Observacao
            };

            _anuncioMapper.Save(anuncioForDatabase);
        }

        public void UpdateAnuncio(AnuncioWebMotors anuncioWebMotors)
        {
            var anuncioFromDatabase = _anuncioMapper.Get(anuncioWebMotors.Id);

            anuncioFromDatabase.Marca = anuncioWebMotors.Marca.Split("#")[1];
            anuncioFromDatabase.Modelo = anuncioWebMotors.Modelo.Split("#")[1];
            anuncioFromDatabase.Versao = anuncioWebMotors.Versao.Split("#")[1];
            anuncioFromDatabase.Ano = anuncioWebMotors.Ano;
            anuncioFromDatabase.Quilometragem = anuncioWebMotors.Quilometragem;
            anuncioFromDatabase.Observacao = anuncioWebMotors.Observacao;

            _anuncioMapper.Update(anuncioFromDatabase);
        }

        public void DeleteAnuncio(int id)
        {
            var anuncioFromDatabase = _anuncioMapper.Get(id);

            _anuncioMapper.Delete(anuncioFromDatabase);
        }
    }
}
