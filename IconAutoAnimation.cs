using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This class is attached to the parent object of the buttons you want to animate in forward and reverse order
// On start, gets all child buttons into _buttons and gets each position and scale vector into _buttonsPositions and _buttonsScale
public class IconAutoAnimation : MonoBehaviour
{
    // Data fields
    private List<Button> _buttons = new List<Button>();
    private List<Vector3> _buttonPositions = new List<Vector3>();
    private List<Vector3> _buttonScale = new List<Vector3>();
    
    // Set left or right side controls
    [SerializeField]
    private string _id;
    
    // Tween timing variables
    [SerializeField]
    private float _tweenMove;
    [SerializeField]
    private float _tweenScale;

    // This is to test tween types
    public LeanTweenType tweenType;


    private void Start()
    {
        GetChildButtons();
        GetChildButtonPositions();
    }

    private void GetChildButtons()
    {
        foreach (var item in gameObject.GetComponentsInChildren<Button>())
        {
            _buttons.Add(item);
        }
    }

    private void GetChildButtonPositions()
    {
        foreach (var button in _buttons)
        {
            _buttonPositions.Add(button.GetComponent<RectTransform>().anchoredPosition);
            _buttonScale.Add(button.GetComponent<RectTransform>().localScale);
        }
    }

    // id set by user for each object in the inspector, gate defines 1 of 2 directions for array to cycle in PlayerInputEvents
    public void SetNewVectorsAndAnimateOneWay(string id, bool isReversed)
    {
        if (id == _id)
        {
            // reverse the list if gate == 2, then return to original direction after the loop
            if (isReversed)
            {
                _buttons.Reverse();
            }
            
            for (int i = 0; i < _buttons.Count; i++)
            {
                int ii = 1;

                if (i == 0)
                {
                    LeanTween.moveLocal(_buttons[i].gameObject, _buttons[(_buttons.Count - 1)].transform.localPosition, _tweenMove).setEase(tweenType);
                    LeanTween.scale(_buttons[i].gameObject, _buttons[(_buttons.Count - 1)].transform.localScale, _tweenScale).setEase(tweenType);
                }
                else
                {
                    LeanTween.moveLocal(_buttons[i].gameObject, _buttons[(i * ii) - ii].transform.localPosition, _tweenMove).setEase(tweenType);
                    LeanTween.scale(_buttons[i].gameObject, _buttons[(i * ii) - ii].transform.localScale, _tweenScale).setEase(tweenType);
                }
            }

            if (isReversed)
            {
                _buttons.Reverse();
            }
        }
    }
}
