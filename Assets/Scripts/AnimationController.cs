using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Sprite moveUp;
    [SerializeField] private Sprite moveDown;
    [SerializeField] private Sprite moveLeft;
    [SerializeField] private Sprite moveRight;

    public float effectOnExplodeTime = 1.0f;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = CnInputManager.GetAxis("Horizontal");
        float vertInput = CnInputManager.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)
        {
            if (Mathf.Abs(horInput) > Mathf.Abs(vertInput))
            {
                if (horInput > 0)
                {
                    _spriteRenderer.sprite = moveRight;
                }
                else
                {
                    _spriteRenderer.sprite = moveLeft;
                }
            }
            else
            {
                if (vertInput > 0)
                {
                    _spriteRenderer.sprite = moveUp;
                }
                else
                {
                    _spriteRenderer.sprite = moveDown;
                }
            }
        }
    }

    public void BombExploded()
    {
        StartCoroutine(EffectOnExplode());
    }

    IEnumerator EffectOnExplode()
    {
        iTween.RotateBy(this.gameObject, new Vector3(0.0f, 0.0f, 60.0f), effectOnExplodeTime);

        yield return new WaitForSeconds(effectOnExplodeTime);

        iTween.RotateTo(this.gameObject, new Vector3(0.0f, 0.0f, 0.0f), .1f);
    }
}
