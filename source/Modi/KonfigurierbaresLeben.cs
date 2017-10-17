using System;
using System.Collections.Generic;
using System.Linq;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Modi
{
    public class KonfigurierbaresLeben : IchBinLebendig
    {
        private readonly int _punkte;
        private readonly IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> _verbleibendeLeben;
        private readonly IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> _wennExtraLeben;

        public KonfigurierbaresLeben(int punkte,
            IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> verbleibendeLeben,
            IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> wennExtraLeben)
        {
            _punkte = punkte;
            _verbleibendeLeben = verbleibendeLeben;
            _wennExtraLeben = wennExtraLeben;
        }

        public IchBinSuperMario Vermindern()
        {
            var nächstesLeben = _verbleibendeLeben.First();
            var verbleibendeLeben = _verbleibendeLeben.Skip(1);

            var vermindertesLeben = new KonfigurierbaresLeben(_punkte, verbleibendeLeben, _wennExtraLeben);

            return nächstesLeben(vermindertesLeben);
        }

        public IchBinLebendig Erhöhen()
        {
            var extraLeben = _wennExtraLeben.ToList();
            var erhöhteLeben = extraLeben.Concat(_verbleibendeLeben);
            return new KonfigurierbaresLeben(_punkte, erhöhteLeben, _wennExtraLeben);
        }

        public IchBinLebendig FindetPunkte(int gefundenePunkte)
        {
            var neuePunktzahl = _punkte + gefundenePunkte;

            if (neuePunktzahl < 100)
                return new KonfigurierbaresLeben(neuePunktzahl, _verbleibendeLeben, _wennExtraLeben);

            var erhöhteLeben = _wennExtraLeben.Concat(_verbleibendeLeben);
            return new KonfigurierbaresLeben(neuePunktzahl - 100, erhöhteLeben, _wennExtraLeben);
        }
    }
}