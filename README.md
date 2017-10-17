Katas - Super Mario
==================

Hier zeige ich meinen [SOLID](https://de.wikipedia.org/wiki/Prinzipien_objektorientierten_Designs) Ansatz in C# anhand einer von mir erfundenen Kata für den sagenumwobenen Super Mario.
Besonderen Fokus habe ich auf die Prinzipien der objektorientierten Programmierung gelegt. Viele Entwurfsmuster finden darin Anwendung.
Ebenso geht es um grundsätzliche Entwicklungsansätze wie API First Design und Divide-and-Conquer.

### Iterationen

#### Iteration 1
-	Wenn Super Mario startet, ist er klein.
-	Wenn der kleine Mario vom Gegner getroffen wird, ist er tot und mit ihm kann nicht mehr gespielt werden.


#### Iteration 2
-	Wenn ein kleiner Super Mario einen Pilz findet,  wird er ein Super Mario mit Pilz.
-	Wenn Super Mario mit Pilz einen Pilz findet, bleibt er im Zustand Super Mario mit 	Pilz.
-	Wenn Super Mario mit Pilz vom Gegner getroffen wird, wird er zum kleinen Mario.


#### Iteration 3
-	Wenn Super Mario startet, soll er 3 Leben haben.
-	Wenn Super Mario stirbt, verliert er ein Leben.
-	Wenn alle Leben aufgebraucht sind, ist Super Mario tot und mit ihm kann nicht mehr gespielt werden.


#### Iteration 4
-	Wenn Super Mario ein Leben findet, erhöhen sich seine verfügbaren Leben.
-	Wenn ein toter Super Mario ein Leben findet, kann wieder mit ihm gespielt werden.


#### Iteration 5
-	Wenn Super Mario eine Feuerblume findet, wächst er.
-	Wenn Super Mario mit Feuerblume vom Gegner getroffen wird, wird er zum Mario mit Pilz.
-	Wenn Super Mario mit Feuerblume einen Pilz findet, behält er seine Feuerblume.


#### Iteration 6
-	Wenn Super Mario eine Eisblume findet, wächst er.
-	Wenn Super Mario mit Eisblume vom Gegner getroffen wird, wird er zum Mario mit Pilz.
-	Wenn Super Mario mit Eisblume einen Pilz findet, behält er seine Eisblume.
-	Wenn Super Mario mit Eisblume eine Feuerblume findet, wechselt er zur Feuerblume (vice versa).
-	Wenn Super Mario mit Eisblume den Befehl zum Schießen erhält, schießt er Eis.
-	Wenn Super Mario mit Feuerblume den Befehl zum Schießen erhält, schießt er Feuer.
-	Wenn Super Mario ohne Blume den Befehl zum Schießen erhält, passiert nichts.


#### Iteration 7
-	Wenn Mario einen Stern findet, dann verliert er diesen automatisch nach 2 Sekunden wieder.
-	Wenn Mario aktuell einen Stern besitzt und vom Gegner getroffen wird, dann passiert ihm nichts.
-	Wenn ein kleiner Mario mit Stern Pilz oder Blume findet, wächst er, behält aber seinen Stern bei.


#### Iteration 8:
-	Wenn Mario einen Joshi findet, dann ändert sich seine Größe nicht.
-	Wenn Mario mit Joshi vom Gegner getroffen wird, dann verliert er seinen Joshi, verändert aber seine Größe nicht.
-	Wenn ein kleiner Mario mit Yoshi einen Pilz oder Blume findet, wächst er, behält aber seinen Yoshi bei.


#### Iteration 9:
-	Wenn Mario Punkte findet, summieren diese sich auf einem Punktekonto.
-	Wenn 100 Punkte auf dem Konto sind, dann erhält Mario 1 weiteres Leben und der Punktestand fängt wieder bei 0 an. 
- 	Wenn Mario endgültig stirbt, verliert er seine Punkte.

### Iteration 10:
-	Es soll einen neuen Spielmodus "Infinity" geben, bei dem Mario unedlich viele Leben als kleiner Mario hat.

### Iteration 11:
-	Es soll einen neuen Spielmodus "GroßeWelt" geben, bei dem Mario 2 Leben hat, dafür aber jedes Leben mit Pilz startet.

### Iteration 12:
-	Es soll einen neuen Spielmodus "TabulaRasa" geben, bei dem Mario 3 Leben hat
	-	und als kleiner Mario startet
	-	danach als Mario mit Pilz geboren wird
	-	und im letzten Leben mit Feuerblume anfängt.
	-	Als Extraleben soll es immer 2 Leben mit Pilz geben.

#### Optionale Iteration
-	Super Mario soll nach 3 verbrauchten Leben wieder 3 neue erhalten und ein Zähler soll erhöht werden, der das  Aufladen trackt.


#### Kontakt
1. [Blog](https://e.co-IT.eu/uli-armbruster/blog)
2. [Twitter](https://e.co-IT.eu/uli-armbruster/twitter)
3. [Xing](https://e.co-IT.eu/uli-armbruster/xing)
4. [LinkedIn](https://e.co-IT.eu/uli-armbruster/xing)
5. [Facebook](https://e.co-IT.eu/uli-armbruster/facebook)
6. [YouTube](https://e.co-IT.eu/uli-armbruster/youtube)
7. [Github](https://e.co-IT.eu/uli-armbruster/github)