namespace SuperMarioRefactoring
{
  public interface IchBinSuperMario
  {
    int AnzahlLeben { get; }

    IchBinSuperMario WirdVonGegnerGetroffen();
    IchBinSuperMario FindetLeben();
    IchBinSuperMario FindetPilz();
    IchBinSuperMario FindetFeuerblume();
    IchBinSuperMario FindetYoshi();
    IchBinSuperMario FälltInLoch();
  }
}