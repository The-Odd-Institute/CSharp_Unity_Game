using UnityEngine;

public class TrailScript : MonoBehaviour
{
    [SerializeField] private GameObject player = null, ghost = null;

    public void CallTrailing ()
    {
        InvokeRepeating ("StartTrailing", 0.05f, .1f);;
    }

    void Update ()
    {
        // this has to go to the GameManager
        if (GameManager.instance.gameStatus == Modes.over)
            CancelInvoke ("StartTrailing");
    }

    public void StartTrailing ()
    {
        GameObject nextGhost = Instantiate (ghost,
            player.transform.position,
            player.transform.rotation);

        Destroy (nextGhost, 1.0f);
    }
}