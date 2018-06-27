namespace SuperMarioRefactoring.Refactoring08
{
  internal class KleinerMario : IchBinSuperMario
  {
    public KleinerMario(int leben)
    {
      Leben = leben;
    }

    public int Leben { get; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return VermindereLeben();
    }

    public IchBinSuperMario FindetPilz()
    {
      return new MarioMitPilz(Leben);
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitFeuerblume(Leben);
    }

    public IchBinSuperMario FindetLeben()
    {
      return new KleinerMario(Leben + 1);
    }

    public IchBinSuperMario FindetYoshi()
    {
      return new MarioMitYoshi(this);
    }

    public IchBinSuperMario FälltInLoch()
    {
      return VermindereLeben();
    }

    private IchBinSuperMario VermindereLeben()
    {
      if (Leben - 1 > 0)
        return new KleinerMario(Leben - 1);

      return new ToterMario();
    }
  }
}