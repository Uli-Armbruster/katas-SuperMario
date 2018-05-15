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

    public void WirdVonGegnerGetroffen()
    {
      if (Status == Status.Tot)
        return;

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
  }

  internal enum Status
  {
    Tot,
    Klein,
    MitPilz,
    MitFeuerblume
  }
}