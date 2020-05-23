using Microsoft.AspNetCore.Mvc;

namespace BookSubscriptions.Presenters
{
  public sealed class JsonContentResult : ContentResult
  {
    public JsonContentResult()
    {
      ContentType = "application/json";
    }
  }
}
