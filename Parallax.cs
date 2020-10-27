using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallax;
    public float endX;
    public float startX;

    private void Update()
    {
        if(transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }

        if(PlayerController.speed <= 0)
        {
            PlayerController.speed = 0;
        }
    }

    private void FixedUpdate()
    {
        if(PlayerController.speed > 0)
        {
            transform.Translate(Vector2.left * PlayerController.speed * parallax * Time.fixedDeltaTime);
        }
    }
}
