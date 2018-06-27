namespace SuperMarioRefactoring.Refactoring06
{
  internal class MarioMitPilz : IchBinSuperMario
  {
    public MarioMitPilz(int leben)
    {
      Leben = leben;
      Status = Status.MitPilz;
    }

    public int Leben { get; }
    public Status Status { get; }
    public bool ReitetYoshi { get; private set; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return new KleinerMario(Leben);
    }

    public IchBinSuperMario FindetPilz()
    {
      return this;
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitFeuerblume(Leben);
    }

    public IchBinSuperMario FindetLeben()
    {
      return new MarioMitPilz(Leben + 1);
    }

    public IchBinSuperMario FindetYoshi()
    {
      ReitetYoshi = true;
      return this;
    }

    public IchBinSuperMario FälltInLoch()
    {
      return Leben - 1 > 0
        ? new KleinerMario(Leben - 1)
        : null;
    }
  }
}