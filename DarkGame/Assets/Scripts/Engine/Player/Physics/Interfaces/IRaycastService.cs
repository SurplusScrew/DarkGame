using UnityEngine;

public interface IRaycastService
{
    bool HasHitSomething( Vector3 startPosition, Vector3 Direction, float length );

    Collider ColliderOfHitObject( Vector3 startPosition, Vector3 Direction, float length );

}

public class UnityRaycastService : IRaycastService
{
    public UnityRaycastService(){}
    private void DoRaycast (out RaycastHit hit, Vector3 startPosition, Vector3 Direction, float length)
    {
        Ray ray = new Ray(startPosition, Direction);
        Physics.Raycast(ray, out hit, length);
    }
    public bool HasHitSomething( Vector3 startPosition, Vector3 Direction, float length )
    {
        RaycastHit hit;
        Debug.DrawRay(startPosition, Direction * length, Color.red, 10f );
        DoRaycast(out hit, startPosition, Direction, length);
        return hit.collider != null;
    }

    public Collider ColliderOfHitObject( Vector3 startPosition, Vector3 Direction, float length )
    {
        RaycastHit hit;
        DoRaycast(out hit, startPosition, Direction, length);
        return hit.collider;
    }
}