using System;
using System.Collections.Generic;

namespace DSA.Lab04B
{
    /// <summary>
    /// Priority queue implemented with a binary min-heap.
    ///
    /// Invariant:
    /// each parent's Priority is <= the Priority of each of its children.
    ///
    /// The heap is NOT fully sorted.
    /// </summary>
    public sealed class BinaryHeapDispatchQueue<T>
    {
        private readonly List<PriorityEntry<T>> _heap = new List<PriorityEntry<T>>();

        public int Count => _heap.Count;

        public void Enqueue(T item, int priority)
        {
            _heap.Add(new PriorityEntry<T>(item, priority));
            SiftUp(_heap.Count - 1);
        }

        public PriorityEntry<T> PeekNext()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            return _heap[0];
        }

        public PriorityEntry<T> DequeueNext()
        {

            if( _heap.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            PriorityEntry<T> result = _heap[0];
            int lastIndex = _heap.Count - 1;

            if(lastIndex == 0)
            {
                _heap.RemoveAt(0);
                return result;
            }

            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            SiftDown(0);
            return result;

        }

        private void SiftUp(int index)
        {

            while(index >= 0)
            {
                int parentIndex = ParentIndex (index);

                if (_heap[index].Priority >= _heap[parentIndex].Priority)
                {
                    break;
                }

                Swap(index, parentIndex);
                index = parentIndex;
            }

        }

        private void SiftDown(int index)
        {

            while (true)
            {
                int leftChild = LeftChildIndex (index);
                int rightChild = RightChildIndex (index);
                int smallestIndex = index;

               if(leftChild < _heap.Count && _heap[leftChild].Priority < _heap[smallestIndex].Priority)
                {
                    smallestIndex = leftChild;
                }

               if(rightChild < _heap.Count && _heap[rightChild].Priority < _heap[smallestIndex].Priority)
                {
                    smallestIndex = rightChild;
                }

               if(smallestIndex == index)
                {
                    break;
                }

                Swap(index, smallestIndex);
                index = smallestIndex;

            }

            // TODO:
            // Compare the current entry with its children.
            // If a child should come first, swap with the smaller-priority child.
        }

        private static int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int a, int b)
        {
            PriorityEntry<T> temp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = temp;
        }
    }
}
