using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualCursor : MonoBehaviour
{
    [SerializeField] private RectTransform cursor;
    public VirtualMouseBaseInput input;

    void Reset()
    {
        cursor = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        cursor.position = input.mousePosition;
    }
}
