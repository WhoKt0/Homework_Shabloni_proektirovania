using System;
using AppProduct.Module_7.Dz7.SmartHome.Devices;
using AppProduct.Module_7.Dz7.SmartHome.Commands;

namespace AppProduct.Module_7.Dz7.SmartHome
{
    class Program
    {
        static void Main()
        {
            var light = new Light("Гостиная");
            var door = new Door("Входная");
            var thermo = new Thermostat("Коридор");

            var remote = new RemoteControl();
            remote.Bind("L-ON", new LightOnCommand(light));
            remote.Bind("L-OFF", new LightOffCommand(light));
            remote.Bind("D-OPEN", new DoorOpenCommand(door));
            remote.Bind("D-CLOSE", new DoorCloseCommand(door));
            remote.Bind("T-PLUS", new ThermostatIncreaseCommand(thermo, 2));
            remote.Bind("T-MINUS", new ThermostatDecreaseCommand(thermo, 3));

            var macro = new MacroCommand(new LightOnCommand(light), new DoorOpenCommand(door), new ThermostatIncreaseCommand(thermo, 1));
            remote.Bind("SCENE-HOME", macro);

            remote.Press("L-ON");
            remote.Press("D-OPEN");
            remote.Press("T-PLUS");
            remote.Undo();
            remote.Press("SCENE-HOME");
            remote.Press("NO-CMD");
            remote.Undo();
            remote.Undo();
            remote.Undo();
            remote.Undo();
        }
    }
}
