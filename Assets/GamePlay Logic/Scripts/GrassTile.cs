using System.Collections;
using UnityEngine;

public class GrassTile : MonoBehaviour
{
    public GameObject treeInstance;

    private Vector3 _position;
    private Vector3 _offsetPosition;
    private float offsetValue = .25f;

    private bool hasTree = false;

    private void Start()
    {
        _position = transform.position;
        _offsetPosition = _position;
        _offsetPosition.y -= offsetValue;
        treeInstance.SetActive(HasTree());
    }

    public void OnClick()
    {
        transform.position = _offsetPosition;
        StartCoroutine(ResetPosition());
        ToggleTree();
    }

    public bool ToggleTree()
    {
        if (hasTree)
        {
            hasTree = false;
        } else if (!hasTree) hasTree = true;

        treeInstance.SetActive(hasTree);

        return HasTree();
    }

    public bool HasTree()
    {
        return hasTree;
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(.25f);
        transform.position = _position;
    }
    
}
