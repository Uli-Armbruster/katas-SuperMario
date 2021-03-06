﻿using System;
using FakeItEasy;
using FluentAssertions;
using SuperMarioImWorkshop.Kontrakte;
using Xunit;

// ReSharper disable ConvertToLocalFunction

namespace SuperMarioImWorkshop.Status
{
    public class MarioMitEisblumeSpecs : SpecsMotherBase
    {
        protected override IchBinSuperMario CreateMario()
        {
            return new MarioMitEisblume(Leben);
        }

        [Fact]
        public void Mario_mit_Eisblume_findet_Feuerblume_und_behält_diese()
        {
            Assert<MarioMitFeuerblume>(Act(Arrange(), mario => mario.FindetFeuerblume()));
        }

        [Fact]
        public void Mario_mit_Eisblume_findet_Eisblume_und_behält_diese()
        {
            Assert<MarioMitEisblume>(Act(Arrange(), mario => mario.FindetEisblume()));
        }

        [Fact]
        public void Mario_mit_Eisblume_findet_Pilz_und_behält_Eisblume()
        {
            Assert<MarioMitEisblume>(Act(Arrange(), mario => mario.FindetPilz()));
        }

        [Fact]
        public void Mario_mit_Eisblume_findet_Stern_und_behält_diesen()
        {
            Assert<MarioMitStern>(Act(Arrange(), mario => mario.FindetStern()));
        }

        [Fact]
        public void Mario_mit_Eisblume_findet_Yoshi_und_behält_diesen()
        {
            Assert<MarioMitYoshi>(Act(Arrange(), mario => mario.FindetYoshi()));
        }

        [Fact]
        public void Mario_mit_Eisblume_wird_zu_Mario_mit_Pilz_wenn_er_vom_Gegner_getroffen_wird()
        {
            Assert<MarioMitPilz>(Act(Arrange(), mario => mario.WirdVonGegnerGetroffen()));
            A.CallTo(() => Leben.Vermindern()).MustHaveHappened(Repeated.Never);
        }

        [Fact]
        public void Mario_mit_Eisblume_schießt_Eis()
        {
            var mit = string.Empty;
            Action<string> munition = wert => mit = wert;

            Assert<MarioMitEisblume>(Act(Arrange(), mario => mario.Schießen(munition)));

            mit.Should().BeEquivalentTo("Eis");
        }
    }
}