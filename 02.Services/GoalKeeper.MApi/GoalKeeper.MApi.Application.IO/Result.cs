using System.Collections.Generic;

namespace GoalKeeper.MApi.Application.IO
{
    public class Result<T>
    {
        public Result(T data)
        {
            Data = data;
        }

        //[JsonConstructor]
        //public Result(T data, List<string> messages)
        //    : this(data)
        //{
        //    Messages = messages;
        //}

        public T Data { get; }

        public List<string> Messages { get; } = new List<string>();
    }
}
