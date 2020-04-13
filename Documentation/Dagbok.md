# DAGBOK
## 2020-03-30- Måndag [@Group]
Vi har fått uppgiften introducerad för oss. Och skissar upp följande:

Klasser
Properties
Metoder
Scenarios


## 2020-03-30- Måndag [@Adgnascor]

Added basic functionality in following classes User,Pawn,Menu,Dice

Class User:
Private Constructor that sets Name and gets Pawn.GetSetOfPawn(). Which gets called by method GetPlayersAndName(int numberOfPlayers). 
This Method ask every user of their name and create users for each player and returns a List of players

Class Pawn:
Constructor: Pawn(), ShowPawnColorMenu(), SetColorOnPawn(userChoice), GetSetOfPawn()

ShowPawnColorMenu shows the color to choose between.
SetColorOnPawn returns the color choice in form of a string.
GetSetOfPawns uses above methods to create 4 pawns with chosen color and return this as a List of Pawns that User gets when we create every player.

Class Menu:
HowManyPlayers() returns an int of how many players. This means that when we call for User.GetPlayersAndName(menu.HowManyPlayers()) we get an end result of all players with their name and choosen pawn color.



Class Dice:
Has Constructor with default Roll value.

And a method for RollDice() wich returns a random int between 1 and 6.

## 2020-03-31- Tisdag [@Group]
Current state of the game:
amount of players can be chosen
player can enter name and choose pawn color
a player has one pawn
we have a list of 57 squares - the game board
a pawn starts on square 1
a pawn can go from square 1 to 57 by a dice being rolled - random method used
a pawn needs to roll the exact amount to be able to go to sqaure 57 (cannot roll more than 57)



## 2020-04-03- Fredag[@Group]
State of the game: 
after refactoring we kind of broke the game but got it working the same day
players can have four pawns
players can get into goal in the correct amount of steps
right information is displayed in the console (text based no ascii)

## 2020-04-05- Söndag [@Adgnascor]
Changes I made:
PawnMove and its methods is no longer static
When a player gets to choose what pawn to move, we only shows the pawns that is left
And some minor changes as naming etc.
Started with pulling out the GUI stuff from GameEngine.Library and creating the basic GUI in ConsoleGUI instead

Pushed it to Branch: William_NoFluent
## 2020-04-06- Måndag[@Group]
KAOS UPPSTOD efter code review och vi började refaktorera

## 2020-04-07- Tisdag[@Group]
Vi har lagt till databas
Vi kan spara game
Vi kan ladda game genom att välja vilket game name man har på den spelomgången
Refaktorerat klart och fått åter bra struktur på vår kod.


## 2020-04-09 - Torsdag[@Group]

Vi har lagt till tester, snyggat till program.cs ännu mer. 
Förbereder inför presentationen.

