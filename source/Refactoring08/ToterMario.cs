namespace SuperMarioRefactoring.Refactoring08
{
  public class ToterMario : IchBinSuperMario
  {
    public int Leben => 0;

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
      return new KleinerMario(1);
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