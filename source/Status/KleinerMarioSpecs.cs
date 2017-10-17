using System;
using FakeItEasy;
using FluentAssertions;
using SuperMarioImWorkshop.Kontrakte;
using Xunit;

// ReSharper disable ConvertToLocalFunction

namespace SuperMarioImWorkshop.Status
{
    public class KleinerMarioSpecs : SpecsMotherBase
    {
        protected override IchBinSuperMario CreateMario()
        {
            return new KleinerMario(Leben);
        }

        [Fact]
        public void Kleiner_Mario_findet_Eisblume_und_behält_diese()
        {
            Assert<MarioMitEisblume>(Act(Arrange(), mario => mario.FindetEisblume()));
        }

        [Fact]
        public void Kleiner_Mario_findet_Feuerblume_und_behält_diese()
        {
            Assert<MarioMitFeuerblume>(Act(Arrange(), mario => mario.FindetFeuerblume()));
        }

        [Fact]
        public void Kleiner_Mario_findet_Pilz_und_behält_diesen()
        {
            Assert<MarioMitPilz>(Act(Arrange(), mario => mario.FindetPilz()));
        }

        [Fact]
        public void Kleiner_Mario_findet_Stern_und_behält_diesen()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetStern()));
        }

        [Fact]
        public void Kleiner_Mario_findet_Yoshi_und_behält_diesen()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario=> mario.FindetYoshi()));
        }

        [Fact]
        public void Kleiner_Mario_verliert_Leben_wenn_er_vom_Gegner_getroffen_wird()
        {
            Assert<ToterMario>(Act(Arrange(), mario => mario.WirdVonGegnerGetroffen()));
            A.CallTo(() => Leben.Vermindern()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Kleiner_Mario_kann_nicht_schießen()
        {
            Action<string> munition = A.Fake<Action<string>>();
            Assert<KleinerMario>(Act(Arrange(), mario => mario.Schießen(munition)));
            A.CallTo(() => munition(A<string>.Ignored)).MustHaveHappened(Repeated.Never);
        }
    }
}