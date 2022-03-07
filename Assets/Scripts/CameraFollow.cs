using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    Vector3 offset;
    [SerializeField] float followRate = .25f; // rate by which camera follows the ball

    void Start() { // you set this at the beginning
        offset = player.transform.position - transform.position;
    }

    void Update() {
        if (GameManager.instance.gameStatus == Modes.running)
            Follow();
    }

    void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = player.transform.position - offset;

        Vector3 newCamPos = Vector3.Lerp(currentPos,
                                          targetPos,
                                          followRate * Time.deltaTime);

        gameObject.transform.position = newCamPos;
    }
}
