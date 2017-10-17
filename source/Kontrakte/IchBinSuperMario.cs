using System;

namespace SuperMarioImWorkshop.Kontrakte
{
    // ReSharper disable once InconsistentNaming
    public interface IchBinSuperMario
    {
        IchBinSuperMario WirdVonGegnerGetroffen();
        IchBinSuperMario FindetPunkte(int punkte);
        IchBinSuperMario FindetPilz();
        IchBinSuperMario FindetLeben();
        IchBinSuperMario FindetFeuerblume();
        IchBinSuperMario FindetEisblume();
        IchBinSuperMario FindetStern();
        IchBinSuperMario FindetYoshi();
        IchBinSuperMario Schießen(Action<string> mit);
    }
}