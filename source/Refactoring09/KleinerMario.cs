namespace SuperMarioRefactoring.Refactoring09
{
  internal class KleinerMario : IchBinSuperMario
  {
    private readonly IchBinLebendig _leben;

    public KleinerMario(IchBinLebendig leben)
    {
      _leben = leben;
    }

    public int Leben { get; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return VermindereLeben();
    }

    public IchBinSuperMario FindetPilz()
    {
      return new MarioMitPilz(_leben);
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitFeuerblume(_leben);
    }

    public IchBinSuperMario FindetLeben()
    {
      return new KleinerMario(_leben.Erhöhen());
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
      return _leben.Vermindern();
    }
  }
}