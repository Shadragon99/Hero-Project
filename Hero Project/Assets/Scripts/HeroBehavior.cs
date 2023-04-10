using UnityEngine;	
using System.Collections;

public class HeroBehavior : MonoBehaviour {

	public float kHeroSpeed = 20f;
    public GameObject mEgg = null;
	private const float kHeroRotateSpeed = 90f/2f; // 90-degrees in 2 seconds
    public float maxdown;
    public float cdown;
	// Use this for initialization
	void Start () {
        if (mEgg == null)
            mEgg = Resources.Load("Prefabs/Egg") as GameObject;

        cdown = maxdown;
	}
	
	// Update is called once per frame
	void Update () {
        #region motion control
        transform.position += Input.GetAxis ("Vertical")  * transform.up * (kHeroSpeed * Time.smoothDeltaTime);
        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (kHeroRotateSpeed * Time.smoothDeltaTime));
        #endregion

        GlobalBehavior.sTheGlobalBehavior.ObjectClampToWorldBound(this.transform);

        if(Input.GetKey(KeyCode.Space) && cdown <= 0)
        {
            Instantiate(mEgg, transform.position, transform.rotation);
            cdown = maxdown;
        }
        if(cdown > 0)
        {
            cdown -= Time.deltaTime;
        }

        if (Input.GetKey("space"))  // VS. GetKeyDown <<-- even, one per key press
        { // space bar hit
            GameObject e = Instantiate(mEgg) as GameObject;
            EggBehavior egg = e.GetComponent<EggBehavior>(); // Shows how to get the script from GameObject
            if (null != egg)
            {
                e.transform.position = transform.position;
            }
        }

    }
}
