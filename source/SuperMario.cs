using System;

namespace SuperMarioRefactoring
{
  public class SuperMario
  {
    //API stabil halten
    public SuperMario():this(3)
    {
      
    }

    //Nicht öffentlich, um falsche Nutzung zu vermeiden
    private SuperMario(int anzahlLeben)
    {
      Status = Status.Klein;
      AnzahlLeben = anzahlLeben;
    }

    //Factory-Pattern
    public static SuperMario StarteMitLeben(int anzahlLeben)
    {
      return new SuperMario(anzahlLeben);
    }

    internal Status Status { get; private set; }
    internal int AnzahlLeben { get; private set; }
    internal bool BesitztYoshi { get; private set; }

    public SuperMario WirdVonGegnerGetroffen()
    {
      if (Status == Status.Tot)
        return this;

      if (BesitztYoshi)
      {
        BesitztYoshi = false;
        return this;
      }

      if (Status == Status.MitFeuerblume)
      {
        Status = Status.MitPilz;
        return this;
      }

      if (Status == Status.MitPilz)
      {
        Status = Status.Klein;
        return this;
      }

      if (Status == Status.Klein)
      {
        VermindereLeben();
        return this;
      }

      throw new InvalidOperationException();
    }

    private void VermindereLeben()
    {
      if (AnzahlLeben == 0)
      {
        Status = Status.Tot;
      }

      AnzahlLeben -= 1;
    }

    public SuperMario FindetLeben()
    {
      if (Status != Status.Tot)
      {
        AnzahlLeben += 1;
        return this;
      }

      Status = Status.Klein;
      AnzahlLeben = 0;

      return this;
    }

    public SuperMario FindetPilz()
    {
      if (Status == Status.Tot)
        return this;

      if (Status == Status.MitFeuerblume)
        return this;

      Status = Status.MitPilz;

      return this;
    }

    public SuperMario FindetFeuerblume()
    {
      if (Status == Status.Tot)
        return this;

      Status = Status.MitFeuerblume;

      return this;
    }

    public SuperMario FindetYoshi()
    {
      BesitztYoshi = true;
      return this;
    }

    public SuperMario FälltInLoch()
    {
      BesitztYoshi = false;
      Status = Status.Klein;

      VermindereLeben();
      return this;
    }
  }

  internal enum Status
  {
    Tot,
    Klein,
    MitPilz,
    MitFeuerblume
  }
}