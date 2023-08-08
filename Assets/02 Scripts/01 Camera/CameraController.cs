using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    // �ʿ��� ���۳�Ʈ
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