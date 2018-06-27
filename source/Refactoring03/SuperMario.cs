using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Xunit;

namespace SuperMarioRefactoring.Refactoring03
{
  public class SuperMarioSpecs
  {
    [Fact]
    public void Kleiner_Mario_mit_einem_Leben_stirbt_bei_Treffer()
    {
      new SuperMario(1)
        .WirdVonGegnerGetroffen()
        .Should()
        .BeNull();
    }

    [Fact]
    public void Kleiner_Mario_mit_zwei_Leben_verliert_Leben_bei_Treffer()
    {
      var mario = new SuperMario(2)
        .WirdVonGegnerGetroffen();

      mario.Should().NotBeNull();
      mario.Leben.Should().Be(1);
    }

    [Fact]
    public void Mario_fällt_mit_Yoshi_und_Feuerblume_in_Loch_und_muss_klein_weiterspielen()
    {
      var mario = new SuperMario()
        .FindetFeuerblume()
        .FindetYoshi()
        .FälltInLoch();

      mario.Should().NotBeNull();
      mario.Status.Should().Be(Status.Klein);
      mario.ReitetYoshi.Should().BeFalse();
      mario.Leben.Should().Be(2);
    }

    [Fact]
    public void Mario_findet_Leben_und_hat_insgesamt_1_Leben_mehr()
    {
      new SuperMario(2)
        .FindetLeben()
        .Leben.Should().Be(3);
    }

    [Fact]
    public void Mario_findet_Pilz_und_wächst()
    {
      new SuperMario()
        .FindetPilz()
        .Status.Should().Be(Status.MitPilz);
    }

    [Fact]
    public void Mario_findet_Yoshi_und_wird_zum_Reiter()
    {
      var mario = new SuperMario()
        .FindetYoshi()
        .ReitetYoshi.Should().BeTrue();
    }

    [Fact]
    public void Mario_mit_Feuerblume_findet_Pilz_und_behält_Feuerblume()
    {
      new SuperMario()
        .FindetFeuerblume()
        .FindetPilz()
        .Status.Should().Be(Status.MitFeuerblume);
    }

    [Fact]
    public void Mario_mit_Pilz_wird_klein_bei_Treffer()
    {
      var mario = new SuperMario()
        .FindetPilz()
        .WirdVonGegnerGetroffen();

      mario.Should().NotBeNull();
      mario.Status.Should().Be(Status.Klein);
    }

    [Fact]
    public void Mario_mit_Yoshi_wird_von_Gegner_getroffen_und_verliert_Yoshi_und_behält_Größe()
    {
      var mario = new SuperMario()
        .FindetFeuerblume()
        .FindetYoshi()
        .WirdVonGegnerGetroffen();

      mario.ReitetYoshi.Should().BeFalse();
      mario.Status.Should().Be(Status.MitFeuerblume);
    }

    [Fact]
    public void Mario_startet_mit_3_Leben()
    {
      var mario = new SuperMario()
        .WirdVonGegnerGetroffen()
        .WirdVonGegnerGetroffen();

      mario.Should().NotBeNull();

      mario = mario.WirdVonGegnerGetroffen();
      mario.Should().BeNull();
    }
  }

  internal class SuperMario
  {
    public SuperMario()
      : this(3, Status.Klein)
    {
    }

    public SuperMario(int leben)
      : this(leben, Status.Klein)
    {
    }

    private SuperMario(int leben, Status status)
    {
      if (leben <= 0)
        throw new ArgumentOutOfRangeException(nameof(leben));

      Leben = leben;
      Status = status;
    }

    public int Leben { get; }

    public Status Status { get; }

    public bool ReitetYoshi { get; private set; }

    /// <summary>
    /// </summary>
    /// <returns>null, wenn Mario tot ist</returns>
    public SuperMario WirdVonGegnerGetroffen()
    {
      if (ReitetYoshi)
      {
        ReitetYoshi = false;
        return this;
      }

      var übergänge = new Dictionary<Status, Func<SuperMario>>();
      übergänge.Add(Status.Klein, VermindereLeben);
      übergänge.Add(Status.MitFeuerblume, () => new SuperMario(Leben, Status.MitPilz));
      übergänge.Add(Status.MitPilz, () => new SuperMario(Leben, Status.Klein));

      if (übergänge.ContainsKey(Status))
        return übergänge[Status]();

      throw new InvalidDataException("Unbekannter Status");
    }

    public SuperMario FindetPilz()
    {
      return Status == Status.MitFeuerblume
        ? this
        : new SuperMario(Leben, Status.MitPilz);
    }

    public SuperMario FindetFeuerblume()
    {
      return new SuperMario(Leben, Status.MitFeuerblume);
    }

    public SuperMario FindetLeben()
    {
      return new SuperMario(Leben + 1, Status);
    }

    public SuperMario FindetYoshi()
    {
      ReitetYoshi = true;
      return this;
    }

    public SuperMario FälltInLoch()
    {
      ReitetYoshi = false;
      return VermindereLeben();
    }

    private SuperMario VermindereLeben()
    {
      return Leben - 1 > 0
        ? new SuperMario(Leben - 1, Status.Klein)
        : null;
    }
  }

  internal enum Status
  {
    Klein,
    MitPilz,
    MitFeuerblume
  }
}