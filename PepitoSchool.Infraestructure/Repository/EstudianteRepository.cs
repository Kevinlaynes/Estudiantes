using PepitoSchool.Domain.Entities;
using PepitoSchool.Domain.Interface;
using PepitoSchool.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchool.Infraestructure.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {

        private IPepitoSchoolContext pepitoSchoolContext;

        public EstudianteRepository(IPepitoSchoolContext pepitoSchoolContext)
        {
            this.pepitoSchoolContext = pepitoSchoolContext;
        }
        public void Create(Estudiante t)
        {
            try
            {
                ValidateEmployee(t);
                pepitoSchoolContext.estudiantes.Add(t);
                pepitoSchoolContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Employee no puede ser null.");
                }

                Estudiante estudiante = FindByCarnet(t.Carnet);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto con dni {t.Id} no existe.");
                }

                pepitoSchoolContext.estudiantes.Remove(estudiante);
                int result = pepitoSchoolContext.SaveChanges();

                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante FindByCarnet(string carnet)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(carnet))
                {

                    throw new ArgumentException($"El objeto id no puede ser null o estar vacia");
                }

                return pepitoSchoolContext.estudiantes.FirstOrDefault(x => x.Carnet.Equals(carnet));
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public List<Estudiante> GetAll()
        {
            try
            {
                return pepitoSchoolContext.estudiantes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto estudiante no puede ser null.");
                }

                Estudiante estudiante = FindByCarnet(t.Carnet);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto estudiante con ese  id  no existe.");
                }


                pepitoSchoolContext.estudiantes.Update(estudiante);
                return pepitoSchoolContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        private void ValidateEmployee(Estudiante estudiante)
        {
            if (estudiante == null)
            {
                throw new ArgumentNullException("El objeto employee no puede ser null.");
            }

            if (string.IsNullOrWhiteSpace(estudiante.Carnet))
            {
                throw new Exception("El carnet  no puede ser null o vacio.");
            }

           
        }
    }
}
