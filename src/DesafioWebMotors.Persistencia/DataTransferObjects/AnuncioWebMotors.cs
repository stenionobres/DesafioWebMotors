﻿
namespace DesafioWebMotors.Persistence.DataTransferObjects
{
    public class AnuncioWebMotors
    {
        public int Id { get; set; }
        
        public string Marca { get; set; }
        
        public string Modelo { get; set; }
       
        public string Versao { get; set; }

        public int Ano { get; set; }

        public int Quilometragem { get; set; }
        
        public string Observacao { get; set; }
    }
}
