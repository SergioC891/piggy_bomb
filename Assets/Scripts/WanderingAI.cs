using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject movedObject;
    [SerializeField] private bool LookAtTargetCharacter;
    [SerializeField] private GameObject targetCharacter;
    

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public float movementDelay = 0.2f;
    public float effectOnExplodeTime = 1.0f;
    public Vector3 rotateAngleOnExplode = new Vector3(0.0f, 0.0f, 60.0f);

    private float currentTime = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (currentTime <= movementDelay)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            
            Ray2D ray = new Ray2D(transform.position, transform.forward);
            RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, transform.forward);

            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-180, 180);
                transform.Rotate(0, 0, angle);
                movedObject.SendMessage("moveToPosition", transform.position);
            }
            else
            {
                if (LookAtTargetCharacter)
                {
                    transform.LookAt(new Vector3(targetCharacter.transform.position.x, targetCharacter.transform.position.y, 0.0f));
                }
            }

            currentTime = 0.0f;
        }
    }
    public void BombExploded()
    {
        StartCoroutine(EffectOnExplode());
    }

    IEnumerator EffectOnExplode()
    {
        movedObject.SendMessage("EffectOnExplode", SendMessageOptions.DontRequireReceiver);
        iTween.RotateBy(movedObject, rotateAngleOnExplode, effectOnExplodeTime);

        yield return new WaitForSeconds(effectOnExplodeTime);

        iTween.RotateTo(movedObject, Vector3.zero, .1f);
    }
}
