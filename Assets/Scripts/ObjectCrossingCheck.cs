using UnityEngine;

public class ObjectCrossingCheck : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("playerTag"))
        {
            if (gameObject.CompareTag("blockTag"))
            {
                Invoke("DropBlock", 0.05f);


                // Scoring
                GameManager.instance.IncrementScore();
                
            }
            else if (gameObject.CompareTag("pickupTag"))
            {
                Destroy(gameObject);
                // // Scoring - we passed a pickup
                GameManager.instance.IncrementPickup();
            }
        }
    }

    void DropBlock()
    {
        transform.parent.gameObject.GetComponentInParent<Rigidbody>().useGravity = true;
        transform.parent.gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
        transform.parent.gameObject.GetComponentInParent<Rigidbody>().AddForce(Physics.gravity,
            ForceMode.Acceleration);
        Destroy(transform.parent.gameObject, .5f);
    }

}