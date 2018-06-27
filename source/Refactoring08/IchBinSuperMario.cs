namespace SuperMarioRefactoring.Refactoring08
{
  public interface IchBinSuperMario
  {
    int Leben { get; }

    IchBinSuperMario WirdVonGegnerGetroffen();

    IchBinSuperMario FindetPilz();
    IchBinSuperMario FindetFeuerblume();
    IchBinSuperMario FindetLeben();
    IchBinSuperMario FindetYoshi();
    IchBinSuperMario FälltInLoch();
  }
}