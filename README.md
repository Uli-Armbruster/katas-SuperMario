Katas - Super Mario
==================

Hier zeige ich meinen [SOLID](https://de.wikipedia.org/wiki/Prinzipien_objektorientierten_Designs) Ansatz in C# anhand einer von mir erfundenen Kata für den sagenumwobenen Super Mario.
Besonderen Fokus habe ich auf die Prinzipien der objektorientierten Programmierung gelegt. Viele Entwurfsmuster finden darin Anwendung.
Ebenso geht es um grundsätzliche Entwicklungsansätze wie API First Design und Divide-and-Conquer.

==================
## Branch: RefactoringTechniken
Dieser Branch orientiert sich lose am Master-Branch und hat den Zweck Refactoring Techniken einzuüben. Dazu wuren Anforderungen gegenüber der originären Kata geändert und der Code anders aufgebaut.

==================


### Iterationen

#### Iteration 1
-	Wenn Super Mario startet, ist er klein.
-	Wenn der kleine Mario vom Gegner getroffen wird, ist er tot und mit ihm kann nicht mehr gespielt werden
    - Bedeutet: Aktionen haben keine Auswirkung wie z.B. auf einem physischen Controller
-	Wenn ein kleiner Super Mario einen Pilz findet,  wird er ein Super Mario mit Pilz.
-	Wenn Super Mario mit Pilz einen Pilz findet, bleibt er im Zustand Super Mario mit Pilz.
-	Wenn Super Mario mit Pilz vom Gegner getroffen wird, wird er zum kleinen Mario.
-	Wenn Super Mario eine Feuerblume findet, wächst er.
-	Wenn Super Mario mit Feuerblume vom Gegner getroffen wird, wird er zum Mario mit Pilz.
-	Wenn Super Mario mit Feuerblume einen Pilz findet, behält er seine Feuerblume.


#### Iteration 2
-	Wenn Super Mario startet, soll er 3 Leben haben.
-	Wenn Super Mario stirbt, verliert er ein Leben.
-	Wenn alle Leben aufgebraucht sind, ist Super Mario tot und mit ihm kann nicht mehr gespielt werden.


#### Iteration 3
-	Wenn Super Mario ein Leben findet, erhöhen sich seine verfügbaren Leben.
-	Wenn ein toter Super Mario ein Leben findet, kann wieder mit ihm gespielt werden.


#### Iteration 4:
-	Wenn Mario einen Joshi findet, dann ändert sich seine Größe nicht.
-	Wenn Mario mit Joshi vom Gegner getroffen wird, dann verliert er seinen Joshi, verändert aber seine Größe nicht.
-	Wenn ein kleiner Mario mit Yoshi einen Pilz oder Blume findet, wächst er, behält aber seinen Yoshi bei.


#### Iteration 5:
-	Wenn Mario in ein Loch fällt, verliert er ein Leben und beginnt klein ohne Yoshi wieder.



#### Kontakt
1. [Blog](https://e.co-IT.eu/uli-armbruster/blog)
2. [Twitter](https://e.co-IT.eu/uli-armbruster/twitter)
3. [Xing](https://e.co-IT.eu/uli-armbruster/xing)
4. [LinkedIn](https://e.co-IT.eu/uli-armbruster/xing)
5. [Facebook](https://e.co-IT.eu/uli-armbruster/facebook)
6. [YouTube](https://e.co-IT.eu/uli-armbruster/youtube)
7. [Github](https://e.co-IT.eu/uli-armbruster/github)