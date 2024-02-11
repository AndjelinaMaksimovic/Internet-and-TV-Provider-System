using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Memento {
    internal class Snapshot {

        private Stack<ConcreteCommand> commandsUndo;
        private Stack<ConcreteCommand> commandsRedo;
        private Database.Database instance;

        public Snapshot(Database.Database instance) {
            this.commandsUndo = new Stack<ConcreteCommand>();
            this.commandsRedo = new Stack<ConcreteCommand>();
            this.instance = instance;
        }

        public void CreateSnapshot(Dictionary<string, object> parameters) {
            this.commandsUndo.Push(new ConcreteCommand(parameters, instance));
        }

        public void RestoreSnapshot() {
            if(commandsUndo.Count == 0) return;

            ConcreteCommand command = commandsUndo.Pop();
            commandsRedo.Push(command);
            command.undo();
        }

    }
}
