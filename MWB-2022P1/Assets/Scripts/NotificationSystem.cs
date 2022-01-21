using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class NotificationSystem : MonoBehaviour
{
    public static NotificationSystem instance;
    public List<Notification> notificationList = new List<Notification>();
    public float notiTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        notiTime += Time.deltaTime;
    }
    public Notification CreateNotification(string text, Sprite icon, Notification.NotiType type)
    {
        Notification noti = new Notification();
        noti.text = text;
        noti.icon = icon;
        noti.type = type;
        noti.timestamp = notiTime;

        return noti;
    }
    public void RecieveNotification(Notification noti)
    {
        //Adds Notification to Global List
        notificationList.Add(noti);
        Debug.Log(noti.timestamp + ": " + noti.text);
    }
}

public class Notification
{
    public string text;
    public Sprite icon;
    public enum NotiType
    {
        Null,
        Alert,
        Warning,
        Message,
        Inventory
    }
    public NotiType type;
    public float timestamp;
}
