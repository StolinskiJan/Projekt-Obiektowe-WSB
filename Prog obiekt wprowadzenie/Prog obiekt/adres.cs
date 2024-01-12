using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_obiekt
{
    internal class Adres
    {
        public string Ulica {  get; set; }
        public string NumerDomu { get; set; }
        public string NumerMieszkania { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public string Panstwo { get; set; }

        
        public string AdresPelny => $"{AdresPocztowy}";

        public string AdresPocztowy
        {
            get
            {
                return $"UL. {Ulica} {NumerDomu}/{NumerMieszkania}\n{KodPocztowy} {Miasto}\n {Panstwo}";
            }

        }

        /*Moje
         * private string _ulica;
        private string _adresdomu;
        private string _nrmieszkania;
        private string _kodpocztowy;
        private string _miasto;
        private string _panstwo;
        public string Ulica
        {
            get { return _ulica; }
            set { _ulica = value; }
        }

        public string adresdomu
        {
            get { return _adresdomu; }
            set { _adresdomu = value; }
        }

        public string nrmieszkania
        {
            get { return _nrmieszkania; }
            set { _nrmieszkania = value; }
        }

        public string kodpocztowy
        {
            get { return _kodpocztowy; }
            set { _kodpocztowy = value; }
        }
        public string miasto
        {
            get { return _miasto; }
            set { _miasto = value; }
        }

        public string panstwo
        {
            get { return _panstwo; }
            set { _panstwo = value; }
        }
        public void UstawDane(string ulica, string adresdomu, string nrmieszkania, string adresdomu, string ulica, string adresdomu)
        {
            this.Ulica = ulica;
            this.adresdomu = adresdomu;
            this.nrmieszkania = nrmieszkania;
        }*/

    }
}
