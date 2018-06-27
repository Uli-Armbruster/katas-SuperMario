﻿using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace SuperMarioRefactoring.Iteration3
{
  public class SuperMarioSpecs
  {
    [Fact]
    public void Kleiner_Mario_mit_einem_Leben_stirbt_bei_Treffer()
    {
      var mario = new SuperMario(1);

      mario = mario.WirdVonGegnerGetroffen();

      mario.Should().BeNull();
    }

    [Fact]
    public void Kleiner_Mario_mit_zwei_Leben_verliert_Leben_bei_Treffer()
    {
      var mario = new SuperMario(2);

      mario = mario.WirdVonGegnerGetroffen();

      mario.Should().NotBeNull();
      mario.Leben.Should().Be(1);
    }

    [Fact]
    public void Mario_startet_mit_3_Leben()
    {
      var mario = new SuperMario();

      mario = mario
        .WirdVonGegnerGetroffen()
        .WirdVonGegnerGetroffen();

      mario.Should().NotBeNull();

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
    public void Mario_mit_Pilz_wird_klein_bei_Treffer()
    {
      var mario = new SuperMario();
      mario.FindetPilz();

      mario = mario.WirdVonGegnerGetroffen();

      mario.Should().NotBeNull();
      mario.Status.Should().Be(Status.Klein);
    }

    [Fact]
    public void Mario_mit_Feuerblume_findet_Pilz_und_behält_Feuerblume()
    {
      var mario = new SuperMario();
      mario.FindetFeuerblume();

      mario.FindetPilz();

      mario.Status.Should().Be(Status.MitFeuerblume);
    }
  }

  internal class SuperMario
  {
    public SuperMario()
      : this(3)
    {
    }

    public SuperMario(int leben)
    {
      if (leben <= 0)
        throw new ArgumentOutOfRangeException(nameof(leben));

      Leben = leben;
      Status = Status.Klein;
    }

    public int Leben { get; private set; }

    public Status Status { get; private set; }


    /// <summary>
    /// </summary>
    /// <returns>null, wenn Mario tot ist</returns>
    public SuperMario WirdVonGegnerGetroffen()
    {
      switch (Status)
      {
        case Status.Klein:
          {
            Leben -= 1;
            return Leben > 0 ? this : null;
          }
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