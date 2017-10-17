using UnityEngine;

public interface IRigidbodyService
{
    bool useGravity {get;set;}
    Vector3 velocity{get;set;}

    void AddForce(Vector3 position, ForceMode ForceMode);
}

public class UnityRigidbodyService : IRigidbodyService
{
    private Rigidbody Rigidbody;

    public bool useGravity
    {
        get{return Rigidbody.useGravity;}
        set{Rigidbody.useGravity = value;}
    }

    public Vector3 velocity
    {
        get{return Rigidbody.velocity;}
        set{Rigidbody.velocity = value;}
    }

    public UnityRigidbodyService(Rigidbody rigidbody)
    {
        Rigidbody = rigidbody;
    }
    public void AddForce(Vector3 position, ForceMode ForceMode)
    {
        Rigidbody.AddForce(position, ForceMode);
    }

}