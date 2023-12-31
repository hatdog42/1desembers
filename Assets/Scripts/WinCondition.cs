using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private float _startTime;
    [SerializeField] private float winConditionTime;
    
    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _startTime >= winConditionTime)
        {
            SceneManager.LoadScene("GoodEndScene");
        }
    }
}