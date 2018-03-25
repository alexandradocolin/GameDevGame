using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class StaticVariables : NetworkBehaviour
{
    [SyncVar]
    public int player1_wins = 0;

    [SyncVar]
    public int player2_wins = 0;

    public string thisPlayerName = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
