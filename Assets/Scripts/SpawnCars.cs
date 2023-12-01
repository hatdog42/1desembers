using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private List<Sprite> carSpritesFront;
    [SerializeField] private List<Sprite> carSpritesBack;
    [SerializeField] private float carSpeed;
    [SerializeField] private Vector2 intervalRandomRange = new Vector2(2, 10);
    [SerializeField] private Direction direction;
    private float _interval;
    private float _lastSpawnTime;
    
    private void Start()
    {
        _interval = Random.Range(intervalRandomRange.x, intervalRandomRange.y);
        _lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (_lastSpawnTime < Time.time - _interval)
        {
            SpawnCar();
            _interval = Random.Range(intervalRandomRange.x, intervalRandomRange.y);
            _lastSpawnTime = Time.time;
        }
    }
    
    private void SpawnCar()
    {
        if (direction == Direction.Down)
        {
            var newCar = Instantiate(carPrefab, transform.position, Quaternion.identity);
            newCar.GetComponent<SpriteRenderer>().sprite = carSpritesFront[Random.Range(0, carSpritesFront.Count)];
            newCar.GetComponent<Rigidbody2D>().velocity = carSpeed * -transform.up;
        }
        else if (direction == Direction.Up)
        {
            var newCar = Instantiate(carPrefab, transform.position, Quaternion.identity);
            newCar.GetComponent<SpriteRenderer>().sprite = carSpritesBack[Random.Range(0, carSpritesBack.Count)];
            newCar.GetComponent<Rigidbody2D>().velocity = carSpeed * transform.up;
        }
    }
    
    private enum Direction { Up, Down }
}