using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public sealed class GameLifeTimeSystem : MonoBehaviour
	{
		[Inject]
		public List<IFixedUpdate> FixedUpdates { get; } = new();
		[Inject]
		public List<IUpdate> Updates { get; } = new();

		private void Update()
		{
			foreach (var update in Updates)
				update.CustomUpdate();
		}

		private void FixedUpdate()
		{
			foreach (var fixedUpdate in FixedUpdates)
				fixedUpdate.CustomFixedUpdate();
		}
	}
}