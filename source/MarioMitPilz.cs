using System;

namespace SuperMarioRefactoring
{
  class MarioMitPilz : IchBinSuperMario
  {
    public int AnzahlLeben { get; private set; }

    public MarioMitPilz(int anzahlLeben)
    {
      AnzahlLeben = anzahlLeben;
    }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
     return new KleinerMario(AnzahlLeben);
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