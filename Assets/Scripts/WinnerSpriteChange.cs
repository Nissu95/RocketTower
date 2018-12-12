using UnityEngine.UI;
using UnityEngine;

public class WinnerSpriteChange : MonoBehaviour
{
    Image winnerImage;

    private void Awake()
    {
        winnerImage = GetComponent<Image>();
    }

    private void Start()
    {
        winnerImage.sprite = PlayerManager.GetWinnerSprite();
        winnerImage.color = PlayerManager.GetWinnerColor();
    }
}
