namespace SuperMarioRefactoring
{
  public interface IchBinSuperMario
  {
    int AnzahlLeben { get; }
    bool BesitztYoshi { get; }
    Status Status { get; }

    SuperMario WirdVonGegnerGetroffen();
    SuperMario FindetLeben();
    SuperMario FindetPilz();
    SuperMario FindetFeuerblume();
    SuperMario FindetYoshi();
    SuperMario FälltInLoch();
  }
}