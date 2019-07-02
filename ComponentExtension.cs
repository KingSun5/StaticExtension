using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// time:2019/5/8
/// author:Sun
/// des:Transfom_静态类拓展
/// </summary>
public static class ComponentExtension {

	/// <summary>
	/// 为组件添加监听事件
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="eventTriggerType"></param>
	/// <param name="callback"></param>
	/// <returns></returns>
	public static void AddListener(this Component obj,EventTriggerType eventTriggerType,UnityAction<BaseEventData> callback)
	{
		//添加EventTrigger组件
		EventTrigger trigger = obj.GetComponent<EventTrigger>();
		if (trigger == null)
		{
			trigger = obj.gameObject.AddComponent<EventTrigger>();
		}
		
		//获取事件列表
		List<EventTrigger.Entry> entries = trigger.triggers;
		if (entries==null)
		{
			entries = new List<EventTrigger.Entry>();
		}
		//获取对应事件
		EventTrigger.Entry entry = new EventTrigger.Entry();
		bool isExist = false;
		for (int i = 0; i < entries.Count; i++)
		{
			if (entries[i].eventID == eventTriggerType)
			{
				entry = entries[i];
				isExist = true;
			}
		}
		entry.callback.AddListener(callback);
		if (!isExist)
		{
			entry.eventID = eventTriggerType;
			trigger.triggers.Add(entry);
		}
	}

}
