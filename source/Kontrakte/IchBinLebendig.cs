using System;

namespace SuperMarioImWorkshop.Kontrakte
{
    // ReSharper disable once InconsistentNaming
    public interface IchBinLebendig
    {
        IchBinSuperMario Vermindern();

        IchBinLebendig Erhöhen();

        IchBinLebendig FindetPunkte(int punkte);
    }
}