using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 20f;
	private Bounds Boundary;
	private Vector3 area;
	
	// Use this for initialization
	void Start () {
		NewDirection();
		Boundary = GlobalBehavior.getBoundary;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (mSpeed * Time.smoothDeltaTime) * transform.up;
		GlobalBehavior globalBehavior = GameObject.Find ("GameManager").GetComponent<GlobalBehavior>();
		
		GlobalBehavior.WorldBoundStatus status =
			globalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
			
		if (status != GlobalBehavior.WorldBoundStatus.Inside) {
			Debug.Log("collided position: " + this.transform.position);
			NewDirection();
		}

		updateBounds();
	}

	// New direction will be something completely random!
	private void NewDirection() {
		Vector2 v = Random.insideUnitCircle;
		transform.up = new Vector3(v.x, v.y, 0.0f);
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Egg" || col.gameObject.tag == "GreenUp")
		{
			transform.position = new Vector3(Random.Range(Boundary.min.x, Boundary.max.x), Random.Range(Boundary.min.y, Boundary.max.y), 0);
			Debug.Log(Boundary.min.x);
		}
	}

	private void updateBounds()
	{
		area = GlobalBehavior.getBoundary.size;
		area.x *= 0.85f;
		area.y *= 0.85f;
		Boundary = new Bounds(GlobalBehavior.getBoundary.center, area);
	}
}
