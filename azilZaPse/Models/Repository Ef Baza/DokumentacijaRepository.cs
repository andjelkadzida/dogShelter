using azilZaPse.Models.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace azilZaPse.Models.Repository_Ef_Baza
{
    public class DokumentacijaRepository : IDokumentacijaInterface
    {
        private AzilZaPseEntities1 azilEntities = new AzilZaPseEntities1();

        public void DodajDokumentaciju(DokumentacijaBO novaDokumentacija)
        {
            Dokumentacija dokument = new Dokumentacija();
            dokument.idCipa = novaDokumentacija.IdCipa;
            Vlasnik noviVlasnik = azilEntities.Vlasniks.FirstOrDefault(x => x.idVlasnika == novaDokumentacija.IdVlasnika);
            Kuce novoKuce = azilEntities.Kuces.FirstOrDefault(x => x.idCipa == novaDokumentacija.IdCipa);
            dokument.Vlasnik = noviVlasnik;
            dokument.Kuce = novoKuce;
            //dokument.idDokumentacije = azilEntities.Dokumentacijas.Max(x => x.idDokumentacije) + 1;
            dokument.idVlasnika = novaDokumentacija.IdVlasnika;
            dokument.datumIzdavanja = System.DateTime.Today.ToShortDateString();
            dokument.tekstDokumentacije = "Ugovor zaključen dana " + dokument.datumIzdavanja + " između azila za pse i " + dokument.Vlasnik.imeVlasnika + " " + dokument.Vlasnik.prezimeVlasnika + ".\n" + "Ugovorene strane su saglasne da je predmet ovog ugovora udomljavanje psa iz azila. Podnosilac zahteva, " + dokument.Vlasnik.imeVlasnika + " " + dokument.Vlasnik.prezimeVlasnika + " se obavezuje da će nakon zaključenja ovog ugovora voditi brigu o psu: " + dokument.Kuce.ime + " rase: " + dokument.Kuce.rasa + " ,starosti: " + dokument.Kuce.starost + " godina. Pol psa: " + dokument.Kuce.pol + " sa  čipom " + dokument.idCipa;
            azilEntities.Dokumentacijas.Add(dokument);
            Kuce updateKuceta = (from p in azilEntities.Kuces
                                 where p.idCipa == novaDokumentacija.IdCipa
                                 select p).SingleOrDefault();
            updateKuceta.idVlasnika = novaDokumentacija.IdVlasnika;                                         //Update-ujemo kuce da ga uklonimo iz azila
            updateKuceta.uAzilu = false;                                                                    //i dodelimo mu vlasnika
            azilEntities.SaveChanges();
        }

        public void DodajVlasnika(VlasnikBO noviVlasnik)
        {
            Vlasnik vlasnik = new Vlasnik();
            vlasnik.idVlasnika = noviVlasnik.IdVlasnika;
            vlasnik.imeVlasnika = noviVlasnik.ImeVlasnika;
            vlasnik.prezimeVlasnika = noviVlasnik.PrezimeVlasnika;
            vlasnik.adresa = noviVlasnik.Adresa;
            azilEntities.Vlasniks.Add(vlasnik);
            azilEntities.SaveChanges();
        }

        public IEnumerable<DokumentacijaBO> NadjiDokumentaciju(string idVlasnika)
        {
            List<DokumentacijaBO> lista = new List<DokumentacijaBO>();
            foreach (Dokumentacija dokumentacija in azilEntities.Dokumentacijas)
            {
                if (dokumentacija.idVlasnika == idVlasnika)
                {
                    DokumentacijaBO trazenaDokumentacija = new DokumentacijaBO();
                    trazenaDokumentacija.IdCipa = dokumentacija.idCipa;
                    trazenaDokumentacija.IdDokumentacije = dokumentacija.idDokumentacije;
                    trazenaDokumentacija.IdVlasnika = dokumentacija.idVlasnika;
                    trazenaDokumentacija.DatumIzdavanja = dokumentacija.datumIzdavanja;
                    trazenaDokumentacija.TekstDokumentacije = dokumentacija.tekstDokumentacije;
                    lista.Add(trazenaDokumentacija);
                }
            }

            return lista;
        }
    }
}