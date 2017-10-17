using System;
using System.Reactive.Linq;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Status
{
    public class MarioMitStern : IchBinSuperMario
    {
        private IchBinSuperMario _träger;
        private IchBinSuperMario _aktuellerStatus;
        private bool _schutzBeendet;

        public MarioMitStern(IchBinSuperMario träger)
        {
            _träger = träger;
            _aktuellerStatus = this;

            SetzeAufVorherigenStatusNach1Sekunde();
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            if (_schutzBeendet)
                return _träger.WirdVonGegnerGetroffen();

            return this;
        }

        public IchBinSuperMario FindetPunkte(int punkte)
        {
            return AktionAusführen(() => _träger.FindetPunkte(punkte));
        }

        public IchBinSuperMario FindetPilz()
        {
            return AktionAusführen(() => _träger.FindetPilz());
        }

        public IchBinSuperMario FindetLeben()
        {
            return AktionAusführen(() => _träger.FindetLeben());
        }

        public IchBinSuperMario FindetFeuerblume()
        {
            return AktionAusführen(() => _träger.FindetFeuerblume());
        }

        public IchBinSuperMario FindetEisblume()
        {
            return AktionAusführen(() => _träger.FindetEisblume());
        }

        public IchBinSuperMario FindetStern()
        {
            return _aktuellerStatus;
        }

        public IchBinSuperMario FindetYoshi()
        {
            return AktionAusführen(() => _träger.FindetYoshi());
        }

        public IchBinSuperMario Schießen(Action<string> mit)
        {
            return AktionAusführen(() => _träger.Schießen(mit));
        }

        private void SetzeAufVorherigenStatusNach1Sekunde()
        {
            Observable
                .Timer(TimeSpan.FromSeconds(1))
                .Subscribe(x =>
                {
                    _schutzBeendet = true;
                    _aktuellerStatus = _träger;
                });
        }

        private IchBinSuperMario AktionAusführen(Func<IchBinSuperMario> aktion)
        {
            _träger = aktion();
            return _aktuellerStatus;
        }
    }
}