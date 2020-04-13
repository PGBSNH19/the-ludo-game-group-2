# Documentation

Use this file to fill in your documentation

# USER STORIES
•     As a user I want to be given the option to start a new game or open an existing game.  
When "new game" has been chosen:  
•     As a user I want to amount of players can be chosen.  
•     As a user I want to enter name.  
•     As a user I want to choose pawn color.  
•     As a user I want to choose which of my pawn to move on the gameboard.  
•     As a user I want to "see" where my pawn are located across the board.  
•     As a user I want to roll the exact amount to be able to    go to sqaure 57 (cannot roll more than 57)  
When "open an existing game" has been chosen:  
•     As a user I want to be able to start where we left  
•     As a user I want to be able to get all the information about the game  

# CLASSES (first idea)

# Menu
## Properties
## Methods
Logo()  
MenuNumberOfPlayers()  
MenuGetUserName()  
UserTurn()  
StartGame()  
GetSavedGame()  



# User
## Properties
Name string  
List<Pawn> Pawns / Pawn[] Pawns  
## Methods  
ICreatePlayer(Name,Pawns[4])  
Som en användare ska jag kunna välja en färg, för att kunna ta del av spelet och flytta fram min pawn.  

# Pawn 
## Properties
int Position  
string Color  
int SquareID   
int UserID  

## Methods
Pawn(Position,Color,SquareID)  
?MovePawn(int moves)  
 
En pawn ska kunna flytta sig fram på brädet för att kunna ta sig vidare i spelet.   

# Dice
## Properties
int Roll (1, 2, 3, 4, 5, 6)  
## Methods
Math.randomINT(1-6)  

# MOVE
## Properties
int Moves  
int PawnID  
## Methods
?MovePawn(int moves)  

# SQUARE

## Properties
int SquareID  
int BoardID  
int PawnID   
## Methods
Om det står två stycken Pawns på samma SquareID så ska en Pawn knuffas bort på den ruta som de delar och flyttas tillbaka till sin startposition.  

# GameBoard
## Properties
int TotalSquares (57?)  
## Methods

# Game
## Properties
Name  
User[]  
pawn-color   
ID  
Board  

# UserTurn : IUserTurn
## Properties
## Methods
Turn=PlayerRoleDice(Muränan).PlayerMovePawn(PawnRed,intStepToMove)  
Turn=PlayerRoleDice(Fredrika_Awsome).PlayerMovePawn(PawnRed,intStepToMove)  

# MOCKUP
PlayerRoleDice(User Muränan){  

Roll Dice with Math.Random  
Return this;  
}  

PlayerMovePawn(PawnRed[1])  
{  
Vi får ett intresultat av RoleDice (antal steg pawn ska flyttas fram), ex 4.  
Move pawn forwards on the board. (If pawn is currently in SquareID 4 move to 8)  
}  

# SCENARIOS
## PUSH 
Turn=PlayerRoleDice(Fredrika_Awsome).PlayerMovePawn(PawnRed,intStepToMove).PlayerPushPawnInSquare(currentPawn)  
## BETWEEN SQUARE 51-56
Turn=PlayerRoleDice(Fredrika_Awsome).PlayerMovePawn(PawnRed,intStepToMove)  
## PAWN.POSITION > 57
If(User.PawnPosition>= 51&& User.PawnPosition < 57)  
Movetowards center  
TotalSquares- PawnPosition  
 
## LAST PAWN.POSITION > 57
else if(User.PawnPosition.Last>= 57)  
ConsoleWriteLine(Congrats you won)  
Break game;  


# DAGBOK
## 2020-03-30- Måndag [@Group]
Vi har fått uppgiften introducerad för oss. Och skissar upp följande:  

Klasser  
Properties  
Metoder  
Scenarios  

### 2020-03-30- Måndag [@Adgnascor]
Added basic functionality in following classes User,Pawn,Menu,Dice  

### Class User:
Private Constructor that sets Name and gets Pawn.GetSetOfPawn(). Which gets called by method GetPlayersAndName(int numberOfPlayers).   
This Method ask every user of their name and create users for each player and returns a List of players  

### Class Pawn:
Constructor: Pawn(), ShowPawnColorMenu(), SetColorOnPawn(userChoice), GetSetOfPawn()  

ShowPawnColorMenu shows the color to choose between.  
SetColorOnPawn returns the color choice in form of a string.  
GetSetOfPawns uses above methods to create 4 pawns with chosen color and return this as a List of Pawns that User gets when we create every player.  

### Class Menu:
HowManyPlayers() returns an int of how many players. This means that when we call for User.GetPlayersAndName(menu.HowManyPlayers()) we get an end result of all players with their name and choosen pawn color.  



### Class Dice:
Has Constructor with default Roll value.  

And a method for RollDice() wich returns a random int between 1 and 6.  

## 2020-03-31- Tisdag [@Group]
### Current state of the game:
amount of players can be chosen  
player can enter name and choose pawn color  
a player has one pawn  
we have a list of 57 squares - the game board  
a pawn starts on square 1  
a pawn can go from square 1 to 57 by a dice being rolled - random method used  
a pawn needs to roll the exact amount to be able to go to sqaure 57 (cannot roll more than 57)  

## 2020-04-03- Fredag[@Group]
### State of the game: 
after refactoring we kind of broke the game but got it working the same day
players can have four pawns
players can get into goal in the correct amount of steps
right information is displayed in the console (text based no ascii)

## 2020-04-05- Söndag [@Adgnascor]
### Changes I made:
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

# HUR VI LAGT UPP VIDEOPRESENTATIONEN -
## A walkthrough of the thoughts behind the solution (Diagrams is a good thing)
Irvin Inledande tankar, hur funderade vi inför uppiften, planering osv? Hur tänker vi om den nu när den är klar? Hur vi arbetat utifrån userstories exempelvis
## A demo of the application running, it could be a video or screenshots 
Irvin Köra programmet, visa upp hur det fungerar. Inleda med detta? 
## Important parts of the code Parts of the code you are proud of Cool patterns / frameworks that you have used 
Har vi gjort några extra bra lösningar som vi är stolta över? Har vi gjort något utöver uppgiftsbeskrivningen? Använt andra verktyg etc

#### Fredrika Tester.
#### Fredrika GameMotor-klassen.
 
#### William 
Hur vi sparar spelet och öppnar det sparade spelet.
#### FREDRIKA GameInitializer-klassen

#### Murre Databasen
Två tabeller. Tankar kring det. Skulle vi ha haft en Game-tabell också? 
#### Murre RunGUI-klassen. 
#### Fredrika 
Especially useful codereview comments , hur såg vi på kommentarerna? var de konstruktiva? Hur jobbade vi utifrån dem?  
#### Murre 
A description of your process Which tools did you use and for what? How did the team communicate? Did you part up your work in the team? And how? 
Kommunikation, arbetade vi ihop, på eget håll. Funkade det bra etc
#### Lessons learnt during the process 
#### Irvin 
Hade vi planerat ordentligt? Behövde vi göra om? Arbetsfördelning etc
#### William What would you had done differently? 
Saker vi kunde lagt till etc, om vi haft mer tid. Vad hade vi kunnat göra annorlunda? 
Namngivning och sååååå.
Tittat mer på spelet i början, utgått mer från det. Få fram en spelare, alla steg i en spelomgång. 
Separera klasser etc mer från början.
