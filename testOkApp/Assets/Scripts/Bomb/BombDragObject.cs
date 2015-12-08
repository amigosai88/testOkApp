using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace OAT
{
	public class BombDragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public Transform m_draggedIcon;
		bool m_dragStarted;

		public void OnBeginDrag(PointerEventData eventData)
		{

			m_dragStarted = true;
			m_draggedIcon.gameObject.SetActive(true);
		}

		public void OnDrag(PointerEventData eventData)
		{
			if(!m_dragStarted)
				return;

			m_draggedIcon.transform.position = Camera.main.ScreenToWorldPoin(new Vector3(eventData.position.x, eventData.position.y, 0f));
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if(!m_dragStarted)
				return;

			m_dragStarted = false;
			m_draggedIcon.gameObject.SetActive(false);
			GameController.Instance.levelController.UseBomb();
		}
	}
}