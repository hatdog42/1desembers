using UnityEngine;

public class Car : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoadEnd"))
        {
            Destroy(gameObject);
        }
    }
}