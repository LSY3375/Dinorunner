using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED=3;

    public static float globalspeed;
    public static float score;
    public static bool isLive;
    public GameObject uiover;

    void Awake()
    {
        isLive = true;
        if(PlayerPrefs.HasKey("score"))
            PlayerPrefs.SetFloat("score", 0);

    }

}
