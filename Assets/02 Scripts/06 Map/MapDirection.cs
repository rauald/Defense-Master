using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapDirection : MonoBehaviour
{
    [SerializeField] private MapLoop parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 _dir;
        int idx;

        if(collision.transform.tag == "Player")
        {
            _dir = PlayerController.instance.GetDirection();

            // ¿À¸¥ÂÊ
            if(_dir.x > 0)
            {
                idx = transform.GetSiblingIndex();
            }
            else if (_dir.x < 0)
            {
                //idx = 
            }
        }
    }
}