var board = new Board(1, 5);
while(!board.HasWinner())
{
    //Each player gets 3 rolls
    for (int i = 0; i < 3; i++)
    {
        var diceRollValue = board.Dice.GetNextRoll();
        board.CurrentPlayer.Move(diceRollValue);
    }
    board.CurrentPlayer.AddToScore(board.CurrentPlayer.BoardPosition);
    board.AdvancePlayer();
}

var winner = board.Pawns.Single(_ => _.CurrentScore >= 1000);
var loser = board.Pawns.FirstOrDefault(_ => _.CurrentScore < 1000);

Console.WriteLine(loser?.CurrentScore * board.Dice.NumberOfRolls);

class Board
{
    public Board(int firstPlayerStartingPosition, int secondPlayerStartingPosition)
    {
        Pawns = new List<Pawn>();
        Dice = new DeterministicDice();
        Pawns.Add(new Pawn(firstPlayerStartingPosition));
        Pawns.Add(new Pawn(secondPlayerStartingPosition));
    }

    private int _currentPlayerIndex = 0;
    public Pawn CurrentPlayer 
    {
        get
        {
            return Pawns[_currentPlayerIndex];
        }
    }
    public void AdvancePlayer()
    {
        _currentPlayerIndex++;
        if(_currentPlayerIndex >= Pawns.Count)
        {
            _currentPlayerIndex = 0;
        }
    }
    public bool HasWinner()
    {
        foreach (var pawn in Pawns)
        {
            if(pawn.CurrentScore >= 1000)
            {
                return true;
            }
        }
        return false;
    }
    public List<Pawn> Pawns { get; set; }
    public DeterministicDice Dice { get; set; }
}

class Pawn
{
    public Pawn(int startingPosition)
    {
        BoardPosition = startingPosition;
    }

    public int BoardPosition { get; set; }
    public int CurrentScore { get; private set; }
    public void AddToScore(int scoreToAdd)
    {
        CurrentScore += scoreToAdd;
    }
    public void Move(int spacesToMove)
    {
        BoardPosition += spacesToMove;
        BoardPosition = BoardPosition % 10;
        if(BoardPosition == 0)
        {
            BoardPosition = 10;
        }
    }
}

class DeterministicDice
{

    private int _rollValue = 0;
    public int NumberOfRolls { get; private set; }
    public int GetNextRoll()
    {
        NumberOfRolls++;
        if(++_rollValue > 100)
        {
            _rollValue = 1;
        }
        return _rollValue;
    }
}