using AtualizaScanc.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using IWshRuntimeLibrary;

namespace AtualizaScanc
{
    internal class ScancServices
    {

        public void AtualizaScanc(FilialScanc filial, String pathInstaller)
        {


            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = pathInstaller,
                    UseShellExecute = true,
                    Arguments = " /DIR=" + '"' + filial.PathInstall + '"' + " /SILENT"
                };
                
                
                //Process.Start(pathInstaller);


                Process.Start(psi);
                CriaAtalho(filial);

            }
            catch (Exception ex) { 
            
                Console.WriteLine("Algo deu errado:  " + ex.ToString());
            
            }

        }

        public void CriaAtalho(FilialScanc filial)
        {

            try
            {
                if (!System.IO.File.Exists(filial.PathShortcut))
                {
                    WshShell shell = new WshShell();
                    IWshShortcut link = shell.CreateShortcut(filial.PathShortcut);
                    link.TargetPath = filial.PathInstall + "\\BIN\\SCANCCTB.EXE";
                    link.Save();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }

        }

        public void CriaRetificadora(String sourceDir,FilialScanc filial, String destinationDir, bool recursive)
        {

            try
            {

                if (Directory.Exists(sourceDir))
                {
                    var dir = new DirectoryInfo(sourceDir);

                    if(dir.Exists)
                    {

                        DirectoryInfo[] dirs = dir.GetDirectories();

                        Directory.CreateDirectory(destinationDir);

                        foreach (FileInfo file in dir.GetFiles()) {

                            string targetFilePath = Path.Combine(destinationDir, file.Name);
                            file.CopyTo(targetFilePath);

                            Console.WriteLine("Copiando arquivo" + file.Name);

                        }

                        if (recursive)
                        {
                            foreach (DirectoryInfo subDir in dirs)
                            {
                                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                                CriaRetificadora(subDir.FullName, null, newDestinationDir, true);
                            }
                        }


                    }
                }



            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }
}
