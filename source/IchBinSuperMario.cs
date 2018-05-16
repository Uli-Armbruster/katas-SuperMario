namespace SuperMarioRefactoring
{
  public interface IchBinSuperMario
  {
    int AnzahlLeben { get; }
    bool BesitztYoshi { get; }
    Status Status { get; }

    IchBinSuperMario WirdVonGegnerGetroffen();
    IchBinSuperMario FindetLeben();
    IchBinSuperMario FindetPilz();
    IchBinSuperMario FindetFeuerblume();
    IchBinSuperMario FindetYoshi();
    IchBinSuperMario FälltInLoch();
  }
}