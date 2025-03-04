using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image Stick;
    public Vector2 Value;
    private bool isTriggered;

    private void Start()
    {
        isTriggered = false;
    }

    private void Update()
    {
        if (isTriggered)
        {
            var maxRange = GetComponent<RectTransform>().rect.width / 2.5f;
            var dist = Vector3.Distance(transform.position, Input.mousePosition);
            var deltaPos = (Input.mousePosition - transform.position);
            Stick.transform.position = Input.mousePosition;
            if (dist > maxRange)
            {
                Stick.transform.position = transform.position + deltaPos.normalized * maxRange;
            }

            deltaPos = Stick.transform.position - transform.position;
            Value.x = deltaPos.x / maxRange;
            Value.y = deltaPos.y / maxRange;
            Debug.Log(deltaPos);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTriggered = false;
        Stick.transform.position = transform.position;
        Value = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTriggered = true;
    }
}
