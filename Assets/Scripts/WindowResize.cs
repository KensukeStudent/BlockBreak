using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WindowResize
{
    // 属性の設定
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        // スクリーンサイズの指定
        Screen.SetResolution(1600, 900, false);
    }
}