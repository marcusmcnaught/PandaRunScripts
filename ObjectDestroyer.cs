using UnityEngine;

public class TrackDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Destroyed");
        Destroy(other.gameObject);        
    }
}
