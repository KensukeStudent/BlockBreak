using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Box生成クラス
/// </summary>
public class BoxManager : MonoBehaviour
{
    /// <summary>
    /// ボックス格納
    /// </summary>
    Box[] boxArray;

    /// <summary>
    /// 破壊したボックス数
    /// </summary>
    int hitBoxCount = 0;

    private void Start()
    {
        var boxes = GameObject.FindGameObjectsWithTag("Box");

        boxArray = new Box[boxes.Length];

        for (int i = 0; i < boxes.Length; i++)
        {
            boxArray[i] = boxes[i].GetComponent<Box>();
        }
    }

    private void Update()
    {
        for (int i = 0; i < boxArray.Length; i++)
        {
            var box = boxArray[i];

            if(box.Hit && box.gameObject.activeInHierarchy)
            {
                box.gameObject.SetActive(false);
                hitBoxCount++;

                //全てのボックスを破壊したらゲームクリア
                if (hitBoxCount == boxArray.Length) GameClear();
            }
        }
    }

    /// <summary>
    /// 全てのブロックを破壊出来たらクリア
    /// </summary>
    void GameClear()
    {
        Debug.Log("クリア");
    }
}