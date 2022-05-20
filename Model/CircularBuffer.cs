using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffer.Model
{
    class CircularBuffer<T>
    {
        #region variables
        private const int defaultBufferSize = 5;    // Default Buffer size
        private int writeAmount;  // Amount writes
        #endregion

        #region properties
        public T[] bufferItems { get; private set; }    // Array of the Buffer Items
        public int writer { get; private set; }     // write index
        public int reader { get; private set; }     // read index
        #endregion

        #region constructors
        public CircularBuffer(): this(defaultBufferSize) {}

        public CircularBuffer(int initualizedBufferSize)
        {
            this.bufferItems = new T[initualizedBufferSize];
            this.writeAmount = 0;
            this.writer = 0;
            this.reader = 0;
        }
        #endregion

        #region methods
        public void Write(T value)
        {
            // When writeAmount matches the Buffer size, the Buffer is full
            if (this.writeAmount == bufferItems.Length)
            {
                throw new Exception("Buffer is full");
            }

            this.bufferItems[this.writer++] = value;    // Writes new value to the Buffer index of writer
            this.writer %= this.bufferItems.Length;     // Writer Index is set via the carry value
            this.writeAmount++;     // writeAmount gets increased
        }

        public T Read()
        {
            // When writeAmount is zero, then no values have been written to the Buffer
            if(this.writeAmount == 0)
            {
                throw new Exception("Buffer is empty");
            }

            T bufferItem = this.bufferItems[this.reader++];     // The item to read is accessed via the reader index
            this.reader %= this.bufferItems.Length;     // Reader Index is set via the carry value
            this.writeAmount--;     // After every read the writeAmount gets decreased, to detect if the Buffer is empty
            return bufferItem;
        }
        #endregion


    }
}
