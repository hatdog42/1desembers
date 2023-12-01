using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private  GameObject carPrefab;
    [SerializeField] private List<Sprite> carSpritesFront;
    [SerializeField] private List<Sprite> carSpritesBack;
    [SerializeField] private float carSpeed;
    [SerializeField] private Vector2 intervalRandomRange = new Vector2(2, 10);
    private float _interval;
    private float _lastSpawnTime;
    [SerializeField] private Direction direction;

    private enum Direction
    {
        Up,
        Down
    }

    private void Start()
    {
        _lastSpawnTime = Time.time;
        _interval = Random.Range(intervalRandomRange.x, intervalRandomRange.y);
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
}