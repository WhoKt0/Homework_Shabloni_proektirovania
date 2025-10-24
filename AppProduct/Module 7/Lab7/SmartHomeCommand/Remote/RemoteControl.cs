using System;
using System.Collections.Generic;

namespace AppProduct.Module_7.Lab7.SmartHome.Commands
{
    public class RemoteControl
    {
        private readonly Dictionary<string, ICommand> _buttons = new();
        private readonly Stack<ICommand> _undo = new();
        public void Bind(string key, ICommand command) => _buttons[key] = command ?? new NullCommand();
        public void Press(string key)
        {
            if (!_buttons.TryGetValue(key, out var cmd)) cmd = new NullCommand();
            Console.WriteLine($"> [{key}] -> {cmd.Name}");
            cmd.Execute();
            if (cmd is not NullCommand) _undo.Push(cmd);
        }
        public void PressUndo()
        {
            if (_undo.Count == 0) { Console.WriteLine("Нечего отменять."); return; }
            var cmd = _undo.Pop();
            Console.WriteLine($"> UNDO {cmd.Name}");
            cmd.Undo();
        }
    }
}
