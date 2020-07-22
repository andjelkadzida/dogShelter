using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace azilZaPse.Models.Interfejsi
{
    public interface IKuceInterface
    {
        void Dodaj (KuceBO kuce);
        void Udomi(int idKuceta);
        IEnumerable<KuceBO> NadjiKucePoParametrima(int Starost, string rasa, string pol);

        void UpdateKartona(KartonPsaBO karton);
    }
}
