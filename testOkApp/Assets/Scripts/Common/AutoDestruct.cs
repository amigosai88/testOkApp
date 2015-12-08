using UnityEngine;
using System.Collections;

namespace OAT
{
	public class AutoDestruct : MonoBehaviour 
	{
		public float delay = 0.5f;

		void Update () 
		{
			delay -= Time.deltaTime;
			if(delay < 0f)
				Destroy(this.gameObject);
		}
	}
}