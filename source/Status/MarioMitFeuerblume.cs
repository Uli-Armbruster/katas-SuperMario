using System;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Status
{
    public class MarioMitFeuerblume : IchBinSuperMario
    {
        private readonly IchBinLebendig _leben;

        public MarioMitFeuerblume(IchBinLebendig leben)
        {
            _leben = leben;
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return new MarioMitPilz(_leben);
        }

        public IchBinSuperMario FindetPunkte(int punkte)
        {
            return new MarioMitFeuerblume(_leben.FindetPunkte(punkte));
        }

        public IchBinSuperMario FindetPilz()
        {
            return this;
        }

        public IchBinSuperMario FindetLeben()
        {
            return new MarioMitFeuerblume(_leben.Erhöhen());
        }

        public IchBinSuperMario FindetFeuerblume()
        {
            return this;
        }

        public IchBinSuperMario FindetEisblume()
        {
            return new MarioMitEisblume(_leben);
        }

        public IchBinSuperMario FindetStern()
        {
            return new MarioMitStern(this);
        }

        public IchBinSuperMario FindetYoshi()
        {
            return new MarioMitYoshi(this);
        }

        public IchBinSuperMario Schießen(Action<string> mit)
        {
            mit("Feuer");
            return this;
        }
    }
}