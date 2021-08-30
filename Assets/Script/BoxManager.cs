using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Box�����N���X
/// </summary>
public class BoxManager : MonoBehaviour
{
    /// <summary>
    /// �{�b�N�X�i�[
    /// </summary>
    Box[] boxArray;

    /// <summary>
    /// �j�󂵂��{�b�N�X��
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

            if (!box.gameObject.activeInHierarchy) return;

            if(box.Hit)
            {
                box.gameObject.SetActive(false);

                //�S�Ẵ{�b�N�X��j�󂵂���Q�[���N���A
                if (hitBoxCount == boxArray.Length) GameClear();
            }
        }
    }

    /// <summary>
    /// �S�Ẵu���b�N��j��o������N���A
    /// </summary>
    void GameClear()
    {
        Debug.Log("�N���A");
    }
}