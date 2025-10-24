using System;
using AppProduct.Module_7.Lab7.SmartHome.Devices;

namespace AppProduct.Module_7.Lab7.SmartHome.Commands
{
    public class NullCommand : ICommand
    {
        public string Name => "None";
        public void Execute() { Console.WriteLine("Кнопка не назначена."); }
        public void Undo() {}
    }

    public class LightOnCommand : ICommand
    {
        private readonly Light _l;
        public string Name => $"LightOn({_l.Location})";
        public LightOnCommand(Light l) { _l = l; }
        public void Execute() => _l.On();
        public void Undo() => _l.Off();
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _l;
        public string Name => $"LightOff({_l.Location})";
        public LightOffCommand(Light l) { _l = l; }
        public void Execute() => _l.Off();
        public void Undo() => _l.On();
    }

    public class TvOnCommand : ICommand
    {
        private readonly Television _tv;
        public string Name => $"TvOn({_tv.Location})";
        public TvOnCommand(Television tv) { _tv = tv; }
        public void Execute() => _tv.On();
        public void Undo() => _tv.Off();
    }

    public class TvOffCommand : ICommand
    {
        private readonly Television _tv;
        public string Name => $"TvOff({_tv.Location})";
        public TvOffCommand(Television tv) { _tv = tv; }
        public void Execute() => _tv.Off();
        public void Undo() => _tv.On();
    }

    public class AcOnCommand : ICommand
    {
        private readonly AirConditioner _ac;
        public string Name => $"AcOn({_ac.Location})";
        public AcOnCommand(AirConditioner ac) { _ac = ac; }
        public void Execute() => _ac.On();
        public void Undo() => _ac.Off();
    }

    public class AcOffCommand : ICommand
    {
        private readonly AirConditioner _ac;
        public string Name => $"AcOff({_ac.Location})";
        public AcOffCommand(AirConditioner ac) { _ac = ac; }
        public void Execute() => _ac.Off();
        public void Undo() => _ac.On();
    }

    public class AcSetTempCommand : ICommand
    {
        private readonly AirConditioner _ac;
        private readonly int _newTemp;
        private int _prev;
        public string Name => $"AcSetTemp({_ac.Location}:{_newTemp})";
        public AcSetTempCommand(AirConditioner ac, int temp) { _ac = ac; _newTemp = temp; }
        public void Execute() { _prev = _ac.Temperature; _ac.SetTemp(_newTemp); }
        public void Undo() { _ac.SetTemp(_prev); }
    }

    public class AcEcoModeCommand : ICommand
    {
        private readonly AirConditioner _ac;
        private readonly bool _mode;
        private bool _prev;
        public string Name => $"AcEco({_ac.Location}:{_mode})";
        public AcEcoModeCommand(AirConditioner ac, bool mode) { _ac = ac; _mode = mode; }
        public void Execute() { _prev = _ac.EcoMode; _ac.SetEco(_mode); }
        public void Undo() { _ac.SetEco(_prev); }
    }

    public class MacroCommand : ICommand
    {
        private readonly ICommand[] _commands;
        public string Name => "Macro";
        public MacroCommand(params ICommand[] commands) { _commands = commands ?? Array.Empty<ICommand>(); }
        public void Execute() { foreach (var c in _commands) c.Execute(); }
        public void Undo() { for (int i=_commands.Length-1;i>=0;i--) _commands[i].Undo(); }
    }
}
