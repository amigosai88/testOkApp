using UnityEngine;
using System.Collections;



namespace OAT
{
	public class UnitModel : MonoBehaviour 
	{
		public UnitView unitView;
		public UnitController unitController;

		public void KillUnit()
		{
			unitView.KillUnit();
			StartCoroutine(DestroyAfterDelay(0.5f));
		}

		IEnumerator DestroyAfterDelay(float delay)
		{
			yield return new WaitForSeconds(delay);
			Destroy(this.gameObject);
		}
	}
}