using UnityEngine;

public class KillAll : MonoBehaviour{

    [SerializeField] private string tagPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        

        if (other.gameObject.tag == tagPlayer && health != null)
        {
            health.Kill();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}