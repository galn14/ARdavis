using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleControl : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private float _scale = 0.1f;

    private Transform _transform;
    private bool _zoomIn;
    private bool _zoomOut;

    private void Awake()
    {
        _transform = _object.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _zoomIn = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            _zoomIn = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _zoomOut = true;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            _zoomOut = false;
        }

        if (_zoomIn)
        {
            _transform.localScale += new Vector3(_scale, _scale, _scale) * Time.deltaTime;
        }

        if (_zoomOut)
        {
            _transform.localScale -= new Vector3(_scale, _scale, _scale) * Time.deltaTime;
        }

        Debug.Log("ZoomIn");
    }

    public void ZoomInButtonDown() {
        _zoomIn = true;
    }

    public void ZoomInButtonUp() {
        _zoomIn = false;
    }

    public void ZoomOutButtonDown() {
        _zoomOut = true;
    }

    public void ZoomOutButtonUp() {
        _zoomOut = false;
    }

    public void ZoomIn() {
        _transform.localScale += new Vector3(_scale, _scale, _scale) * Time.deltaTime;
    }

    public void ZoomOut() {
        _transform.localScale -= new Vector3(_scale, _scale, _scale) * Time.deltaTime;
    }
}
