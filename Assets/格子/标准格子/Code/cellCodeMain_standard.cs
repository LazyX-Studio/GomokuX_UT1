using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using UnityEngine.Rendering.Universal;

public class cellCodeMain_standard : MonoBehaviour
{
    // 位置参数
    public float PosX;
    public float PosY;
    
    // 棋子精灵参数
    public GameObject chessPieceGameObject; // 精灵对象
    public string chessPieceSprite_location; // 精灵地址，null为无精灵

    public Light2D LightPrompt; // 提示光
    
    public playerRegistrationForm_Normal playerRegistrationForm; // 玩家注册表
    
    // Start is called before the first frame update
    void Start()
    {
        calculate_CellPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 初始化
    public void initialize_Main()
    {
        
    }
    

    // 相对位置计算
    void calculate_CellPosition()
    {
        // 相对位置
        Vector3 relativePosition = transform.localPosition;

        PosX = (int)relativePosition.x;
        PosY = -(int)relativePosition.y;
    }
    
    
    
    // 格子棋子显示状态更新
    public void updateStatus(int playerNumber)
    {
        chessPieceGameObject.GetComponent<SpriteRenderer>().sprite =
            playerRegistrationForm.PlayerGomoku_Sprite[playerNumber - 1];
    }
    
    
    
    // 提示光（固定类型）
    public void LightOpen_prompt(int PromptNumber)
    {
        LightPrompt.intensity = 1.0f;
    }



    // 5连提示光检查
    public void LightExamine_5Companies(int Number)
    {
        if (Number != 0)
        {
            LightPrompt.intensity = 3.0f;
            LightPrompt.color = Color.red;
            
            // Debug.Log(PosX + " " + PosY);
        }
    }
    
    // 精灵图片刷新（内置备用代码）
    // 函数：加载指定地址的精灵并应用到对象的 SpriteRenderer
    public void LoadAndSetSprite(string spriteAddress, GameObject targetObject)
    {
        Addressables.LoadAssetAsync<Sprite>(spriteAddress).Completed += (AsyncOperationHandle<Sprite> handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                // 获取目标对象的 SpriteRenderer 并设置精灵
                SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = handle.Result;
                }
            }
            else
            {
                Debug.LogError("Failed to load sprite: " + spriteAddress);
            }
        };
    }
}
