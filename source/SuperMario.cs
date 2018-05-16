using System;
using System.Collections.Generic;

namespace SuperMarioRefactoring
{
  public class SuperMario
  {
    private readonly Dictionary<Status, Func<SuperMario>> _representationen =
      new Dictionary<Status, Func<SuperMario>>();

    //API stabil halten
    public SuperMario() : this(3)
    {
    }

    //Nicht öffentlich, um falsche Nutzung zu vermeiden
    private SuperMario(int anzahlLeben)
    {
      Status = Status.Klein;
      AnzahlLeben = anzahlLeben;

      ErzeugeStatusübergängeBeiTreffern();
    }

    private void ErzeugeStatusübergängeBeiTreffern()
    {
      _representationen.Add(Status.Tot, () => this);

      _representationen.Add(Status.MitFeuerblume,
        () =>
        {
          Status = Status.MitPilz;
          return this;
        });


      _representationen.Add(Status.MitPilz,
        () =>
        {
          Status = Status.Klein;
          return this;
        });


      _representationen.Add(Status.Klein,
        () =>
        {
          VermindereLeben();
          return this;
        });
    }

    internal Status Status { get; private set; }
    internal int AnzahlLeben { get; private set; }
    internal bool BesitztYoshi { get; private set; }

    //Factory-Pattern
    public static SuperMario StarteMitLeben(int anzahlLeben)
    {
      return new SuperMario(anzahlLeben);
    }

    public SuperMario WirdVonGegnerGetroffen()
    {
      if (BesitztYoshi)
      {
        BesitztYoshi = false;
        return this;
      }


      if (_representationen.ContainsKey(Status))
        return _representationen[Status]();


      throw new InvalidOperationException();
    }

    private void VermindereLeben()
    {
      if (AnzahlLeben == 0) Status = Status.Tot;

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