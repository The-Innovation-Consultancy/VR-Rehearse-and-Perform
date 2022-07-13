using UnityEngine;
using UnityEngine.UI;
using VRUiKits.Utils;

public class ExampleCardItemAction : MonoBehaviour
{
    public Text title;
    public Text description;
    public Image img;

    void Start()
    {
        // Subscribing to OnCardClick method
        GetComponent<CardItem>().OnCardClicked += ShowDescription;
    }

    void ShowDescription(Card card)
    {
        title.text = card.title;
        description.text = card.description;
        Color temp = img.color;
        temp.a = 1f;
        img.color = temp;
        img.sprite = card.image;
    }
}
