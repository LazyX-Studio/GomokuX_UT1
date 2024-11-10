# 五子棋X_UT1 Introduction  

A simple open-source multiplayer Gomoku project.  

## Status  
Currently, it is still a functional test version.  
- Planned improvements include enhancing the UI and ensuring compatibility (e.g., resolving issues with fullscreen on Windows).  

## Future Plans  
- If time permits, AI features may be added, such as warnings for live-4/live-3 situations.  
- Experimenting with some fun modes.  
- **Note:** Online multiplayer is not being considered for now due to the lack of server funding and the author's learning stage.  

---

## Complete Functional "Experience" Guide  

### Getting Started  
1. Ensure you have a usable computer (with sufficient memory).  
2. Learn the basics of using Unity (you don't need programming skills, just know how to use the software).  
3. Download **Unity 2022.3.43f1c1** (other versions might work, but 2022.3.x is recommended to avoid compatibility issues).  

---

### How to Operate  

1. **Download and Import the Code**  
   - Import the code into Unity.  
   - Navigate to the `Assets/测验` folder in the project panel.  
   - Find the subfolder `功能测验/棋盘标准功能` and open the map named `棋盘标准功能测试`.  

   **Path:**  
   `Assets/测验/功能测验/棋盘标准功能/棋盘标准功能测试.unity`  

2. **Check for Errors**  
   - Run the map and verify everything works.  
   - If errors occur, consult an AI assistant (like Kimi) or provide feedback in the open-source repository.  

3. **Customize Player Settings**  
   - Locate the `控制` object in the map and select it.  
   - In the Inspector panel, find the component `MapController_PlayerInput`.  
     - **PlayerName:** Represents the player's name (currently non-functional).  
     - **PlayerGomoku_SpriteAddress:** Specifies the player's chess piece sprite object address (viewable in the Addressables Groups panel).  
     - **PlayerGomoku_SpriteColor:** Determines the player's chess piece color.  
   - The number of players is determined by the number of PlayerName entries.  

4. **Adjust Chessboard Settings**  
   - In the `MapController_StandardChessboardFunctionalityTest` component:  
     - **ChessboardMapSizeX/Y:** Represents the chessboard's dimensions. A square board is recommended for optimal gameplay.  

--- 

Enjoy exploring the early-stage functionality of 五子棋X_UT1!
