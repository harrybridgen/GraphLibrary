using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> {
    public Node? Head { get; private set; }
    public Node? Tail { get; private set; }
    public int Count { get; private set; }

    public class Node {
        public T? Data { get; set; }
        public Node? Next { get; internal set; }
        public Node? Prev { get; internal set; }
        public Node(T data) => Data = data;
    }

    public void Append(T data) {
        var newNode = new Node(data);
        if (Head == null) {
            Head = Tail = newNode;
        }
        else {
            Tail!.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }
        Count++;
    }

    public void Prepend(T data) {
        var newNode = new Node(data);
        if (Head == null) {
            Head = Tail = newNode;
        }
        else {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }
        Count++;
    }

    public void RemoveNode(T Data) {
        Node? Current = Head;
        while(Current != null) {
            if (Current.Data == null) {
                return;
            }
            if (Current.Data.Equals(Data)) {
                if (Current == Head) {
                    RemoveHead();
                }
                else if (Current == Tail) {
                    RemoveTail();
                }
                else {
                    Current.Prev.Next = Current.Next;
                    Current.Next.Prev = Current.Prev;
                    Count--;
                }
                return;
            }
            Current = Current.Next;
        }
    }

    public T? PeekHead() => Head is null ? default : Head.Data;
    public T? PeekTail() => Tail is null ? default : Tail.Data;

    public void RemoveHead() {
        if (Head == null) return;

        var oldHead = Head;
        if (Head == Tail) {
            Head = Tail = null;
        }
        else {
            Head = oldHead.Next;
            Head!.Prev = null;
            oldHead.Next = null;
        }
        Count--;
    }

    public void RemoveTail() {
        if (Tail == null) return;

        var oldTail = Tail;
        if (Head == Tail) {
            Head = Tail = null;
        }
        else {
            Tail = oldTail.Prev;
            Tail!.Next = null;
            oldTail.Prev = null;
        }
        Count--;
    }

    public void Clear() {
        while (Head != null) {
            RemoveHead();
        }
    }

    public void Print() {
        if (Head == null) {
            Console.WriteLine("LinkedList is empty.");
            return;
        }

        var current = Head;
        while (current != null) {
            Console.Write(current.Data);
            if (current.Next != null) {
                Console.Write(" <-> "); // show link
            }
            current = current.Next;
        }
        Console.WriteLine(); // newline after printing all nodes
    }

}