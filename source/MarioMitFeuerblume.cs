namespace SuperMarioRefactoring
{
  internal class MarioMitFeuerblume : IchBinSuperMario
  {
    public MarioMitFeuerblume(int anzahlLeben)
    {
      AnzahlLeben = anzahlLeben;
    }

    public int AnzahlLeben { get; private set; }
    public bool BesitztYoshi { get; private set; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      if (!BesitztYoshi)
        return new MarioMitPilz(AnzahlLeben);

      BesitztYoshi = false;
      return this;
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
      BesitztYoshi = true;
      return this;
    }

    public IchBinSuperMario FälltInLoch()
    {
      if (AnzahlLeben == 0) return new ToterMario();

      return new KleinerMario(AnzahlLeben - 1);
    }
  }
}