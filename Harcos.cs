using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        private string nev;
        private int szint;
        private int tapasztalat;
        private int eletero;
        private int alapEletero;
        private int alapSebzes;

        public Harcos(string nev, int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;
            switch (statuszSablon)
            {
                case 1:
                    this.alapEletero = 15;
                    this.alapSebzes = 3; break;
                case 2:
                    this.alapEletero = 12;
                    this.alapSebzes = 4; break;
                case 3:
                    this.alapEletero = 8;
                    this.alapSebzes = 5; break;
                default: break;
            }
            this.eletero = MaxEletero;
            
        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Eletero { get => eletero; set => eletero = value; }
        public int AlapEletero { get => alapEletero; }
        public int AlapSebzes { get => alapSebzes; }
        public int Sebzes { get => alapSebzes + szint; }
        public int SzintLepeshez { get => 10 + szint * 5; }
        public int MaxEletero { get => alapEletero + szint * 3; }

        public override string ToString()
        {
            return string.Format("{0} - LVL: {1} - EXP: {2} - HP: {3} - DMG: {4}", nev,szint,tapasztalat/SzintLepeshez,eletero/MaxEletero,Sebzes);
        }
    }
}
