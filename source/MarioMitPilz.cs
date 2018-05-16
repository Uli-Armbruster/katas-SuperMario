namespace SuperMarioRefactoring
{
  internal class MarioMitPilz : IchBinSuperMario
  {
    public MarioMitPilz(int anzahlLeben)
    {
      AnzahlLeben = anzahlLeben;
    }

    public int AnzahlLeben { get; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return new KleinerMario(AnzahlLeben);
    }

    public IchBinSuperMario FindetLeben()
    {
      return new MarioMitPilz(AnzahlLeben + 1);
    }

    public IchBinSuperMario FindetPilz()
    {
      return this;
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new MarioMitFeuerblume(AnzahlLeben);
    }

    public IchBinSuperMario FindetYoshi()
    {
      return new MarioMitYoshi(this);
    }

    public IchBinSuperMario FälltInLoch()
    {
      if (AnzahlLeben == 0) return new ToterMario();
      return new KleinerMario(AnzahlLeben - 1);
    }
  }
}