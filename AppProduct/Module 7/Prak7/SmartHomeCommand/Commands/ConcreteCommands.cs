using AppProduct.Module_7.Prak7.SmartHome.Devices;
using System;

namespace AppProduct.Module_7.Prak7.SmartHome.Commands
{
    public class NullCommand : ICommand
    {
        public string Name => "None";
        public void Execute() { Console.WriteLine("Команда не назначена."); }
        public void Undo() { }
    }

    public class LightOnCommand : ICommand
    {
        private readonly Light _light;
        public string Name => $"LightOn({_light.Location})";
        public LightOnCommand(Light light) { _light = light; }
        public void Execute() => _light.On();
        public void Undo() => _light.Off();
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _light;
        public string Name => $"LightOff({_light.Location})";
        public LightOffCommand(Light light) { _light = light; }
        public void Execute() => _light.Off();
        public void Undo() => _light.On();
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
        private int _prevTemp;
        public string Name => $"AcSetTemp({_ac.Location}:{_newTemp})";
        public AcSetTempCommand(AirConditioner ac, int newTemp) { _ac = ac; _newTemp = newTemp; }
        public void Execute() { _prevTemp = _ac.Temperature; _ac.SetTemperature(_newTemp); }
        public void Undo() { _ac.SetTemperature(_prevTemp); }
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

    public class TvSetChannelCommand : ICommand
    {
        private readonly Television _tv;
        private readonly int _channel;
        private int _prev;
        public string Name => $"TvSetChannel({_tv.Location}:{_channel})";
        public TvSetChannelCommand(Television tv, int channel) { _tv = tv; _channel = channel; }
        public void Execute() { _prev = _tv.Channel; _tv.SetChannel(_channel); }
        public void Undo() { _tv.SetChannel(_prev); }
    }

    public class ShadesOpenCommand : ICommand
    {
        private readonly Shades _s;
        public string Name => $"ShadesOpen({_s.Location})";
        public ShadesOpenCommand(Shades s) { _s = s; }
        public void Execute() => _s.Open();
        public void Undo() => _s.Close();
    }

    public class ShadesCloseCommand : ICommand
    {
        private readonly Shades _s;
        public string Name => $"ShadesClose({_s.Location})";
        public ShadesCloseCommand(Shades s) { _s = s; }
        public void Execute() => _s.Close();
        public void Undo() => _s.Open();
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
