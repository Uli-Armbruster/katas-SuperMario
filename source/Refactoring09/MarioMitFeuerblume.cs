namespace SuperMarioRefactoring.Refactoring09
{
  internal class MarioMitFeuerblume : IchBinSuperMario
  {
    private readonly IchBinLebendig _leben;

    public MarioMitFeuerblume(IchBinLebendig leben)
    {
      _leben = leben;
    }

    public int Leben { get; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return new MarioMitPilz(_leben);
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
      return new MarioMitFeuerblume(_leben.Erhöhen());
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