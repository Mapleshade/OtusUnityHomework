using System.Collections.Generic;

namespace ShootEmUp
{
	public class EnemiesModel
	{
		private readonly List<EnemyCharacterEntity> _activeEnemies = new();

		public List<EnemyCharacterEntity> ActiveEnemies => _activeEnemies;
	}
}