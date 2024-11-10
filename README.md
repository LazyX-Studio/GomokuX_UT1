# 五子棋X_UT1介绍
一个简单的开源多人五子棋项目

# 状态
目前还是一个功能测验版本\
会完善UI界面和兼容性(在win下似乎存在无法全屏的问题)\

# 未来规划
如果有时间的化会做一下人工智障，对活4/活3的警告等等，也会试图制作一些比较好玩的模式。\
目前不会考虑网络联机，一是没钱搞服务器，二是作者没学(还是初学水平)

# 目前完整功能“体验”指南

## 开始
首先你需要一台能用的电脑（确保内存充足）\
然后稍微学一下unity这个软件怎么用（只要会用就行，不是说要会编程）\
最后下载一下unity2022.3.43f1c1（其他版本也不是不行，但最好是2022.3.x的，不然可能会出问题）

## 操作
首先把代码下载下来导入unity,找到Assets下的“测验”文件夹（就是项目面板的这个测验文件夹）然后找到功能测验功能测验/棋盘标准功能，里面有一个名为棋盘标准功能测试的地图，把他打开即可\
具体路径:Assets/测验/功能测验/棋盘标准功能/棋盘标准功能测试\.unity\
检查一下运行，如果有报错可以问一下Ai(比如kimi),不行可以在开源库里反馈一下。

在地图里找到“控制”这个对象，选中它，在检查起面板找到“MapController_PlayerInPut”这个组件，里面的PlayerName代表玩家名字（目前没个卵用），PlayerGomoku_SpriteAddress代表玩家棋子精灵对象地址（可以到Addressables Groups面板看一下），PlayerGomoku_SpriteColor代表玩家棋子的颜色，玩家数量由PlayerName数量决定。

“MapController_StandardChessboardFunctionalityTest”组件的ChessboardMapSizeX和ChessboardMapSizeY代表棋盘大小，建议是正方形。
