using System;
using System.Collections.Generic;
using AppProduct.Module_7.Prak7.SmartHome.Commands;

namespace AppProduct.Module_7.Prak7.SmartHome.Remote
{
    public class RemoteControl
    {
        private readonly Dictionary<int, ICommand> _slots = new Dictionary<int, ICommand>();
        private readonly Stack<ICommand> _undo = new Stack<ICommand>();
        private readonly Stack<ICommand> _redo = new Stack<ICommand>();

        private readonly List<ICommand> _recordBuffer = new List<ICommand>();
        private bool _isRecording = false;

        public void Assign(int slot, ICommand command) => _slots[slot] = command ?? new NullCommand();
        public void Press(int slot)
        {
            if (!_slots.TryGetValue(slot, out var cmd)) cmd = new NullCommand();
            cmd.Execute();
            if (!(cmd is NullCommand))
            {
                _undo.Push(cmd);
                _redo.Clear();
                if (_isRecording) _recordBuffer.Add(cmd);
            }
        }
        public void Undo()
        {
            if (_undo.Count == 0) { Console.WriteLine("Нечего отменять."); return; }
            var cmd = _undo.Pop();
            cmd.Undo();
            _redo.Push(cmd);
        }
        public void Redo()
        {
            if (_redo.Count == 0) { Console.WriteLine("Нечего повторять."); return; }
            var cmd = _redo.Pop();
            cmd.Execute();
            _undo.Push(cmd);
        }

        public void StartRecording() { _recordBuffer.Clear(); _isRecording = true; Console.WriteLine("Запись макро: старт"); }
        public ICommand StopRecording()
        {
            _isRecording = false;
            Console.WriteLine($"Запись макро: стоп ({_recordBuffer.Count} команд)");
            return new MacroCommand(_recordBuffer.ToArray());
        }
    }
}
