namespace SuperMarioRefactoring.Refactoring07
{
  public interface IchBinSuperMario
  {
    int Leben { get; }
    Status Status { get; }

    /// <summary>
    /// </summary>
    /// <returns>null, wenn Mario tot ist</returns>
    IchBinSuperMario WirdVonGegnerGetroffen();
    IchBinSuperMario FindetPilz();
    IchBinSuperMario FindetFeuerblume();
    IchBinSuperMario FindetLeben();
    IchBinSuperMario FindetYoshi();
    IchBinSuperMario FälltInLoch();
  }
}