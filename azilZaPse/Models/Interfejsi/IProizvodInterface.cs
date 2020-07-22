using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace azilZaPse.Models.Interfejsi
{
    interface IProizvodInterface
    {
        IEnumerable<ProizvedeniProizvodiBO> NadjiProizvod(int idProizvoda);

        void IzbrisiProizvod(int IdProizvoda);

        void menjajStanjeProizvoda(int idProizvoda, int idProizvodjaca, double kolicina);
    }
}
