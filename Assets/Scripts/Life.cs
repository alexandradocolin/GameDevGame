using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Life : NetworkBehaviour
{
    public const int maxLives = 5;

    public Texture heart;

    public string playerName = "";

    public GameObject theOtherPlayer;

    public string theOtherPlayerName = "";

    [SyncVar(hook = "UpdateHearts")]
    public int currentLives = maxLives;


    public void LoseLife()
    {
        if (!isServer)
        {
            return;
        }

        currentLives--;
        if (currentLives <= 0)
        {
            currentLives = 0;
            Debug.Log("Dead!");
        }
    }

    void UpdateHearts(int health)
    {

    }

    void OnGUI()
    {
        if (!isLocalPlayer)
            return;

        if (transform.gameObject.name == "Player 1")
        {
            playerName = "Player 1";
            theOtherPlayer = GameObject.Find("Player 2");
            theOtherPlayerName = "Player 2";
        }
        else
        {
            playerName = "Player 2";
            theOtherPlayer = GameObject.Find("Player 1");
            theOtherPlayerName = "Player 1";
        }

        GUI.Label(new Rect(10, 185, Screen.width, heart.height), playerName);
        GUI.Label(new Rect(Screen.width - 60, 185, Screen.width, heart.height), theOtherPlayerName);
        if (currentLives > 0)
        {
            for (int i = 0; i < currentLives; i++)
            {
                var pos = new Rect(30 * i + 10, 210, heart.width / 40, heart.height / 40);
                GUI.DrawTexture(pos, heart);
            }
        }
        else
        {
            GUI.Label(new Rect(10, 210, Screen.width, heart.height), "You lost!");
            GUI.Label(new Rect(Screen.width - 65, 210, Screen.width, heart.height), "You won!");
        }
        //made this way for single player testing
        if (GameObject.Find("Player 2"))
        {
            if (GameObject.Find("Player 2").GetComponent<Life>().currentLives > 0)
            {
                for (int i = GameObject.Find("Player 2").GetComponent<Life>().currentLives - 1; i >= 0; i--)
                {
                    var pos = new Rect(Screen.width - 30 * i - 10, 210, heart.width / 40, heart.height / 40);
                    GUI.DrawTexture(pos, heart);
                }
            }
            else
            {
                GUI.Label(new Rect(10, 210, Screen.width, heart.height), "You won!");
                GUI.Label(new Rect(Screen.width - 65, 210, Screen.width, heart.height), "You lost!");
            }
        }
    }
}
