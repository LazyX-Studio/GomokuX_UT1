using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class cellCodeMain_standard : MonoBehaviour
{
    // 位置参数
    public float PosX;
    public float PosY;
    
    // 棋子精灵参数
    public GameObject chessPieceGameObject; // 精灵对象
    public string chessPieceSprite_location; // 精灵地址，null为无精灵
    
    // Start is called before the first frame update
    void Start()
    {
        calculate_CellPosition();
    }

    // Update is called once per frame
    void Update()
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
