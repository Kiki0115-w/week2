using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            //string name = "";
            string[] ironManSuit = new string[2];
            ironManSuit[0] = "Mark I";
            ironManSuit[1] = "Mark II";

            string tonyStarkWear = ironManSuit[0];

            Debug.Log($"TonyStark Wear: {tonyStarkWear}");
            Debug.Log($"Room size: {ironManSuit.Length}");

            Debug.Log(ironManSuit[0]);
            Debug.Log(ironManSuit[1]);

        }

        public void LCT02_ArrayInitialize()
        {
            string[] spiderMan = {
                "Classic SpiderMan",
                "Black Suit",
                "Iron Spider Suit"
            };
            int sizeOfRoomSpiderMan = spiderMan.Length;
            Debug.Log($"Room size: {sizeOfRoomSpiderMan}");
            Debug.Log(spiderMan[0]);
            Debug.Log(spiderMan[1]);
            Debug.Log(spiderMan[2]);

            string[] batman = new string[2] {
                "Classic BatMan",
                "White bat"
            };
            int sizeOfRoomBatman = batman.Length;
            Debug.Log($"Room size: {sizeOfRoomBatman}");
            Debug.Log(batman[0]);
            Debug.Log(batman[1]);

        }

        public void LCT03_SyntaxLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("<10 : " + i);
            }
            Debug.Log("===");
            for (int i = 1; i <= 10; i++)
            {
                Debug.Log("<=10 : " + i);
            }

        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            for (int i = 0; i < ironManSuitNames.Length; i++)
            {
                Debug.Log(ironManSuitNames[i]);
            }
            Debug.Log("===");
            for (int i = 0; i < ironManSuitNames.Length; i+=2)
            {
                Debug.Log(ironManSuitNames[i]);
            }
        }

        public void LCT05_Syntax2DArray()
        {
            int[,] my2DArray;

            my2DArray = new int[2, 2] {
                { 1, 2 },
                { 3, 4 }
            };
            Debug.Log($"my2DArray[0, 0] = {my2DArray[0, 0]}");
            Debug.Log($"my2DArray[0, 1] = {my2DArray[0, 1]}");
            Debug.Log($"my2DArray[1, 0] = {my2DArray[1, 0]}");
            Debug.Log($"my2DArray[1, 1] = {my2DArray[1, 1]}");

            my2DArray[0, 1] = 6;
            my2DArray[1, 1] = 8;

            Debug.Log("After change value");
            Debug.Log($"my2DArray[0, 1] = {my2DArray[0, 1]}");
            Debug.Log($"my2DArray[1, 1] = {my2DArray[1, 1]}");
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            int row = my2DArray.GetLength(0);
            int column = my2DArray.GetLength(1);
            Debug.Log($"rows = {row}");
            Debug.Log($"cols = {column}");
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            //throw new System.NotImplementedException();

            if (columns <= 0 || rows <= 0)
            {
                Debug.Log("Invalid columns or rows");
                return;
            }

            for (int r = 0; r < rows; r++)
            {
                string rowOutput = "";

                for (int c = 0; c < columns; c++)
                {
                    rowOutput += "*";
                }

                Debug.Log(rowOutput);
            }
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            //throw new System.NotImplementedException();
            if (items == null || items.Length == 0)
            {
                Debug.Log("No items to drop.");
                return;
            }

            int randomIndex = Random.Range(0, items.Length);
            GameObject selectedItem = items[randomIndex];
            Instantiate(selectedItem, transform.position, Quaternion.identity);
            Debug.Log("Got item: " + selectedItem.name);
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            //throw new System.NotImplementedException();
            if (floorTiles == null || floorTiles.Length == 0)
            {
                Debug.Log("No floor tiles to create map.");
                return;
            }
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int randomIndex = Random.Range(0, floorTiles.Length);
                    GameObject selectedTile = floorTiles[randomIndex];
                    GameObject tileInstance = Instantiate(selectedTile, new Vector2(x, y), Quaternion.identity);

                    tileInstance.name = $"[{x}:{y}]";
                    Debug.Log(tileInstance.name);
                }
            }
        }
        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            //throw new System.NotImplementedException();
            if (wall == null || columns <= 0 || rows <= 0)
            {
                return;
            }
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                    {
                        GameObject wallInstance = Instantiate(wall, new Vector2(x, y), transform.rotation);
                        wallInstance.name = $"[{x}:{y}]";
                    }
                }
            }
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            //throw new System.NotImplementedException();
            if (enemyHP == null || enemyHP.Length == 0) return;

            int n = enemyHP.Length;

            enemyHP[0] -= damage;
            if (enemyHP[0] < 0) enemyHP[0] = 0;
            Debug.Log($"FirstEnemy hp :{enemyHP[0]}");

            enemyHP[n - 1] -= damage;
            if (enemyHP[n - 1] < 0) enemyHP[n - 1] = 0;
            Debug.Log($"LastEnemy hp :{enemyHP[n - 1]}");

            enemyHP[target] -= damage;
            if (enemyHP[target] < 0) enemyHP[target] = 0;
            Debug.Log($"TargetEnemy {target} hp :{enemyHP[target]}");
        }
        

        public void AS05_DynamicIterationLoop(int n)
        {
            //throw new System.NotImplementedException();
            for (int i = 0; i < n; i++)
            {
                Debug.Log(i);
            }
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            //throw new System.NotImplementedException();
            if (ironManSuitNames == null || ironManSuitNames.Length == 0)
            {
                Debug.Log("No suits found.");
                return;
            }
            int i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i++;
            }
            Debug.Log("===");
            i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i += 2;
            }
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            //throw new System.NotImplementedException();
            if (heroHPs == null || heroHPs.Length == 0) return;

            int n = heroHPs.Length;

            heroHPs[0] += heal;
            Debug.Log($"FirstHero hp :{heroHPs[0]}");

            heroHPs[n - 1] += heal;
            Debug.Log($"LastHero hp :{heroHPs[n - 1]}");

            heroHPs[targetIndex] += heal;
            Debug.Log($"TargetHero {targetIndex} hp :{heroHPs[targetIndex]}");
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            //throw new System.NotImplementedException();
            if (dialogues == null || dialogues.Length == 0)
            {
                Debug.Log("No dialogues available.");
                return;
            }

            int randomIndex = UnityEngine.Random.Range(0, dialogues.Length);

            string selectedDialogue = dialogues[randomIndex];

            Debug.Log(selectedDialogue);
        }

        public void AS09_MultiplicationTable(int n)
        {
            //throw new System.NotImplementedException();
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{n}x{i}={n * i}");
            }
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            //throw new System.NotImplementedException();
            int sum = 0;
            int i = 0;

            while (i <= n)
            {
                sum += i;
                i++;
            }
            Debug.Log($"ผลรวมของ n จาก 0 ถึง {n} คือ {sum}");
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            //throw new System.NotImplementedException();
            if (enemyHPs == null || enemyHPs.Length == 0 || enemyPrefab == null)
            {
                Debug.Log("No enemies to spawn or enemyPrefab is null.");
                return;
            }

            for (int i = 0; i < enemyHPs.Length; i++)
            {
                Vector2 spawnPosition = new Vector2(i + 1, 0);
                GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                Debug.Log($"new enemy at position x = {spawnPosition.x}");
            }
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            //throw new System.NotImplementedException();
            float timer = 0f;

            if (CountTime <= 0f)
            {
                Debug.Log("End timer : 0");
                yield break;
            }

            while (timer < CountTime)
            {
                timer += Time.deltaTime;
                if (timer > CountTime)

                    timer = CountTime;

                Debug.Log("timer : " + timer.ToString("F2"));

                yield return null; 
            }
            Debug.Log("End timer : " + CountTime.ToString("F2"));
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            //throw new System.NotImplementedException();
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
                return;

            int sum = 0;
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                sum += matrix[row, j];
            }

            Debug.Log(sum);
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            //throw new System.NotImplementedException();
            if (matrix == null || column < 0 || column >= matrix.GetLength(1))
                return;

            int sum = 0;
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                sum += matrix[i, column];
            }

            Debug.Log(sum);

        }

        public void AS15_MakeTheTriangle(int size)
        {
            //throw new System.NotImplementedException();
            for (int i = 1; i <= size; i++)
            {
                string line = "";

                for (int j = 0; j < i; j++)
                {
                    line += "*";
                }

                Debug.Log(line);
            }
        }
        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            //throw new System.NotImplementedException();
            for (int i = 1; i <= 12; i++)
            {
                string line = "";

                line += $"2 x {i} = {2 * i}\t";

                line += $"3 x {i} = {3 * i}\t";

                line += $"4 x {i} = {4 * i}";

                Debug.Log(line);
            }
        }

        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            //throw new System.NotImplementedException();
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }



        #endregion
    }

}
