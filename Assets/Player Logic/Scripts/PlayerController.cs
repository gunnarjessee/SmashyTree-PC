using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject selectedObject;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    private void OnClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            Transform tile = hit.transform;
            if (tile.tag.Equals("GrassTile"))
            {
                selectedObject = tile.gameObject;
                if (selectedObject.GetComponent<GrassTile>().HasTree())
                    selectedObject.GetComponent<GrassTile>().OnClick();
            }
        }
    }

}
