using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraOrthoSize : MonoBehaviour
{
    [SerializeField]
    private Camera gameCamera = Camera.main;
    [SerializeField]
    private int zoom = 1;

	private void LateUpdate()
	{
        this.gameCamera.orthographicSize = (540 / 2) / this.zoom;
	}
}
