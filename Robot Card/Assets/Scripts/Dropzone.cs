using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

	public Draggable.Player playerNum = Draggable.Player.UNDEFINED;

	public void OnPointerEnter(PointerEventData eventData)
	{
		//Debug.Log("OnPointerEnter");
		if (eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null)
		{
			if (playerNum == d.playerNum)
			{
				if (!this.gameObject.tag.Equals("Playzone"))
				{
					d.placeholderParent = this.transform;
				}
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//Debug.Log("OnPointerExit");
		if (eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null && d.placeholderParent == this.transform)
		{
			d.placeholderParent = d.parentToReturnTo;
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null)
		{
			if (playerNum == d.playerNum)
			{
				if (this.gameObject.tag.Equals("Playzone"))
				{
					if(this.transform.childCount > 0)
					{
						this.GetComponentInChildren<Draggable>().UpdateCard(d.parentToReturnTo, d.placeHolder.transform.GetSiblingIndex());
					}
					d.parentToReturnTo = this.transform;
				}
				else
				{
					d.parentToReturnTo = this.transform;
				}
			}
		}

	}

}
