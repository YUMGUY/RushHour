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

    public void insert(Monster m)
    {
        queue.Insert(getSize(), m);
        size++;
    }

    public void remove(int index)
    {
        queue.RemoveAt(index);
    }

}
