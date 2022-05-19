using PepitoSchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PepitoSchool.Domain.Interfaces
{
    public interface IPepitoSchoolContext
    {
        public DbSet<Estudiante> estudiantes{ get; set; }
      

        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
