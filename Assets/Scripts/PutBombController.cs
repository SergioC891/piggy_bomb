using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PutBombController : MonoBehaviour
{
    private PutBomb _putBomb;

    void Start()
    {
        _putBomb = GetComponent<PutBomb>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CnInputManager.GetButtonUp("PutBomb"))
        {
            _putBomb.putBomb(this.transform);
        }
    }
}
