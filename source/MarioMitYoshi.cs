namespace SuperMarioRefactoring
{
  internal class MarioMitYoshi : IchBinSuperMario
  {
    private readonly IchBinSuperMario _reiter;

    public int AnzahlLeben => _reiter.AnzahlLeben;

    public MarioMitYoshi(IchBinSuperMario reiter)
    {
      _reiter = reiter;
    }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return _reiter;
    }

    public IchBinSuperMario FindetLeben()
    {
      return new MarioMitYoshi(_reiter.FindetLeben());
    }

    public IchBinSuperMario FindetPilz()
    {
      return new MarioMitYoshi(_reiter.FindetPilz());
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitYoshi(_reiter.FindetFeuerblume());
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