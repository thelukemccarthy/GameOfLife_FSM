namespace GameOfLife
{
    public interface ICellStateMachine
    {
        CellStates GetNextState(CellStates currentCellState, int numberOfAliveNeighbours);
    }
}