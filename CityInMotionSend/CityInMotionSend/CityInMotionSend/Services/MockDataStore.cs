using CityInMotionSend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInMotionSend.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        public static List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Primăria Timișoara va vinde lemn la licitație", Description="Primăria Timișoara va vinde la licitație două tipuri de lemn, ale căror prețuri de pornire pleacă de la 280, respectiv 350 de lei/mc. Lemnul provine din fondul forestier deținut de Primăria Timișoara la Sacu.\r\nPrimăria Timișoara are la Sacu un fond forestier, de aproape 685 de hectare, administrat pe o perioadă de 10 ani de Regia Națională a Pădurilor – Romsilva prin Ocolul Silvic Ana Lugojana, în baza unui contract încheiat la începutul anului 2019.\r\nDe aici provine lemnul pe care primăria îl va vinde, în baza „Regulamentului de valorificare a masei lemnoase din fondul forestier proprietate publică”, printr-o licitație desfășurată de Direcția Silvică.\r\nEste vorba de două tipuri de lemn, în total 877,86 mc. Din primul tip de lemn sunt disponibili 360,51 mc, cu un preț de pornire la licitație de 280 de lei/mc, iar din al doilea sunt disponibili 517,35 mc, cu un preț de pornire de 350 de lei/mc.\r\nProiectul de hotărâre privind aprobarea volumului și prețurilor a fost votat de consilierii locali în ședința de joi, 24 noiembrie. A trecut cu …. voturi.\r\n\r\n" , Location = "Timisoara",Rating = 0},
                new Item { Id = Guid.NewGuid().ToString(), Text = "FÂNTÂNA ARTEZIANĂ DE BASM! SPECTACOL PE MUZICĂ ÎN CENTRUL MUNICIPIULUI SATU MARE", Description="În această seară au fost făcute noi probe la fântâna arteziană din fața clădirii Consiliului Județean. Fântâna a fost modernizată în cadrul proiectului care vizează reabilitarea întregii zone centrale a municipiului.\r\nAstăzi au avut loc noi probe, la fântână arteziană din Centrul Nou al municipiului Satu Mare. A fost verificat fluxul de apă și sistemul de iluminare. Autoritățile nu au oferit mai multe detalii, dar se pare că vorbim de o fântână arteziană muzicală, care cu siguranță va deveni un punct de atracție pentru sătmăreni.\r\nLucrările au continuat în ritm alert în ultimele săptămâni în pasajul Corneliu Coposu. Autoritățile au anunțat inițial că la finalul lunii decembrie se așteaptă ca lucrările în zona centrală să fie finalizate.\r\nCentrul Nou al municipiului Satu Mare se află într-un proiect de reabilitare finanțat cu fonduri europene. Centrul Nou și Aleea Corneliu Coposu sunt modernizate printr-o investiție de 13,15 milioane lei, iar 27,096 milioane de lei sunt investiți în construcția pasarelei pietonale peste râul Someş.\r\n",Location = "Satu Mare",Rating = 0},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Studenții de la UBB ies astăzi în stradă pentru a protesta", Description="Studenții de la Universitatea Babeș-Bolyai din Cluj-Napoca ies astăzi în stradă astăzi începând cu ora 16:30 pentru a protesta împotriva revenirii la cursuri fizic. \r\nOrganizațiile studențești din Universitatea Babeș-Bolyai din Cluj-Napoca organizează astăzi, începând cu ora 16:30, „un protest față de recentele acțiuni ale Ministerului Educației” privind activitatea față în față, potrivit unui anunț al Organizaţiei Studenţilor din UBB (OSUBB), informează Edupedu.\r\n„Anunțul Ministerului Educației, privind revenirea în totalitate la învățământul fizic, a reprezentat o serie de declarații haotice, care au bulversat întreaga comunitate Universitară”, conform reprezentanților studenților din Cluj.\r\nAstfel, ei susțin ca decizia să fie luată de universitate, nu de minister: „Mai mult, să se analizeze capacitatea de cazare, domeniile de studiu ale universității, cadrele didactice disponibile și aparatura necesară pentru a oferi educație calitativă, nu grăbită”.\r\nSorin Cîmpeanu a anunțat inițial că universitățile trebuie să revină la cursuri cu prezență fizică de la încheierea stării de alertă pentru că nu mai au cadru legal pentru a continua online.\r\n" ,Location = "Cluj",Rating = 0},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Reabilitarea Centrului Vechi  Satu Mare", Description="Proiectul prevede transformarea Pieţei Libertăţii în zonă pietonală, prin care oraşul să devină mai prietenos cu locuitorii săi şi mai atractiv pentru turişti. Modernizarea Centrului Vechi va consta în extinderea zonei accesibile pietonilor şi bicicliştilor, prin amenajarea unor arii pietonale modernizate, precum şi crearea unei piste pentru biciclete. \r\nProiectul mai prevede crearea unei benzi dedicate pentru mijloacele de transport public de călători, inclusiv reabilitarea părţii carosabile a infrastructurii rutiere.  Modernizarea zonei centrale P-ţa Libertăţii presupune reconfigurarea aleilor pietonale existente, prin crearea unor trasee pietonale noi, precum şi dotarea cu mobilier urban şi reamenajarea spaţiilor verzi.\r\n\r\nValoarea totală a proiectului: 19.045.446.63 lei" ,Location = "Satu Mare",Rating = 0},
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}