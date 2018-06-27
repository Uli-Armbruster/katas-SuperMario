namespace SuperMarioRefactoring.Refactoring07
{
  internal class MarioMitFeuerblume : IchBinSuperMario
  {
    public MarioMitFeuerblume(int leben)
    {
      Leben = leben;
      Status = Status.MitFeuerblume;
    }

    public int Leben { get; }
    public Status Status { get; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return new MarioMitPilz(Leben);
    }

    public IchBinSuperMario FindetPilz()
    {
      return this;
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return this;
    }

    public IchBinSuperMario FindetLeben()
    {
      return new MarioMitFeuerblume(Leben + 1);
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