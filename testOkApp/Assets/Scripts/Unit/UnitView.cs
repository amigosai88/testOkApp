using UnityEngine;
using System.Collections;


namespace OAT
{
	public class UnitView : MonoBehaviour 
	{
		public UnitModel unitModel;
		public MeshRenderer meshRenderer;
		public GameObject deathEffectPrefab;

		public void KillUnit()
		{
			Instantiate(deathEffectPrefab).transform.position = transform.position;
			gameObject.SetActive(false);
		}
	}
}