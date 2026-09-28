namespace GameOfLife;

public static class GameOfLifeExtension
{
    public static void Simulate(this GameOfLifeSequentialVersion? game, int generations, TextWriter? writer, char aliveCell, char deadCell)
    {
        ArgumentNullException.ThrowIfNull(game);
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentOutOfRangeException.ThrowIfNegative(generations);

        for (int g = 1; g <= generations; g++)
        {
            game.NextGeneration();
            writer.WriteLine($"Generation {game.Generation}:");
            WriteGrid(writer, game.GetCurrentGeneration(), aliveCell, deadCell);
        }
    }

    public static Task SimulateAsync(this GameOfLifeParallelVersion? game, int generations, TextWriter? writer, char aliveCell, char deadCell)
    {
        ArgumentNullException.ThrowIfNull(game);
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentOutOfRangeException.ThrowIfNegative(generations);

        return SimulateAsyncCore(game, generations, writer, aliveCell, deadCell);
    }

    private static async Task SimulateAsyncCore(GameOfLifeParallelVersion game, int generations, TextWriter writer, char aliveCell, char deadCell)
    {
        for (int g = 1; g <= generations; g++)
        {
            game.NextGeneration();
            await writer.WriteLineAsync($"Generation {game.Generation}:");
            var grid = game.GetCurrentGeneration();
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    await writer.WriteAsync(grid[r, c] ? aliveCell : deadCell);
                }

                await writer.WriteLineAsync();
            }
        }
    }

    private static void WriteGrid(TextWriter writer, bool[,] grid, char aliveCell, char deadCell)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                writer.Write(grid[r, c] ? aliveCell : deadCell);
            }

            writer.WriteLine();
        }
    }
}
