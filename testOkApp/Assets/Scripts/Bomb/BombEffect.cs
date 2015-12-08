using UnityEngine;
using System.Collections;

namespace OAT
{
	public class BombEffect : MonoBehaviour
	{
		public Transform bombField;

		void Update()
		{
			bombField.localScale += Vector3.one * GameConfig.BOMB_SPEED;
			if(bombField.localScale.x >= GameConfig.BOMB_RADIUS)
				Destroy(this.gameObject);
		}
	}
}