using FluentAssertions;
using Xunit;

namespace SuperMarioRefactoring.Refactoring09
{
  public class Specs
  {
    [Fact]
    public void Kleiner_Mario_mit_einem_Leben_stirbt_bei_Treffer()
    {
      new KleinerMario(Leben.KleinerMarioStirbt(1))
        .WirdVonGegnerGetroffen()
        .Should().BeOfType<ToterMario>();
    }

    [Fact]
    public void Mario_fällt_mit_Yoshi_und_Feuerblume_in_Loch_und_muss_klein_weiterspielen()
    {
      new MarioMitYoshi(new MarioMitFeuerblume(Leben.KleinerMarioStirbt(3)))
        .FälltInLoch()
        .Should().BeOfType<KleinerMario>();
    }

    [Fact]
    public void Mario_fällt_mit_Yoshi_und_Feuerblume_wird_getroffen_und_verliert_Yoshi()
    {
      new MarioMitYoshi(new MarioMitFeuerblume(Leben.KleinerMarioStirbt(3)))
        .WirdVonGegnerGetroffen()
        .Should().BeOfType<MarioMitFeuerblume>();
    }
  }
}