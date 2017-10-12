using System;

namespace SuperMarioKata
{
    internal class ToterMario : IchBinSuperMario
    {
        [ThreadStatic]
        private static IchBinSuperMario _instanz;

        public static IchBinSuperMario Instanz => _instanz ?? (_instanz = new ToterMario());

        private ToterMario()
        {
            
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return this;
        }
    }
}