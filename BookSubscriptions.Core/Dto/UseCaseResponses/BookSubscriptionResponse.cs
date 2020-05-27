using System.Collections.Generic;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Interfaces;

namespace BookSubscriptions.Core.Dto.UseCaseResponses
{
    public class BookSubscriptionResponse : UseCaseResponseMessage
    {
        public IEnumerable<int> BookIdList { get; }
        public IEnumerable<Error> Errors { get; }

        public BookSubscriptionResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public BookSubscriptionResponse(IEnumerable<int> bookIdList, bool success = false, string message = null) : base(success, message)
        {
            BookIdList = bookIdList;
        }
    }
}
