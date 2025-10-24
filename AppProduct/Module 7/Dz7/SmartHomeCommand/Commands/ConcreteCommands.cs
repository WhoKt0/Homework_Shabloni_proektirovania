using System;
using AppProduct.Module_7.Dz7.SmartHome.Devices;

namespace AppProduct.Module_7.Dz7.SmartHome.Commands
{
    public class NullCommand : ICommand
    {
        public string Name => "None";
        public bool Executed { get; private set; }
        public void Execute() { Console.WriteLine("Кнопка не назначена."); Executed = false; }
        public void Undo() {}
    }

    public abstract class CommandBase : ICommand
    {
        public bool Executed { get; protected set; }
        public abstract string Name { get; }
        public abstract void Execute();
        public abstract void Undo();
    }

    public class LightOnCommand : CommandBase
    {
        private readonly Light _light;
        public override string Name => $"LightOn({_light.Location})";
        public LightOnCommand(Light light) { _light = light; }
        public override void Execute() { _light.On(); Executed = true; }
        public override void Undo() { if (Executed) _light.Off(); }
    }

    public class LightOffCommand : CommandBase
    {
        private readonly Light _light;
        public override string Name => $"LightOff({_light.Location})";
        public LightOffCommand(Light light) { _light = light; }
        public override void Execute() { _light.Off(); Executed = true; }
        public override void Undo() { if (Executed) _light.On(); }
    }

    public class DoorOpenCommand : CommandBase
    {
        private readonly Door _door;
        public override string Name => $"DoorOpen({_door.Location})";
        public DoorOpenCommand(Door door) { _door = door; }
        public override void Execute() { _door.Open(); Executed = true; }
        public override void Undo() { if (Executed) _door.Close(); }
    }

    public class DoorCloseCommand : CommandBase
    {
        private readonly Door _door;
        public override string Name => $"DoorClose({_door.Location})";
        public DoorCloseCommand(Door door) { _door = door; }
        public override void Execute() { _door.Close(); Executed = true; }
        public override void Undo() { if (Executed) _door.Open(); }
    }

    public class ThermostatIncreaseCommand : CommandBase
    {
        private readonly Thermostat _t;
        private readonly int _delta;
        public override string Name => $"Thermo+({_t.Location}:{_delta})";
        public ThermostatIncreaseCommand(Thermostat t, int delta) { _t = t; _delta = delta; }
        public override void Execute() { _t.Increase(_delta); Executed = true; }
        public override void Undo() { if (Executed) _t.Decrease(_delta); }
    }

    public class ThermostatDecreaseCommand : CommandBase
    {
        private readonly Thermostat _t;
        private readonly int _delta;
        public override string Name => $"Thermo-({_t.Location}:{_delta})";
        public ThermostatDecreaseCommand(Thermostat t, int delta) { _t = t; _delta = delta; }
        public override void Execute() { _t.Decrease(_delta); Executed = true; }
        public override void Undo() { if (Executed) _t.Increase(_delta); }
    }

    public class MacroCommand : CommandBase
    {
        private readonly ICommand[] _commands;
        public override string Name => "Macro";
        public MacroCommand(params ICommand[] commands) { _commands = commands ?? Array.Empty<ICommand>(); }
        public override void Execute() { foreach (var c in _commands) c.Execute(); Executed = true; }
        public override void Undo() { for (int i=_commands.Length-1;i>=0;i--) _commands[i].Undo(); }
    }
}
