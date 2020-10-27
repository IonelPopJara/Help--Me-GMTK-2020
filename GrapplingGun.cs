using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    /*
     * Cada vez que hago click, debo fijarme en la orientacion del Fire Point
     * Asi se le agrega la fuerza al rigidbody del personaje
     */

    public static Vector2 mouseClickPos;

    public Rigidbody2D rb;

    public float dashForce;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        Vector2 dir = mouseClickPos - rb.position;

        if (Input.GetMouseButtonDown(0))
        {
            Dash(dir);
        }
    }

    private void Dash(Vector2 dir)
    {
        rb.AddForce(dir * dashForce, ForceMode2D.Impulse);
        mouseClickPos = rb.position;
    }
}
