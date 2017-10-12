using Xunit;
using FluentAssertions;

namespace SuperMarioKata
{
    public class MarioSpecs
    {
        [Fact]
        public void Der_kleine_Mario_stirbt_wenn_er_vom_Gegner_getroffen_wird()
        {
            var mario = new Mario();
            var getroffenerMario = mario.WirdVonGegnerGetroffen();
            getroffenerMario.Should().Be(Mario.ToterMario());

        }
    }

    // ReSharper disable once InconsistentNaming
    public interface IchBinSuperMario
    {
        IchBinSuperMario WirdVonGegnerGetroffen();
    }

    public class Mario : IchBinSuperMario
    {
        public static IchBinSuperMario ToterMario()
        {
            return new ToterMario();
        }

        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return new ToterMario();
        }
    }

    public class ToterMario : IchBinSuperMario
    {
        public IchBinSuperMario WirdVonGegnerGetroffen()
        {
            return this;
        }
    }
}