using PepitoSchool.Domain.Entities;
using PepitoSchool.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchool.Domain.Interface
{
    public interface IEstudianteRepository: IRepository<Estudiante>
    {
        Estudiante FindByCarnet(string carnet);
    }
}
