using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChangeScene1 : MonoBehaviour
{
    Button btn;
    public string sceneName;

	void Start ()
    {
        btn = transform.gameObject.GetComponentInChildren<Button>() as Button;
        btn.onClick.AddListener(WinnerDance);
        btn.interactable = false;
        btn.gameObject.SetActive(false);

        if (GameObject.Find("Player 1") && GameObject.Find("Player 1").GetComponent<Life>().currentLives == 0 || GameObject.Find("Player 2") && GameObject.Find("Player 2").GetComponent<Life>().currentLives == 0)
        {
            btn.gameObject.SetActive(true);
            btn.interactable = true;
            //GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 100), "Game Over");
        }
        //    if (GameObject.Find("Player 1").GetComponent<Life>().currentLives == 0)
               // SceneManager.LoadScene("Assets/Scenes/Level2.unity", LoadSceneMode.Single);
        /*if (GameObject.Find("Player 2"))
            if (GameObject.Find("Player 2").GetComponent<Life>().currentLives == 0)
                SceneManager.LoadScene("Assets/Scenes/Level2.unity", LoadSceneMode.Single);*/
    }

    void ChangeScreen()
    {
        SceneManager.LoadScene(sceneName);
        NetworkManager.singleton.ServerChangeScene(sceneName);
    }

    void WinnerDance()
    {
        GameObject player1 = GameObject.Find("Player 1");
        GameObject player2 = GameObject.Find("Player 2");
        int total_wins = 0;
        total_wins += player1.GetComponent<Life>().levels_won;
        total_wins += player2.GetComponent<Life>().levels_won;
        Debug.Log(total_wins);
        //Scene scene = SceneManager.GetActiveScene();
        if (total_wins == 3)
        {
            Animation anim;
            Debug.Log("if");
            if (player1.GetComponent<Life>().levels_won >= player2.GetComponent<Life>().levels_won)
                anim = player1.GetComponent<Animation>();
            else
                anim = player2.GetComponent<Animation>();
            //anim.Play("Recorded");
            return;
        }
        else
        {
            Debug.Log("else");
            ChangeScreen();
            return;
        }
    }
	
	void Update ()
    {
        GameObject player1 = GameObject.Find("Player 1");
        GameObject player2 = GameObject.Find("Player 2");
        if (player1 && player1.GetComponent<Life>().currentLives == 0 || player2 && player2.GetComponent<Life>().currentLives == 0)
        {   
            btn.gameObject.SetActive(true);
            btn.interactable = true;
        }
    }
}
