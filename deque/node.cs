namespace node
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }

        public T Data { get; set; }
        public DoublyNode<T> Prev { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
}
