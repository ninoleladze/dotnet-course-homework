namespace GameOfLife;

public sealed class GameOfLifeSequentialVersion
{
    private readonly bool[,] initialGrid;
    private bool[,] currentGrid;

    public GameOfLifeSequentialVersion(int rows, int columns)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(rows, 0);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(columns, 0);
        var rng = new Random();
        this.initialGrid = new bool[rows, columns];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                this.initialGrid[r, c] = rng.Next(2) == 1;
            }
        }

        this.currentGrid = (bool[,])this.initialGrid.Clone();
    }

    public GameOfLifeSequentialVersion(bool[,] grid)
    {
        ArgumentNullException.ThrowIfNull(grid);
        this.initialGrid = (bool[,])grid.Clone();
        this.currentGrid = (bool[,])grid.Clone();
    }

    public int Generation { get; private set; }

    public bool[,] CurrentGeneration => this.GetCurrentGeneration();

    public void Restart()
    {
        this.currentGrid = (bool[,])this.initialGrid.Clone();
        this.Generation = 0;
    }

    public void NextGeneration()
    {
        int rows = this.currentGrid.GetLength(0);
        int cols = this.currentGrid.GetLength(1);
        var next = new bool[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                int neighbors = this.CountAliveNeighbors(r, c);
                next[r, c] = this.currentGrid[r, c]
                    ? neighbors == 2 || neighbors == 3
                    : neighbors == 3;
            }
        }

        this.currentGrid = next;
        this.Generation++;
    }

    internal bool[,] GetCurrentGeneration() => (bool[,])this.currentGrid.Clone();

    private int CountAliveNeighbors(int row, int column)
    {
        int rows = this.currentGrid.GetLength(0);
        int cols = this.currentGrid.GetLength(1);
        int count = 0;
        for (int dr = -1; dr <= 1; dr++)
        {
            for (int dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0)
                {
                    continue;
                }

                int nr = row + dr, nc = column + dc;
                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && this.currentGrid[nr, nc])
                {
                    count++;
                }
            }
        }

        return count;
    }
}
