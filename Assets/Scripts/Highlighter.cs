using UnityEngine;

public class Highlighter : MonoBehaviour
{
    IClickable currentObject;
    [SerializeField] GameObject selectionPanel;
    public void Highlight(IClickable click)
    {
        DeHighlight();
        if (click == currentObject) return;
        currentObject = click;
        currentObject.OnHoverEnter();
    }

    public void DeHighlight()
    {
        if (currentObject == null) return;
        if (!currentObject.Equals(null))
        currentObject.OnHoverExit();
        currentObject = null;
    }
}
