using System;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Status
{
    internal class MarioMitPilz : IchBinSuperMario
    {
        private readonly IchBinLebendig _leben;

        public MarioMitPilz(IchBinLebendig leben)
        {
            _leben = leben;
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return new KleinerMario(_leben);
        }

        public IchBinSuperMario FindetPunkte(int punkte)
        {
            return new MarioMitPilz(_leben.FindetPunkte(punkte));
        }

        public IchBinSuperMario FindetPilz()
        {
            return this;
        }

        public IchBinSuperMario FindetLeben()
        {
            return new MarioMitPilz(_leben.Erhöhen());
        }

        public IchBinSuperMario FindetFeuerblume()
        {
            return new MarioMitFeuerblume(_leben);
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
            return this;
        }
    }
}