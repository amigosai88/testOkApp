using UnityEngine;
using System.Collections;

namespace OAT
{
	public class BombEffect : MonoBehaviour
	{
		public Transform bombField;

		void OnTriggerEnter(Collider other)
		{
			UnitController unit = other.gameObject.GetComponent<UnitController>();
			if(unit != null)
				unit.unitModel.unitController.RemoveController();
		}

		void Update()
		{
			bombField.localScale += Vector3.one * GameConfig.BOMB_SPEED;
			if(bombField.localScale.x >= GameConfig.BOMB_RADIUS)
				Destroy(this.gameObject);
		}
	}
}