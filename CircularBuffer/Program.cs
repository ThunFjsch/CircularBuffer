using Buffer.Model;

namespace Buffer
{
    public class Program
    {
        public static void Main()
        {
            CircularBuffer<string> circularBuffer = new CircularBuffer<string>();

            try
            {
                circularBuffer.Write("Hello,");
                circularBuffer.Write("World!");


                Console.WriteLine(circularBuffer.Read());
                Console.WriteLine(circularBuffer.Read());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}