namespace SuperMarioRefactoring.Refactoring06
{
  public interface IchBinSuperMario
  {
    int Leben { get; }
    Status Status { get; }
    bool ReitetYoshi { get; }

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