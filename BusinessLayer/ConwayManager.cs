using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ConwayManager
    {
        public Grid GetNextSimulation(Grid inputGrid) {

            var size = inputGrid.Rows.Count;
            var newGrid = new Grid();
            newGrid.Rows = new List<Row>();
            for (var i = 0; i < size; i++)
            {
                var x = i;
                var newRow = new Row();
                newRow.Cells = new List<Cell>();
                for (var j = 0; j < size; j++)
                {
                    var y = j;

                    var curentCellAlive = inputGrid.Rows[x].Cells[y].isAlive;

                    int numberOfAliveNeighbors = isNeighbourAlive(inputGrid, size, x, y, -1, 0)
                        + isNeighbourAlive(inputGrid, size, x, y, -1, 1)
                        + isNeighbourAlive(inputGrid, size, x, y, 0, 1)
                        + isNeighbourAlive(inputGrid, size, x, y, 1, 1)
                        + isNeighbourAlive(inputGrid, size, x, y, 1, 0)
                        + isNeighbourAlive(inputGrid, size, x, y, 1, -1)
                        + isNeighbourAlive(inputGrid, size, x, y, 0, -1)
                        + isNeighbourAlive(inputGrid, size, x, y, -1, -1);

                    bool shouldLive = false;

                    if (curentCellAlive && (numberOfAliveNeighbors == 2 || numberOfAliveNeighbors == 3))
                        shouldLive = true;

                    if (!curentCellAlive && (numberOfAliveNeighbors == 3))
                        shouldLive = true;

                    var newCell = new Cell { isAlive = shouldLive };
                    newRow.Cells.Add(newCell);
                }
                newGrid.Rows.Add(newRow);
            }
            return newGrid;

        }
        private int isNeighbourAlive(Grid gridObj, int size, int x, int y, int xOffset, int yOffset)
        {
            int result = 0;

            int proposedOffsetX = x + xOffset;
            int proposedOffsetY = y + yOffset;
            var outOfBonds = proposedOffsetX < 0 || proposedOffsetX >= size | proposedOffsetY < 0 || proposedOffsetY >= size;
            if (!outOfBonds)
            {
                result = gridObj.Rows[x + xOffset].Cells[y + yOffset].isAlive ? 1 : 0;
            }
            return result;
        }
    }
}
