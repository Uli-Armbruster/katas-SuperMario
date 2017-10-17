using System;
using FakeItEasy;
using FluentAssertions;
using SuperMarioImWorkshop.Kontrakte;
using Xunit;

// ReSharper disable ConvertToLocalFunction

namespace SuperMarioImWorkshop.Status
{
    public class MarioMitPilzSpecs : SpecsMotherBase
    {
        protected override IchBinSuperMario CreateMario()
        {
            return new MarioMitPilz(Leben);
        }

        [Fact]
        public void Mario_mit_Pilz_findet_Eisblume_und_behält_diese()
        {
            Assert<MarioMitEisblume>(Act(Arrange(), mario => mario.FindetEisblume()));
        }

        [Fact]
        public void Mario_mit_Pilz_findet_Feuerblume_und_behält_diese()
        {
            Assert<MarioMitFeuerblume>(Act(Arrange(), mario => mario.FindetFeuerblume()));
        }

        [Fact]
        public void Mario_mit_Pilz_findet_Pilz_und_behält_diesen()
        {
            Assert<MarioMitPilz>(Act(Arrange(), mario => mario.FindetPilz()));
        }

        [Fact]
        public void Mario_mit_Pilz_findet_Stern_und_behält_diesen()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetStern()));
        }

        [Fact]
        public void Mario_mit_Pilz_findet_Yoshi_und_behält_diesen()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.FindetYoshi()));
        }

        [Fact]
        public void Mario_mit_Pilz_wird_kleinem_Mario_wenn_er_vom_Gegner_getroffen_wird()
        {
            Assert<KleinerMario>(Act(Arrange(), mario => mario.WirdVonGegnerGetroffen()));
            A.CallTo(() => Leben.Vermindern()).MustHaveHappened(Repeated.Never);
        }

        [Fact]
        public void Mario_mit_Pilz_kann_nicht_schießen()
        {
            Action<string> munition = A.Fake< Action<string>>();
            Assert<MarioMitPilz>(Act(Arrange(), mario => mario.Schießen(munition)));
            A.CallTo(() => munition(A<string>.Ignored)).MustHaveHappened(Repeated.Never);
        }
    }
}