

using System;

namespace BookSubscriptions.Core.Dto
{
    public sealed class Error
    {
        private Type type;
        private object mexssage;

        public string Code { get; }
        public string Description { get; }

        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public Error(Type type, object mexssage)
        {
            this.type = type;
            this.mexssage = mexssage;
        }
    }
}
