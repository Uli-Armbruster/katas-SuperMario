using System;

namespace SuperMarioRefactoring
{
  public class SuperMario
  {
    public SuperMario()
    {
      Status = Status.Klein;
      AnzahlLeben = 3;
    }

    internal Status Status { get; private set; }
    internal int AnzahlLeben { get; private set; }
    internal bool BesitztYoshi { get; private set; }

    public void WirdVonGegnerGetroffen()
    {
      if (Status == Status.Tot)
        return;

      if (BesitztYoshi)
      {
        BesitztYoshi = false;
        return;
      }

      if (Status == Status.MitFeuerblume)
      {
        Status = Status.MitPilz;
        return;
      }

      if (Status == Status.MitPilz)
      {
        Status = Status.Klein;
        return;
      }

      if (Status == Status.Klein)
      {
        VermindereLeben();
        return;
      }

      throw new InvalidOperationException();
    }

    private void VermindereLeben()
    {
      if (AnzahlLeben == 0)
      {
        Status = Status.Tot;
        return;
      }

      AnzahlLeben -= 1;
    }

    public void FindetLeben()
    {
      if (Status != Status.Tot)
      {
        AnzahlLeben += 1;
        return;
      }

      Status = Status.Klein;
      AnzahlLeben = 0;
    }

    public void FindetPilz()
    {
      if (Status == Status.Tot)
        return;

      if (Status == Status.MitFeuerblume)
        return;

      Status = Status.MitPilz;
    }

    public void FindetFeuerblume()
    {
      if (Status == Status.Tot)
        return;

      Status = Status.MitFeuerblume;
    }

    public void FindetYoshi()
    {
      BesitztYoshi = true;
    }

    public void FälltInLoch()
    {
      BesitztYoshi = false;
      Status = Status.Klein;

      VermindereLeben();
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