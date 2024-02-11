using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Memento {
    internal class Snapshot {

        private Stack<ConcreteCommand> commands;
        private Database.Database instance;

        public Snapshot(Database.Database instance) {
            this.commands = new Stack<ConcreteCommand>();
            this.instance = instance;
        }

        public void CreateSnapshot(Dictionary<string, object> parameters) {
            this.commands.Push(new ConcreteCommand(parameters, instance));
        }

        public void RestoreSnapshot() {
            if(commands.Count == 0) return;

            ConcreteCommand command = commands.Pop();
            command.undo();
        }

    }
}
