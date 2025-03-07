using AtualizaScanc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AtualizaScanc.Infra
{
    public class ScancRepository : IScancRepository<FilialScanc>
    {
        FilialScancContext db = new FilialScancContext();
        public FilialScanc CriarFilial(FilialScanc filial)
        {
            Console.WriteLine("Criando nova Filial");
            db.Add(filial);
            db.SaveChanges();

            return filial;
        }

        public bool DeleteFilial(FilialScanc filial)
        {
            throw new NotImplementedException();
        }

        public List<FilialScanc> GetAllFiliais() 
        {
            var filiais =  db.FiliaisScanc.ToList<FilialScanc>();

            return filiais;
        }

        public FilialScanc GetFilial(Guid filialId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFilial(FilialScanc filial)
        {
            throw new NotImplementedException();
        }
    }
}
