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
        //��ǥ��-10 ���ϰ� �Ǹ� �ٽ� �� ���������� ����
        transform.Translate(24, 0, 0, Space.Self);
        onMove.Invoke();
    }
}
