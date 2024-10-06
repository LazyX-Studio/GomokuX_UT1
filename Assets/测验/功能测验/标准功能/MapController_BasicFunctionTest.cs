using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController_BasicFunctionTest : MonoBehaviour
{
    public CellInteractionHandler cellInteractionHandler; // 单元格子交互处理函数库
    
    // Start is called before the first frame update
    void Start()
    {
        initialize_LibraryLoading();
    }

    // Update is called once per frame
    void Update()
    {
        // 检查鼠标左键是否按下
        if (Input.GetMouseButtonDown(0))
        {
            GameObject LgameObject = cellInteractionHandler.DetectTopmostObject();
            if (LgameObject != null)
            {
                // 判断类型
                if (LgameObject.GetComponent<IDT_Normal>().tag == "Cell类碰撞体")
                {
                    GameObject CellGameObject;
                    // 检查是否有父级
                    if (LgameObject.transform.parent != null)
                    {
                        // 获取父级对象
                        CellGameObject = LgameObject.transform.parent.gameObject;

                        string CellGameObjectTag = null;
                        
                        // 检测父级标签
                        try
                        {
                            CellGameObjectTag = CellGameObject.GetComponent<IDT_Normal>().tag;
                        }
                        catch
                        {
                            Debug.Log("Unable to recognize the identification tag");
                        }

                        if (CellGameObjectTag == "Cell 标准型号")
                        {
                            
                        }
                        else
                        {
                            Debug.Log("This identification tag operation is not currently available");
                        }
                    }
                    else
                    {
                        Debug.Log("The GameObject has no parent.");
                    }
                }
            }
        }
    }

    public void initialize_LibraryLoading()
    {
        cellInteractionHandler = GetComponent<CellInteractionHandler>();
    }
}
