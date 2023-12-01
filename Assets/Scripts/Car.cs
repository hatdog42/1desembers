using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Car : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoadEnd"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Snow"))
        {
            Slip();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene("BadEndScene");
    }

    private void Slip()
    {
        var rnd = new Random();
        var result = rnd.Next(0, 2) * 2 - 1;
        var direction = _rigidbody2D.velocityY * result * Vector2.up;
        var direction2 = Vector2.right * result;
        
        _rigidbody2D.velocity += (direction + direction2).normalized;
    }
}