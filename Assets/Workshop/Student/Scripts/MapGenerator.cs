using System;
using UnityEngine;

namespace Workshop.Student
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };

        // 1. declare Players variable
        public GameObject[] playerPrefabs;


        // 7. declare Exit variable 


        public void Start()
        {
            // 1. random player at the position <0, 0> map
            int playerPrefabIndex = UnityEngine.Random.Range(0, playerPrefabs.Length);
            Instantiate(playerPrefabs[playerPrefabIndex],
                new Vector2(5, 5),
                Quaternion.identity
                );

            // 2. create obstacles
            for (int posX = 0; posX < 5; posX++)
            {
                Instantiate(wallTiles[0],
                new Vector2(posX, 2),
                Quaternion.identity
                );
            }

            // 3. create floor
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Instantiate(floorTiles[0],
                    new Vector2(col, row),
                    Quaternion.identity
                    );
                }
            }

            // 4. create walls
            for (int row = -1; row < rows+1; row++)
            {
                for (int col = -1; col < columns + 1; col++)
                {
                    if (col == -1 || col == columns || row == -1 || row == rows)
                    {
                        Instantiate(wallTiles[0],
                        new Vector2(col, row),
                        Quaternion.identity
                        );
                    }
                    
                }
            }

            // 5. random foods
            int numberOfFoods = UnityEngine.Random.Range(1, 5);
            for (int i = 0; i < numberOfFoods; i++)
            {
                int x = UnityEngine.Random.Range(0, columns);
                int y = UnityEngine.Random.Range(0, rows);
                Instantiate(foodTiles[0], new Vector2(x, y), Quaternion.identity);
            }

            // 6. generate item along with the saveItemMap
            for (int y = 0; y < saveItemMap.GetLength(0); y++)
            {
                for (int x = 0; x < saveItemMap.GetLength(1); x++)
                {
                    string item = saveItemMap[x, y];
                    if (item != " ")
                    {
                        for (int i = 0; i < foodTiles.Length; i++)
                        {
                            foodTiles[i].name = item;
                            {
                                Instantiate(foodTiles[i], 
                                   new Vector2(x, y), 
                                   Quaternion.identity
                                );
                            }
                        }
                    }
                }
            }

            // 7. place exit


        }
    }

}