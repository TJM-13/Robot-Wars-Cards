using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Transform parentToReturnTo = null;
	GameObject placeHolder = null;
	public Transform placeholderParent = null;
	Vector2 offset;

	public void OnBeginDrag(PointerEventData eventData)
	{
		offset = eventData.position  - new Vector2(this.transform.position.x, this.transform.position.y);
		placeHolder = Instantiate(this.gameObject);
		placeHolder.transform.SetParent(this.transform.parent);
		placeHolder.GetComponent<Image>().color = Color.clear;
		for (int j = 0; j < placeHolder.transform.childCount; j++)
		{
			placeHolder.transform.GetChild(j).gameObject.SetActive(false);
		}
		placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent(this.transform.parent.parent);
		
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		this.transform.position = eventData.position - offset;
		if (placeHolder.transform.parent != placeholderParent)
			placeHolder.transform.SetParent(placeholderParent);

		int newSiblingIndex = placeholderParent.childCount;

		for (int i = 0; i < placeholderParent.childCount; i++)
		{
			if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
			{

				newSiblingIndex = i;

				if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeHolder.transform.SetSiblingIndex(newSiblingIndex);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.SetParent(parentToReturnTo);
		this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		Destroy(placeHolder);
	}
}
