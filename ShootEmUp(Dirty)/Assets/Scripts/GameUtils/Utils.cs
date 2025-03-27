using System.Collections.Generic;
using ShootEmUp;
using UnityEngine;

public static class Utils
{
	public const float NOT_INITIALIZED_DEFAULT_TIME = -1;

	public static bool InBounds(this Vector3 position,
		float leftBorder,
		float rightBorder,
		float downBorder,
		float topBorder)
	{
		var positionX = position.x;
		var positionY = position.y;
		return positionX > leftBorder
				&& positionX < rightBorder
				&& positionY > downBorder
				&& positionY < topBorder;
	}

	public static CharacterEntity GetMyPlayer(this List<CharacterEntity> entities)
	{
		foreach (var characterEntity in entities)
		{
			if (characterEntity.TeamComponent.IsPlayer)
				return characterEntity;
		}

		Debug.LogError("can't find our player!");
		return null;
	}

	public static Vector3 RandomPosition(this Vector3[] positions)
	{
		var index = Random.Range(0, positions.Length);
		return positions[index];
	}

	public static void MoveByRigidbodyVelocity(this Rigidbody2D rigidbody2D, Vector2 vector, float speed)
	{
		var nextPosition = rigidbody2D.position + vector * speed;
		rigidbody2D.MovePosition(nextPosition);
	}
}