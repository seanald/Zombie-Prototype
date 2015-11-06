using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraOrthoSize : MonoBehaviour
{
    [SerializeField]
    private Camera gameCamera;
    [SerializeField]
    private int zoom = 1;

	void Start()
	{
		gameCamera = Camera.main;
	}

	private void LateUpdate()
	{
        this.gameCamera.orthographicSize = (790 / 2) / this.zoom;
	}
}
