using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public static UIHealth instance;

    [Header("Сердечки")]
    public Image[] hearts;

    [Header("Спрайты")]
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHearts(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < health ? fullHeart : emptyHeart;
        }
    }
}