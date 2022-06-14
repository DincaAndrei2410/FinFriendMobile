using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinFriend.Models;
using Models.Models;

namespace FinFriend.Services
{
    public class Data
    {
        public static IEnumerable<Company> Companies => new List<Company>()
            {
                new Company() { CompanyName = "Amazon.com Inc.", CompanySymbol="AMZN", CompanyLogo="http://media.corporate-ir.net/media_files/IROL/17/176060/Oct18/Amazon%20logo.PNG", IsSelected=true, },
                new Company() { CompanyName = "Apple Inc.", CompanySymbol="AAPL", CompanyLogo="https://pngimg.com/uploads/apple_logo/apple_logo_PNG19674.png", IsSelected=true,},
                new Company() { CompanyName = "Google LLC", CompanySymbol="GOOGL", CompanyLogo="https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Google_2015_logo.svg/368px-Google_2015_logo.svg.png"},
                new Company() { CompanyName = "Tesla, Inc.", CompanySymbol="TSLA", CompanyLogo="https://upload.wikimedia.org/wikipedia/commons/e/e8/Tesla_logo.png"},
                new Company() { CompanyName = "Facebook", CompanySymbol="FB", CompanyLogo="https://1000logos.net/wp-content/uploads/2016/11/Facebook-logo.png"},
                new Company() { CompanyName = "Netflix, Inc.", CompanySymbol="NFLX", CompanyLogo="https://i.pinimg.com/originals/f6/97/4e/f6974e017d3f6196c4cbe284ee3eaf4e.png"},
                new Company() { CompanyName = "Microsoft", CompanySymbol="MSFT", CompanyLogo="https://i.pinimg.com/originals/ce/af/83/ceaf8384322af790486cff176a0a2f24.png"},
                new Company() { CompanyName = "Visa", CompanySymbol="V", CompanyLogo="https://lavca.org/wp-content/uploads/2019/07/VISA-logo-square.png"},
                new Company() { CompanyName = "MasterCard", CompanySymbol="MA", CompanyLogo="https://cdn.vox-cdn.com/thumbor/UKSLdttYoIK2bv1gd231rqL4eiQ=/1400x788/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/13674554/Mastercard_logo.jpg"},
                new Company() { CompanyName = "NVIDIA.", CompanySymbol="NVDA", CompanyLogo="https://upload.wikimedia.org/wikipedia/sco/thumb/2/21/Nvidia_logo.svg/1280px-Nvidia_logo.svg.png"},
            };

        public static IEnumerable<Neighborhood> Neighborhoods => 
            new List<Neighborhood>()
            {
                new Neighborhood()
                {
                    Id = 1,
                    Name = "Militari"
                },
                new Neighborhood()
                {
                    Id = 2,
                    Name = "Drumul Taberei"
                },
                new Neighborhood()
                {
                    Id = 3,
                    Name = "Chitila"
                },
                new Neighborhood()
                {
                    Id = 4,
                    Name = "Titan"
                }
            };

        public static IEnumerable<RealEstateCredit> Credits =>
        new List<RealEstateCredit>()
                {
                    new RealEstateCredit() { BankName = "ING Groep N.V", DobandaAnuala = "4 %", Logo = "https://upload.wikimedia.org/wikipedia/commons/4/4b/ING_logo.png", RataLunara = "1200 LEI", TotalPlata = "50,00 LEI", SimulatorURL = "https://ing.ro/persoane-fizice/credite/ipotecar"},
                    new RealEstateCredit() { BankName = "Banca Comerciala Romana", DobandaAnuala = "4.5 %", Logo = "https://seeklogo.com/images/B/banca-comerciala-romana-bcr-logo-A86AEFB56F-seeklogo.com.png", RataLunara = "1200 LEI", TotalPlata = "50,00 LEI", SimulatorURL = "https://calculator-rate-credit.bcr.ro/"},
                    new RealEstateCredit() { BankName = "Banca Transilvania", DobandaAnuala = "4.5 %", Logo = "https://www.bancatransilvania.ro/themes/bancatransilvania/assets/images/logos/BT_Logo_2_Color.png", RataLunara = "1200 LEI", TotalPlata = "50,00 LEI", SimulatorURL = "https://www.bancatransilvania.ro/credite/credite-de-nevoi/credit-de-nevoi-curente-cu-destinatie-imobiliara"},
                };
}
}
