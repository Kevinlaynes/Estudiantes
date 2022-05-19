using PepitoSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchool.AppCore.Interface
{
    public interface IEstudiantesService : IService<Estudiante>
    {
        Estudiante FindByCarnet(string carnet);

    }
}
