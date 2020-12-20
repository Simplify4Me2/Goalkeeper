using System.Collections.Generic;

namespace GoalKeeper.Common.Application.IO
{
    public class Result<T>
    {
        public Result(T data)
        {
            Data = data;
        }

        public T Data { get; }

        public List<string> Messages { get; } = new List<string>();
    }
}
