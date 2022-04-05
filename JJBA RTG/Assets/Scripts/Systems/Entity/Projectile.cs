using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : Stats
{
	public Hitbox box;
	public Timer lifeTime;
	internal Rigidbody rb;
	
	internal override void Start()
	{
		base.Start();
		lifeTime.Start();

		rb = GetComponent<Rigidbody>();
		transform.SetParent(null);
	}
	
	internal virtual void FixedUpdate()
	{
		lifeTime.UpdateTimer();
		if (stopped) return;
		
		if(lifeTime.complete)	Destroy(gameObject);
		if(box.parent != null) Atk();
		
		Move();
	}
	
	public virtual void Atk()
	{
		if(box.AtkProjectile(damageMultiplier))	Destroy(gameObject);
	}
	
	public virtual void Move()
	{
		rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
	}

	internal virtual void DrawBoxes(){
		box.DrawHitBox();
	}

	void OnDrawGizmosSelected()
	{
		DrawBoxes();
	}	
}