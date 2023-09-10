using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardsContainer; // Objeto "Cards" no Unity que contém os sprites.
    public Image cardImage; // Componente Image onde a carta será exibida.

    private Sprite[] cardSprites; // Array de sprites das cartas.
    private bool cardShown = false; // Controla se a carta está sendo mostrada.

    private void Start()
    {
        // Inicialize o array de sprites com os sprites dentro do objeto "Cards".
        cardSprites = new Sprite[cardsContainer.transform.childCount];
        for (int i = 0; i < cardSprites.Length; i++)
        {
            cardSprites[i] = cardsContainer.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void ShowCard(int cardNumber)
    {
        // Verifique se o número da carta está dentro dos limites do array.
        if (cardNumber >= 1 && cardNumber <= cardSprites.Length)
        {
            // Mostre a carta correspondente no componente Image.
            cardImage.sprite = cardSprites[cardNumber - 1]; // Subtrai 1 porque os índices de array começam em 0.
            cardImage.enabled = true; // Ative o componente Image para mostrar a carta.
            cardShown = true; // Marque que a carta está sendo mostrada.
        }
        else
        {
            // Se o número da carta estiver fora dos limites, exiba uma mensagem de erro.
            Debug.LogWarning("Número de carta fora dos limites.");
        }
    }

    public void HideCard()
    {
        // Desative o componente Image para ocultar a carta.
        cardImage.enabled = false;
        cardShown = false; // Marque que a carta não está sendo mostrada.
    }

    public bool IsCardShown()
    {
        return cardShown; // Retorna se a carta está sendo mostrada ou não.
    }
}
