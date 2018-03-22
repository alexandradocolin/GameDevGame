using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Life : NetworkBehaviour
{
    public const int maxLives = 5;
    public Texture heart;

    [SyncVar]
    int levels_won = 0;

    [SyncVar]
    public int currentLives = maxLives;

    int other_player_lives = 0;

    int gui_row_height = 25;
    int gui_first_row_x = 185;

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
                theOtherPlayer.GetComponent<Life>().levels_won++;
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

        GUI.Label( new Rect( 0, gui_first_row_x, Screen.width, heart.height ), playerName, left_align_style );
        GUI.Label( new Rect( 0, gui_first_row_x, Screen.width, heart.height ), theOtherPlayerName, right_align_style );

        GUI.Label( new Rect( 0, gui_first_row_x + gui_row_height * 2, Screen.width, heart.height ), levels_won + " levels won", left_align_style );
        if( theOtherPlayer != null )
        {
            GUI.Label( new Rect( 0, gui_first_row_x + gui_row_height * 2, Screen.width, heart.height ), theOtherPlayer.GetComponent<Life>().levels_won + " levels won", right_align_style );
        }

        if( currentLives != 0 && other_player_lives != 0 )
        {
            for( int i = 0; i < currentLives; i++ )
            {
                var pos = new Rect( heart_size * i + 10, gui_first_row_x+gui_row_height, heart_size, heart_size );
                GUI.DrawTexture( pos, heart, ScaleMode.ScaleToFit );
            }
            for( int i = 0; i < other_player_lives; i++ )
            {
                var pos = new Rect( Screen.width - maxLives * heart_size + heart_size * i - 10, gui_first_row_x+gui_row_height, heart_size, heart_size );
                GUI.DrawTexture( pos, heart, ScaleMode.ScaleToFit );
            }
        }
        else
        {
            if( other_player_lives == 0 )
            {
                GUI.Label( new Rect( 0, gui_first_row_x + gui_row_height, Screen.width, heart.height ), "You won!", left_align_style );
                GUI.Label( new Rect( 0, gui_first_row_x + gui_row_height, Screen.width, heart.height ), "You lost!", right_align_style );
            }
            else
            {
                if( currentLives == 0 )
                {
                    GUI.Label( new Rect( 0, gui_first_row_x + gui_row_height, Screen.width, heart.height ), "You lost!", left_align_style );
                    GUI.Label( new Rect( 0, gui_first_row_x + gui_row_height, Screen.width, heart.height ), "You won!", right_align_style );
                }
            }
        }
        //made this way for single player testing
        /*if( GameObject.Find( "Player 2" ) )
        {
            if( GameObject.Find( "Player 2" ).GetComponent<Life>().currentLives > 0 )
            {
                for( int i = GameObject.Find( "Player 2" ).GetComponent<Life>().currentLives - 1; i >= 0; i-- )
                {
                    var pos = new Rect( Screen.width - 30 * i - 10, 210, heart.width / 40, heart.height / 40 );
                    GUI.DrawTexture( pos, heart );
                }
            }
            else
            {
                GUI.Label( new Rect( 10, 210, Screen.width, heart.height ), "You won!" );
                GUI.Label( new Rect( Screen.width - 65, 210, Screen.width, heart.height ), "You lost!" );
            }
        }*/
    }
}
