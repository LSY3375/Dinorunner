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


    void Update()
    {
        //�������
        if (!isLive) return;
        
        //��ŸŸ�Ӱ� ������ ���� �ӵ� ����
        score += Time.deltaTime * 2;
        globalspeed = ORIGIN_SPEED + score * 0.01f;
        
    }
    public void GameOver()
    {
        uiover.SetActive(true);
        isLive = false;

        float highScore = PlayerPrefs.GetFloat("Score");
        PlayerPrefs.SetFloat("Score", Mathf.Max(highScore, score));
    }
    public void reStart()
    {
        SceneManager.LoadScene(0);
        score = 0;
        isLive = true;
    }
}
