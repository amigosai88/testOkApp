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
			if(GameController.Instance.levelController.GetBombsCount() < 1)
				return;

			m_dragStarted = true;
			m_draggedIcon.gameObject.SetActive(true);
		}

		public void OnDrag(PointerEventData eventData)
		{
			if(!m_dragStarted)
				return;

			if(GameController.IsPaused)
			{
				m_dragStarted = false;
				m_draggedIcon.gameObject.SetActive(false);
				return;
			}

			m_draggedIcon.transform.position = new Vector3(eventData.position.x, eventData.position.y, 0f);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if(!m_dragStarted || GameController.IsPaused)
				return;

			m_dragStarted = false;
			m_draggedIcon.gameObject.SetActive(false);
			GameController.Instance.levelController.UseBomb(eventData.position);
		}
	}
}