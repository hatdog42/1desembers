using UnityEngine;

public class Car : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoadEnd"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Snow"))
        {
            var direction = Vector2.up;
            var direction2 = Vector2.right * (Random.Range(0, 2) - 1);
            GetComponent<Rigidbody2D>().velocity += (direction + direction2).normalized;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Crash!");
    }
}