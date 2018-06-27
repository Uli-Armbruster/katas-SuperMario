namespace SuperMarioRefactoring.Refactoring08
{
  internal class MarioMitPilz : IchBinSuperMario
  {
    public MarioMitPilz(int leben)
    {
      Leben = leben;
    }

    public int Leben { get; }

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
      if (Leben - 1 > 0)
        return new KleinerMario(Leben - 1);

      return new ToterMario();
    }
  }
}