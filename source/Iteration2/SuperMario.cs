using System.IO;
using FluentAssertions;
using Xunit;

namespace SuperMarioRefactoring.Iteration2
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

      mario.Status.Should().Be(Status.MitPilz);
    }

    [Fact]
    public void Mario_mit_Feuerblume_findet_Pilz_und_behält_Feuerblume()
    {
      var mario = new SuperMario();
      mario.FindetFeuerblume();

      mario.FindetPilz();

      mario.Status.Should().Be(Status.MitFeuerblume);
    }

    [Fact]
    public void Mario_mit_Pilz_wird_klein_bei_Treffer()
    {
      var mario = new SuperMario();
      mario.FindetPilz();

      mario = mario.WirdVonGegnerGetroffen();

      mario.Should().NotBeNull();
      mario.Status.Should().Be(Status.Klein);
    }
  }

  internal class SuperMario
  {
    public SuperMario()
    {
      Status = Status.Klein;
    }

    public Status Status { get; private set; }


    /// <summary>
    /// </summary>
    /// <returns>null, wenn Mario tot ist</returns>
    public SuperMario WirdVonGegnerGetroffen()
    {
      switch (Status)
      {
        case Status.Klein:
          return null;
        case Status.MitFeuerblume:
          Status = Status.MitPilz;
          return this;
        case Status.MitPilz:
          Status = Status.Klein;
          return this;
        default:
          throw new InvalidDataException("Unbekannter Status");
      }
    }

    public void FindetPilz()
    {
      if (Status == Status.MitFeuerblume)
        return;

      Status = Status.MitPilz;
    }

    public void FindetFeuerblume()
    {
      Status = Status.MitFeuerblume;
    }
  }

  internal enum Status
  {
    Klein,
    MitPilz,
    MitFeuerblume
  }
}