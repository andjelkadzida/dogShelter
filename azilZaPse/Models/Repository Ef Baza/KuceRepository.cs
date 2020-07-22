using azilZaPse.Models.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models.Repository_Ef_Baza
{
    public class KuceRepository : IKuceInterface
    {

        private AzilZaPseEntities1 azilEntities = new AzilZaPseEntities1();


        public void Dodaj(KuceBO novoKuce)
        {
            Kuce kuca = new Kuce();
            Kuce PostojiKuce = azilEntities.Kuces.FirstOrDefault(x => x.idCipa == novoKuce.IdCipa);                 //ne dopustiti kreiranje novog kuceta ako vec postoji
            if (PostojiKuce == null)                                                                                //kako vratiti korisniku informacije?
            {
                kuca.idCipa = novoKuce.IdCipa;
                kuca.idVlasnika = novoKuce.IdVlasnika;
                kuca.ime = novoKuce.Ime;
                kuca.pol = novoKuce.Pol;
                kuca.rasa = novoKuce.Rasa;
                kuca.starost = novoKuce.Starost;
                kuca.uAzilu = true;
                azilEntities.Kuces.Add(kuca);
                azilEntities.SaveChanges();
            }
        }

        public IEnumerable<KuceBO> KuciciUAzilu()                                               //funkcija koju koristimo kada nam trebaju samo kucici koji su u azilu
        {
            List<KuceBO> lista = new List<KuceBO>();
            foreach (Kuce kuce in azilEntities.Kuces)
            {
                if (kuce.uAzilu == true)
                {
                    KuceBO trazenoKuce = new KuceBO();
                    trazenoKuce.IdCipa = kuce.idCipa;
                    trazenoKuce.IdVlasnika = kuce.idVlasnika;
                    trazenoKuce.Ime = kuce.ime;
                    trazenoKuce.Pol = kuce.pol;
                    trazenoKuce.Rasa = kuce.rasa;
                    trazenoKuce.Starost = kuce.starost;
                    trazenoKuce.UAzilu = kuce.uAzilu;
                    lista.Add(trazenoKuce);
                }
            }
            return lista;
        }

        public IEnumerable<KuceBO> NadjiKucePoParametrima(int starost, string rasa, string pol)
        {
            List<KuceBO> lista = new List<KuceBO>();
            foreach(Kuce kuce in azilEntities.Kuces)
            {
                if(kuce.starost == starost || kuce.rasa == rasa || kuce.pol == pol)
                {
                    KuceBO trazenoKuce = new KuceBO();
                    trazenoKuce.IdCipa = kuce.idCipa;
                    trazenoKuce.IdVlasnika = kuce.idVlasnika;
                    trazenoKuce.Ime = kuce.ime;
                    trazenoKuce.Pol = kuce.pol;
                    trazenoKuce.Rasa = kuce.rasa;
                    trazenoKuce.Starost = kuce.starost;
                    trazenoKuce.UAzilu = kuce.uAzilu;
                    lista.Add(trazenoKuce);
                }
            }

            foreach (KuceBO kuce in lista.ToList())
            {
                if (starost != 0)
                {
                    if (kuce.Starost != starost)
                    {
                        lista.Remove(kuce);
                    }
                }
                if (!String.IsNullOrEmpty(rasa))
                {
                    if (kuce.Rasa != rasa)
                    {
                        lista.Remove(kuce);
                    }
                }
                if (!String.IsNullOrEmpty(pol))
                {
                    if (kuce.Pol != pol)
                    {
                        lista.Remove(kuce);
                    }
                }
            }
        
                return lista;
        }

        public void Udomi(int idKuceta)
        {
            Kuce kuce = azilEntities.Kuces.FirstOrDefault(t => t.idCipa == idKuceta);
            kuce.uAzilu = !kuce.uAzilu;
            if (kuce.uAzilu == null)                                                            //nullable bool, inace bi moglo if(kuce.uAzilu)
            {
                kuce.idVlasnika = null;
            }
            azilEntities.SaveChanges();
        }

        public void UpdateKartona(KartonPsaBO NoviKarton)
        {
            KartonPsa Karton = azilEntities.KartonPsas.FirstOrDefault(x => x.idCipa == NoviKarton.IdCipa);      //Jedan karton koji cemo ubaciti ili updateovati
            bool PostojiKuce = azilEntities.Kuces.Any(x => x.idCipa == NoviKarton.IdCipa);                       //Provera da li kuce sa unetim ID zapravo postoji
            if (!PostojiKuce)
            {
                return;
            }
            if (Karton == null)
            {
                Karton = new KartonPsa();
                Karton.idCipa = NoviKarton.IdCipa;
                Karton.alergije = NoviKarton.Alergije;
                Karton.daLiJeVakcinisan = NoviKarton.DaLiJeVakcinisan;
                Karton.ociscenOdParazita = NoviKarton.OciscenOdParazita;
                azilEntities.KartonPsas.Add(Karton);
            }
            else
            {
                Karton.idCipa = NoviKarton.IdCipa;
                Karton.alergije = NoviKarton.Alergije;
                Karton.daLiJeVakcinisan = NoviKarton.DaLiJeVakcinisan;
                Karton.ociscenOdParazita = NoviKarton.OciscenOdParazita;
                azilEntities.SaveChanges();

            }
            azilEntities.SaveChanges();
        }
    }
}