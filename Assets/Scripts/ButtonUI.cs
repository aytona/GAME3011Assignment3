using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Events that sets the button
public class ButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public void OnPointerDown(PointerEventData eventData) {
        SetFontColorBlack();
    }

    public void OnPointerUp(PointerEventData eventData) {
        ResetFontColor();
    }

    // Sets button font to black
    private void SetFontColorBlack() {
        gameObject.GetComponentInChildren<Text>().color = Color.black;
    }

    // Resets button font back to white
    private void ResetFontColor() {
        gameObject.GetComponentInChildren<Text>().color = Color.white;
    }
}
