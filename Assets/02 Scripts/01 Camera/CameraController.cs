using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    // 필요한 컴퍼넌트
    [SerializeField] private Transform targetPos;

    [SerializeField] private float speed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    private void Update()
    {
        Vector3 _move = new Vector3(0, 0, -10);

        transform.position = targetPos.position + _move;

    }
}