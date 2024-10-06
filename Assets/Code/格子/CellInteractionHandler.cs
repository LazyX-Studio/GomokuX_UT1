using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInteractionHandler : MonoBehaviour
// 单元格子交互处理函数存放库
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    // 函数：检测鼠标点击并返回点击的最上面的2D对象
    public GameObject DetectTopmostObject()
    {
        // 检查鼠标左键是否按下
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击位置并将其从屏幕坐标转换为世界坐标
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 发射一条从鼠标位置向下的射线来检测点击的2D对象
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // 如果射线检测到了对象
            if (hit.collider != null)
            {
                // 输出点击的对象名称
                // Debug.Log("Clicked on: " + hit.collider.gameObject.name);

                // 返回被点击的对象
                return hit.collider.gameObject;
            }
        }

        // 如果没有检测到任何对象，则返回null
        return null;
    }

}
