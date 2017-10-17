using System;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Status
{
    public class MarioMitYoshi : IchBinSuperMario
    {
        private readonly IchBinSuperMario _reiter;

        public MarioMitYoshi(IchBinSuperMario reiter)
        {
            _reiter = reiter;
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return _reiter;
        }

        public IchBinSuperMario FindetPunkte(int punkte)
        {
            return new MarioMitYoshi(_reiter.FindetPunkte(punkte));
        }

        public IchBinSuperMario FindetPilz()
        {
            return new MarioMitYoshi(_reiter.FindetPilz());
        }

        public IchBinSuperMario FindetLeben()
        {
            return new MarioMitYoshi(_reiter.FindetLeben());
        }

        public IchBinSuperMario FindetFeuerblume()
        {
            return new MarioMitYoshi(_reiter.FindetFeuerblume());
        }

        public IchBinSuperMario FindetEisblume()
        {
            return new MarioMitYoshi(_reiter.FindetEisblume());
        }

        public IchBinSuperMario FindetStern()
        {
            return new MarioMitYoshi(_reiter.FindetStern());
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