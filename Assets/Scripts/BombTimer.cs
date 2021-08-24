using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    public float putBombDelay = 10.0f;

    private float currentTime = 0.0f;

    private PutBomb _putBomb;
    void Start()
    {
        _putBomb = GetComponent<PutBomb>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= putBombDelay)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            _putBomb.putBomb(this.transform);

            currentTime = 0.0f;
        }
    }
}
