namespace SuperMarioRefactoring
{
  internal class KleinerMario : IchBinSuperMario
  {
    public KleinerMario(int anzahlLeben)
    {
      AnzahlLeben = anzahlLeben;
    }

    public int AnzahlLeben { get; private set; }
    public bool BesitztYoshi { get; private set; }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      if (BesitztYoshi)
      {
        BesitztYoshi = false;
        return this;
      }

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