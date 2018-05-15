namespace SuperMarioRefactoring
{
  public class SuperMario
  {
    public SuperMario()
    {
      IstTot = false;
      IstGroß = false;
    }

    public bool IstTot { get; private set; }
    private bool IstGroß { get; set; }

    public void WirdVonGegnerGetroffen()
    {
      if (IstGroß)
      {
        IstGroß = false;
        return;
      }

      IstTot = true;
    }

    public void FindetPilz()
    {
      if (IstTot)
        return;

      IstGroß = true;
    }
  }
}