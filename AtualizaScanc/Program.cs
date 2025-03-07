using AtualizaScanc;
using AtualizaScanc.Domain;
using AtualizaScanc.Infra;
using IWshRuntimeLibrary;
using System.Text.Json;


Console.WriteLine("AtualizaScanc");


WindowsService atualizaScanc = new WindowsService();
ScancRepository scancRepository = new ScancRepository();

Console.WriteLine("1 - Atualizar Scanc");
string opcao = Console.ReadLine();
FilialScanc filialScanc = new ("SCANC MALUCO", "C:\\TEMP\\scancShortcut.lnk", "C:\\TEMP\\SCANC");

var json = System.IO.File.ReadAllBytes("c:\\TEMP\\SCANC.json");

var jsonObject = JsonDocument.Parse(json);

var scancPath = @"C:\Sistemas CSC";

IEnumerable<FilialScanc> filiais2 = atualizaScanc.ScanAtalhosEmPasta(scancPath);

/*foreach(var filial in filiais2)
{
    Console.WriteLine(filial.Name);
    scancRepository.CriarFilial(filial);
}*/


var filiaisDB = scancRepository.GetAllFiliais();

foreach(var filial in filiaisDB)
{
    Console.WriteLine(filial.Name);
}



while (opcao != "0")
{
    Console.WriteLine("1 - Atualizar todo Scanc\n");
    Console.WriteLine("2 - Nova retificadora\n");

    switch (opcao)
    {
        case "1":
            Console.WriteLine("Atualizando Scanc");

            atualizaScanc.AtualizaScanc(filialScanc, "C:\\TEMP\\instalar_scanc_ctb.exe");

            break;

        case "2":
            Console.WriteLine("Retificadora");

            atualizaScanc.CriaRetificadora(filialScanc.PathInstall, filialScanc, "c:\\temp\\retif2\\SCANC34564565645447575445566445", true);
            scancRepository.CriarFilial(filialScanc);
            var filiais = scancRepository.GetAllFiliais();
            foreach (FilialScanc filial in filiais)
            {
                Console.WriteLine(filial.Name);
            }


            break;

        case "3":




        default: Console.WriteLine("Opção não encontrada"); break;
    }

}