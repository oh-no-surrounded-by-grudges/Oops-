# 《完蛋！我被怨气包围了！》

## 背景故事

主人公是一个手无寸铁的大学生，他突然发现学校里出现大量怨灵，每个怨灵都是大学生生活中的怨气所幻化而成，例如被偷外卖的愤怒、分手的痛苦、毕业的迷茫等，主人公希望安抚这些怨灵保护校园。

## 具体玩法

### 主界面

![image-20240208222633722](C:\Users\xinji\Desktop\Oops-\Docs\README\image-20240208222633722.png)

主界面分为三个按钮：开始游戏 Start、退出游戏 Exit 和设置 Setting，初次游戏需要进行设置，如果直接点击开始也会自动跳转到设置界面。

### 设置 API

![image-20240208222829510](C:\Users\xinji\Desktop\Oops-\Docs\README\image-20240208222829510.png)

需要设置百度语音识别的 API 和 OpenAI ChatGPT 3.5 的 API，注意百度语音识别必须使用国内网络，所以后者接口也需要使用国内代理服务或者支持 OpenAI 接口格式的国内 LLM 服务。

百度语音识别新注册用户可以领取充足的免费额度，请访问：[百度AI开放平台 (baidu.com)](https://ai.baidu.com/tech/speech)。之后需要创建一个应用，然后将 API Key 和 Secret Key 填入即可。

国内 OpenAI 代理我使用的服务是 https://link-ai.tech/，登录也可以领取充足的免费额度，将该网站的 API 链接（）和 API Key 填入即可。

我的 API 设置如下（有效期至本课程出成绩，但也可能被提前用完额度，请助教自行申请 API hhh）：

```
OpenAI Url: https://api.link-ai.chat/v1/chat/completions
OpenAI Key: Link_xfPuDOMfOnKON3ENZvj1LXdk5DAR5uhyJLZD6olPTV
Baidu Key: U6AgdQS5CfwOOvOXoeKqot4q
Baidu Secret: QzKGyu4ThilauZU6UkIZViTUsZdBTwNv
```

### 游戏界面与操作

![image-20240208224150165](C:\Users\xinji\Desktop\Oops-\Docs\README\image-20240208224150165.png)

主人公通过方向键控制，在行走过程中可以按空格键闪现，闪现后有一段时间硬直。

主人公只有一条生命，如果被敌人攻击到就直接结束游戏。

用户需要一直和敌人对话来降低对方的怒气值，当敌人的怒气值降低到一定程度即可通关。

敌人当前的怒气值显示在屏幕最上方的进度条里，怒气值越高敌人的移动速度、攻击速度越快。