using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
     * Lo que pasa es que como todas estan instanciadas al mismo tiempo,
     * cuando presionas una tecla, todas las instancias lo sienten
     */
    [Header("QTE Counter")]
    public int qteCounter;

    public KeyCode[] keys;

    public KeyCode[] qteKeys;

    public Animator animator;

    private void Awake()
    {
        keys[0] = KeyCode.A;
        keys[1] = KeyCode.S;
        keys[2] = KeyCode.D;
    }
    private void Start()
    {
        qteKeys[0] = keys[Random.Range(0, 3)];

        if(qteCounter > 1)
        {
            qteKeys[1] = keys[Random.Range(0, 3)];
        }

        if(qteCounter > 2)
        {
            qteKeys[2] = keys[Random.Range(0, 3)];
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * PlayerController.speed * Time.fixedDeltaTime);
    }

    
    #region Death
    public IEnumerator Death(float time)
    {
        
        //Set death animation
        animator.SetTrigger("Death");
        //After the blow set the sound and effects
        yield return new WaitForSeconds(time);
        //print("Ahora");
        DifficultyManager.canMove = true;
        //Particles
        //Sound
        Destroy(gameObject, 2f);
    }

    public IEnumerator Spare(float time)
    {
        animator.SetTrigger("Spare");
        yield return new WaitForSeconds(time);
        //print("Muevete");
        DifficultyManager.canMove = true;
        Destroy(gameObject, 2f);
        //Particles, Sounds and Effects
    }
    #endregion
}
