using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchControl : MonoBehaviour
{
    [SerializeField] Transform _testObject;

	[SerializeField] private InputActionAsset _asset;
	[SerializeField] private InputActionMap _map;
	[SerializeField] private InputAction _touchPosAction;

	[SerializeField]  Camera _camera;

	[SerializeField]  private Vector3 _touchPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
		_map = _asset.actionMaps[0];
        _touchPosAction = _map.FindAction("TouchPosition");
		if(_touchPosAction != null)
		{
			Debug.Log("Successfully added input action");
			Debug.Log($"{_touchPosAction.name}");
		}
    }
	private void Awake()
	{
	}

	// Update is called once per frame
	void Update()
    {
		_touchPosition = _camera.ScreenToWorldPoint(_touchPosAction.ReadValue<Vector2>());
		_touchPosition.z = 0;
		_testObject.position = _touchPosition;

	}

	private void OnEnable()
	{
		Debug.Log($"Enabled");
		_touchPosAction.Enable();
		_touchPosAction.performed += TouchPressed;
	}

	private void OnDisable()
	{
		Debug.Log($"Disabled");
		_touchPosAction.performed -= TouchPressed;
		_touchPosAction.Disable();
	}
	private void TouchPressed(InputAction.CallbackContext context)
	{
	}
}
