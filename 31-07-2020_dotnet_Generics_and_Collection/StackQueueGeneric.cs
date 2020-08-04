using System;

class Stack_gen<T>
{
    int max_size;
    int curr_size;
    int top;
    T[] arr;
    public Stack_gen(int size)
    {
        max_size = size;
        curr_size = 0;
        arr = new T[size];
        top = -1;
    }

    public void gettop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is empty!!");
            return ;
        }
        Console.WriteLine("Value at the top of stack is : "+arr[top]);
    }

    public void removetop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is already empty!!");
            return;
        }
        Console.WriteLine("Data removed from stack top: " + arr[top]);
        top = top - 1;
    }
    
    public void push(T data)
    {
        if (top == max_size-1)
        {
            Console.WriteLine("Stack has reached it's max limit!!");
        }
        top = top + 1;
        arr[top] = data;
        Console.WriteLine("Data Entered in Stack: " + data);
    }

    public int getsize()
    {
        return top+1;
    }
}

class Queue_gen<T>
{
    int max_size;
    int curr_size;
    T[] arr;
    public Queue_gen(int size)
    {
        max_size = size;
        curr_size = 0;
        arr = new T[size];
    }

    public void front()
    {
        if(curr_size==0){
            Console.WriteLine("Queue is empty!!");
        }
        Console.WriteLine("Element at the front of queue is: "+arr[0]);
    }

    public void removefront()
    {
        if (curr_size == 0)
        {
            Console.WriteLine("Queue is empty!!");
        }
        Console.WriteLine("Data removed from queue front: " + arr[0]);
        curr_size = curr_size - 1;
        int i = 0;
        while (i<curr_size)
        {
            arr[i] = arr[i + 1];
            i++;
        }
    }

    public void push(T data)
    {
        if (curr_size == max_size)
        {
            Console.WriteLine("Queue has reached it's max limit!!");
            return;
        }
        arr[curr_size] = data;
        curr_size = curr_size + 1;
        Console.WriteLine("Data Entered in Queue: " + data);
    }

    public int getsize()
    {
        return curr_size;
    }
}

public class SQ_gen
{
    public static void Main(string [] args)
    {
        Stack_gen<int> s = new Stack_gen<int>(6);
        Queue_gen<char> q = new Queue_gen<char>(5);
        s.push(1);
        s.push(2);
        s.push(3);
        s.push(4);
        s.push(5);
        s.removetop();
        s.gettop();
        s.push(6);
        s.push(7);
        s.getsize();

        q.push('a');
        q.push('b');
        q.push('c');
        q.push('d');
        q.push('e');
        q.push('f');
        q.front();
        q.removefront();
        q.front();
        q.getsize();
    }
}
    