using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SnowOnTheRowdControler : MonoBehaviour, IEndDragHandler
{
    
    [SerializeField]private float speed;
    
    private bool _canMove = true;

    private RectTransform transform;

    [FormerlySerializedAs("Rigt")] public bool rightSide;


    private void Start() => transform = GetComponent<RectTransform>();

    private void Update()
    {
        if (_canMove)
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stop"))
        {
            _canMove = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canMove = true;
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
