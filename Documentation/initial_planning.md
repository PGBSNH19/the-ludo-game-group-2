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


