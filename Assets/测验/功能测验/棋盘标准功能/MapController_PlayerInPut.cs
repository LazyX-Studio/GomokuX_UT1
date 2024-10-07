using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController_PlayerInPut : MonoBehaviour
{
    public string[] PlayerName; // 玩家名字注册表
    public string[] PlayerGomoku_SpriteAddress; // 玩家棋子精灵对象地址
    public Color[] PlayerGomoku_SpriteColor; // 玩家棋子颜色
    
    // 交互制库
    public playerRegistrationForm_Normal playerRegistrationForm_Normal;

    public MapController_StandardChessboardFunctionalityTest MapController_StandardChessboardFunctionalityTest;
    
    // Start is called before the first frame update
    void Start()
    {
        // 传递玩家数据
        playerRegistrationForm_Normal.PlayerName = PlayerName;
        playerRegistrationForm_Normal.PlayerGomoku_SpriteAddress = PlayerGomoku_SpriteAddress;
        playerRegistrationForm_Normal.PlayerGomoku_SpriteColor = PlayerGomoku_SpriteColor;

        MapController_StandardChessboardFunctionalityTest.initialize_Main();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
