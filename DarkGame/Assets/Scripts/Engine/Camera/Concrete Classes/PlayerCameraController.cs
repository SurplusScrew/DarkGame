using UnityEngine;
public class PlayerCameraController
{
	public float RotationSpeed;
	public float XLimit;

	public PlayerCameraController(ref float RotationSpeed, ref float XLimit)
	{
		this.RotationSpeed = RotationSpeed;
		this.XLimit = XLimit;
	}

    public Quaternion Rotate(Quaternion startingOrientation, Vector2 cameraInput)
    {
		return Quaternion.Euler( GetLimitedCameraRotation( startingOrientation, cameraInput ));
    }

    public Vector3 GetLimitedCameraRotation(Quaternion startingOrientation, Vector2 cameraInput)
    {
		Vector3 rotationAroundPlayer = new Vector3( cameraInput.y, cameraInput.x, 0 );

        Vector3 intendedAngle = startingOrientation.eulerAngles + ( rotationAroundPlayer * RotationSpeed );

		return LimitAngle( intendedAngle );
    }


	public Vector3 LimitAngle(Vector3 angleToLimit)
	{
		if( angleToLimit.x > XLimit &&
			angleToLimit.x <  360 - XLimit )
		{
			if (angleToLimit.x > 180)
			{
				angleToLimit.x = 360-XLimit;
			}
			else
			{
				angleToLimit.x = XLimit;
			}
		}
		return angleToLimit;
	}

    public Vector3 CalculateNewCameraPosition(Vector3 startPosition, Vector3 targetPosition, float lerpSpeed)
    {
        return Vector3.Lerp(startPosition, targetPosition, lerpSpeed);
    }
}