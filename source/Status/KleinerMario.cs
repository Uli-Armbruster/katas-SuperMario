using System;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Status
{
    internal class KleinerMario : IchBinSuperMario
    {
        private readonly IchBinLebendig _leben;

        public KleinerMario(IchBinLebendig leben)
        {
            _leben = leben;
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            var neuesleben = _leben.Vermindern();
            return neuesleben;
        }

        public IchBinSuperMario FindetPunkte(int punkte)
        {
            return new KleinerMario(_leben.FindetPunkte(punkte));
        }

        public IchBinSuperMario FindetPilz()
        {
            return new MarioMitPilz(_leben);
        }

        public IchBinSuperMario FindetLeben()
        {
            return new KleinerMario(_leben.Erhöhen());
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