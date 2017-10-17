using System;
using FakeItEasy;
using FluentAssertions;
using SuperMarioImWorkshop.Kontrakte;

namespace SuperMarioImWorkshop.Status
{
    public abstract class SpecsMotherBase
    {
        protected abstract IchBinSuperMario CreateMario();
        protected IchBinLebendig Leben = A.Fake<IchBinLebendig>();

        protected IchBinSuperMario Arrange()
        {
            A.CallTo(() => Leben.Vermindern()).Returns(new ToterMario(null));
            return CreateMario();
        }

        protected IchBinSuperMario Act(IchBinSuperMario sut, Func<IchBinSuperMario, IchBinSuperMario> transformation)
        {
            return transformation(sut);
        }

        protected void Assert<T>(IchBinSuperMario sut) where T : IchBinSuperMario
        {
            sut.Should().BeAssignableTo<T>();
        }
    }
}