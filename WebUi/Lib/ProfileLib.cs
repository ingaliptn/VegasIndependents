using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WebUi.Lib
{
    public static class ProfileLib
    {
        public static string GetUrl(int number)
        {
            const string json = @"[{""EscortName"":""Alexa"",""EscortId"":""88""},
            { ""EscortName"":""Ally"",""EscortId"":""76""},
            { ""EscortName"":""Ally"",""EscortId"":""96""},
            { ""EscortName"":""Amy"",""EscortId"":""107""},
            { ""EscortName"":""Angelina"",""EscortId"":""92""},
            { ""EscortName"":""Anna"",""EscortId"":""91""},
            { ""EscortName"":""Annabelle"",""EscortId"":""85""},
            { ""EscortName"":""Arina"",""EscortId"":""98""},
            { ""EscortName"":""Bella"",""EscortId"":""77""},
            { ""EscortName"":""Brianna"",""EscortId"":""72""},
            { ""EscortName"":""Candice"",""EscortId"":""75""},
            { ""EscortName"":""Capri"",""EscortId"":""99""},
            { ""EscortName"":""Carol"",""EscortId"":""81""},
            { ""EscortName"":""Celine"",""EscortId"":""78""},
            { ""EscortName"":""Chloe"",""EscortId"":""102""},
            { ""EscortName"":""Cici"",""EscortId"":""108""},
            { ""EscortName"":""Cindy"",""EscortId"":""109""},
            { ""EscortName"":""Delray"",""EscortId"":""103""},
            { ""EscortName"":""Heather"",""EscortId"":""95""},
            { ""EscortName"":""Irene"",""EscortId"":""86""},
            { ""EscortName"":""Jen"",""EscortId"":""79""},
            { ""EscortName"":""Jenna"",""EscortId"":""100""},
            { ""EscortName"":""Josephine"",""EscortId"":""104""},
            { ""EscortName"":""Kana"",""EscortId"":""110""},
            { ""EscortName"":""Kathi"",""EscortId"":""111""},
            { ""EscortName"":""Katie"",""EscortId"":""93""},
            { ""EscortName"":""Kerry"",""EscortId"":""97""},
            { ""EscortName"":""Kissy"",""EscortId"":""105""},
            { ""EscortName"":""Kumi"",""EscortId"":""112""},
            { ""EscortName"":""Laura"",""EscortId"":""84""},
            { ""EscortName"":""Lauren"",""EscortId"":""94""},
            { ""EscortName"":""Leanne"",""EscortId"":""83""},
            { ""EscortName"":""May"",""EscortId"":""113""},
            { ""EscortName"":""Mia"",""EscortId"":""80""},
            { ""EscortName"":""Micah"",""EscortId"":""73""},
            { ""EscortName"":""Paula"",""EscortId"":""82""},
            { ""EscortName"":""Priya"",""EscortId"":""106""},
            { ""EscortName"":""Riley"",""EscortId"":""101""},
            { ""EscortName"":""Sandra"",""EscortId"":""89""},
            { ""EscortName"":""Sella"",""EscortId"":""114""},
            { ""EscortName"":""Susanna"",""EscortId"":""87""},
            { ""EscortName"":""Tara"",""EscortId"":""90""},
            { ""EscortName"":""Zoe"",""EscortId"":""74""}]";

            var model = JsonConvert.DeserializeObject<List<ProfileName>>(json);
            var name = model.Where(z => z.EscortId == number.ToString()).Select(z => z.EscortName).First().ToLower();
            return $"/profile/{name}.php";
        }
    }

    public class ProfileName
    {
        public string EscortName { get; set; }
        public string EscortId { get; set; }
    }
}
