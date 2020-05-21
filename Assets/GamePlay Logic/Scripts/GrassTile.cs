using System.Collections;
using UnityEngine;

public class GrassTile : MonoBehaviour
{

    private Vector3 _position;
    private Vector3 _offsetPosition;
    private float offsetValue = .25f;
    private void Start()
    {
        _position = transform.position;
        _offsetPosition = _position;
        _offsetPosition.y -= offsetValue;
    }

    public void OnClick()
    {
        transform.position = _offsetPosition;
        StartCoroutine(ResetPosition());
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(.25f);
        transform.position = _position;
    }
    
}
