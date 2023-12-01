using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class SnowOnTheRoadController : MonoBehaviour, IEndDragHandler
{
    
    [SerializeField]private float speed;
    
    private bool _canMove = true;

    public bool rightSide;


    private void Start()
    {
        SetRandomStuff();
    }
    private void Update()
    {
        if (_canMove)
        {
            transform.position += (speed/4) * Time.deltaTime * Vector3.right;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("stop"))
        {
            _canMove = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canMove = true;

        if (transform.position.x < 0)
        {
            rightSide = true;
        }
        else
        {
            rightSide = false;
        }
        
        SetRandomStuff();
    }

    private void SetRandomStuff()
    {
        transform.localScale = new Vector3(1,1,1) * Random.Range(1, 3);
        
        if (rightSide)
        {
            speed = Random.Range(1, 5);
        }
        else
        {
            speed = -Random.Range(1, 5);
        }
    }
}
