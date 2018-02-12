using System;
using System.Collections.Generic;
using System.Text;

namespace Penny.Models
{
    public class City
    {

        // Returns a list of all the cities that an item could originate from
        // statically defined rn, but suject to change if we have time
        public static IList<string> GetConditions()
        {
            string cities = "Alice,Butterworth,East London,Graaff-Reinet,Grahamstown,King William’s Town,Mthatha,Port Elizabeth,Queenstown,Uitenhage,Zwelitsha,Free State,Bethlehem,Bloemfontein,Jagersfontein,Kroonstad,Odendaalsrus,Parys,Phuthaditjhaba,Sasolburg,Virginia,Welkom,Gauteng,Benoni,Boksburg,Brakpan,Carletonville,Germiston,Johannesburg,Krugersdorp,Pretoria,Randburg,Randfontein,Roodepoort,Soweto,Springs,Vanderbijlpark,Vereeniging,KwaZulu-Natal,Durban,Empangeni,Ladysmith,Newcastle,Pietermaritzburg,Pinetown,Ulundi,Umlazi,Limpopo,Giyani,Lebowakgomo,Musina,Phalaborwa,Polokwane,Seshego,Sibasa,Thabazimbi,Mpumalanga,Emalahleni,Nelspruit,Secunda,North West,Klerksdorp,Mahikeng,Mmabatho,Potchefstroom,Rustenburg,Northern Cape,Kimberley,Kuruman,Port Nolloth,Western Cape,Bellville,Cape Town,Constantia,George,Hopefield,Oudtshoorn,Paarl,Simon’s Town,Stellenbosch,Swellendam,Worcester";
            var splitCities = cities.Split(',');

            return splitCities;
        }
    }
}
