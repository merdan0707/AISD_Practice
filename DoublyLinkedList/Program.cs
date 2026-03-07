namespace DoublyLinkedList;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new[] { 1, 2, 3, 4, 5 };
        DoublyList<int> doublyList = new DoublyList<int>(arr);
        doublyList.Add(6);
        doublyList.Add(7);
        doublyList.AddFirst(0);
        doublyList.AddFirst(-1);
        doublyList.AddFirst(-2);
        doublyList.Print();
        
        doublyList.AddPosition(3,1804);
        int [] arr2 = new[] { 10,20,30 };
        doublyList.AddRange(arr2);
        doublyList.Print();
        
        doublyList.RemoveInPosition(3);
        doublyList.Print();
    }
}