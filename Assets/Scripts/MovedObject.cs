using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedObject : MonoBehaviour
{
    [SerializeField] private Sprite moveUp;
    [SerializeField] private Sprite moveDown;
    [SerializeField] private Sprite moveLeft;
    [SerializeField] private Sprite moveRight;

    [SerializeField] private Sprite moveUpDirty;
    [SerializeField] private Sprite moveDownDirty;
    [SerializeField] private Sprite moveLeftDirty;
    [SerializeField] private Sprite moveRightDirty;

    public float moveTime = 0.2f;
    public float effectOnExplodeTime = 1.0f;

    private SpriteRenderer _spriteRenderer;

    enum Movement
    {
        Up, Down, Left, Right
    }

    private Movement currentSpriteMovement;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void moveToPosition(Vector3 position)
    {
        changeSpriteByPosition(position);

        iTween.MoveTo(this.gameObject, iTween.Hash("x", position.x, "y", position.y, "time", moveTime, "easetype", iTween.EaseType.linear));
    }

    public void changeSpriteByPosition(Vector3 position)
    {
        if ((Mathf.Abs(position.x) - Mathf.Abs(transform.position.x)) > (Mathf.Abs(position.y) - Mathf.Abs(transform.position.y)))
        {
            if ((position.x - transform.position.x) > 0)
            {
                _spriteRenderer.sprite = moveRight;
                currentSpriteMovement = Movement.Right;
            }
            else
            {
                _spriteRenderer.sprite = moveLeft;
                currentSpriteMovement = Movement.Left;
            }
        }
        else
        {
            if ((position.y - transform.position.y) > 0)
            {
                _spriteRenderer.sprite = moveUp;
                currentSpriteMovement = Movement.Up;
            }
            else
            {
                _spriteRenderer.sprite = moveDown;
                currentSpriteMovement = Movement.Down;
            }
        }
    }

    public void EffectOnExplode()
    {
        StartCoroutine(EffectOnExplodeRoutine());
    }

    IEnumerator EffectOnExplodeRoutine()
    {
        if (currentSpriteMovement == Movement.Up)
        {
            _spriteRenderer.sprite = moveUpDirty;
        }
        else if (currentSpriteMovement == Movement.Down)
        {
            _spriteRenderer.sprite = moveDownDirty;
        }
        else if (currentSpriteMovement == Movement.Left)
        {
            _spriteRenderer.sprite = moveLeftDirty;
        }
        else if (currentSpriteMovement == Movement.Right)
        {
            _spriteRenderer.sprite = moveRightDirty;
        }

        yield return new WaitForSeconds(effectOnExplodeTime);

        if (currentSpriteMovement == Movement.Up)
        {
            _spriteRenderer.sprite = moveUp;
        }
        else if (currentSpriteMovement == Movement.Down)
        {
            _spriteRenderer.sprite = moveDown;
        }
        else if (currentSpriteMovement == Movement.Left)
        {
            _spriteRenderer.sprite = moveLeft;
        }
        else if (currentSpriteMovement == Movement.Right)
        {
            _spriteRenderer.sprite = moveRight;
        }
    }
}
