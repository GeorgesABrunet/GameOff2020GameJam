using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
 	private float scrollSpeed = .05f;
	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		float offset = Time.time * scrollSpeed;
		// texture offsets shift how the texture is drawn onto the 3D object, skewing its
		// UV coordinates; this results in a scrolling effect when applied on one axis
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
		//rend.material.SetTextureOffset("_BumpMap", new Vector2(offset, 0));
	}
}
