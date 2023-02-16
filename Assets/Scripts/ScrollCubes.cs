using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCubes : MonoBehaviour
{
    [SerializeField] private GameObject _cubes;
    private Vector3 _screenPoint,_offset;
    private float _lockedPos;
    private void OnMouseDown()
    {
        Cursor.visible = false;
        _lockedPos = _screenPoint.x;
        _offset = _cubes.transform.localPosition - Camera.main.ScreenToViewportPoint(new Vector3 (Input.mousePosition.x, _screenPoint.y, _screenPoint.z));
        _offset.y = _lockedPos; _offset.z = _lockedPos;
        
    }

    private void OnMouseDrag()
    {
        Vector3 _curScreenPoint = new Vector3(Input.mousePosition.x, _screenPoint.y, _screenPoint.z);
        Vector3 _curPosition = Camera.main.ScreenToViewportPoint(_curScreenPoint) + _offset;
        _curPosition.y = _lockedPos; _curPosition.z = _lockedPos;
        _cubes.transform.localPosition = _curPosition;
    }

    private void OnMouseUp()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        if (_cubes.transform.localPosition.x > 0)
            _cubes.transform.localPosition = Vector3.MoveTowards(_cubes.transform.localPosition, new Vector3(0f, _cubes.transform.localPosition.y, _cubes.transform.localPosition.z), Time.deltaTime * 10f);
        else if (_cubes.transform.localPosition.x < -6f)
            _cubes.transform.localPosition = Vector3.MoveTowards(_cubes.transform.localPosition, new Vector3(-6f, _cubes.transform.localPosition.y, _cubes.transform.localPosition.z), Time.deltaTime * 10f);
    }
}
