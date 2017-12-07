using UnityEngine;

public interface IColliderService
{

    Bounds GetBounds();
}

public class UnityColliderService : IColliderService
{
    Collider collider;

    public Bounds GetBounds(){
        return collider.bounds;
    }

    public UnityColliderService(Collider col)
    {
        collider = col;
    }
}