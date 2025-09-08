using Unity.VisualScripting;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // A reference to your character's movement script (optional, but useful)
    public PlayerController playerController;
    public ScoreCounter scoreCounter;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrack"))
        {
            return;
        }
        // Check if the colliding object is a power-up
        if (other.CompareTag("Point"))
        {
            GivePoint();
            Destroy(other.gameObject); // Destroy the power-up object
        }
        else if (other.CompareTag("Wasabi"))
        {
            JumpPowerUp();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Octopus"))
        {
            OctopusPowerUp();
            Destroy(other.gameObject);
        }
    }

    void GivePoint()
    {
        Debug.Log("Point Collected!");
        scoreCounter.UpdateScore(1);
    }

    void JumpPowerUp()
    {
        Debug.Log("Jump Power-up Collected!");
        // Example: Increase player's jump height
    }

    void OctopusPowerUp()
    {
        Debug.Log("Octopus Power-up Collected!");
    }

}