using AtualizaScanc;
using AtualizaScanc.Domain;

Console.WriteLine("AtualizaScanc");

ScancServices atualizaScanc = new ScancServices();

Console.WriteLine("1 - Atualizar Scanc");
string opcao = Console.ReadLine();

FilialScanc filialScanc = new FilialScanc(Guid.NewGuid(),"SCANC MALUCO", "C:\\TEMP\\scancShortcut.lnk", "C:\\TEMP\\SCANC");

switch (opcao)
{
    case "1": Console.WriteLine("Atualizando Scanc");

        atualizaScanc.AtualizaScanc(filialScanc, "C:\\TEMP\\instalar_scanc_ctb.exe");
        
        break;

    case "2": Console.WriteLine("Retificadora");

        atualizaScanc.CriaRetificadora(filialScanc.PathInstall,filialScanc, "c:\\temp\\retif2\\SCANC301224", true);

        break;




    default: Console.WriteLine("Opção não encontrada");break;
}