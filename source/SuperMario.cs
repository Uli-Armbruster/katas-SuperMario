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

    private Status Status { get; set; }
    private int AnzahlLeben { get; set; }
    private bool BesitztYoshi { get; set; }

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
        if (AnzahlLeben == 0)
        {
          Status = Status.Tot;
          return;
        }

        AnzahlLeben -= 1;

        return;
      }

      throw new InvalidOperationException();
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
  }

  internal enum Status
  {
    Tot,
    Klein,
    MitPilz,
    MitFeuerblume
  }
}