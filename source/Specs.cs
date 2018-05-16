using FluentAssertions;
using Xunit;

namespace SuperMarioRefactoring
{
  public class Specs
  {
    [Fact]
    public void Mario_beginnt_klein_mit_3_Leben_und_ohne_Yoshi()
    {
      //Properties müssen von außen zugreifbar sein
      //widerpsricht OOP

      var mario = new SuperMario();
      mario.Status.Should().BeEquivalentTo(Status.Klein);
      mario.AnzahlLeben.Should().Be(3);
      mario.BesitztYoshi.Should().BeFalse();
    }


    [Fact]
    public void Kleiner_Mario_ohne_Leben_stirbt_und_ist_tot()
    {
      //Ausgangssituation erzeugen ist aufwändig
      //Eigentlich müsste ich nach jedem Treffer prüfen, dass er nicht bereits tot ist,
      //da Logik in der Methode sehr unübersichtlich ist

      //arrange
      var mario = new SuperMario();
      mario.WirdVonGegnerGetroffen();
      mario.Status.Should().BeEquivalentTo(Status.Klein);

      mario.WirdVonGegnerGetroffen();
      mario.WirdVonGegnerGetroffen();

      //act
      mario.WirdVonGegnerGetroffen();

      //assert
      mario.Status.Should().BeEquivalentTo(Status.Tot);
    }

    [Fact]
    public void NEU_Kleiner_Mario_ohne_Leben_stirbt_und_ist_tot()
    {
      //API First: Wir würde ich es als Konsument gerne nutzen
      //Kann ich die API trotzdem konstant halten

      //arrange
      var mario = SuperMario.StarteMitLeben(0);

      //act
      mario.WirdVonGegnerGetroffen();

      //assert
      mario.Status.Should().BeEquivalentTo(Status.Tot);
    }
    

    [Fact]
    public void Mario_mit_Feuerblume_und_ohne_Yoshi_wird_vom_Gegner_getroffen_wird_zu_Mario_mit_Pilz()
    {
      //Anzahl Tests verdoppelt sich ggf. mit jeder neuen Anforderung
      //siehe unten

      var mario = new SuperMario();
      mario.FindetFeuerblume();

      mario.WirdVonGegnerGetroffen();

      mario.Status.Should().BeEquivalentTo(Status.MitPilz);
      mario.BesitztYoshi.Should().BeFalse();
      mario.AnzahlLeben.Should().Be(3);
    }

    [Fact]
    public void Mario_mit_Feuerblume_und_mit_Yoshi_wird_vom_Gegner_getroffen_behält_Feuerblumde()
    {
      //Anzahl Tests verdoppelt sich ggf. mit jeder neuen Anforderung
      //siehe oben
      var mario = new SuperMario();
      mario.FindetFeuerblume();
      mario.FindetYoshi();

      mario.WirdVonGegnerGetroffen();

      mario.Status.Should().BeEquivalentTo(Status.MitFeuerblume);
      mario.BesitztYoshi.Should().BeFalse();
      mario.AnzahlLeben.Should().Be(3);
    }

    [Fact]
    public void NEU_Mario_mit_Feuerblume_und_mit_Yoshi_wird_vom_Gegner_getroffen_behält_Feuerblumde()
    {
      //Anzahl Tests verdoppelt sich ggf. mit jeder neuen Anforderung
      //siehe oben
      var mario = SuperMario
        .StarteMitLeben(3)
        .FindetFeuerblume()
        .FindetYoshi()
        .WirdVonGegnerGetroffen();

      mario.Status.Should().BeEquivalentTo(Status.MitFeuerblume);
      mario.BesitztYoshi.Should().BeFalse();
      mario.AnzahlLeben.Should().Be(3);
    }
   

    [Fact]
    public void FälltInLoch()
    {
      //Test durchläuft mehrere Methoden

      var mario = new SuperMario();
      mario.WirdVonGegnerGetroffen();
      mario.FindetFeuerblume();
      mario.FindetYoshi();

      mario.FälltInLoch();

      mario.Status.Should().BeEquivalentTo(Status.Klein);
      mario.AnzahlLeben.Should().Be(1);
      mario.BesitztYoshi.Should().BeFalse();
    }

    [Fact]
    public void MitTotemMarioLässtSichNichtSpielen()
    {
      //wie prüfe ich, dass keine Aktionen mehr ausgeführt werden?
      //Debugging?

      var mario = new SuperMario();
      mario.WirdVonGegnerGetroffen();
      mario.WirdVonGegnerGetroffen();
      mario.WirdVonGegnerGetroffen();
      mario.WirdVonGegnerGetroffen();

      mario.FindetFeuerblume();

      mario.Status.Should().BeEquivalentTo(Status.Tot);
    }
  }
}