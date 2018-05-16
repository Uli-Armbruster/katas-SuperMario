namespace SuperMarioRefactoring
{
  internal class MarioMitYoshi : IchBinSuperMario
  {
    private readonly IchBinSuperMario _reiter;

    public MarioMitYoshi(IchBinSuperMario reiter)
    {
      _reiter = reiter;
    }

    public int AnzahlLeben => _reiter.AnzahlLeben;

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return _reiter;
    }

    public IchBinSuperMario FindetLeben()
    {
      _reiter.FindetLeben();
      return this;
    }

    public IchBinSuperMario FindetPilz()
    {
      _reiter.FindetPilz();
      return this;
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      _reiter.FindetFeuerblume();
      return this;
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