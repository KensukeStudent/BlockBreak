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
            //更新処理
            if (!box.Anim) box.OnUpdate();

            if(box.Hit && !box.Anim)
            {
                //破壊アニメーション再生
                box.SetBreak();

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
        GameManager.Instance.ChangeGamaMode(GameMode.GameClear);
    }
}