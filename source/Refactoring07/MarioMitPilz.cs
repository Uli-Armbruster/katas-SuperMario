namespace SuperMarioRefactoring.Refactoring07
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
      return new MarioMitYoshi(this);
    }

    public IchBinSuperMario FälltInLoch()
    {
      return Leben - 1 > 0
        ? new KleinerMario(Leben - 1)
        : null;
    }
  }
}