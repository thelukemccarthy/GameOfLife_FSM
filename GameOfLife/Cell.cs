namespace GameOfLife
{
    public class Cell
    {
        public CellStates CellState { get; set; }

        public Cell()
        {
            CellState = CellStates.Dead;
        }
    }
}
