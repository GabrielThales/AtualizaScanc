﻿using AtualizaScanc.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using IWshRuntimeLibrary;
using AtualizaScanc.Infra;

namespace AtualizaScanc
{
    public class WindowsService
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
                    //scancRepository.GetAllFiliais();
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
                                CriaRetificadora(subDir.FullName, filial, newDestinationDir, true);
                            }
                        }


                    }

                }


            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public IEnumerable<FilialScanc> ScanAtalhosEmPasta(string folderPath)
        {
            var directoryInfo = new DirectoryInfo(folderPath);
            var lnkFiles = directoryInfo.GetFiles("*.lnk", SearchOption.AllDirectories);
            var count = 0;
            var filiais = new List<FilialScanc>();

            foreach (var lnkFile in lnkFiles)
            {
                string targetPath = GetShortcutTargetPath(lnkFile.FullName);
                //Console.WriteLine($"Atalho: {lnkFile.FullName} -> Executável: {targetPath}");
                if ((!System.IO.File.Exists(targetPath)) && targetPath.Contains("SCANCCTB.exe"))
                {
                    count++;
                    filiais.Add(new FilialScanc(lnkFile.Name, lnkFile.FullName, targetPath.Replace("BIN\\SCANCCTB.exe", "")));

                }

            }
            Console.WriteLine($"Total de Fliais encontradas: {count}");
            return filiais;
        }
        public string GetShortcutTargetPath(string shortcutPath)
        {
            var shell = new WshShell();
            var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            return shortcut.TargetPath;
        }


    }


}
