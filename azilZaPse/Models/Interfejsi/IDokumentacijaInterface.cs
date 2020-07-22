using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace azilZaPse.Models.Interfejsi
{
    public interface IDokumentacijaInterface
    {
        void DodajDokumentaciju(DokumentacijaBO dokumentacija);

        void DodajVlasnika(VlasnikBO vlasnik);

        IEnumerable<DokumentacijaBO> NadjiDokumentaciju(string idVlasnika);
    }
}
