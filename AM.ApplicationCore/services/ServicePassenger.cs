using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.Services;
using AM.ApplicationCore.interfaces;

namespace AM.ApplicationCore.services
{
    public class ServicePassenger : Service<Passenger>, IServicePassenger
    {
        public ServicePassenger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
