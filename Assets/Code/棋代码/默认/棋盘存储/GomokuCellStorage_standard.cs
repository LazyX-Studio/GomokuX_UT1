using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuCellStorage_Standard : MonoBehaviour
{
    public int[,] GomokuMap; // 存储地图

    public int[,,] GomokuMapInformation; // 提示储存地图
    /*
     * 0层 5连 标值>0,标-1为默认,其他标0
     * 1层 活4 标值>0,标-1为默认,其他标0
     * ...
     */
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
