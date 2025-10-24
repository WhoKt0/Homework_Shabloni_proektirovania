using System;
using System.Collections.Generic;

namespace AppProduct.Module_7.Dz7.SmartHome.Commands
{
    public class RemoteControl
    {
        private readonly Dictionary<string, ICommand> _slots = new();
        private readonly Stack<ICommand> _history = new();

        public void Bind(string key, ICommand command) => _slots[key] = command ?? new NullCommand();

        public void Press(string key)
        {
            if (!_slots.TryGetValue(key, out var cmd)) cmd = new NullCommand();
            Console.WriteLine($"> [{key}] {cmd.Name}");
            cmd.Execute();
            if (cmd.Executed) _history.Push(cmd);
        }

        public void Undo()
        {
            if (_history.Count == 0) { Console.WriteLine("История пуста — отменять нечего."); return; }
            var cmd = _history.Pop();
            Console.WriteLine($"> UNDO {cmd.Name}");
            cmd.Undo();
        }
    }
}
