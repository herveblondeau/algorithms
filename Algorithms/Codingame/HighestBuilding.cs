// https://www.codingame.com/training/hard/the-highest-building

using System.Collections.Generic;
using System.Linq;

namespace Codingame.HighestBuilding
{
    public class HighestBuilding
    {

        public List<Building> GetHighestBuildings(string[] picture)
        {
            List<Building> highestBuildings = new List<Building>();
            int i = 0;
            int highestHeight = 0;

            // Starting from the left, we move on the ground floor towards the right
            // Everytime we find a building block, we build the corresponding building (this is done by GetBuilding())
            // We build the list of highest buildings as we go
            while (i < picture[0].Length)
            {
                Building building = GetBuilding(picture, i);
                // No building here, just move one spot to the right
                if (building == null)
                {
                    i++;
                }
                // Building found
                else
                {
                    // New highest building -> remove all previously found highest buildings and save the new one
                    if (building.Height > highestHeight)
                    {
                        highestBuildings.Clear();
                        highestBuildings.Add(building);
                        highestHeight = building.Height;
                    }
                    // 
                    else if (building.Height == highestHeight)
                    {
                        highestBuildings.Add(building);
                    }

                    // Move right by the width of the building
                    i += building.Width;
                }
            }

            return highestBuildings;
        }

        // This method starts from the ground floor at a given position, then builds the whole building
        private Building GetBuilding(string[] picture, int column)
        {
            List<int> heights = new List<int>();
            int width = 0;
            int height = 0;
            int row = 0;

            // Move up then right to compute each column of the building
            while (column < picture[0].Length && picture[row][column] == '#')
            {
                width++;

                while (row < picture.Length && picture[row][column] == '#')
                {
                    height++;
                    row++;
                }
                heights.Add(height);
                height = 0;

                row = 0;
                column++;
            }

            if (heights.Count == 0)
            {
                return null;
            }

            return new Building(heights);
        }

        public class Building
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int[] Heights { get; set; }

            public Building(List<int> heights)
            {
                Heights = heights.ToArray();
                Width = heights.Count;
                Height = Heights.Max();
            }
        }
    }
}
