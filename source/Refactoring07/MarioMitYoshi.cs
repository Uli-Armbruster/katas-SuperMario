namespace SuperMarioRefactoring.Refactoring07
{
  public class MarioMitYoshi : IchBinSuperMario
  {
    private readonly IchBinSuperMario _reiter;

    public MarioMitYoshi(IchBinSuperMario reiter)
    {
      _reiter = reiter;
    }

    public int Leben => _reiter.Leben;

    public Status Status => _reiter.Status;

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return _reiter;
    }

    public IchBinSuperMario FindetPilz()
    {
      return new MarioMitYoshi(_reiter.FindetPilz());
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitYoshi(_reiter.FindetFeuerblume());
    }

    public IchBinSuperMario FindetLeben()
    {
      return new MarioMitYoshi(_reiter.FindetLeben());
    }

    public IchBinSuperMario FindetYoshi()
    {
      return this;
    }

    public IchBinSuperMario FälltInLoch()
    {
      return Leben - 1 > 0
        ? new KleinerMario(Leben - 1)
        : null;
    }
  }
}