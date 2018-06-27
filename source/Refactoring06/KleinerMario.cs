namespace SuperMarioRefactoring.Refactoring06
{
  internal class KleinerMario : IchBinSuperMario
  {
    public KleinerMario(int leben)
    {
      Leben = leben;
      Status = Status.Klein;
    }

    public int Leben { get; }
    public Status Status { get; }
    public bool ReitetYoshi { get; private set; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return VermindereLeben();
    }

    public IchBinSuperMario FindetPilz()
    {
      return new MarioMitPilz(Leben);
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitFeuerblume(Leben);
    }

    public IchBinSuperMario FindetLeben()
    {
      return new KleinerMario(Leben + 1);
    }

    public IchBinSuperMario FindetYoshi()
    {
      ReitetYoshi = true;
      return this;
    }

    public IchBinSuperMario FälltInLoch()
    {
      return VermindereLeben();
    }

    private IchBinSuperMario VermindereLeben()
    {
      return Leben - 1 > 0
        ? new KleinerMario(Leben - 1)
        : null;
    }
  }
}