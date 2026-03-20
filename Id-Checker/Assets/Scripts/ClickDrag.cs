
using UnityEngine;
public class ClickDrag : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform clickObject;
    bool isMouseDown = false;

    void Start() { }

    void Update()
    {
        mousePosition = Input.mousePosition;
        Ray mouseray = Camera.main.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(0))  
        {
            raycastHit2D = Physics2D.Raycast(mouseray.origin, mouseray.direction);
            clickObject = raycastHit2D ? raycastHit2D.collider.transform : null;
            if (clickObject)
            {
                isMouseDown = true;  
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (clickObject)
                clickObject.GetComponent<SpriteRenderer>().color = Color.white;
            isMouseDown = false;
            clickObject = null;
        }

        if (isMouseDown && clickObject)
        {
            raycastHit2D = Physics2D.Raycast(mouseray.origin, mouseray.direction);

            if (raycastHit2D && clickObject.GetInstanceID() == raycastHit2D.collider.transform.GetInstanceID())
            {
                clickObject.GetComponent<SpriteRenderer>().color = Color.green;  
            }
            else
            {
                clickObject.GetComponent<SpriteRenderer>().color = Color.white;  
            }
        }
    }
}