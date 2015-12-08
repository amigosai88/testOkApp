using UnityEngine;
using System.Collections;



namespace OAT
{
	public class UnitModel : MonoBehaviour 
	{
		public UnitView unitView;
		public UnitController unitController;
		public BaseUnitMove unitMove;

		public void KillUnit()
		{
			unitMove.StopMoving();
			unitView.KillUnit();
			StartCoroutine(DestroyAfterDelay(0.5f));
		}

		IEnumerator DestroyAfterDelay(float delay)
		{
			yield return new WaitForSeconds(delay);
			GameController.Instance.levelController.RemoveUnitFromActive(this);
			Destroy(this.gameObject);
		}

		public void UnitStopped()
		{
			GameController.Instance.levelController.DemagePlayer();
			StartCoroutine(DestroyAfterDelay(0.5f));
		}
	}
}