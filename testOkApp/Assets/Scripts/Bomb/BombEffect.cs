using UnityEngine;
using System.Collections;

namespace OAT
{
	public class BombEffect : MonoBehaviour
	{
		void OnTriggerEnter(Collider other)
		{
			UnitController unit = other.gameObject.GetComponent<UnitController>();
			if(unit != null)
				unit.unitModel.unitController.RemoveController();
		}

		void Update()
		{
			transform.localScale += Vector3.one * GameConfig.BOMB_SPEED;

			if(transform.localScale.x >= GameConfig.BOMB_RADIUS)
				Destroy(this.gameObject);
		}
	}
}