using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _spawnTF;
    [SerializeField] private TMP_Text _pointText;
    private float _time = 0.0f;
    private Vector2 spawn;
    // Start is called before the first frame update
    private void Start()
    {
        spawn = _spawnTF.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_time > 0.0f)
        {
            Debug.Log(_time);
            _time -= Time.deltaTime;
        }
        else 
        {
            Instantiate(_coinPrefab, spawn, Quaternion.identity);
            Debug.Log("You're time's up!");
            _time = Random.Range(0.5f, 1.5f);
        }
    }
    public void Score(int _points)
    {
        string points = _points.ToString();
        _pointText.text = $"Points: {points}";
    }
}
