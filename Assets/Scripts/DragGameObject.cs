using System;
using UnityEngine;

public class DragGameObject : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;
    
    public AudioSource Audio;
    public AudioClip snow;
    
    private void OnMouseDown()
    {
        var position = gameObject.transform.position;
        if (Camera.main != null)
        {
            _screenPoint = Camera.main.WorldToScreenPoint(position);
            _offset = position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
        }
        else
        {
            Debug.Log("No Main Camera");
        }
    }

    private void OnMouseDrag()
    {
        var curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        if (Camera.main != null)
        {
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
            transform.position = curPosition;
        }
        else
        {
            Debug.Log("No Main Camera");
        }
    }

    private void OnMouseUp()
    {
        Audio.PlayOneShot(snow);
    }
}