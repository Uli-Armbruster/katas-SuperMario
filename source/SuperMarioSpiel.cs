using System;
using System.Collections.Generic;
using System.Linq;
using SuperMarioImWorkshop.Kontrakte;
using SuperMarioImWorkshop.Modi;
using SuperMarioImWorkshop.Status;

namespace SuperMarioImWorkshop
{
    internal class SuperMarioSpiel
    {
        private readonly IchBinLebendig _leben;

        public SuperMarioSpiel(IchBinLebendig leben)
        {
            _leben = leben;
        }

        public static IchBinSuperMario StarteTabulaRasaModus()
        {
            var extraLeben = Enumerable.Repeat(MarioMitPilz(), 2);

            var begrenzteLeben = new List<Func<IchBinLebendig, IchBinSuperMario>>
            {
                MarioMitPilz(),
                MarioMitFeuerblume()
            }.Concat(Unendlich(ToterMario()));

            var konfiguriertesLeben = new KonfigurierbaresLeben(0, begrenzteLeben, extraLeben);

            return new SuperMarioSpiel(konfiguriertesLeben).StarteAlsKleinerMario();
        }

        public static IchBinSuperMario StarteGroßeWeltModus()
        {
            var extraLeben = Enumerable.Repeat(MarioMitPilz(), 1);

            var begrenztesLeben = Enumerable
                .Repeat(MarioMitPilz(), 1)
                .Concat(Unendlich(ToterMario()));

            var konfiguriertesLeben = new KonfigurierbaresLeben(0, begrenztesLeben, extraLeben);

            return new SuperMarioSpiel(konfiguriertesLeben).StarteAlsMarioMitPilz();
        }

        public static IchBinSuperMario StarteInfinityModus()
        {
            return StarteMitUnendlicheLeben().StarteAlsKleinerMario();
        }

        public static SuperMarioSpiel StarteMitUnendlicheLeben()
        {
            var keinLeben = Enumerable.Empty<Func<IchBinLebendig, IchBinSuperMario>>();
            var unendlichLeben = new KonfigurierbaresLeben(0, Unendlich(KleinerMario()), keinLeben);

            return new SuperMarioSpiel(unendlichLeben);
        }

        public static SuperMarioSpiel StarteMitVorgegebenerAnzahlLeben(int anzahl)
        {
            var extraLeben = Enumerable.Repeat(KleinerMario(), 1);

            var begrenztesLeben = Enumerable
                .Repeat(KleinerMario(), anzahl)
                .Concat(Unendlich(ToterMario()));

            var konfiguriertesLeben = new KonfigurierbaresLeben(0, begrenztesLeben, extraLeben);
            return new SuperMarioSpiel(konfiguriertesLeben);
        }

        public static SuperMarioSpiel StarteMitDreiLeben()
        {
            return StarteMitVorgegebenerAnzahlLeben(3);
        }

        public IchBinSuperMario StarteAlsKleinerMario()
        {
            return new KleinerMario(_leben);
        }

        public IchBinSuperMario StarteAlsMarioMitPilz()
        {
            return new MarioMitPilz(_leben);
        }

        public IchBinSuperMario StarteAlsMarioMitFeuerblume()
        {
            return new MarioMitFeuerblume(_leben);
        }

        private static Func<IchBinLebendig, IchBinSuperMario> ToterMario()
        {
            IchBinSuperMario ToterMario(IchBinLebendig leben)
            {
                return new ToterMario(leben);
            }

            return ToterMario;
        }

        private static Func<IchBinLebendig, IchBinSuperMario> KleinerMario()
        {
            IchBinSuperMario NeuesLeben(IchBinLebendig leben)
            {
                return new KleinerMario(leben);
            }

            return NeuesLeben;
        }

        private static Func<IchBinLebendig, IchBinSuperMario> MarioMitPilz()
        {
            IchBinSuperMario NeuesLeben(IchBinLebendig leben)
            {
                return new MarioMitPilz(leben);
            }

            return NeuesLeben;
        }

        private static Func<IchBinLebendig, IchBinSuperMario> MarioMitFeuerblume()
        {
            IchBinSuperMario NeuesLeben(IchBinLebendig leben)
            {
                return new MarioMitFeuerblume(leben);
            }

            return NeuesLeben;
        }

        private static IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> Unendlich(
            Func<IchBinLebendig, IchBinSuperMario> wiederhole)
        {
            while (true)
                yield return wiederhole;
            // ReSharper disable once IteratorNeverReturns
        }
    }
}