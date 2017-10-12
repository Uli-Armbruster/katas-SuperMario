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

    public class Mario
    {
        public static Mario ToterMario()
        {
            return new Mario();
        }

        public Mario WirdVonGegnerGetroffen()
        {
            throw new System.NotImplementedException();
        }
    }
}