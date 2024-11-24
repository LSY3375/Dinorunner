using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class reposition : MonoBehaviour
{
    public UnityEvent onMove;
    void LateUpdate()
    {
        if (transform.position.x > -10)
            return;
        //좌표가-10 이하가 되면 다시 맨 오른쪽으로 보냄
        transform.Translate(24, 0, 0, Space.Self);
        onMove.Invoke();
    }
}
