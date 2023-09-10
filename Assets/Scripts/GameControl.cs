using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2;

    public static int diceSideThrown = 0; //guarda o que saiu nos dados. PÚBLICA!
    public static int player1StartWaypoint = 0; //posições iniciais dos jogadores
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    void Start () {

        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown) //se o player 1 chegou no waypoint
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false; //manda ele parar
            player1MoveText.gameObject.SetActive(false); //esconde o sua vez dele
            player2MoveText.gameObject.SetActive(true); //ativa o sua vez do player2
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1; //atualiza a posição inicial pra onde ele tá agora
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown) //se o player 2 chegou no waypoint
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false; //manda ele parar
            player2MoveText.gameObject.SetActive(false); //esconde o sua vez dele
            player1MoveText.gameObject.SetActive(true); //ativa o sua vez do player1
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1; //atualiza a posição inicial pra onde ele tá agora
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length) //se o player1 chegou no fim
        {
            whoWinsTextShadow.gameObject.SetActive(true); 
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Venceu!";
            gameOver = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length) 
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Venceu!";
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { //vê quem tem que se mover
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true; //vez dele
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true; //vez dele
                break;
        }
    }
}
