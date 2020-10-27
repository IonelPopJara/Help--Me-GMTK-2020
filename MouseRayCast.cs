using UnityEngine;

public class MouseRayCast : MonoBehaviour
{   
    private void Update()
    {
        GetMouseInput();
    }
    private void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Grapple Point"))
            {
                GrapplingGun.mouseClickPos = hitInfo.collider.transform.position;
            }
        }
        else
        {
            Debug.Log("There's nothing here");
        }

    }
}
