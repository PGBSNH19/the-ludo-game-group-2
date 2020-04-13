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
## Methods
### HowManyPlayers()
### DisplayMessageReturnUserInput()
### DisplayMessageReturn()

# User
## Properties
public int UserID { get; set; }
public int PlayerID { get; set; }
public string Name { get; set; }
public string GameName { get; set; }
public List<Pawn> Pawns;
user()
public User(string name, int PlayerID, List<Pawn> Pawns, string GameName)
       
## Methods
PawnByID(int id)

# Pawn 
## Properties
public int PawnID { get; set; }
public int PawnNumber { get; set; }
public int Position { get; set; }
public string Color { get; set; }
public bool HasStarted { get; set; }
public int Count { get; set; }
public bool HasReachedGoal { get; set; }
public User User { get; set; }
public int UserID { get; set; }

Pawn(int PawnNumber, int Position, string Color)

# Die
## Properties
private int Roll
Die()

# SQUARE

## Properties
public int SquareID { get; set; }
public int GameBoardID { get; set; }
public int SquareNumber { get; set; }
public bool IsEmpty { get; set; }
Square(int number)

# GameBoard
## Properties
private List<Square> squares;
public List<Square> Squares { get => squares; set => squares = value; }
Public GameBoard()

## Methods
PopulateBoard()

# RUNGUI
int NumberOfPlayers()
string GetAndReturnName()
ShowPawnColorMenu()
ShowWhichPlayer(User user)
ShowDie(int rollResult)
int TimeToChoosePawn(User user)
WalkWithPawn(Pawn pawn,int dieResult)

# GAMEINITIALIZER
## Properties 
List<user> Users
Die Die
GameBoard GameBoard
GameInitializer()
 
 ## Methods
 AddUserToPlayerList(User user)
 User PlayerByID(int playerID)
 List<Pawn> CreateListOfPawns(string color)
 string TranslateChoiceToColor(string userChoice)
 SetStartPosition(Pawn pawn)
 IfNotStartedSetStartPosition(Pawn pawn)
 List<Square> PopulateBoard()
 
 # GAMEMOTOR
 
 ## Methods
 bool CheckIfReachedGoal(User user, Pawn pawn, bool gameHasEnd)
 List<Pawn> CountActivePawns(User user)
 RollDie(Die die)
 int Move(Pawn pawn, int dieRoll)
 OccupySquare(GameBoard gameBoard, int endSquare)

## XUNIT-TEST
[Theory]
TestDieCantRollMoreThanSixAndLessThanOne(int randomNext)

[Theory]
TestColorExpectedStartPosition(string color, int expectedPositionOnBoard)

[Theory]
TestWhichPlayerRound(int playerID)

[Theory]
TestCreateListOfPawns(string color)

[Fact]
TestGameBoardTotalSquaresIsCorrect56()

[Fact]
TestIfPawnHaStartedIsFalseAndSetValueToTrue()

[Theory]
TestHowManyActivePawnsLeft(int amount)

[Fact]
TestIfPawnCanOccupySquarePosition()


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

### Fredrika Tester.
### Fredrika GameMotor-klassen.
 
### William Hur vi sparar spelet och öppnar det sparade spelet.
### FREDRIKA GameInitializer-klassen

### Murre Databasen, två tabeller. Tankar kring det. Skulle vi ha haft en Game-tabell också? 
### Murre RunGUI-klassen. 
### Fredrika Especially useful codereview comments , hur såg vi på kommentarerna? var de konstruktiva? Hur jobbade vi utifrån dem?  
### Murre A description of your process Which tools did you use and for what? How did the team communicate? Did you part up your work in the team? And how? 
Kommunikation, arbetade vi ihop, på eget håll. Funkade det bra etc
### Lessons learnt during the process 
### Irvin Hade vi planerat ordentligt? Behövde vi göra om? Arbetsfördelning etc
### William What would you had done differently? 
Saker vi kunde lagt till etc, om vi haft mer tid. Vad hade vi kunnat göra annorlunda? 
Namngivning och sååååå.
Tittat mer på spelet i början, utgått mer från det. Få fram en spelare, alla steg i en spelomgång. 
Separera klasser etc mer från början.





