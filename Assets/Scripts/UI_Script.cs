using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text pickupText;

    [SerializeField] Text highScoreText;
    [SerializeField] Text highPickupText;

    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();

        pickupText.text = GameManager.instance.pickup.ToString();


        highScoreText.text = GameManager.instance.highScore.ToString();

        highPickupText.text = GameManager.instance.highPickup.ToString();

    }
}
