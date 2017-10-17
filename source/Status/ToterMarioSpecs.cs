using System;
using FakeItEasy;
using FluentAssertions;
using SuperMarioImWorkshop.Kontrakte;
using Xunit;

// ReSharper disable ConvertToLocalFunction

namespace SuperMarioImWorkshop.Status
{
    public class ToterMarioSpecs : SpecsMotherBase
    {
        private IchBinSuperMario _mario;

        protected override IchBinSuperMario CreateMario()
        {
            _mario = new ToterMario(Leben);
            return _mario;
        }

        private void Assert(IchBinSuperMario mario)
        {
            mario.Should().BeSameAs(_mario);
        }

        [Fact]
        public void Toter_Mario_verändert_sicht_nicht_wenn_er_eine_Eisblume_findet()
        {
            Assert(Act(Arrange(), mario => mario.FindetEisblume()));
        }

        [Fact]
        public void Toter_Mario_verändert_sicht_nicht_wenn_er_eine_Feuerblume_findet()
        {
            Assert(Act(Arrange(), mario => mario.FindetFeuerblume()));
        }

        [Fact]
        public void Toter_Mario_verändert_sicht_nicht_wenn_er_einen_Pilz_findet()
        {
            Assert(Act(Arrange(), mario => mario.FindetPilz()));
        }

        [Fact]
        public void Toter_Mario_verändert_sicht_nicht_wenn_er_einen_Stern_findet()
        {
            Assert(Act(Arrange(), mario => mario.FindetStern()));
        }

        [Fact]
        public void Toter_Mario_verändert_sicht_nicht_wenn_er_Yoshi_findet()
        {
            Assert(Act(Arrange(), mario=> mario.FindetYoshi()));
        }

        [Fact]
        public void Toter_Mario_verändert_sich_nicht_wenn_er_vom_Gegner_getroffen_wird()
        {
            Assert(Act(Arrange(), mario => mario.WirdVonGegnerGetroffen()));
            A.CallTo(() => Leben.Vermindern()).MustHaveHappened(Repeated.Never);
        }

        [Fact]
        public void Toter_Mario_findet_Leben_und_wird_lebendig()
        {
            Assert<KleinerMario>(Act(Arrange(), mario => mario.FindetLeben()));
            A.CallTo(() => Leben.Erhöhen()).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Toter_Mario_kann_nicht_schießen()
        {
            Action<string> munition = A.Fake<Action<string>>();
            Assert(Act(Arrange(), mario => mario.Schießen(munition)));
            A.CallTo(() => munition(A<string>.Ignored)).MustHaveHappened(Repeated.Never);
        }
    }
}