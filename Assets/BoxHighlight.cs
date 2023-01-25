using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHighlight : MonoBehaviour
{

    [SerializeField] public static string selectableTag = "Selectable";
    [SerializeField] private GameObject selectedXHair;
    [SerializeField] private GameObject originalXHair;
    [SerializeField] private float Range = 5f;

    public static Transform _selection;
    public static RaycastHit hit_;

    void Update()
    {
    if (_selection != null)
        {
            selectedXHair.SetActive(false);
            originalXHair.SetActive(true);
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Range))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionOutline = selection.GetComponent<Renderer>();
                if (selectionOutline != null)
                {
                    originalXHair.SetActive(false);
                    selectedXHair.SetActive(true);

                }
                _selection = selection;
                hit_ = hit;
            }
        }
    }
}
