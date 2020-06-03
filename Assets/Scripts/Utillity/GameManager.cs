using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject gameoverObject = null;
    [SerializeField] PlayerTrans playerTrans = null;

    public void GameOver()
    {
        gameoverObject.SetActive(true);
        playerTrans.GameOver();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
    }

    void Restart()
    {
        gameoverObject.SetActive(false);
        playerTrans.Restart();
    }

}
