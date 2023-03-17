using System;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Glaubers.Tcc.Api.Functions.Functions
{
    public static class TesteFunction
    {
        [FunctionName("Teste-Get")]
        public static IActionResult Get([HttpTrigger(AuthorizationLevel.Function, "get", Route = "teste/get")] HttpRequest req)
        {
            return new OkObjectResult("Teste Get");
        }

        [FunctionName("Teste-GetByID")]
        public static IActionResult GetByID([HttpTrigger(AuthorizationLevel.Function, "get", Route = "teste/get/{id}")] HttpRequest req, Guid id)
        {
            return new OkObjectResult($"Teste GetByID: {id}");
        }

        [FunctionName("Teste-Post")]
        public static IActionResult Post([HttpTrigger(AuthorizationLevel.Function, "post", Route = "teste/post")] HttpRequest req, ILogger log)
        {
            return new OkObjectResult("Teste Post");
        }
    }
}
