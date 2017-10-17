Katas - Super Mario
==================

Hier zeige ich meinen [SOLID](https://de.wikipedia.org/wiki/Prinzipien_objektorientierten_Designs) Ansatz in C# anhand einer von mir erfundenen Kata für den sagenumwobenen Super Mario.
Besonderen Fokus habe ich auf die Prinzipien der objektorientierten Programmierung gelegt. Viele Entwurfsmuster finden darin Anwendung.
Ebenso geht es um grundsätzliche Entwicklungsansätze wie API First Design und Divide-and-Conquer.

==================
## Branch: conference-talks
Dieser Branch orientiert sich lose am Master-Branch und hat den Zweck Defensives Design zu demonstrieren. Dazu wurden Anforderungen gegenüber der originären Kata geändert und der Code anders aufgebaut.
Aufgrund der Auslegung auf 45 Minuten kann auch nur ein grober Einblick gegeben werden.
Die zugehörige Präsentation befindet sich [hier](https://speakerdeck.com/uli_armbruster/defensives-design).

==================
## Interessenten
Ihr wollt Teile davon in euren Vorträgen verwenden, ihr wollt ein Training zu dem Thema oder ich soll dazu in euerer Community einen Vortrag halten, dann kontaktiert mich über die unten genannten Kanäle.

==================

### Iterationen

#### Iteration 1
-	Wenn Super Mario startet, ist er klein.
-	Wenn der kleine Mario vom Gegner getroffen wird, ist er tot und mit ihm kann nicht mehr gespielt werden.
-	Wenn ein kleiner Super Mario einen Pilz findet,  wird er ein Super Mario mit Pilz.
-	Wenn Super Mario mit Pilz einen Pilz findet, bleibt er im Zustand Super Mario mit Pilz.
-	Wenn Super Mario mit Pilz vom Gegner getroffen wird, wird er zum kleinen Mario.


#### Iteration 2
-	Wenn Super Mario eine Feuerblume findet, wächst er.
-	Wenn Super Mario mit Feuerblume vom Gegner getroffen wird, wird er zum Mario mit Pilz.
-	Wenn Super Mario mit Feuerblume einen Pilz findet, behält er seine Feuerblume.


#### Iteration 3
-	Wenn Super Mario startet, soll er 3 Leben haben.
-	Wenn Super Mario stirbt, verliert er ein Leben.
-	Wenn alle Leben aufgebraucht sind, ist Super Mario tot und mit ihm kann nicht mehr gespielt werden.


#### Iteration 4
-	Wenn Super Mario ein Leben findet, erhöhen sich seine verfügbaren Leben.
-	Wenn ein toter Super Mario ein Leben findet, kann wieder mit ihm gespielt werden. Er startet dann mit 1 Leben. (vgl. Readme in der Iteration 4)


#### Iteration 5
-	Wenn Mario einen Joshi findet, dann ändert sich seine Größe nicht.
-	Wenn Mario mit Joshi vom Gegner getroffen wird, dann verliert er seinen Joshi, verändert aber seine Größe nicht.
-	Wenn ein kleiner Mario mit Yoshi einen Pilz oder Blume findet, wächst er, behält aber seinen Yoshi bei.


#### Iteration 6
-	Wenn Mario in ein Loch fällt, verliert er ein Leben und beginnt klein ohne Yoshi wieder.


#### Kontakt
1. [Blog](https://e.co-IT.eu/uli-armbruster/blog)
2. [Twitter](https://e.co-IT.eu/uli-armbruster/twitter)
3. [Xing](https://e.co-IT.eu/uli-armbruster/xing)
4. [LinkedIn](https://e.co-IT.eu/uli-armbruster/xing)
5. [Facebook](https://e.co-IT.eu/uli-armbruster/facebook)
6. [YouTube](https://e.co-IT.eu/uli-armbruster/youtube)
7. [Github](https://e.co-IT.eu/uli-armbruster/github)