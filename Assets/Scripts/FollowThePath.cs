﻿using UnityEngine;
using UnityEngine.UI; // Pra acessar o componente Image.
using System.Collections.Generic; // Pra usar List<T>.

public class FollowThePath : MonoBehaviour {
    public Transform[] waypoints;
    [SerializeField]
    private float moveSpeed = 1f;
    [HideInInspector]
    public int waypointIndex = 0;
    public bool moveAllowed = false;

    public GameObject cardsObject; // Referência ao objeto "Cards".
    public List<Sprite> cardSprites; // Lista de sprites das cartas.

    private Image cardImage; // Referência ao componente Image do objeto "Cards".

    private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
        cardImage = cardsObject.GetComponent<Image>(); // Obtém o componente Image.
        ShowCard(); // Mostra a primeira carta no início.
    }

    private void Update () {
        if (moveAllowed)
            Move();
    }

    private void Move() {
        if (waypointIndex <= waypoints.Length - 1) {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position) {
                waypointIndex += 1;
                ShowCard(); // Mostra a carta correspondente ao novo waypoint.
            }
        }
    }

    private void ShowCard() {
        if (waypointIndex < cardSprites.Count) {
            if (waypointIndex -1 < 0){
                cardImage.sprite = cardSprites[waypointIndex]; // Início do jogo, mostra a carta zero    
            } else {
            cardImage.sprite = cardSprites[waypointIndex -1]; // Define o sprite da carta.
            }
        }
    }
}