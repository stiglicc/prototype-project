using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null) { 
            Debug.Log("More than 1 of inventory's found");
             return; 
        }

            instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 20;

    public List<Item> items = new List<Item>();
    public void Add (Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough space");

            return;
        }
        items.Add(item);
        if(onItemChangedCallBack!=null)
        onItemChangedCallBack.Invoke();  
    }
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
