using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private  GameObject carPrefab;
    [SerializeField] private List<Sprite> carSprites;
    [SerializeField] private float carSpeed;
    [SerializeField] private int interval;
    private float _lastSpawnTime;

    private void Start()
    {
        _lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (_lastSpawnTime < Time.time - interval)
        {
            SpawnCar();
            _lastSpawnTime = Time.time;
        }
    }
    
    private void SpawnCar()
    {
        var newCar = Instantiate(carPrefab, transform.position, Quaternion.identity);
        newCar.GetComponent<SpriteRenderer>().sprite = carSprites[Random.Range(0, carSprites.Count)];
        newCar.GetComponent<Rigidbody2D>().velocity = carSpeed * -transform.up;
    }
}
