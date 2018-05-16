using System;

namespace SuperMarioRefactoring
{
  class KleinerMario : IchBinSuperMario
  {
    public KleinerMario(int anzahlLeben)
    {
      AnzahlLeben = anzahlLeben;
    }

    public int AnzahlLeben { get; }
    public bool BesitztYoshi { get; }
    public Status Status { get; }
    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      throw new NotImplementedException();
    }

    public IchBinSuperMario FindetLeben()
    {
      throw new NotImplementedException();
    }

    public IchBinSuperMario FindetPilz()
    {
      throw new NotImplementedException();
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      throw new NotImplementedException();
    }

    public IchBinSuperMario FindetYoshi()
    {
      throw new NotImplementedException();
    }

    public IchBinSuperMario FälltInLoch()
    {
      throw new NotImplementedException();
    }
  }
}