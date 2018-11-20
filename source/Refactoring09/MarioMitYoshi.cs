namespace SuperMarioRefactoring.Refactoring09
{
  public class MarioMitYoshi : IchBinSuperMario
  {
    private readonly IchBinSuperMario _reiter;

    public MarioMitYoshi(IchBinSuperMario reiter)
    {
      _reiter = reiter;
    }

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
      return _reiter.FälltInLoch();
    }
  }
}