using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Image Stick;
    public Vector2 Value;
    private bool isTriggered;
    private Vector3 touchingPos;

    private void Start()
    {
        isTriggered = false;
    }

    private void Update()
    {
        if (isTriggered)
        {
            var maxRange = GetComponent<RectTransform>().rect.width / 2.5f;
            var dist = Vector3.Distance(transform.position, touchingPos);
            var deltaPos = (touchingPos - transform.position);
            Stick.transform.position = touchingPos;
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
        touchingPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        touchingPos = eventData.position;
    }
}
