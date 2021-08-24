using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBomb : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;

    private GameObject _bomb;
    private int bombCounter = 0;
    public void putBomb(Transform _transform)
    {
        _bomb = Instantiate(bombPrefab) as GameObject;

        _bomb.transform.position = new Vector3(_transform.position.x, _transform.position.y, 0.0f);
        _bomb.transform.name = _bomb.transform.name + bombCounter.ToString();

        bombCounter++;
    }
}
