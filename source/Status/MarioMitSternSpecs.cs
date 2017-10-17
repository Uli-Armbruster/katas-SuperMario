using System;
using System.Threading;
using FakeItEasy;
using SuperMarioImWorkshop.Kontrakte;
using Xunit;

// ReSharper disable ConvertToLocalFunction

namespace SuperMarioImWorkshop.Status
{
    public class MarioMitSternSpecs : SpecsMotherBase
    {
        private IchBinSuperMario _träger;

        protected override IchBinSuperMario CreateMario()
        {
            _träger = A.Fake<IchBinSuperMario>();
            return new MarioMitStern(_träger);
        }

        [Fact]
        public void Mario_mit_Stern_findet_Eisblume_und_gibt_diese_an_den_Reiter_weiter()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetEisblume()));
            A.CallTo(() => _träger.FindetEisblume()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Stern_findet_Feuerblume_und_gibt_diese_an_den_Reiter_weiter()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetFeuerblume()));
            A.CallTo(() => _träger.FindetFeuerblume()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Stern_findet_Leben_und_gibt_dieses_an_den_Reiter_weiter()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetLeben()));
            A.CallTo(() => _träger.FindetLeben()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Stern_findet_Pilz_und_gibt_diesen_an_den_Reiter_weiter()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetPilz()));
            A.CallTo(() => _träger.FindetPilz()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Stern_findet_Stern_und_behält_aktuellen_Stern()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetStern()));
            A.CallTo(() => _träger.FindetStern()).MustHaveHappened(Repeated.Never);
        }

        [Fact]
        public void Mario_mit_Stern_findet_Yoshi_und_gibt_diesen_an_den_Träger_weiter()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetYoshi()));
            A.CallTo(() => _träger.FindetYoshi()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Stern_passiert_nichts_wenn_er_vom_Gegner_getroffen_wird()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.WirdVonGegnerGetroffen()));
            A.CallTo(() => _träger.WirdVonGegnerGetroffen()).MustHaveHappened(Repeated.Never);
        }

        [Fact]
        public void Mario_mit_Stern_und_Blume_kann_schießen()
        {
            var marioMitSternUndBlume = new MarioMitStern(new MarioMitFeuerblume(null));
            var munition = A.Fake<Action<string>>();
            Assert<MarioMitStern>(Act(marioMitSternUndBlume, mario => mario.Schießen(munition)));
            A.CallTo(() => munition(A<string>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_verliert_Stern_nach_abgelaufener_Zeit()
        {
            IchBinSuperMario marioMitSternUndBlume = new MarioMitStern(new MarioMitFeuerblume(null));

            marioMitSternUndBlume = marioMitSternUndBlume.WirdVonGegnerGetroffen();
            Assert<MarioMitStern>(Act(marioMitSternUndBlume, mario => mario.WirdVonGegnerGetroffen()));

            Thread.Sleep(TimeSpan.FromMilliseconds(1010));

            Assert<MarioMitPilz>(Act(marioMitSternUndBlume, mario => mario.WirdVonGegnerGetroffen()));
        }
    }
}