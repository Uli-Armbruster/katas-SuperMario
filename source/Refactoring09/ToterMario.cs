namespace SuperMarioRefactoring.Refactoring09
{
  public class ToterMario : IchBinSuperMario
  {
    private readonly IchBinLebendig _leben;

    public ToterMario(IchBinLebendig leben)
    {
      _leben = leben;
    }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return this;
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
      return new KleinerMario(_leben.Erhöhen());
    }

    public IchBinSuperMario FindetYoshi()
    {
      return this;
    }

    public IchBinSuperMario FälltInLoch()
    {
      return this;
    }
  }
}