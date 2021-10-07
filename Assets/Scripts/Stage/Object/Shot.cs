using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    /// <summary>
    /// ’e‚Ì‘¬“x
    /// </summary>
    const float speed = 15.0f;

    private void Update()
    {
        if (GameManager.I.gameMode != GameMode.GameStart) return;

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Box")) Destroy(gameObject);
    }
}
