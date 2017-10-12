namespace SuperMarioKata
{
    public class Mario : IchBinSuperMario
    {
        public static IchBinSuperMario ToterMario()
        {
            return SuperMarioKata.ToterMario.Instanz;
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return SuperMarioKata.ToterMario.Instanz;
        }
    }
}