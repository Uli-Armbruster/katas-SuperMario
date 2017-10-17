using System;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Status
{
    public class ToterMario : IchBinSuperMario
    {
        private readonly IchBinLebendig _leben;

        public ToterMario(IchBinLebendig leben)
        {
            _leben = leben;
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return this;
        }

        public IchBinSuperMario FindetPunkte(int punkte)
        {
            return this;
        }

        public IchBinSuperMario FindetPilz()
        {
            return this;
        }

        public IchBinSuperMario FindetLeben()
        {
            return new KleinerMario(_leben.Erhöhen());
        }

        public IchBinSuperMario FindetFeuerblume()
        {
            return this;
        }

        public IchBinSuperMario FindetEisblume()
        {
            return this;
        }

        public IchBinSuperMario FindetStern()
        {
            return this;
        }

        public IchBinSuperMario FindetYoshi()
        {
            return this;
        }

        public IchBinSuperMario Schießen(Action<string> mit)
        {
            return this;
        }
    }
}