# Grupparbete1
  
#ASCII-baserat Dungeon-spel i konsolfönster.
  
*Spelare som flyttar runt i en Dungeon för att hitta skatten.
*Spelaren ska undvika eller besegra monster.
*Spelaren har olika föremål som vapen och health potions.
  
När användaren trycker på WASD så flyttas karaktären runt på kartan.
  
*Interfacet visar vad som kommer ske för action när användaren trycker på respektive WASD.
Ex.
W - Move Up
A - Wall, blocked
S - Attack monster downwards
D - Pick Up Health Potion
  
*Karaktärsobjekt har funktion för Move(Direction), kallar på funktion hos Kartan att flytta karaktärsobjekt till specifik ruta.
*Equipmentobjekt har funktion för Use() som aktiverar funktion.
  
#Main loop
Ritar ut karta, visar alternativ och tar in input.


  
*Game Over-skärm
*Victory-skärm
