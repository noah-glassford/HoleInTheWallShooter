using UnityEngine;

public class MakePassthrough : MonoBehaviour
{
  public bool UpdateTransform = false;

  void Start()
  {
    GameObject ovrCameraRig = GameObject.Find("OVRCameraRig");
    OVRPassthroughLayer layer = ovrCameraRig.GetComponent<OVRPassthroughLayer>();
    layer.AddSurfaceGeometry(gameObject, UpdateTransform);

    // Disable the mesh renderer to avoid rendering the surface within Unity
    MeshRenderer mr = GetComponent<MeshRenderer>();
    if (mr)
    {
      mr.enabled = false;
    }
  }
}
