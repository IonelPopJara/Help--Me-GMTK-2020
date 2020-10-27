using UnityEngine;

public class CharacterControllerMouse : MonoBehaviour
{
    public Camera cam;

    private Rigidbody2D rb;

    private Vector2 mousePos;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = angle;
    }
}
