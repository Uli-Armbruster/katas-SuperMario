namespace SuperMarioRefactoring
{
  internal class KleinerMario : IchBinSuperMario
  {
    public KleinerMario(int anzahlLeben)
    {
      AnzahlLeben = anzahlLeben;
    }

    public int AnzahlLeben { get; private set; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      if (AnzahlLeben == 0)
        return new ToterMario();

      AnzahlLeben -= 1;

      return this;
    }

    public IchBinSuperMario FindetLeben()
    {
      AnzahlLeben += 1;
      return this;
    }

    public IchBinSuperMario FindetPilz()
    {
      return new MarioMitPilz(AnzahlLeben);
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