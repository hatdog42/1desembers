using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private  GameObject carPrefab;
    [SerializeField] private List<Sprite> carSprites;
    [SerializeField] private float carSpeed;
    [SerializeField] private int interval;
    private float _startTime;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        if (_startTime < Time.time - interval)
        {
            SpawnCar();
            ++interval;
        }
    }
    
    private void SpawnCar()
    {
        var newCar = Instantiate(carPrefab, transform.position, quaternion.identity);
        newCar.GetComponent<SpriteRenderer>().sprite = carSprites[Random.Range(0, carSprites.Count)];
        newCar.GetComponent<Rigidbody2D>().velocity = carSpeed * transform.up;
    }
}
