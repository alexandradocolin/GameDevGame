using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Life : NetworkBehaviour
{
    public const int maxLives = 5;
    public Texture heart;
    public static StaticVariables statVars = null;

    [SyncVar]
    public int currentLives = maxLives;

    int other_player_lives = 0;

    int gui_row_height = 25;
    int gui_first_row_x = Screen.height - 65;

    public void increment_levels_won()
    {
        switch( transform.gameObject.name )
        {
            case "Player 1":
                statVars.player1_wins++;
                break;
            case "Player 2":
                statVars.player2_wins++;
                break;
            default:
                break;
        }
    }

    public void set_levels_won( int val )
    {
        switch( transform.gameObject.name )
        {
            case "Player 1":
                statVars.player1_wins = val;
                break;
            case "Player 2":
                statVars.player2_wins = val;
                break;
            default:
                break;
        }
    }

    public int get_levels_won()
    {
        switch( transform.gameObject.name )
        {
            case "Player 1":
                return statVars.player1_wins;
            case "Player 2":
                return statVars.player2_wins;
            default:
                return 0;
        }
    }

    private GameObject get_other_player()
    {
        GameObject theOtherPlayer = null;
        if( transform.gameObject.name == "Player 1" )
        {
            theOtherPlayer = GameObject.Find( "Player 2" );
            //theOtherPlayerName = "Player 2";
        }
        else
        {
            theOtherPlayer = GameObject.Find( "Player 1" );
            //theOtherPlayerName = "Player 1";
        }
        return theOtherPlayer;
    }

    public void LoseLife()
    {
        if( !isServer )
        {
            return;
        }

        GameObject theOtherPlayer = get_other_player();

        if( currentLives == 1 )
        {
            if( theOtherPlayer != null )
            {
                theOtherPlayer.GetComponent<Life>().increment_levels_won();
            }
            Debug.Log( "Dead!" );
        }

        if( currentLives > 0 )
        {
            currentLives--;
        }
    }

    void OnGUI()
    {
        if( !isLocalPlayer )
        {
            return;
        }

        string playerName = this.gameObject.name;
        string theOtherPlayerName = "Player missing";
        GameObject theOtherPlayer = get_other_player();

        int heart_size = 20;
        GUIStyle left_align_style = new GUIStyle( GUI.skin.label );
        GUIStyle right_align_style;

        left_align_style.alignment = TextAnchor.UpperLeft;
        left_align_style.margin = new RectOffset( 10, 10, 0, 0 );

        right_align_style = new GUIStyle( left_align_style );
        right_align_style.alignment = TextAnchor.UpperRight;


        if( theOtherPlayer == null )
            other_player_lives = -1;
        else
        {
            other_player_lives = theOtherPlayer.GetComponent<Life>().currentLives;
            theOtherPlayerName = theOtherPlayer.name;
        }
        GUI.Label( new Rect( 10, Screen.height - 65, Screen.width, heart.height ), playerName, left_align_style );
        GUI.Label( new Rect( -10, Screen.height - 65, Screen.width, heart.height ), theOtherPlayerName, right_align_style );

        GUI.Label( new Rect( 10, gui_first_row_x + gui_row_height * 2 - 10, Screen.width, heart.height ), get_levels_won() + " levels won", left_align_style );
        if( theOtherPlayer != null )
        {
            GUI.Label( new Rect( -10, gui_first_row_x + gui_row_height * 2 - 10, Screen.width, heart.height ), theOtherPlayer.GetComponent<Life>().get_levels_won() + " levels won", right_align_style );
        }

        if( currentLives != 0 && other_player_lives != 0 )
        {
            for( int i = 0; i < currentLives; i++ )
            {
                var pos = new Rect( ( heart_size + 5 ) * i + 10, gui_first_row_x + gui_row_height - 3, heart_size, heart_size );
                GUI.DrawTexture( pos, heart );
            }
            for( int i = other_player_lives - 1; i >= 0; i-- )
            {
                var pos = new Rect( Screen.width - ( heart_size + 5 ) * i - 30, gui_first_row_x + gui_row_height - 3, heart_size, heart_size );
                GUI.DrawTexture( pos, heart );
            }
        }
        else
        {
            if( other_player_lives == 0 )
            {
                GUI.Label( new Rect( 10, gui_first_row_x + gui_row_height - 3, Screen.width, heart.height ), "You won!", left_align_style );
                GUI.Label( new Rect( -10, gui_first_row_x + gui_row_height - 3, Screen.width, heart.height ), "You lost!", right_align_style );
            }
            else
            {
                if( currentLives == 0 )
                {
                    GUI.Label( new Rect( 10, gui_first_row_x + gui_row_height - 3, Screen.width, heart.height ), "You lost!", left_align_style );
                    GUI.Label( new Rect( -10, gui_first_row_x + gui_row_height - 3, Screen.width, heart.height ), "You won!", right_align_style );
                }
            }
        }
        //made this way for single player testing
        /*if(GameObject.Find("Player 2"))
        {
            if(GameObject.Find("Player 2").GetComponent<Life>().currentLives > 0)
            {
                for(int i = GameObject.Find("Player 2").GetComponent<Life>().currentLives - 1; i >= 0; i--)
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
        }*/
    }

    void Start()
    {
        if( statVars == null )
        {
            try
            {
                statVars = GameObject.Find( "StaticVariables" ).GetComponent<StaticVariables>();
            }
            catch( Exception e )
            {
                ;
            }
        }
    }
}
