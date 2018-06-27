using System;
using System.Collections.Generic;
using System.IO;

namespace SuperMarioRefactoring.Refactoring06
{
  internal class SuperMario : IchBinSuperMario
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
    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      if (ReitetYoshi)
      {
        ReitetYoshi = false;
        return this;
      }

      var übergänge = new Dictionary<Status, Func<IchBinSuperMario>>();
      übergänge.Add(Status.Klein, VermindereLeben);
      übergänge.Add(Status.MitFeuerblume, () => new MarioMitPilz(Leben));
      übergänge.Add(Status.MitPilz, () => new KleinerMario(Leben));

      if (übergänge.ContainsKey(Status))
        return übergänge[Status]();

      throw new InvalidDataException("Unbekannter Status");
    }

    public IchBinSuperMario FindetPilz()
    {
      if (Status == Status.MitFeuerblume)
        return new MarioMitFeuerblume(Leben);

      return new MarioMitPilz(Leben);
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitFeuerblume(Leben);
    }

    public IchBinSuperMario FindetLeben()
    {
      return new SuperMario(Leben + 1, Status);
    }

    public IchBinSuperMario FindetYoshi()
    {
      ReitetYoshi = true;
      return this;
    }

    public IchBinSuperMario FälltInLoch()
    {
      ReitetYoshi = false;
      return VermindereLeben();
    }

    private IchBinSuperMario VermindereLeben()
    {
      if ( Leben - 1 <= 0)
        return null;

      return new KleinerMario(Leben - 1);
    }
  }
}