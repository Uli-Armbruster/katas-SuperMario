using FluentAssertions;
using Xunit;

namespace SuperMarioRefactoring.Iteration1
{
  public class SuperMarioSpecs
  {
    [Fact]
    public void Kleiner_Mario_stirbt_bei_Treffer()
    {
      var mario = new SuperMario();

      mario = mario.WirdVonGegnerGetroffen();

      mario.Should().BeNull();
    }

    [Fact]
    public void Mario_findet_Pilz_und_wächst()
    {
      var mario = new SuperMario();

      mario.FindetPilz();

      mario.BesitztPilz.Should().BeTrue();
    }

    [Fact]
    public void Mario_mit_Pilz_wird_klein_bei_Treffer()
    {
      var mario = new SuperMario();
      mario.FindetPilz();

      mario = mario.WirdVonGegnerGetroffen();

      mario.Should().NotBeNull();
    }
  }

  internal class SuperMario
  {
    public bool BesitztPilz { get; private set; }

    /// <summary>
    /// </summary>
    /// <returns>null, wenn tot</returns>
    public SuperMario WirdVonGegnerGetroffen()
    {
      if (BesitztPilz)
      {
        BesitztPilz = false;
        return this;
      }

      return null;
    }

    public void FindetPilz()
    {
      BesitztPilz = true;
    }
  }
}