using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Interfaces {
    public interface IAppLogicFacade {

        string getProviderName();
        IEnumerable<Client> getAllClients(string like);

    }
}
