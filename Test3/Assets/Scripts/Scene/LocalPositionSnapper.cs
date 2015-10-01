using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LocalPositionSnapper : MonoBehaviour
{
    private Transform tfm = null;
	
	private void LateUpdate()
	{
        if (this.tfm == null)
        {
            this.tfm = this.GetComponent<Transform>();
        }

        this.tfm.localPosition = new Vector3(Mathf.Round(this.tfm.localPosition.x), Mathf.Round(this.tfm.localPosition.y), Mathf.Round(this.tfm.localPosition.z));
	}
}
