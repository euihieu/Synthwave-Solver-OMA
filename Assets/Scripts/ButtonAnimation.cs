
// Import necessary namespaces
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Needed for pointer event interfaces

// Inherit from MonoBehaviour and implement pointer event interfaces
public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Reference to the Button component
    Button btn;
    // The scale to enlarge to on hover
    Vector3 upScale = new Vector3(1.2f, 1.2f, 1);
    // The original scale of the button
    Vector3 originalScale;

    private void Awake()
    {
        // Get the Button component attached to this GameObject
        btn = gameObject.GetComponent<Button>();
        // Store the original scale of the button
        originalScale = transform.localScale;
        // Add the Anim method as a listener to the button's onClick event
        btn.onClick.AddListener(Anim);
    }

    // This method is called when the button is clicked
    void Anim()
    {
        // Animate the button to the enlarged scale quickly
        LeanTween.scale(gameObject, upScale, 0.1f);
        // Animate the button back to its original scale after a short delay
        LeanTween.scale(gameObject, originalScale, 0.1f).setDelay(0.1f);
    }

    // Called when the mouse pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Animate the button to the enlarged scale on hover
        LeanTween.scale(gameObject, upScale, 0.08f);
    }

    // Called when the mouse pointer exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        // Animate the button back to its original scale when not hovered
        LeanTween.scale(gameObject, originalScale, 0.08f);
    }
}
