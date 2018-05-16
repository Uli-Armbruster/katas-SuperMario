namespace SuperMarioRefactoring
{
  internal class MarioMitFeuerblume : IchBinSuperMario
  {
    public MarioMitFeuerblume(int anzahlLeben)
    {
      AnzahlLeben = anzahlLeben;
    }

    public int AnzahlLeben { get; private set; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return new MarioMitPilz(AnzahlLeben);
    }

    public IchBinSuperMario FindetLeben()
    {
      AnzahlLeben += 1;
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