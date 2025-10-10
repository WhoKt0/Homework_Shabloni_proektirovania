using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppProduct.Module_5.Prak5.SingletonLogger;
using AppProduct.Module_5.Prak5.ReportBuilder;
using AppProduct.Module_5.Prak5.GamePrototype;

namespace AppProduct.Module_5.Prak5
{
    public class ProgramPrak5
    {
        public static void Main()
        {
            var cfgPath = Path.Combine(Path.GetTempPath(), "prak5_logger.json");
            File.WriteAllText(cfgPath, "{\"FilePath\": \"" + Path.Combine(Path.GetTempPath(), "prak5_app.log").Replace("\\","/") + "\", \"Level\": 0}");
            Logger.Instance.LoadConfig(cfgPath);
            Logger.Instance.SetMaxSizeBytes(256 * 1024);
            Logger.Instance.Log("start", LogLevel.Info);

            var tasks = Enumerable.Range(0, 8).Select(i => Task.Run(() =>
            {
                var lvl = (LogLevel)(i % 3);
                Logger.Instance.Log($"t{i} msg at {lvl}", lvl);
            })).ToArray();
            Task.WaitAll(tasks);
            Logger.Instance.Log("end", LogLevel.Info);

            var reader = new LogReader(Path.Combine(Path.GetTempPath(), "prak5_app.log"));
            var errors = reader.Read(LogLevel.Error).ToArray();
            Console.WriteLine($"Errors: {errors.Length}");

            var director = new ReportDirector();
            var style = new ReportStyle { BackgroundColor = "#f7f7f7", FontColor = "#222222", FontSize = 16 };
            var textReport = director.ConstructReport(new TextReportBuilder(), style, ("Отчёт", "Содержимое", "Подвал"),
                ("Раздел 1","Текст"), ("Раздел 2","Ещё текст"));
            var htmlReport = director.ConstructReport(new HtmlReportBuilder(), style, ("Sales", "Q1 Results", "© Company"),
                ("North","Up 10%"), ("South","Flat"));
            var pdfReport = director.ConstructReport(new PdfReportBuilder(), style, ("Invoice #42", "Items...", "Total"));

            var outDir = Path.Combine(Path.GetTempPath(), "prak5_reports");
            Directory.CreateDirectory(outDir);
            var p1 = Path.Combine(outDir, "report.txt");
            var p2 = Path.Combine(outDir, "report.html");
            var p3 = Path.Combine(outDir, "report.pdf");
            textReport.Export(p1);
            htmlReport.Export(p2);
            pdfReport.Export(p3);
            Console.WriteLine("Reports exported");

            var mage = new Character
            {
                Name = "Mage",
                Health = 80,
                Strength = 20,
                Agility = 30,
                Intellect = 90,
                Weapon = new Weapon { Name = "Staff", Damage = 12 },
                Armor = new Armor { Name = "Robe", Defense = 5 }
            };
            mage.Skills.Add(new Skill { Title = "Fireball", Kind = "Magic", Power = 50 });
            mage.Skills.Add(new Skill { Title = "Blink", Kind = "Magic", Power = 10 });

            var mage2 = mage.Clone();
            mage2.Name = "Archmage";
            mage2.Intellect = 99;
            mage2.Skills.Add(new Skill { Title = "Meteor", Kind = "Magic", Power = 100 });

            Console.WriteLine($"{mage.Name} skills: {mage.Skills.Count}");
            Console.WriteLine($"{mage2.Name} skills: {mage2.Skills.Count}");
        }
    }
}
