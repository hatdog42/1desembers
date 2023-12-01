using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class siclistControler : MonoBehaviour
{
    public GameObject syklist;

    private bool idk = true;
    private void Start()
    {
        
    }

    private void IEnumerator()
    {
        while (true)
        {
            new WaitForSeconds(20f);

            Instantiate(syklist,new Vector3(11,0,0),quaternion.identity);
        }
        
    }
}
