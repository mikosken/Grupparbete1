# Grupparbete1
  
## ASCII-baserat Dungeon-spel i konsolfönster.
  
* Spelare som flyttar runt i en Dungeon för att hitta skatten.
* Spelaren ska undvika eller besegra monster.
* Spelaren har olika föremål, som vapen och health potions.
  
När användaren trycker på WASD så flyttas karaktären runt på kartan.
  
* Interfacet visar vad som kommer ske för action när användaren trycker på respektive WASD.
Ex.  
W - Up, Move  
A - Left, blocked by wall  
S - Down, Attack monster  
D - Right, Pick Up Health Potion  
Ska det vara möjligt att utföra flera olika actions mot en och samma ruta, ex. en ruta som innehåller ett monster?  
  
### Main loop
Uppdatera spelarens status (Flytta runt, healing, attack, etc.)  
Uppdatera status för alla monster (Flytta runt, healing, attack, etc.)  
Uppdatera status för eventuellt andra saker  
Rita ut ny karta  
Visa alternativ  
Ta in input  
*Något mer, vilken ordning?*  
  
### Character - Generisk basklass för alla karaktärer (spelare, fiender, djur, etc.)
* Health?  
* Strength?  
Funktion för Move(Direction), kallar på funktion hos Kartan att uppdatera position av karaktärsobjekt till specifik ruta.  
Kan aktivera funktioner hos objekt i inventory för att utföra andra handlingar än att gå.  
Ska allt som kan röra sig i världen vara av basklass character, eller ska vi implementera Move() som interface?  
  
Förslag: Om kartan är ASCII-baserad så kommer karaktärer behöva representeras av ett tecken, lagra detta tecken i karaktärsobjekt?  
I så fall kan kartan för varje objekt på kartan kunna kalla på property 'Representation' för att få detta tecken.

### Player : Character  
Klass som ärver från Character, kontrollerbar av användaren.

### NonPlayerCharacter : Caracter
Klass som ärver från Character, kontrolleras ej av spelaren.  
Förslag: Kan eventuellt flytta runt lite av sig själv?  
Om springer på spelare så gör skada?  

### Equipment-objekt
Funktion för Use(Target) som aktiverar funktion, eller ska vi implementera Use(Target) i ett interface?  
Förslag: Innehåller ett Verb-property som säger vad det kallas att använda objektet.  
Exempelvis "Attack" eller "Swing" för svärd, "Drink" för Potions, etc.  
Abstrakt metod för Use(target).  
  
Om objekt ska kunna ligga på marken för att plockas upp av spelaren så behöver vi kunna representera även det med ett tecken för objektet.  

### Potion : Equipment
Klass som ärver från Equipment.  
Implementerar Use()  

### Sword : Equipment
Klass som ärver Equipment.  
Implementerar Use()  
  
### Map-objekt
Innehåller ett 2D-array (eller lista?) för hela spelvärlden, där varje element visar vad rutan innehåller.  
*Om vi gör på detta vis kan endast ett objekt/karaktär finnas i en ruta åt gången.*  
object[,] world = object[height,width];  
Ett array av typen 'object' kan innehålla alla objekt oavsett typ eftersom alla objekt ärver från 'object'.  
Ska det kunna finnas 'null'-rutor, eller ska vi implementera exempelvis att det finns Floor-objekt för att hålla
reda på vart spelaren kan gå, och Wall-objekt som säger vart spelaren inte kan gå?  
* Steg 1, handgjord karta.
* Steg 2, eventuellt procedurellt genererad karta.  
Stödmetoder för att göra kartskapande enklare:  
DrawPoint(x, y, object) - Placerar ut ett *object* på position x,y.  
DrawRect(x,y, width, height, borderObject, fillObject) - Placerar ut en rektangel på kartan med väggar av *borderObject* och fylld med *fillObject*.  
  
Förslag: Innehåller två 2D-arrayer för världen, en med endast grundkarta med väggar/golv och en som innehåller alla characters/andra objekt som finns i världen?  
Då vet vi automatisk vad som ska finnas i en ruta om inget annat finns där, ex. när spelaren flyttar på sig eller plockar upp ett item från kartan.  
Behöver metod för att skapa string-representation av den del av världen som vi befinner oss i. *string MapString(x,y,width,height)?*  
  
### Victory/lose condition 
* Game Over-skärm
* Victory-skärm
  
### Referensmaterial
Liknande spel: https://en.wikipedia.org/wiki/Rogue_(video_game)
  
