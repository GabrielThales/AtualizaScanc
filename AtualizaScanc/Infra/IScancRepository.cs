using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualizaScanc.Infra
{
    public interface IScancRepository<T>
    {
        public T CriarFilial(T filial);
        public T GetFilial(Guid filialId);
        public List<T>GetAllFiliais();
        bool UpdateFilial(T filial);
        bool DeleteFilial(T filial);
    }
}
