namespace SuperMarioRefactoring
{
  internal class ToterMario : IchBinSuperMario
  {
    public int AnzahlLeben { get; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return this;
    }

    public IchBinSuperMario FindetLeben()
    {
      return new KleinerMario(0);
    }

    public IchBinSuperMario FindetPilz()
    {
      return this;
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return this;
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