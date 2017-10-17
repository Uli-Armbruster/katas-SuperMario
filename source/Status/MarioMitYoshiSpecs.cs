using System;
using FakeItEasy;
using SuperMarioImWorkshop.Kontrakte;
using Xunit;

// ReSharper disable ConvertToLocalFunction

namespace SuperMarioImWorkshop.Status
{
    public class MarioMitYoshiSpecs : SpecsMotherBase
    {
        private IchBinSuperMario _reiter;

        protected override IchBinSuperMario CreateMario()
        {
            _reiter = A.Fake<IchBinSuperMario>();
            return new MarioMitYoshi(_reiter);
        }

        [Fact]
        public void Mario_mit_Yoshi_findet_Eisblume_und_gibt_diese_an_den_Reiter_weiter()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.FindetEisblume()));
            A.CallTo(() => _reiter.FindetEisblume()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Yoshi_findet_Feuerblume_und_gibt_diese_an_den_Reiter_weiter()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.FindetFeuerblume()));
            A.CallTo(() => _reiter.FindetFeuerblume()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Yoshi_findet_Pilz_und_gibt_diesen_an_den_Reiter_weiter()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.FindetPilz()));
            A.CallTo(() => _reiter.FindetPilz()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Yoshi_findet_Stern_und_gibt_diesen_an_den_Reiter_weiter()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.FindetStern()));
            A.CallTo(() => _reiter.FindetStern()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Yoshi_findet_Leben_und_gibt_dieses_an_den_Reiter_weiter()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.FindetLeben()));
            A.CallTo(() => _reiter.FindetLeben()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Mario_mit_Yoshi_findet_Yoshi_und_behält_aktuellen_Yoshi()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.FindetYoshi()));
            A.CallTo(() => _reiter.FindetYoshi()).MustHaveHappened(Repeated.Never);
        }

        [Fact]
        public void Mario_mit_Yoshi_kann_nicht_schießen()
        {
            var munition = A.Fake<Action<string>>();
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.Schießen(munition)));
            A.CallTo(() => munition(A<string>.Ignored)).MustHaveHappened(Repeated.Never);
        }

        [Fact]
        public void Mario_mit_Yoshi_verliert_Yoshi_wenn_er_vom_Gegner_getroffen_wird()
        {
            var marioMitYoshi = new MarioMitYoshi(new KleinerMario(null));
            Assert<KleinerMario>(Act(marioMitYoshi, mario => mario.WirdVonGegnerGetroffen()));
        }
    }
}