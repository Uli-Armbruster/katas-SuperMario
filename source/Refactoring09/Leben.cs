using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioRefactoring.Refactoring09
{
  public class Leben : IchBinLebendig
  {
    private readonly IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> _verbleibendeLeben;
    private readonly IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> _wennExtraLeben;

    private Leben(
      IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> verbleibendeLeben,
      IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> wennExtraLeben)
    {
      _verbleibendeLeben = verbleibendeLeben;
      _wennExtraLeben = wennExtraLeben;
    }

    public IchBinSuperMario Vermindern()
    {
      var nächstesLeben = _verbleibendeLeben.First();
      var verbleibendeLeben = _verbleibendeLeben.Skip(1);

      var vermindertesLeben = new Leben(verbleibendeLeben, _wennExtraLeben);

      return nächstesLeben(vermindertesLeben);
    }

    public IchBinLebendig Erhöhen()
    {
      var extraLeben = _wennExtraLeben.ToList();
      var erhöhteLeben = extraLeben.Concat(_verbleibendeLeben);

      return new Leben(erhöhteLeben, _wennExtraLeben);
    }

    public static IchBinLebendig KleinerMarioStirbt(int anzahlLeben)
    {
      //Der Mario, der das Objekt verwendet, hat schon 1 Leben
      var zusätzlicheLeben = Math.Max(0, anzahlLeben - 1);

      var unendlichTot = Unendlich(ToterMario());

      var begrenztesLeben = Enumerable
        .Repeat(KleinerMario(), zusätzlicheLeben)
        .Concat(unendlichTot);

      var findetLeben = Enumerable.Repeat(KleinerMario(), 1);

      return new Leben(begrenztesLeben, findetLeben);
    }

    private static Func<IchBinLebendig, IchBinSuperMario> KleinerMario()
    {
      IchBinSuperMario KleinerMario(IchBinLebendig leben) => new KleinerMario(leben);
      return KleinerMario;
    }

    private static Func<IchBinLebendig, IchBinSuperMario> ToterMario()
    {
      IchBinSuperMario ToterMario(IchBinLebendig leben) => new ToterMario(leben);
      return ToterMario;
    }

    private static IEnumerable<Func<IchBinLebendig, IchBinSuperMario>> Unendlich(
      Func<IchBinLebendig, IchBinSuperMario> wiederhole)
    {
      while (true)
        yield return wiederhole;
      // ReSharper disable once IteratorNeverReturns
    }
  }
}