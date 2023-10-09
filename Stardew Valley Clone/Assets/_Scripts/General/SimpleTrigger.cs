using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{
	public Action<Transform> onTriggerEnter;
	public Action<Transform> onTriggerExit;
	
	[TagSelector] [SerializeField] private string _tag = "";
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(_tag))
		{
			onTriggerEnter?.Invoke(other.transform);
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag(_tag))
		{
			onTriggerExit?.Invoke(other.transform);
		}
	}
}
