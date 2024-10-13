using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MapController_StandardChessboardFunctionalityTest : MonoBehaviour
{
    private CellInteractionHandler cellInteractionHandler; // 单元格子交互处理函数库

    public GomokuCalculation_Standard GomokuCalculation_Standard; // 计算块

    // 棋盘大小设置
    public int ChessboardMapSizeX;
    public int ChessboardMapSizeY;

    public GameObject[,] ChessboardCellData; // 棋盘格子存储
    public cellCodeMain_standard[,] ChessboardCellData_Code; // 棋盘格子代码调用
    public GameObject[,] ChessboardCellData_frame; // 棋盘格子边框储存
    
    public GameObject ChessboardGameObject; // 棋盘对象
    
    public GomokuCellStorage_Standard gomokuCellStorageStandard; // 棋盘储存
    
    // 相机对象
    public GameObject playerCameraGameObject;
    public Camera playerCameraCamera;
    
    // 背景板对象
    public GameObject backgroundPlateGameObject;
    
    // 玩家信息
    public int playerNumber; // 轮到哪位小可爱了？
    public int playerQuantity; // 玩家数量
    public int[] playerQuit; // 玩家离开，类似桶排序的数组原理

    public playerRegistrationForm_Normal playerRegistrationForm; // 玩家注册表
    
    // 权限锁

    public bool PlayerControl_Lock; // 玩家控制权限锁，控制玩家是否可以正常下棋
    
    // Start is called before the first frame update
    void Start()
    {
        // initialize_Main();
    }

    // Update is called once per frame
    void Update()
    {
        // 检查鼠标左键是否按下与是否有全体玩家下棋权限
        if (Input.GetMouseButtonDown(0) && PlayerControl_Lock)
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
                            PlayerControl_Lock = false; // 先上锁再说OwO/
                            
                            // 查询位置
                            int PosX = (int)CellGameObject.GetComponent<cellCodeMain_standard>().PosX;
                            int PosY = (int)CellGameObject.GetComponent<cellCodeMain_standard>().PosY;
                            
                            // 检测是否被占位
                            if (gomokuCellStorageStandard.GomokuMap[PosX, PosY] == 0)
                            {
                                // 设置占位
                                gomokuCellStorageStandard.GomokuMap[PosX, PosY] = playerNumber;
                                
                                // 计算判断
                                GomokuCalculation_Standard.compute_5companies(new Vector2(PosX, PosY));
                                
                                // 传递方格对象信息
                                                                                                         
                                CellGameObject.GetComponent<cellCodeMain_standard>().updateStatus(playerNumber);
                                
                                // 下一个玩家来
                                int n = playerNumber;
                                if (n == playerQuantity)
                                {
                                    n = 0;
                                }

                                int m = 0;
                                
                                while (playerQuit[n] != 0)
                                {
                                    n++;
                                    m++;
                                    if (n == playerQuantity)
                                    {
                                        n = 0;
                                        Debug.Log(playerQuantity);
                                    }

                                    if (m > playerQuantity + 10)
                                        break;
                                }

                                playerNumber = n + 1;
                            }
                            
                            
                            
                            PlayerControl_Lock = true; // 解锁
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
    
    
    
    // 总初始化
    public async void initialize_Main()
    {
        PlayerControl_Lock = false;
        initialize_LibraryLoading();
        
        // 背景板初始化
        backgroundPlateGameObject.transform.position = new Vector3(ChessboardMapSizeX / 2f,
            ChessboardMapSizeY / -2f,
            0); // 位置
        backgroundPlateGameObject.transform.localScale = new Vector3(ChessboardMapSizeX,
            ChessboardMapSizeY,
            0); // 大小(缩放实现)

        // 相机位置初始化
        playerCameraGameObject.transform.position = backgroundPlateGameObject.transform.position;
        Vector3 cameraPosition = playerCameraGameObject.transform.position;
        cameraPosition.z = -10;
        playerCameraGameObject.transform.position = cameraPosition;

        
        playerCameraCamera.orthographicSize = Mathf.Min(ChessboardMapSizeX, ChessboardMapSizeY) / 2f;
        
        
        int i, j;
        i = j = 0;
        
        // 初始化地图
        gomokuCellStorageStandard.GomokuMap = new int[ChessboardMapSizeX, ChessboardMapSizeY];
        
        // 初始化提示地图
        
        gomokuCellStorageStandard.GomokuMapInformation = new int[ChessboardMapSizeX, ChessboardMapSizeY,1];
        
        // 初始化玩家相关信息
        playerNumber = 1;
        playerQuantity = playerRegistrationForm.PlayerName.Length;
        playerQuit = new int[playerQuantity];

        i = 0;
        while (i < playerQuit.Length)
        {
            playerQuit[i] = 0;
            i++;
        }
        
        // 棋格加载
        
        // 初始化棋盘格数组
        ChessboardCellData = new GameObject[ChessboardMapSizeX, ChessboardMapSizeY];
        ChessboardCellData_Code = new cellCodeMain_standard[ChessboardMapSizeX, ChessboardMapSizeY];
        ChessboardCellData_frame = new GameObject[ChessboardMapSizeX, ChessboardMapSizeY];
        
        // 加载格子对象
        GameObject gridPrefab = await ChessboardCell_LoadObjectAsync("Assets/格子/标准格子.prefab");
        Vector3 gridPosition;
        
        
        i = 0;
        while (i < ChessboardMapSizeX)
        {
            j = 0;
            while (j < ChessboardMapSizeY)
            {
                // 实例化对象
                GameObject gridCell = Instantiate(gridPrefab);

                // 设置为 parentObject 的子级
                gridCell.transform.SetParent(ChessboardGameObject.transform);

                // 设置相对父级的坐标
                gridPosition = new Vector3(j, -i, 0);
                gridCell.transform.localPosition = gridPosition;
                
                // 载入对象
                gridCell.GetComponent<cellCodeMain_standard>().playerRegistrationForm = playerRegistrationForm;

                // 存储到数组
                ChessboardCellData[i, j] = gridCell;
                ChessboardCellData_Code[i, j] = gridCell.GetComponent<cellCodeMain_standard>();
                
                // Debug.Log($"Grid cell instantiated and placed at: {gridPosition}");
                
                // 批量更改对象
                
                // 暂时不需要更改OwO
                
                
                j++;
            }
            i++;
        }
        
        
        // 加载玩家精灵对象
        playerRegistrationForm.PlayerGomoku_Sprite = new Sprite[playerQuantity];
        i = 0;
        while (i < playerQuantity)
        {
            Sprite gridSprits = await PlayerSprite_LoadObjectAsync(
                playerRegistrationForm.PlayerGomoku_SpriteAddress[i]
                );

            playerRegistrationForm.PlayerGomoku_Sprite[i] = gridSprits;

            i++;
        }
        
        
        PlayerControl_Lock = true;
        
        // 测验
        // Debug.Log(ChessboardCellData_Code[2, 2]);
        ChessboardCellData_Code[2,2].LightOpen_prompt(0);
    }
    
    // 代码库初始化
    public void initialize_LibraryLoading()
    {
        cellInteractionHandler = GetComponent<CellInteractionHandler>();
    }
    
    
    
    // 按路径查找子节点
    public GameObject FindChildByPath(GameObject parent, string path)
    {
        // 通过路径直接查找子对象
        Transform childTransform = parent.transform.Find(path);

        // 如果找到了对象，返回对象的 GameObject，否则返回 null
        return childTransform != null ? childTransform.gameObject : null;
    }

    
    
    
    // 异步加载，棋盘格子
    private async Task<GameObject> ChessboardCell_LoadObjectAsync(string objectAddress)
    {
        // 异步加载对象
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(objectAddress);
        
        // 等待加载完成
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            // 返回加载的对象
            return handle.Result;
        }
        else
        {
            Debug.LogError("Failed to load object: " + objectAddress);
            return null;
        }
    }
    
    // 异步加载，精灵
    private async Task<Sprite> PlayerSprite_LoadObjectAsync(string objectAddress)
    {
        // 异步加载 Sprite 对象
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(objectAddress);
    
        // 等待加载完成
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            // 返回加载的 Sprite 对象
            return handle.Result;
        }
        else
        {
            Debug.LogError("Failed to load sprite: " + objectAddress);
            return null;
        }
    }
}
