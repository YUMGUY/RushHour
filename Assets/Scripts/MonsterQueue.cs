using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterQueue : MonoBehaviour
{
    // Start is called before the first frame update
    List<Monster> queue;
    private int size;
    void Start()
    {
        queue = new List<Monster>();
        size = 0;
    }

    public void increaseAllTimeWaiting(float time)
    {
        for (int i = 0; i < size; i++)
        {
            queue[i].increaseTimeWaiting(time);
        }
    }

    public float getTotalTimeWaiting()
    {
        float total = 0;
        for (int i = 0; i < size; i++)
        {
            total += queue[i].getTimeWaiting();
        }

        return total;
    }

    public float getTimeWaiting(int index)
    {
        return queue[index].getTimeWaiting();
    }

    public int getSize()
    {
        return size;
    }

    public void insert(int index, Monster m)
    {
        queue.Insert(index, m);
        size++;
    }

    /*
    public void remove(int index)
    {
        queue[index].moveOffScreen();
        // Destroy(queue[index].gameObject);
        queue[index].barChair.GetComponent<seatProperties>().seatOpen = true;
        queue.RemoveAt(index);
        size--;
    }
    */

    public float getIrritationFactor(int index)
    {
        return queue[index].getIrritationFactor();
    }

    public MonsterDrink getDrink(int index)
    {
        return queue[index].getMonsterDrink();
    }

    public Transform getMonsterTransform(int index)
    {
        return queue[index].gameObject.transform;
    }

    public void replace(int index, Monster m)
    {
        queue[index].moveOffScreen();
        queue[index].barChair.GetComponent<seatProperties>().seatOpen = true;
        queue[index] = m;
    }

}
