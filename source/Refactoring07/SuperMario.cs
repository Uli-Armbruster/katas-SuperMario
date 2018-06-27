using System;

namespace SuperMarioRefactoring.Refactoring07
{
  internal class SuperMario : IchBinSuperMario
  {
    private readonly IchBinSuperMario echterMario;

    public SuperMario()
      : this(3)
    {
    }

    public SuperMario(int leben)
    {
      if (leben <= 0)
        throw new ArgumentOutOfRangeException(nameof(leben));

      echterMario = new KleinerMario(leben);
    }

    private SuperMario(IchBinSuperMario neu)
    {
      echterMario = neu;
    }

    public int Leben => echterMario?.Leben ?? 0;

    public Status Status => echterMario?.Status ?? Status.Klein;

    /// <summary>
    /// </summary>
    /// <returns>null, wenn Mario tot ist</returns>
    public IchBinSuperMario WirdVonGegnerGetroffen()
    {
      var neuerStatus = echterMario.WirdVonGegnerGetroffen();

      return neuerStatus == null
        ? null
        : new SuperMario(neuerStatus);
    }

    public IchBinSuperMario FindetPilz()
    {
      return new SuperMario(echterMario.FindetPilz());
    }

    public IchBinSuperMario FindetFeuerblume()
    {
      return new SuperMario(echterMario.FindetFeuerblume());
    }

    public IchBinSuperMario FindetLeben()
    {
      return new SuperMario(echterMario.FindetLeben());
    }

    public IchBinSuperMario FindetYoshi()
    {
      return new SuperMario(echterMario.FindetYoshi());
    }

    public IchBinSuperMario FälltInLoch()
    {
      var neuerStatus = echterMario.WirdVonGegnerGetroffen();

      return neuerStatus == null
        ? null
        : new SuperMario(neuerStatus);
    }
  }
}