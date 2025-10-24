using System;
using AppProduct.Module_7.Lab7.SmartHome.Devices;
using AppProduct.Module_7.Lab7.SmartHome.Commands;

namespace AppProduct.Module_7.Lab7.SmartHome
{
    class Program
    {
        static void Main()
        {
            var light = new Light("Гостиная");
            var tv = new Television("Гостиная");
            var ac = new AirConditioner("Спальня");

            var remote = new RemoteControl();
            remote.Bind("L-ON", new LightOnCommand(light));
            remote.Bind("L-OFF", new LightOffCommand(light));
            remote.Bind("TV-ON", new TvOnCommand(tv));
            remote.Bind("TV-OFF", new TvOffCommand(tv));
            remote.Bind("AC-ON", new AcOnCommand(ac));
            remote.Bind("AC-20", new AcSetTempCommand(ac, 20));
            remote.Bind("AC-ECO", new AcEcoModeCommand(ac, true));

            var evening = new MacroCommand(
                new LightOnCommand(light),
                new TvOnCommand(tv),
                new AcOnCommand(ac),
                new AcSetTempCommand(ac, 22)
            );
            remote.Bind("SCENE-EVENING", evening);

            remote.Press("L-ON");
            remote.Press("AC-ON");
            remote.Press("AC-20");
            remote.PressUndo();
            remote.Press("SCENE-EVENING");
            remote.Press("TV-OFF");
            remote.Press("NO-CMD"); // пустой слот
        }
    }
}
