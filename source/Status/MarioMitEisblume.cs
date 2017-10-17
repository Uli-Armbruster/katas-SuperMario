using System;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Status
{
    public class MarioMitEisblume : IchBinSuperMario

    {
        private readonly IchBinLebendig _leben;

        public MarioMitEisblume(IchBinLebendig leben)
        {
            _leben = leben;
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return new MarioMitPilz(_leben);
        }

        public IchBinSuperMario FindetPunkte(int punkte)
        {
            return new MarioMitEisblume(_leben.FindetPunkte(punkte));
        }

        public IchBinSuperMario FindetPilz()
        {
            return this;
        }

        public IchBinSuperMario FindetLeben()
        {
            return new MarioMitEisblume(_leben.Erhöhen());
        }

        public IchBinSuperMario FindetFeuerblume()
        {
            return new MarioMitFeuerblume(_leben);
        }

        public IchBinSuperMario FindetEisblume()
        {
            return this;
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
            mit("Eis");
            return this;
        }
    }
}