namespace SuperMarioRefactoring.Refactoring08
{
  internal class MarioMitFeuerblume : IchBinSuperMario
  {
    public MarioMitFeuerblume(int leben)
    {
      Leben = leben;
    }

    public int Leben { get; }

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
      if (Leben - 1 > 0)
        return new KleinerMario(Leben - 1);

      return new ToterMario();
    }
  }
}