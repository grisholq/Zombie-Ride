using UnityEngine;

public class ZombieMovement
{
    private Rigidbody rigidbody;
    private Transform transform;
    
    public ZombieMovement(Transform transform, Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }
    
    public void Move(Vector3 movement)
    {
        rigidbody.MovePosition(transform.position + movement);
    }
}