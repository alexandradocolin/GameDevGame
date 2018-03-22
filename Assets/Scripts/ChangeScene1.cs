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
        btn.onClick.AddListener(ChangeScreen);
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
	
	void Update ()
    {
        if (GameObject.Find("Player 1") && GameObject.Find("Player 1").GetComponent<Life>().currentLives == 0 || GameObject.Find("Player 2") && GameObject.Find("Player 2").GetComponent<Life>().currentLives == 0)
        {
            btn.gameObject.SetActive(true);
            btn.interactable = true;
        }
    }
}
