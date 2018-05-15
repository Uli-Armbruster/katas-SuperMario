using System;

namespace SuperMarioRefactoring
{
  public class SuperMario
  {
    public SuperMario()
    {
      IstTot = false;
      Status = Status.Klein;
    }

    public bool IstTot { get; private set; }
    private Status Status { get; set; }

    public void WirdVonGegnerGetroffen()
    {
      if (IstTot)
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
        IstTot = true;
        return;
      }

      throw new InvalidOperationException();
    }

    public void FindetPilz()
    {
      if (IstTot)
        return;

      if (Status == Status.MitFeuerblume)
        return;

      Status = Status.MitPilz;
    }

    public void FindetFeuerblume()
    {
      if (IstTot)
        return;

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