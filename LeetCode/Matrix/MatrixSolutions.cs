using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Matrix
{
    public static class MatrixSolutions
    {
        public static int DiagonalSum(int[][] matrix)
        {
            var x = matrix[0].Length;
            var y = matrix.Length;

            var elements = x * y;
            var result = 0;
            var res = 0;

            if (elements % 2 == 0)
            {
                var centerDownRight = ((int)Math.Sqrt(elements)) / 2;

                res = matrix[centerDownRight][centerDownRight];
                result += res;
                for (int i = 1; i < centerDownRight; i++)
                {
                    res = matrix[centerDownRight + i][centerDownRight + i];
                    result += res;
                }

                res = matrix[centerDownRight - 1][centerDownRight];
                result += res;
                for (int i = 1; i < centerDownRight; i++)
                {
                    res = matrix[centerDownRight - 1 - i][centerDownRight + i];
                    result += res;
                }
                
                res = matrix[centerDownRight - 1][centerDownRight - 1];
                result += res;
                for (int i = 1; i < centerDownRight; i++)
                {
                    res = matrix[centerDownRight - 1 - i][centerDownRight - 1 - i];
                    result += res;
                }

                res = matrix[centerDownRight][centerDownRight - 1];
                result += res;
                for (int i = 1; i < centerDownRight; i++)
                {
                    res = matrix[centerDownRight + i][centerDownRight - 1 - i];
                    result += res;
                }

                return result;
            }
            else
            {
                var center = ((int)Math.Sqrt(elements) - 1) / 2;

                for (int i = 1; i <= center; i++)
                {
                    result += matrix[center - i][center - i] + matrix[center + i][center + i] + matrix[center + i][center - i] + matrix[center - i][center + i];
                }

                return result + matrix[center][center];
            }
        }

        // 54. Spiral Matrix
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            var x = matrix[0].Length;
            var y = matrix.Length;
            var result = new List<int>();

            var xCicle = 0;
            var yCicle = 0;
            var xReturnCicle = 0;
            var yReturnCicle = 0;

            var positionX = 0;
            var positionY = 0;

            var canContinueX = true;
            var canContinueY = false;

            while (true)
            {
                if (canContinueX)
                {
                    if ((xCicle > 0 && positionX + xCicle < x - 1) || xCicle == 0)
                    {
                        positionX = xCicle;

                        result.Add(matrix[positionY][positionX]);

                        canContinueY = true;
                    }

                    for (int ixright = positionX + 1; ixright < x - xCicle - 1; ++ixright)
                    {
                        positionX = ixright;

                        result.Add(matrix[positionY][positionX]);

                        canContinueY = true;
                    }

                    if (positionX < x - xCicle)
                    {
                        if (positionX + 1 + xCicle < x)
                        {
                            positionX += 1;
                            result.Add(matrix[positionY][positionX]);

                            canContinueY = true;
                        }
                    }
                }
                canContinueX = false;
                xCicle += 1;

                if (canContinueY)
                {
                    for (int yxdown = positionY + 1; yxdown < y - yCicle - 1; ++yxdown)
                    {
                        positionY = yxdown;

                        result.Add(matrix[positionY][positionX]);

                        canContinueX = true;
                    }

                    if (positionY < y - yCicle - 1)
                    {
                        positionY += 1;
                        result.Add(matrix[positionY][positionX]);

                        canContinueX = true;
                    }
                }
                canContinueY = false;
                yCicle += 1;

                if (canContinueX)
                {
                    for (int ixright = positionX - 1; ixright > xReturnCicle; --ixright)
                    {
                        positionX = ixright;

                        result.Add(matrix[positionY][positionX]);

                        canContinueY = true;
                    }

                    if (positionX - xReturnCicle > 0)
                    {
                        positionX -= 1;
                        result.Add(matrix[positionY][positionX]);

                        canContinueY = true;
                    }
                }

                canContinueX = false;
                xReturnCicle += 1;

                if (canContinueY)
                {
                    for (int yxdown = positionY - 1; yxdown > yReturnCicle; --yxdown)
                    {
                        positionY = yxdown;

                        result.Add(matrix[positionY][positionX]);

                        canContinueX = true;
                    }
                }

                canContinueY = false;
                yReturnCicle += 1;

                if (xCicle + yCicle > x + y)
                {
                    break;
                }
            }

            return result;
        }

        // 59. Spiral Matrix II
        public static int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            var elements = n * n;
            var value = 1;

            var x = 0;
            var y = 0;
            var dx = 1;
            var dy = 1;

            while (value <= elements) {
                result[x][y] = value;

                if (y == dy - 1 && x < n - dx)
                {
                    x++;
                }
                else if (x == n - dx && y < n - dy)
                {
                    y++;
                }
                else if (x > dx - 1)
                {
                    x--;
                }
                else if (y > dy)
                {
                    y--;
                    if (y == dy && x == dx - 1)
                    {
                        dx++;
                        dy++;
                    }
                }

                value++;
            }

            int[][] pivot = new int[n][];
            for (int i = 0; i < n; i++)
            {
                pivot[i] = new int[n];
            }
            for (int yp = 0; yp < n; yp++)
            {
                for (int xp = 0; xp < n; xp++)
                {
                    pivot[yp][xp] = result[xp][yp];
                }
            }

            return pivot;
        }
    }
}