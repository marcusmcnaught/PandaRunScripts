using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 15f; 

    void LateUpdate()
    {
        if (PlayerController.IsDead)
        {
            speed = 0f;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -speed * Time.deltaTime + transform.position.z);
    }
}
