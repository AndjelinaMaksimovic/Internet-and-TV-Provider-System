using library.AppLogic.Interfaces;
using library.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic {
    public class AppLogic : IAppLogicFacade {

        private string _configFilepath = "../../../../../config.txt";

        public string getProviderName() {
            return TextParser.Parse(_configFilepath)["PROVIDER"];
        }


    }
}
