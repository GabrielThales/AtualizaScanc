using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualizaScanc.Domain
{
    internal class FilialScanc
    {
        public FilialScanc(Guid id, string name, string pathShortcut, string pathInstall)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PathShortcut = pathShortcut ?? throw new ArgumentNullException(nameof(pathShortcut));
            PathInstall = pathInstall ?? throw new ArgumentNullException(nameof(pathInstall));
        }

        public Guid Id { get; }
        public String Name { get; set; }
        public String PathShortcut { get; set; }
        public String PathInstall { get; set; }

    }
}
