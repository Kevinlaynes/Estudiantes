using PepitoSchool.Domain.Entities;
using PepitoSchool.Domain.Interfaces;

namespace PepitoSchool.Domain.Interface
{
    public interface IEstudianteRepository: IRepository<Estudiante>
    {
        Estudiante FindByCarnet(string carnet);
    }
}
