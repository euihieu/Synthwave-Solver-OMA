using UnityEngine;
using UnityEngine.EventSystems;

public enum ModeOfCursor
{
    Default,
    Hover
}

public class CursorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ModeOfCursor modeOfCursor;


    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorManager.Instance.SetToMode(modeOfCursor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.Instance.SetToMode(ModeOfCursor.Default);
    }
}
