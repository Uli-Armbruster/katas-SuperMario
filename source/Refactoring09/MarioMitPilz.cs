namespace SuperMarioRefactoring.Refactoring09
{
  internal class MarioMitPilz : IchBinSuperMario
  {
    private readonly IchBinLebendig _leben;

    public MarioMitPilz(IchBinLebendig leben)
    {
      _leben = leben;
    }

    public int Leben { get; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return new KleinerMario(_leben);
    }

    public IchBinSuperMario FindetPilz()
    {
      return this;
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitFeuerblume(_leben);
    }

    public IchBinSuperMario FindetLeben()
    {
      return new MarioMitPilz(_leben.Erhöhen());
    }

    public IchBinSuperMario FindetYoshi()
    {
      return new MarioMitYoshi(this);
    }

    public IchBinSuperMario FälltInLoch()
    {
      return _leben.Vermindern();
    }
  }
}