using FluentAssertions;
using SuperMarioImWorkshop.Kontrakte;
using SuperMarioImWorkshop.Status;
using Xunit;

namespace SuperMarioImWorkshop
{
    public class SuperMarioSpielSpecs
    {
        [Fact]
        public void Große_Welt_Spielmodus_entspricht_Anforderungen()
        {
            IchBinSuperMario mario = SuperMarioSpiel.StarteGroßeWeltModus();
            mario.Should().BeAssignableTo<MarioMitPilz>();

            mario = mario.WirdVonGegnerGetroffen().WirdVonGegnerGetroffen();
            mario.Should().BeAssignableTo<MarioMitPilz>();

            mario = mario.WirdVonGegnerGetroffen().WirdVonGegnerGetroffen();
            mario.Should().BeAssignableTo<ToterMario>();
        }

        [Fact]
        public void Tabula_Rasa_Spielmodus_entspricht_Anforderungen()
        {
            IchBinSuperMario mario = SuperMarioSpiel.StarteTabulaRasaModus();

            mario.Should().BeAssignableTo<KleinerMario>();

            mario = mario.WirdVonGegnerGetroffen();
            mario.Should().BeAssignableTo<MarioMitPilz>();

            mario = mario.WirdVonGegnerGetroffen().WirdVonGegnerGetroffen();
            mario.Should().BeAssignableTo<MarioMitFeuerblume>();

            mario = mario.FindetLeben().WirdVonGegnerGetroffen().WirdVonGegnerGetroffen().WirdVonGegnerGetroffen();
            mario.Should().BeAssignableTo<MarioMitPilz>();

            mario = mario.WirdVonGegnerGetroffen().WirdVonGegnerGetroffen();
            mario.Should().BeAssignableTo<MarioMitPilz>();

            mario = mario.WirdVonGegnerGetroffen().WirdVonGegnerGetroffen();
            mario.Should().BeAssignableTo<ToterMario>();
        }

        [Fact]
        public void Extraleben_rettet_Mario_vor_tot()
        {
            SuperMarioSpiel
                .StarteMitDreiLeben()
                .StarteAlsKleinerMario()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .FindetLeben()
                .WirdVonGegnerGetroffen()
                .Should().BeOfType<KleinerMario>();
        }

        [Fact]
        public void Zwei_Mal_sterben_bei_3_Leben_resultiert_in_lebendig()
        {
            SuperMarioSpiel
                .StarteMitDreiLeben()
                .StarteAlsKleinerMario()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .Should().BeOfType<KleinerMario>();
        }

        [Fact]
        public void Vier_Mal_sterben_bei_3_Leben_resultiert_in_tot()
        {
            SuperMarioSpiel
                .StarteMitDreiLeben()
                .StarteAlsKleinerMario()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .Should().BeOfType<ToterMario>();
        }

        [Fact]
        public void Wenn_Mario_unendlich_viele_Leben_hat_kann_er_nie_sterben()
        {
            SuperMarioSpiel
                .StarteMitUnendlicheLeben()
                .StarteAlsMarioMitPilz()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .WirdVonGegnerGetroffen()
                .Should().BeOfType<KleinerMario>();
        }
    }
}