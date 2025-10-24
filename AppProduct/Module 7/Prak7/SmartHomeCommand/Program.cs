using System;
using AppProduct.Module_7.Prak7.SmartHome.Commands;
using AppProduct.Module_7.Prak7.SmartHome.Devices;
using AppProduct.Module_7.Prak7.SmartHome.Remote;

namespace AppProduct.Module_7.Prak7.SmartHome
{
    class Program
    {
        static void Main()
        {
            var remote = new RemoteControl();

            var livingLight = new Light("Гостиная");
            var ac = new AirConditioner("Спальня");
            var tv = new Television("Гостиная");
            var shades = new Shades("Кухня");

            remote.Assign(1, new LightOnCommand(livingLight));
            remote.Assign(2, new LightOffCommand(livingLight));
            remote.Assign(3, new AcOnCommand(ac));
            remote.Assign(4, new AcSetTempCommand(ac, 21));
            remote.Assign(5, new TvOnCommand(tv));
            remote.Assign(6, new TvSetChannelCommand(tv, 5));
            remote.Assign(7, new ShadesCloseCommand(shades));
            remote.Assign(8, new ShadesOpenCommand(shades));

            remote.Press(1);
            remote.Press(3);
            remote.Press(4);
            remote.Undo();
            remote.Redo();

            remote.StartRecording();
            remote.Press(5);
            remote.Press(6);
            remote.Press(7);
            var macro = remote.StopRecording();

            var party = new MacroCommand(new LightOnCommand(livingLight), new AcSetTempCommand(ac, 20), macro);
            party.Execute();
            party.Undo();

            remote.Press(99); // пустой слот
        }
    }
}
