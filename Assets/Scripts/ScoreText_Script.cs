using UnityEngine.UI;
using UnityEngine;

public class ScoreText_Script : MonoBehaviour {

    [SerializeField] IamPlayer iamPlayer;

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update ()
    {
        text.text = "Score: " + iamPlayer.score;
	}
}
