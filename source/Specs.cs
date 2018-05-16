using FluentAssertions;
using Xunit;

namespace SuperMarioRefactoring
{
  public class Specs
  {
    [Fact]
    public void FälltInLoch()
    {
      var mario = new KleinerMario(3)
        .WirdVonGegnerGetroffen()
        .FindetFeuerblume()
        .FindetYoshi()
        .FälltInLoch();

      mario.Should().BeOfType<KleinerMario>();
      mario.AnzahlLeben.Should().Be(1);
    }

    [Fact]
    public void Kleiner_Mario_ohne_Leben_stirbt_und_ist_tot()
    {
      new KleinerMario(0)
        .WirdVonGegnerGetroffen()
        .Should().BeOfType<ToterMario>();
    }

    [Fact]
    public void Mario_beginnt_klein_mit_3_Leben_und_ohne_Yoshi()
    {
      IchBinSuperMario mario = new KleinerMario(3);

      mario.Should().BeOfType<KleinerMario>();
      mario.AnzahlLeben.Should().Be(3);
    }

    [Fact]
    public void Mario_mit_Feuerblume_und_Yoshi_wird_vom_Gegner_getroffen_behält_Feuerblumde()
    {
      //Anzahl Tests verdoppelt sich ggf. mit jeder neuen Anforderung
      //siehe oben
      var mario = new MarioMitYoshi(new MarioMitFeuerblume(3))
        .WirdVonGegnerGetroffen();

      mario.Should().BeOfType<MarioMitFeuerblume>();
      mario.AnzahlLeben.Should().Be(3);
    }

    [Fact]
    public void Mario_mit_Feuerblume_wird_vom_Gegner_getroffen_und_wird_zu_Mario_mit_Pilz()
    {
      //Anzahl Tests verdoppelt sich ggf. mit jeder neuen Anforderung
      //siehe unten

      var mario = new MarioMitFeuerblume(3)
        .WirdVonGegnerGetroffen();

      mario.Should().BeOfType<MarioMitPilz>();
      mario.AnzahlLeben.Should().Be(3);
    }

    [Fact]
    public void MitTotemMarioLässtSichNichtSpielen()
    {
      new ToterMario()
        .FindetFeuerblume()
        .Should().BeOfType<ToterMario>();
    }
  }
}