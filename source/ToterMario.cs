using System;

namespace SuperMarioRefactoring
{
  class ToterMario : IchBinSuperMario {
    public int AnzahlLeben { get; }
    public bool BesitztYoshi { get; private set; }

    public ToterMario()
    {
    }

    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      return this;
    }

    public IchBinSuperMario FindetLeben()
    {
      return new KleinerMario(0);
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
      return this;
    }
  }
}