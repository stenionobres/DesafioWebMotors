using System.Linq;
using System.Collections.Generic;
using DesafioWebMotors.Persistence.DataTransferObjects;
using DesafioWebMotors.Persistence.EntityFrameworkContexts;

namespace DesafioWebMotors.Persistence.Mappers
{
    public class AnuncioWebMotorsMapper
    {
        public AnuncioWebMotors Get(int id)
        {
            using (var context = new DesafioWebMotorsDbContext())
            {
                var anuncio = context.AnuncioWebMotors.Find(id);

                return anuncio;
            }
        }

        public IEnumerable<AnuncioWebMotors> GetAll()
        {
            using (var context = new DesafioWebMotorsDbContext())
            {
                var anuncios = context.AnuncioWebMotors.ToList();

                return anuncios;
            }
        }

        public void Save(AnuncioWebMotors anuncio)
        {
            using (var context = new DesafioWebMotorsDbContext())
            {
                context.AnuncioWebMotors.Add(anuncio);
                context.SaveChanges();
            }
        }

        public void Update(AnuncioWebMotors anuncio)
        {
            using (var context = new DesafioWebMotorsDbContext())
            {
                context.AnuncioWebMotors.Update(anuncio);
                context.SaveChanges();
            }
        }

        public void Delete(AnuncioWebMotors anuncio)
        {
            using (var context = new DesafioWebMotorsDbContext())
            {
                context.AnuncioWebMotors.Remove(anuncio);
                context.SaveChanges();
            }
        }
    }
}
