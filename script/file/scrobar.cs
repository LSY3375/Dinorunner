using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrobar : MonoBehaviour
{
    public int count;
    public float speedRate;

    void Start()
    {
        count = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        //프레임에 따라 왼쪽으로 이동
        if (!GameManager.isLive) return;

        transform.Translate(GameManager.globalspeed * speedRate * Time.deltaTime * -1f, 0, 0);
       
    }
}
