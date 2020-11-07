using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
 	private float scrollSpeed = -.1f;
    Vector2 startPos;
	//private Renderer rend;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
        //rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {

        float newPos = Mathf.Repeat (Time.time * scrollSpeed, 20);
        transform.position = startPos + Vector2.right * newPos;
		/*float offset = Time.time * scrollSpeed;
		// texture offsets shift how the texture is drawn onto the 3D object, skewing its
		// UV coordinates; this results in a scrolling effect when applied on one axis
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
		//rend.material.SetTextureOffset("_BumpMap", new Vector2(offset, 0));
        */
	}
}
