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
        public int Szint
        {
            get => szint; 
            set
            {
                if (Tapasztalat==SzintLepeshez)
                {
                    Tapasztalat -= SzintLepeshez;
                    szint++;
                    Eletero = MaxEletero;
                }
            } }
        public int Tapasztalat
        {
            get => tapasztalat; set
            {
                if (Eletero==0)
                {
                    tapasztalat = 0;
                }
                else { tapasztalat = value; } } }
        public int Eletero { get => eletero; set { if (Eletero > MaxEletero) { Eletero = MaxEletero; } else { eletero = value; } } }
        public int AlapEletero { get => alapEletero; }
        public int AlapSebzes { get => alapSebzes; }
        public int Sebzes { get => alapSebzes + szint; }
        public int SzintLepeshez { get => 10 + szint * 5; }
        public int MaxEletero { get => alapEletero + szint * 3; }

        public override string ToString()
        {
            return string.Format("{0} - LVL: {1} - EXP: {2} - HP: {3} - DMG: {4}", nev,szint,tapasztalat/SzintLepeshez,eletero/MaxEletero,Sebzes);
        }

        public void Megkuzd(Harcos masikHarcos)
        {
            if (this.nev==masikHarcos.nev)
            {
                Console.WriteLine("Hiba! Egyező harcos.");
            }
            else if (this.eletero==0||masikHarcos.eletero==0)
            {
                Console.WriteLine("Hiba! Az életerő 0.");
            }
            else
            {
                string utolsoHarcos; //utolsó támadó harcos
                masikHarcos.Eletero -= this.Sebzes;
                masikHarcos.Tapasztalat += 5;
                utolsoHarcos = this.Nev;
                while (!(this.Eletero==0||masikHarcos.Eletero==0))
                {
                    if (utolsoHarcos==this.Nev)
                    {
                        this.Eletero -= masikHarcos.Sebzes;
                        this.Tapasztalat += 5;
                        utolsoHarcos = masikHarcos.Nev;
                    }
                    else if (utolsoHarcos == masikHarcos.Nev)
                    {
                        masikHarcos.Eletero -= this.Sebzes;
                        masikHarcos.Tapasztalat += 5;
                        utolsoHarcos = this.Nev;
                    }
                }
                if (this.Eletero<=0)
                {
                    masikHarcos.Tapasztalat += 10;
                }
                else if (masikHarcos.Eletero<=0)
                {
                    this.Tapasztalat += 10;
                }
            }
        }
        public void Gyogyul()
        {
            if (Eletero==0)
            {
                Eletero = MaxEletero;
            }
            else
            {
                Eletero += 3 + Szint;
            }

        }
    }
}
