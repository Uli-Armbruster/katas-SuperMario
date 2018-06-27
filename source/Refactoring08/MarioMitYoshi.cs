namespace SuperMarioRefactoring.Refactoring08
{
  public class MarioMitYoshi : IchBinSuperMario
  {
    private readonly IchBinSuperMario _reiter;

    public MarioMitYoshi(IchBinSuperMario reiter)
    {
      _reiter = reiter;
    }

    public int Leben => _reiter.Leben;

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return _reiter;
    }

    public IchBinSuperMario FindetPilz()
    {
      return _reiter.FindetPilz();
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return _reiter.FindetFeuerblume();
    }

    public IchBinSuperMario FindetLeben()
    {
      return _reiter.FindetLeben();
    }

    public IchBinSuperMario FindetYoshi()
    {
      return this;
    }

    public IchBinSuperMario FälltInLoch()
    {
      if (Leben - 1 > 0)
        return new KleinerMario(Leben - 1);

      return new ToterMario();
    }
  }
}