using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualizaScanc.Domain
{
    public class FilialScanc
    {
        public FilialScanc() { }

        public FilialScanc(string name, string pathShortcut, string pathInstall)
        {
            Name = name;
            PathShortcut = pathShortcut;
            PathInstall = pathInstall;
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public String PathShortcut { get; set; }
        public String PathInstall { get; set; }

    }
}
