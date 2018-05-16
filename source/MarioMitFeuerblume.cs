namespace SuperMarioRefactoring
{
  internal class MarioMitFeuerblume : IchBinSuperMario
  {
    public MarioMitFeuerblume(int anzahlLeben)
    {
      AnzahlLeben = anzahlLeben;
    }

    public int AnzahlLeben { get; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return new MarioMitPilz(AnzahlLeben);
    }

    public IchBinSuperMario FindetLeben()
    {
      return new MarioMitFeuerblume(AnzahlLeben + 1);
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
      return new MarioMitYoshi(this);
    }

    public IchBinSuperMario FälltInLoch()
    {
      if (AnzahlLeben == 0) return new ToterMario();
      return new KleinerMario(AnzahlLeben - 1);
    }
  }
}