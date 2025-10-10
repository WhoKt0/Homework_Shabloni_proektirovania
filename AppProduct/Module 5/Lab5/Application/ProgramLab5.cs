using System;
using System.Linq;
using System.Threading.Tasks;
using AppProduct.Module_5.Lab5.SingletonLogger;
using AppProduct.Module_5.Lab5.ComputerBuilder;
using AppProduct.Module_5.Lab5.DocumentPrototype;

namespace AppProduct.Module_5.Lab5
{
    public class ProgramLab5
    {
        public static void Main()
        {
            var logger = Logger.Instance;
            logger.SetLogLevel(LogLevel.Info);
            logger.Log("start", LogLevel.Info);

            var tasks = Enumerable.Range(0, 6).Select(i => Task.Run(() =>
            {
                var lvl = (LogLevel)(i % 3);
                Logger.Instance.Log($"message {i}", lvl);
            })).ToArray();
            Task.WaitAll(tasks);
            Console.WriteLine("Logs written");

            var office = new ComputerDirector(new OfficeComputerBuilder());
            office.ConstructComputer();
            Console.WriteLine(office.GetComputer());

            var gaming = new ComputerDirector(new GamingComputerBuilder());
            gaming.ConstructComputer();
            Console.WriteLine(gaming.GetComputer());

            var proto = new Document { Title = "Template", Content = "Base" };
            proto.Sections.Add(new Section { Title = "Intro", Text = "Hello" });
            proto.Images.Add(new Image { Url = "http://img/x.png", Caption = "X" });
            var manager = new DocumentManager();
            var doc2 = manager.CreateDocument(proto);
            doc2.Title = "Copy";
            doc2.Sections.Add(new Section { Title = "Extra", Text = "More" });
            Console.WriteLine(proto);
            Console.WriteLine(doc2);

            logger.Log("done", LogLevel.Info);
            Console.WriteLine("Log file path set via temp directory.");
        }
    }
}
