using PepitoSchool.AppCore.Interface;
using PepitoSchool.Domain.Entities;
using PepitoSchool.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchool.AppCore.Service
{
    public class EstudianreServuce : IEstudiantesService
    {

        private IEstudianteRepository estudianteRepository;
        public EstudianreServuce(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }
        public void Create(Estudiante t)
        {
            if (t == null)
            {
#pragma warning disable CA2208 // Crear instancias de las excepciones del argumento correctamente
                throw new ArgumentNullException("El Asset no puede ser null.");
#pragma warning restore CA2208 // Crear instancias de las excepciones del argumento correctamente
            }

            estudianteRepository.Create(t);
        }

        public bool Delete(Estudiante t)
        {
            return estudianteRepository.Delete(t);
        }

        public Estudiante FindByCarnet(string carnet)
        {
            return estudianteRepository.FindByCarnet(carnet);
        }

        public List<Estudiante> GetAll()
        {
            return estudianteRepository.GetAll();
        }

        public int Update(Estudiante t)
        {
            return estudianteRepository.Update(t);
        }
    }
}
