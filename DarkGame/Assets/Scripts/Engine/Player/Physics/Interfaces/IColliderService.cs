using UnityEngine;

public interface IColliderService
{
    Bounds bounds{get;}
}

public class UnityColliderService : IColliderService
{
    Collider collider;

    public Bounds bounds{
        get{ return collider.bounds;}
    }

    public UnityColliderService(Collider col)
    {
        collider = col;
    }
}