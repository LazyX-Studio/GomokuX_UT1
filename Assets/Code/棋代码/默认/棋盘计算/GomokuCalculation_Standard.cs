using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuCalculation_Standard : MonoBehaviour
{
    // 五子棋判断计算代码块
    
    public GomokuCellStorage_Standard GomokuCellStorage;

    public int[] piecesAroundNumber; // 8个方向相同棋子数量

    public int piecesNumber;
    
    private Vector2[] direction_xy = new Vector2[] // 收索方向
    {
        new Vector2(0,1),
        new Vector2(1,1),
        new Vector2(1,0),
        new Vector2(1,-1),
        new Vector2(0,-1),
        new Vector2(-1,-1),
        new Vector2(-1,0),
        new Vector2(-1,1),
    };
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void compute_5companies(Vector2 ChessPiece_location) // 5连判断计算
    {
        compute_MatchingAdjacentPieces(ChessPiece_location);

        
        // 检测数量满足
        
        int i = 0;
        while (i < 4)
        {
            if (piecesAroundNumber[i] + piecesAroundNumber[i + 4] >= 4)
            {
                // 写入5连信息

                GomokuCellStorage.GomokuMapInformation[(int)ChessPiece_location.x, (int)ChessPiece_location.y, 0] =
                    piecesNumber;

                int x, y;
                x = (int)ChessPiece_location.x;
                y = (int)ChessPiece_location.y;
                
                int j = 0;
                while (j < piecesAroundNumber[i])
                {
                    GomokuCellStorage.GomokuMapInformation[x += (int)direction_xy[i].x,
                            y += (int)direction_xy[i].y,
                            0] =
                        piecesNumber;
                    j++;
                }
                
                x = (int)ChessPiece_location.x;
                y = (int)ChessPiece_location.y;
                
                j = 0;
                while (j < piecesAroundNumber[i + 4])
                {
                    GomokuCellStorage.GomokuMapInformation[x += (int)direction_xy[i + 4].x,
                            y += (int)direction_xy[i + 4].y,
                            0] =
                        piecesNumber;
                    j++;
                }
            }
            
            i++;
        }
    }

    
    
    // 计算相邻相同棋子的数量
    public void compute_MatchingAdjacentPieces(Vector2 ChessPiece_location)
    {
        
        int[,] GomokuMap = GomokuCellStorage.GomokuMap; // 加载地图

        piecesNumber = GomokuMap[(int)ChessPiece_location.x, (int)ChessPiece_location.y];

        
        // 如果没棋子直接退出
        if (piecesNumber == 0)
        {
            return;
        }
        
        // 初始化周围棋子数量存储数组
        piecesAroundNumber = new int[8];

        
        int i = 0;
        int x, y;
        while (i < 8)
        {
            x = (int)ChessPiece_location.x;
            y = (int)ChessPiece_location.y;

            int j = 0;

            while (GomokuMap[x += (int)direction_xy[i].x, y += (int)direction_xy[i].y] == piecesNumber)
            {
                int maxX, maxY;
                maxX = GomokuMap.GetLength(0);
                maxY = GomokuMap.GetLength(1);

                if (x + (int)direction_xy[i].x > maxX && x + (int)direction_xy[i].x < 0
                                                      && y + (int)direction_xy[i].y > maxY &&
                                                      y + (int)direction_xy[i].y < 0)
                {
                    break;
                }
                
                
                j++;
            }

            piecesAroundNumber[i] = j;

            i++;
        }
    }
}
