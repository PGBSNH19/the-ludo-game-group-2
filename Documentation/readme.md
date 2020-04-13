# Documentation

Use this file to fill in your documentation

# USER STORIES
•     As a user I want to be given the option to start a new game or open an existing game. \
When "new game" has been chosen: \
•     As a user I want to amount of players can be chosen. \
•     As a user I want to enter name. \
•     As a user I want to choose pawn color. \
•     As a user I want to choose which of my pawn to move on the gameboard. \
•     As a user I want to "see" where my pawn are located across the board. \
•     As a user I want to roll the exact amount to be able to    go to sqaure 57 (cannot roll more than 57) \
When "open an existing game" has been chosen: \
•     As a user I want to be able to start where we left \
•     As a user I want to be able to get all the information about the game 

# CLASSES

## Menu
This class is made to handle recurring messages and GUI specific tasks
#### Methods
HowManyPlayers()  
DisplayMessageReturnUserInput()  
DisplayMessageReturn() 

## User
This class decides what a player/user is made of.
#### Properties
public int UserID { get; set; }
public int PlayerID { get; set; }
public string Name { get; set; }
public string GameName { get; set; }
public List<Pawn> Pawns;
user()
public User(string name, int PlayerID, List<Pawn> Pawns, string GameName)
       
#### Methods
PawnByID(int id)

## Pawn 
This class has all the information needed to know which player it belongs to, position on the board etc.
#### Properties
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

## Die
Simple class for rolling a die
#### Properties
private int Roll
Die()

## SQUARE
This is the class that is used to complete the class gameboard below which uses a list of squares
#### Properties
public int SquareID { get; set; }
public int GameBoardID { get; set; }
public int SquareNumber { get; set; }
public bool IsEmpty { get; set; }
Square(int number)

## GameBoard
#### Properties
private List<Square> squares;
public List<Square> Squares { get => squares; set => squares = value; }
Public GameBoard()

#### Methods
PopulateBoard()

## RUNGUI
This is our second class that is GUI specific which we connects to the logic library to gather information and also output data
#### Methods
int NumberOfPlayers()
string GetAndReturnName()
ShowPawnColorMenu()
ShowWhichPlayer(User user)
ShowDie(int rollResult)
int TimeToChoosePawn(User user)
WalkWithPawn(Pawn pawn,int dieResult)

## GAMEINITIALIZER
This class is  used to set up everything that is needed to be able to play the game.
#### Properties 
List<user> Users
Die Die
GameBoard GameBoard
GameInitializer()
 
 #### Methods
 AddUserToPlayerList(User user)
 User PlayerByID(int playerID)
 List<Pawn> CreateListOfPawns(string color)
 string TranslateChoiceToColor(string userChoice)
 SetStartPosition(Pawn pawn)
 IfNotStartedSetStartPosition(Pawn pawn)
 List<Square> PopulateBoard()
 
 ## GAMEMOTOR
 Gamemotor handles the logic in game, as moving a pawn, check if someone reached goal etc.
 #### Methods
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









