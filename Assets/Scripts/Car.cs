using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _rigidbody2D.velocity = speed * transform.forward;
    }
}