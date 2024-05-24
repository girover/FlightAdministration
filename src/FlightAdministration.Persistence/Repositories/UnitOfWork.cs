using FlightAdministration.Core.Repositories;
using FlightAdministration.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAdministration.Persistence.Repositories;
public class UnitOfWork(FlightAdministrationDbContext context) : IUnitOfWork {

    private readonly FlightAdministrationDbContext _context = context;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {

        return await _context.SaveChangesAsync(cancellationToken);
    }
}
