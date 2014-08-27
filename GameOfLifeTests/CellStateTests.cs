using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    [TestFixture]
    public class CellStateTests
    {
        private readonly CellStateMachine _cellStateMachine;

        public CellStateTests()
        {
            _cellStateMachine = new CellStateMachine();
        }

        [Test]
        public void GivenACellWithZeroAliveNeighboursAndACurrentStateOfAliveThenTheCellStateShouldBeDead()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Alive, 0);

            Assert.AreEqual(CellStates.Dead, actualCellStates);
        }

        [Test]
        public void GivenACellWithOneAliveNeighboursAndACurrentStateOfAliveThenTheCellStateShouldBeDead()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Alive, 1);

            Assert.AreEqual(CellStates.Dead, actualCellStates);
        }

        [Test]
        public void GivenACellWithTwoAliveNeighboursAndACurrentStateOfAliveThenTheCellStateShouldBeAlive()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Alive, 2);

            Assert.AreEqual(CellStates.Alive, actualCellStates);
        }

        [Test]
        public void GivenACellWithThreeAliveNeighboursAndACurrentStateOfAliveThenTheCellStateShouldBeAlive()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Alive, 3);

            Assert.AreEqual(CellStates.Alive, actualCellStates);
        }

        [Test]
        public void GivenACellWithFourAliveNeighboursAndACurrentStateOfAliveThenTheCellStateShouldBeDead()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Alive, 4);

            Assert.AreEqual(CellStates.Dead, actualCellStates);
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void GivenACellWithMoreThanThreeAliveNeighboursAndACurrentStateOfAliveThenTheCellStateShouldBeDead(int numberOfAliveNeighbours)
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Dead, numberOfAliveNeighbours);

            Assert.AreEqual(CellStates.Dead, actualCellStates);
        }

        // given a dead start state    
        [Test]
        public void GivenACellWithZeroAliveNeighboursAndACurrentStateOfDeadThenTheCellStateShouldBeDead()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Dead, 0);

            Assert.AreEqual(CellStates.Dead, actualCellStates);
        }

        [Test]
        public void GivenACellWithOneAliveNeighboursAndACurrentStateOfDeadThenTheCellStateShouldBeDead()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Dead, 1);

            Assert.AreEqual(CellStates.Dead, actualCellStates);
        }

        [Test]
        public void GivenACellWithTwoAliveNeighboursAndACurrentStateOfDeadThenTheCellStateShouldBeDead()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Dead, 2);

            Assert.AreEqual(CellStates.Dead, actualCellStates);
        }

        [Test]
        public void GivenACellWithThreeAliveNeighboursAndACurrentStateOfDeadThenTheCellStateShouldBeAlive()
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Dead, 3);

            Assert.AreEqual(CellStates.Alive, actualCellStates);
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void GivenACellWithMoreThanThreeAliveNeighboursAndACurrentStateOfDeadThenTheCellStateShouldBeDead(int numberOfAliveNeighbours)
        {
            var actualCellStates = _cellStateMachine.GetNextState(CellStates.Dead, numberOfAliveNeighbours);

            Assert.AreEqual(CellStates.Dead, actualCellStates);
        }
    }
}
