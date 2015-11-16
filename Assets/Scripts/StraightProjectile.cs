using UnityEngine;
using System.Collections;

public class StraightProjectile : BulletDesu {
	public float projectileSpeed=0; //for spell that shoot something out
	protected GameObject entity;
	private Vector3 clonePosition;
	private Vector3 cloneVelocity;
	private Quaternion cloneOrientation;
	private Direction direction;
	private GameObject bulletToClone;

	public override void execute(GameObject g) {
		entity = g;
		bulletToClone = gameObject;
		if (entity == null){entity = GameObject.FindGameObjectWithTag("Entity");}
		createProjectile (0.25f, 0, 0, 0);
	}
	public override void setDirection(Direction d) {
		direction = d;
	}

	public void createProjectile(float xPos, float yPos, float rotation, float angle) {
		if (direction == Direction.left) {
			clonePosition = entity.transform.position + new Vector3(-xPos, yPos, 0);
			cloneVelocity = new Vector3 (-projectileSpeed, angle, 0);
			cloneOrientation = Quaternion.Euler(0, 0, rotation + 180);
		}
		else if (direction == Direction.right) {
			clonePosition = entity.transform.position + new Vector3(xPos,yPos,0);
			cloneVelocity = new Vector3 (projectileSpeed, angle, 0);
			cloneOrientation = Quaternion.Euler(0, 0, rotation);
		}
		GameObject clonedesu = cloneObject(bulletToClone, clonePosition, cloneVelocity, cloneOrientation);
	//	Physics2D.IgnoreCollision (clonedesu.collider2D, entity.collider2D);
		Destroy (clonedesu,projectileDuration);
	}

	public static GameObject cloneObject (GameObject bulletToClone, Vector3 placetoCreate, Vector3 velocity, Quaternion orientation)
	{		
		GameObject clonedesu = (GameObject)ScriptableObject.Instantiate (bulletToClone, placetoCreate, orientation);
		//Debug.Log("poops: " + clonedesu);
		if (clonedesu.GetComponent<Rigidbody2D>()) {
			clonedesu.GetComponent<Rigidbody2D>().velocity = velocity;
			//Debug.Log ("poop da doops");
		}
		if(clonedesu.GetComponent<AudioSource>())
		{
			clonedesu.GetComponent<AudioSource>().Play();
		}
		return clonedesu;
	}
}
